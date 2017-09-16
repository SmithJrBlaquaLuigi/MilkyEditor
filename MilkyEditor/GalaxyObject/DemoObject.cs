using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class DemoObject
    {
        public DemoObject()
        {

        }

        public DemoObject(Bcsv.Entry entry, string layer, int curID)
        {
            uniqueID = curID;
            Layer = layer;

            name = Convert.ToString(entry["name"]);
            DemoName = Convert.ToString(entry["DemoName"]);
            TimeSheetName = Convert.ToString(entry["TimeSheetName"]);
            ID = Convert.ToInt32(entry["l_id"]);

            SWAppear = Convert.ToInt32(entry["SW_APPEAR"]);
            SW_A = Convert.ToInt32(entry["SW_A"]);
            SW_B = Convert.ToInt32(entry["SW_B"]);
            SWDead = Convert.ToInt32(entry["SW_DEAD"]);

            DemoSkip = Convert.ToInt32(entry["DemoSkip"]);

            X = Convert.ToSingle(entry["pos_x"]);
            Y = Convert.ToSingle(entry["pos_y"]);
            Z = Convert.ToSingle(entry["pos_z"]);

            XRot = Convert.ToSingle(entry["dir_x"]);
            YRot = Convert.ToSingle(entry["dir_y"]);
            ZRot = Convert.ToSingle(entry["dir_z"]);

            XScale = Convert.ToSingle(entry["scale_x"]);
            YScale = Convert.ToSingle(entry["scale_y"]);
            ZScale = Convert.ToSingle(entry["scale_z"]);
        }

        string name, DemoName, TimeSheetName;
        int ID, SWAppear, SWDead, SW_A, SW_B, DemoSkip;
        float X, Y, Z, XRot, YRot, ZRot, XScale, YScale, ZScale;
        string Layer;
        int uniqueID;
    }
}
