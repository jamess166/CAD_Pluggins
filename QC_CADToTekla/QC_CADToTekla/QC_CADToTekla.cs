using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace QC_CADToTekla
{
    public class QC_CADToTekla
    {
        [CommandMethod("ConvertTekla", CommandFlags.Session)]
        public static void ConvertCADToTekla()
        {
            CADToTekla.Execute();
        }
    }
}
