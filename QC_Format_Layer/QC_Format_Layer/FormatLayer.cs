using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Colors;

using app = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Publishing;

namespace QC_Format_Layer
{
    /// <summary>
    /// Colores Sider
    /// </summary>
    public class ColorsSider
    {
        /// <summary>
        /// Color F0
        /// </summary>
        public static Color ColorF0 { get { return Color.FromColorIndex(ColorMethod.ByAci, 38); } }

        /// <summary>
        /// Color F1
        /// </summary>
        public static Color ColorF1 { get { return Color.FromColorIndex(ColorMethod.ByAci, 1); } }

        /// <summary>
        /// Color F2
        /// </summary>
        public static Color ColorF2 { get { return Color.FromColorIndex(ColorMethod.ByAci, 2); } }

        /// <summary>
        /// Color F3
        /// </summary>
        public static Color ColorF3 { get { return Color.FromColorIndex(ColorMethod.ByAci, 70); } }

        /// <summary>
        /// Color F3B
        /// </summary>
        public static Color ColorF3B { get { return Color.FromColorIndex(ColorMethod.ByAci, 3); } }

        /// <summary>
        /// Color F4
        /// </summary>
        public static Color ColorF4 { get { return Color.FromColorIndex(ColorMethod.ByAci, 130); } }

        /// <summary>
        /// Color F4
        /// </summary>
        public static Color ColorF4B { get { return Color.FromColorIndex(ColorMethod.ByAci, 4); } }


        /// <summary>
        /// Color F5
        /// </summary>
        public static Color ColorF5 { get { return Color.FromColorIndex(ColorMethod.ByAci, 5); } }

        /// <summary>
        /// Color F6
        /// </summary>
        public static Color ColorF6 { get { return Color.FromColorIndex(ColorMethod.ByAci, 6); } }

        /// <summary>
        /// Color F7
        /// </summary>
        public static Color ColorF7 { get { return Color.FromColorIndex(ColorMethod.ByAci, 206); } }

        /// <summary>
        /// Color F8
        /// </summary>
        public static Color ColorF8 { get { return Color.FromColorIndex(ColorMethod.ByAci, 139); } }

        /// <summary>
        /// Color F9
        /// </summary>
        public static Color ColorF9 { get { return Color.FromColorIndex(ColorMethod.ByAci, 181); } }

        /// <summary>
        /// Color F10
        /// </summary>
        public static Color ColorF10 { get { return Color.FromColorIndex(ColorMethod.ByAci, 63); } }

        /// <summary>
        /// Color L07
        /// </summary>
        public static Color ColorL07 { get { return Color.FromColorIndex(ColorMethod.ByAci, 30); } }
    }

    public class FormatLayer
    {
        /// <summary>
        /// Documento de CAD
        /// </summary>
        public static Document doc
        {
            get { return app.DocumentManager.MdiActiveDocument; }
        }

        public static Transaction tr;
        public static Database db;

        /// <summary>
        /// Metodo principal
        /// </summary>
        [CommandMethod("SiderLayer", CommandFlags.Session)]
        public static void QCFormatLayer()
        {
            //Variables
            db = doc.Database;

            //Eliminar los Wipeout
            using (DocumentLock docloc = doc.LockDocument())
            {
                using (tr = doc.Database.TransactionManager.StartTransaction())
                {
                    //Borar los wipeout
                    DeleteWipeout();

                    // Crear Layers Sider
                    CreateLayers();

                    //Asigna las capas segun el color de los refuerzos
                    AsignLayers();

                    tr.Commit();
                }
            }

            doc.Editor.WriteMessage("\nQC INGENIEROS: SE EJECUTO CORRECTAMENTE");

        }

        public static void AsignLayers()
        {
            //Obtener todos los elementos
            var ed = doc.Editor;

            PromptSelectionResult selRes = ed.SelectAll();

            //Validar si hay elementos
            if (selRes == null) { return; }
            if (selRes.Value == null) { return; }

            //Ids de los wipeout
            ObjectId[] ids = selRes.Value.GetObjectIds();

            foreach (var id in ids)
            {
                Entity obj = tr.GetObject(id, OpenMode.ForWrite) as Entity;
                if (obj == null) { continue; }
                if(obj is MText) { continue; }
                if (obj is DBText) { continue; }
                AsignLayers(obj);
            }

        }

        /// <summary>
        /// Asignar la capa segun colos de cada elelentos
        /// </summary>
        /// <param name="obj"></param>
        public static void AsignLayers(Entity obj)
        {
            Color color = obj.Color;

            //Verificar los colores
            if (color == ColorsSider.ColorF0)
                obj.Layer = "F0";
            else if (color == ColorsSider.ColorF1)
                obj.Layer = "F1";
            else if (color == ColorsSider.ColorF2)
                obj.Layer = "F2";
            else if (color == ColorsSider.ColorF3B)
                obj.Layer = "F3";
            else if (color == ColorsSider.ColorF4B)
                obj.Layer = "F4";
            else if (color == ColorsSider.ColorF5)
                obj.Layer = "F5";
            else if (color == ColorsSider.ColorF6)
                obj.Layer = "F6";
            else if (color == ColorsSider.ColorF7)
                obj.Layer = "F7";
            else if (color == ColorsSider.ColorF8)
                obj.Layer = "F8";
            else if (color == ColorsSider.ColorF9)
                obj.Layer = "F9";
            else if (color == ColorsSider.ColorF10)
                obj.Layer = "F10";
            else if (color == ColorsSider.ColorL07)
                obj.Layer = "L07";
        }

        /// <summary>
        /// Crea los layer de sider
        /// </summary>
        public static void CreateLayers()
        {
            LayerTable lt = (LayerTable)tr.GetObject(
                    db.LayerTableId,
                    OpenMode.ForRead);

            //Color F0
            CreateLayer(tr, lt, "F0", Color.FromColorIndex(ColorMethod.ByAci, 38));
            //Color F1
            CreateLayer(tr, lt, "F1", Color.FromColorIndex(ColorMethod.ByAci, 1));
            //Color F2
            CreateLayer(tr, lt, "F2", Color.FromColorIndex(ColorMethod.ByAci, 2));
            //Color F3
            CreateLayer(tr, lt, "F3", Color.FromColorIndex(ColorMethod.ByAci, 70));
            //Color F4
            CreateLayer(tr, lt, "F4", Color.FromColorIndex(ColorMethod.ByAci, 130));
            //Color F5
            CreateLayer(tr, lt, "F5", Color.FromColorIndex(ColorMethod.ByAci, 5));
            //Color F6
            CreateLayer(tr, lt, "F6", Color.FromColorIndex(ColorMethod.ByAci, 6));
            //Color F7
            CreateLayer(tr, lt, "F7", Color.FromColorIndex(ColorMethod.ByAci, 206));
            //Color F8
            CreateLayer(tr, lt, "F8", Color.FromColorIndex(ColorMethod.ByAci, 139));
            //Color F9
            CreateLayer(tr, lt, "F9", Color.FromColorIndex(ColorMethod.ByAci, 181));
            //Color F10
            CreateLayer(tr, lt, "F10", Color.FromColorIndex(ColorMethod.ByAci, 63));
            //Color L07
            CreateLayer(tr, lt, "L07", Color.FromColorIndex(ColorMethod.ByAci, 30));
        }

        /// <summary>
        /// Crea cada capa
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="lt"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        public static void CreateLayer(Transaction tr, LayerTable lt,
            string name, Color color)
        {
            try
            {
                LayerTableRecord ltr = new LayerTableRecord();
                ltr.Name = name;
                ltr.Color = color;
                lt.UpgradeOpen();
                ObjectId ltId = lt.Add(ltr);
                tr.AddNewlyCreatedDBObject(ltr, true);
            }
            catch { doc.Editor.WriteMessage("\nQC INGENIEROS: EL LAYER " + name + " YA EXISTE"); }
        }

        /// <summary>
        /// Eliminar los wipeout del modelo
        /// </summary>
        public static void DeleteWipeout()
        {
            var ed = doc.Editor;

            //Obtener todos los elementos del tipo wipeout
            TypedValue[] filterlist = new TypedValue[1];
            filterlist[0] = new TypedValue(0, "WIPEOUT");
            SelectionFilter filter = new SelectionFilter(filterlist);
            PromptSelectionResult selRes = ed.SelectAll(filter);

            //Validar si hay elementos
            if (selRes == null) { return; }
            if (selRes.Value == null) { return; }

            //Ids de los wipeout
            ObjectId[] ids = selRes.Value.GetObjectIds();

            foreach (var id in ids)
            {
                DBObject obj = tr.GetObject(id, OpenMode.ForWrite);
                obj.Erase();
            }
        }
    }
}
