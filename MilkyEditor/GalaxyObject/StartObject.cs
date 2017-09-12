using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class StartObject
    {
        public StartObject()
        {

        }

        public StartObject(Bcsv.Entry entry, string layer, string zone)
        {
            Layer = layer;
            ZoneName = zone;

            name = Convert.ToString(entry["name"]);
            MarioNo = Convert.ToInt32(entry["MarioNo"]);
            ObjArg0 = Convert.ToInt32(entry["Obj_arg0"]);
            CameraID = Convert.ToInt32(entry["Camera_id"]);

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

        public override string ToString() { return String.Format("Starting Point {0} [{1}] [{2}]", MarioNo, Layer, ZoneName); }

        string name;
        int MarioNo, ObjArg0, CameraID;
        float X, Y, Z, XRot, YRot, ZRot, XScale, YScale, ZScale;
        string Layer;
        string ZoneName;
    }
}
