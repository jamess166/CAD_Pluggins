#region Imported Namespaces

//.NET common used namespaces
//QCLibrary.NET common used namespaces
using QCLibraryTekla;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//Syncfusion used namespaces
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

using g3d = Tekla.Structures.Geometry3d;
using mui = Tekla.Structures.Model.UI;
using tsd = Tekla.Structures.Drawing;
using tsg = Tekla.Structures.Dialog;
using tsm = Tekla.Structures.Model;
using tso = Tekla.Structures.Model.Operations;
using System.Diagnostics;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.EditorInput;

#endregion

namespace QC_CADToTekla
{
    /// <summary>
    /// Class container
    /// </summary>
    class CADToTekla
    {
        private static double _xTotal { get; set; }
        /// <summary>
        /// Exportar a Fehab
        /// </summary>
        public static void Execute()
        {
            //Obtener las lineas seleccionadas
            List<Line> lines = SelectElementsCAD();

            //Obtener el x global para transformar coordenadas
            GetXGlobal(lines);

            //Convertir puntos cad a tekla
            List<List<g3d.Point>> pointsTk = getPointsToTekla(lines);

            TeklaTools.CreateRebarTekla(pointsTk);

            //Mensaje de confirmacion
            ViewEvents.ShowMessage("Confirmation message",
            "The export has been successful");

            //Proceso terminado en el prompt
            tso.Operation.DisplayPrompt("The export has been successful");
        }

        /// <summary>
        /// Obtener las lineas de CAD
        /// </summary>
        /// <returns></returns>
        public static List<Line> SelectElementsCAD()
        {
            //Lista para guardar elementos de salida
            List<Line> lines = new List<Line>();

            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            //Opciones de seleccion
            PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
            promptSelectionOptions.AllowDuplicates = false;
            promptSelectionOptions.SingleOnly = false;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                //Seledcionar los elementos
                PromptSelectionResult selectionPrompt = ed.GetSelection(promptSelectionOptions);

                if (selectionPrompt.Status == PromptStatus.OK)
                {
                    foreach (SelectedObject so in selectionPrompt.Value)
                    {
                        if (so == null) { continue; }

                        //Leyendo la entidad de objeto
                        Entity entity = tr.GetObject(so.ObjectId, OpenMode.ForRead) as Entity;

                        //Guardar solo las lineas
                        if (entity is Line)
                        { lines.Add(entity as Line); }
                    }
                }
            }

            return lines;
        }

        /// <summary>
        /// Devuelve las lista de puntos que se deben agregar a tekla
        /// </summary>
        /// <param name="Lines"></param>
        /// <returns></returns>
        public static List<List<g3d.Point>> getPointsToTekla(List<Line> Lines)
        {
            List<List<g3d.Point>> allPoints = new List<List<g3d.Point>>();

            foreach (Line line in Lines)
            {
                List<g3d.Point> pointsTk = new List<g3d.Point>();

                //Puntos CAD
                Point3d onePointCAD = line.StartPoint;
                Point3d twoPointCAD = line.EndPoint;

                //Puntos tekla
                g3d.Point onePointTk = new g3d.Point((onePointCAD.X - _xTotal) * 1000, 0);
                g3d.Point twoPointTk = new g3d.Point((twoPointCAD.X - _xTotal) * 1000, 0);

                //Agregar puntos
                pointsTk.Add(onePointTk);
                pointsTk.Add(twoPointTk);

                //Ordenar por menor x
                pointsTk = pointsTk
                    .OrderBy(x => x.X)
                    .ToList();

                if (pointsTk == null || !pointsTk.Any())
                    continue;

                //Agregar lista a allPoints
                allPoints.Add(pointsTk);
            }

            //Ordenar por el punto de inicio
            allPoints = allPoints.OrderBy(x => x.FirstOrDefault().X).ToList();

            return allPoints;
        }

        /// <summary>
        /// Devuelve la coordenada global x para restar
        /// </summary>
        /// <param name="Lines"></param>
        /// <returns></returns>
        /// 
        public static void GetXGlobal(List<Line> Lines)
        {
            List<double> xs = new List<double>();

            foreach (Line l in Lines)
            {
                xs.Add(l.StartPoint.X);
                xs.Add(l.EndPoint.X);
            }

            xs.Sort();
            _xTotal = xs.First();
        }
    }


    /// <summary>
    /// Herramientas para obtner elementos
    /// </summary>
    class TeklaTools
    {
        //Guardar Modelo
        public static tsm.Model MyModel { get; set; }
        public static string ModelPath { get; set; }

        /// <summary>
        /// Obtener el modelo y verificar si esta conectado
        /// </summary>
        public static bool IsModelConnected()
        {
            if (MyModel == null)
            { MyModel = new tsm.Model(); }

            //Verifico si hay modelo abierto o mensaje
            if (!MyModel.GetConnectionStatus()) { return false; }

            //Carpeta del modelo
            ModelPath = MyModel.GetInfo().ModelPath;

            return true;
        }

        /// <summary>
        /// Crear refuerzo en tekla
        /// </summary>
        /// <param name="allPointsTekla"></param>
        public static void CreateRebarTekla(List<List<g3d.Point>> allPointsTekla)
        {
            //Verificacion de conexion de model
            IsModelConnected();

            //Seleccionar parte en tekla
            tsm.Part part = SelectionElements.ReturnPartSelection(MyModel) as tsm.Part;

            //Seleccionar puntos
            List<g3d.Point> pointSelectUser = SelectPoint();

            //Guardar el plano de trabajo actual
            tsm.TransformationPlane currentTP = MyModel.GetWorkPlaneHandler()
                .GetCurrentTransformationPlane();

            //Convertimos plano de trabajo con referencia a la parte
            MyModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(
                new tsm.TransformationPlane(part.GetCoordinateSystem()));

            //Conteo para la primera barra
            int count = 0;
            bool firtsRebar = true;

            foreach (List<g3d.Point> pointsTekla in allPointsTekla)
            {
                if (count != 0)
                    firtsRebar = false;

                //nuevos puntos
                g3d.Point startPointNew = NewPoint(pointsTekla, pointSelectUser, 0, firtsRebar);
                g3d.Point endPointNew = NewPoint(pointsTekla, pointSelectUser, 1, firtsRebar);

                //Crear poligono para el refuerzo
                tsm.Polygon polygon = new tsm.Polygon();
                polygon.Points.Add(startPointNew);
                polygon.Points.Add(endPointNew);

                //Modificacion de coordenadas
                //tsm.Beam beam = new tsm.Beam(startPonitNew, endPonitNew);

                // Set the Beams Material and Profile.
                //beam.Material.MaterialString = "S235JR";
                //beam.Profile.ProfileString = "HEA400";
                //beam.Insert();

                //Insertar refuerzo
                tsm.RebarGroup rebarGroup = CreateRebarTekla(part, polygon);

                //Conteo
                count++;
            }

            //regresar al plano original
            MyModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTP);
            MyModel.CommitChanges();
        }

        public static tsm.RebarGroup CreateRebarTekla(tsm.Part part, tsm.Polygon polygon)
        {
            //creacion principal del refuerzo
            tsm.RebarGroup rebarGroup = new tsm.RebarGroup();

            //agregar poligono
            rebarGroup.Polygons.Add(polygon);

            //Obtener el nombre de la parte para pone el prefijo
            string name = string.Empty;
            if (ViewTools.IsTopRebar) { name = "SUP"; }
            else { name = "INF"; }

            //Otros Datos
            rebarGroup.Name = name;
            rebarGroup.Size = ViewTools.Size;
            rebarGroup.Grade = ViewTools.Grade;

            return rebarGroup;
        }

        /// <summary>
        /// Devuelve el nuevo punto
        /// </summary>
        /// <param name="points"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static g3d.Point NewPoint(List<g3d.Point> pointsTekla,
            List<g3d.Point> pointSelectUser, int location, bool firtsRebar)
        {
            double movePoint = 0;

            if (firtsRebar && location == 1) { movePoint = ViewTools.InitialCover; }

            g3d.Point point = new g3d.Point(pointsTekla[location].X + movePoint,
                pointSelectUser[0].Y, pointSelectUser[0].Z);

            return point;
        }

        /// <summary>
        /// Devuelve los puntos seleciconado
        /// </summary>
        /// <returns></returns>
        public static List<g3d.Point> SelectPoint()
        {
            List<g3d.Point> points = new List<g3d.Point>();

            var pickers = new mui.Picker();

            //Ancho de viga
            var selected = pickers.PickPoints(mui.Picker.PickPointEnum.PICK_TWO_POINTS
                , "Select the beam points");

            //Agregar en lista de puntos
            foreach (g3d.Point p in selected)
                points.Add(p);

            return points;
        }
    }

    /// <summary>
    /// Clase de herramientas de vista
    /// </summary>
    class ViewTools
    {
        //Recubrimiento
        public static double InitialCover { get; set; }
        public static bool IsTopRebar { get; set; }
        public static double PlaneCover { get; set; }
        public static int CountRebar { get; set; }

        //Caracteristicas de la barra de refuerzo
        public static string Size { get; set; }
        public static string Grade { get; set; }
    }
}
