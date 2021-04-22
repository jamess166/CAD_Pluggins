using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace QCChangeRevision
{
    public class Class1
    {
        [CommandMethod("Revision", CommandFlags.Session)]
        public static void QCChangeRevision()
        {
            FormGeneral frm = new FormGeneral();
            frm.Show();
        }
    }
}
