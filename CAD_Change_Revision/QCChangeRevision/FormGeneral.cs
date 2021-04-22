using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using app = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Publishing;

namespace QCChangeRevision
{
    public partial class FormGeneral : Form
    {
        public string[] fileContent = null;
        public string filePath = null;

        public FormGeneral()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Multiselect = true;
                openFile.RestoreDirectory = true;
                openFile.Filter = "DWG files (*.dwg)|*.dwg|All files (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    fileContent = openFile.SafeFileNames;
                    filePath = Path.GetDirectoryName(openFile.FileName);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (fileContent == null) { return; }

            StringBuilder sbuilder = new StringBuilder();
            sbuilder.AppendLine("Se cambiaron los siguientes planos");
            sbuilder.AppendLine("");

            foreach (string fContent in fileContent)
            {
                FileInfo fi = new FileInfo(filePath + @"\" + fContent);

                string name = Path.GetFileNameWithoutExtension(fi.FullName);
                string extension = fi.Extension;

                string newName = name.Remove(name.Length - 1) + txtRevision.Text;

                File.Move(fi.FullName, filePath + @"\" + newName + extension);

                sbuilder.AppendLine(newName);
            }

            MessageBox.Show(sbuilder.ToString(), "QC Ingenieros");

            fileContent = null;
        }

        private void btnQuitarText_Click(object sender, EventArgs e)
        {
            if (fileContent == null) { return; }

            StringBuilder sbuilder = new StringBuilder();
            sbuilder.AppendLine("Se cambiaron los siguientes archivos");
            sbuilder.AppendLine("");

            foreach (string fContent in fileContent)
            {
                FileInfo fi = new FileInfo(filePath + @"\" + fContent);

                string name = Path.GetFileNameWithoutExtension(fi.FullName);
                string extension = fi.Extension;

                string newName = name.Replace(txtQuitar.Text, "");

                File.Move(fi.FullName, filePath + @"\" + newName + extension);

                sbuilder.AppendLine(newName);
            }

            MessageBox.Show(sbuilder.ToString(), "QC Ingenieros");

            fileContent = null;
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            if (fileContent == null) { return; }

            StringBuilder sbuilder = new StringBuilder();
            sbuilder.AppendLine("Se han modificado los datos con éxito");
            sbuilder.AppendLine("");

            foreach (string fContent in fileContent)
            {
                FileInfo fi = new FileInfo(filePath + @"\" + fContent);

                try
                {
                    ChangeData(fi);
                }
                catch
                {
                    sbuilder.AppendLine("Excepto :");
                    sbuilder.AppendLine(fi.Name);
                }
            }

            MessageBox.Show(sbuilder.ToString(), "QC Ingenieros");
        }

        private void ChangeData(FileInfo file)
        {
            if (file == null) { return; }

            Document doc = app.DocumentManager.Open(file.FullName, false);
            Database db = doc.Database;

            using (DocumentLock docloc = doc.LockDocument())
            {

                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    //DBObjectCollection dBObject = tr.GetAllObjects();
                    BlockTableRecord btrLayout = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.PaperSpace], OpenMode.ForRead, false);
                    BlockTableRecord btrModel = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead, false);

                    foreach (var btrId in btrLayout)
                    {
                        BlockReference blockReference = tr.GetObject(btrId, OpenMode.ForRead) as BlockReference;

                        if (blockReference == null) { continue; }

                        if (blockReference.Name != "MM") { continue; }

                        ChangeData(tr, blockReference);
                    }

                    foreach (var btrId in btrModel)
                    {
                        BlockReference blockReference = tr.GetObject(btrId, OpenMode.ForRead) as BlockReference;

                        if (blockReference == null) { continue; }

                        if (blockReference.Name != "MM") { continue; }

                        ChangeData(tr, blockReference);
                    }

                    tr.Commit();
                }
            }

            doc.CloseAndSave(file.FullName);
        }

        private void ChangeData(Transaction tr, BlockReference br)
        {
            if (br == null) { return; }

            Autodesk.AutoCAD.DatabaseServices.AttributeCollection attributeCollection
        = br.AttributeCollection;

            foreach (ObjectId attId in attributeCollection)
            {

                AttributeReference att = (AttributeReference)tr.GetObject(attId, OpenMode.ForWrite);

                switch (att.Tag)
                {
                    case "METRADO":
                        if (txtDetailEnginer.Text != string.Empty)
                        {
                            att.UpgradeOpen();
                            att.TextString = txtDetailEnginer.Text;
                            att.DowngradeOpen();
                        }
                        break;
                    case "DIBUJADO":
                        if (txtDrawingCAD.Text != string.Empty)
                        {
                            att.UpgradeOpen();
                            att.TextString = txtDrawingCAD.Text;
                            att.DowngradeOpen();
                        }
                        break;
                    case "REVISADO":
                        if (txtRevisionOTC.Text != string.Empty)
                        {
                            att.UpgradeOpen();
                            att.TextString = txtRevisionOTC.Text;
                            att.DowngradeOpen();
                        }
                        break;
                    case "EMITIDOPARA":
                        if (txtIssuedFor.Text != string.Empty)
                        {
                            att.UpgradeOpen();
                            att.TextString = txtIssuedFor.Text;
                            att.DowngradeOpen();
                        }
                        break;
                    case "NRO.DE.PROYECTO":
                        if (txtProjectNumber.Text != string.Empty)
                        {
                            att.UpgradeOpen();
                            att.TextString = txtProjectNumber.Text;
                            att.DowngradeOpen();
                        }
                        break;
                    case "FECHA":
                        if (chkDate.Checked == true)
                        {
                            att.UpgradeOpen();
                            att.TextString = dateTimeFecha.Value.ToString("dd/MM/yyyy");
                            att.DowngradeOpen();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void dateTimeFecha_ValueChanged(object sender, EventArgs e)
        {
            chkDate.Checked = true;
        }

        /// <summary>
        /// Purga todos los archivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Purge_Click(object sender, EventArgs e)
        {
            if (fileContent == null) { return; }

            StringBuilder sbuilder = new StringBuilder();
            sbuilder.AppendLine("Se han purgado los archivos con éxito");
            sbuilder.AppendLine("");

            foreach (string fContent in fileContent)
            {
                FileInfo fi = new FileInfo(filePath + @"\" + fContent);

                try
                {
                    PurgeAllFile(fi);
                }
                catch
                {
                    sbuilder.AppendLine("Excepto :");
                    sbuilder.AppendLine(fi.Name);
                }
            }

            MessageBox.Show(sbuilder.ToString(), "QC Ingenieros");
        }

        /// <summary>
        /// Purga el plano
        /// </summary>
        /// <param name="fi"></param>
        private void PurgeAllFile(FileInfo file)
        {
            if (file == null) { return; }

            Document doc = app.DocumentManager.Open(file.FullName, false);
            Database db = doc.Database;

            using (DocumentLock docloc = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    List<SymbolTable> listTables = new List<SymbolTable>();
                    listTables.Add(tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable);
                    listTables.Add(tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable);
                    listTables.Add(tr.GetObject(db.TextStyleTableId, OpenMode.ForRead) as TextStyleTable);
                    listTables.Add(tr.GetObject(db.DimStyleTableId, OpenMode.ForRead) as DimStyleTable);
                    listTables.Add(tr.GetObject(db.LinetypeTableId, OpenMode.ForRead) as LinetypeTable);
                    listTables.Add(tr.GetObject(db.ViewTableId, OpenMode.ForRead) as ViewTable);

                    foreach (SymbolTable table in listTables)
                    {
                        ObjectIdCollection layersId = new ObjectIdCollection();

                        do
                        {
                            layersId.Clear();

                            foreach (ObjectId ob in table)
                                layersId.Add(ob);

                            db.Purge(layersId);

                            foreach (ObjectId id in layersId)
                            {
                                DBObject obj = tr.GetObject(id, OpenMode.ForWrite);
                                obj.Erase();
                            }

                        } while (layersId.Count != 0);
                    }

                    tr.Commit();
                }
            }

            doc.CloseAndSave(file.FullName);
        }

        /// <summary>
        /// Purga los layer
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="db"></param>
        public void PurgLayer(Transaction tr, Database db)
        {
            LayerTable layerTable = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;

            ObjectIdCollection layersId = new ObjectIdCollection();

            do
            {
                layersId.Clear();

                foreach (ObjectId ob in layerTable)
                    layersId.Add(ob);

                db.Purge(layersId);

                foreach (ObjectId id in layersId)
                {
                    DBObject obj = tr.GetObject(id, OpenMode.ForWrite);
                    obj.Erase();
                }

            } while (layersId.Count != 0);
        }

        //Autodesk.AutoCAD.DatabaseServices.AttributeCollection attributeCollection = 
        //    br.AttributeCollection;

        //foreach (ObjectId attId in attributeCollection)
        //{
        //    AttributeReference attRef =
        //        (AttributeReference)tr.GetObject(attId, OpenMode.ForRead);


        //}
    }
}

