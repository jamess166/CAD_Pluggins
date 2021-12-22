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
        /// <summary>
        /// Exportar a Fehab
        /// </summary>
        public static void Execute()
        {
            //Obtener las lineas seleccionadas
            List<Line> Lines = SelectElementsCAD();

            //

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

                if(selectionPrompt.Status == PromptStatus.OK)
                {
                    foreach (SelectedObject so in selectionPrompt.Value)
                    {
                        if(so == null) { continue; }

                        //Leyendo la entidad de objeto
                        Entity entity = tr.GetObject(so.ObjectId, OpenMode.ForRead) as Entity;
                        
                        //Guardar solo las lineas
                        if(entity is Line) 
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
            List<List<g3d.Point>> points = new List<List<g3d.Point>>();

            return points;
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
    }

    /// <summary>
    /// Clase de herramientas de vista
    /// </summary>
    class ViewTools
    {
        public static int selOption { get; set; }
        public static string pathFile { get; set; }
        public static string nameFile { get; set; }
        public static ViewMain viewMain { get; set; }
    }
}
