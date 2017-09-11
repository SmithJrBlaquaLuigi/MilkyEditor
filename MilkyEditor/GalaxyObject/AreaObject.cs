using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class AreaObject
    {
        public AreaObject()
        {

        }

        /*
         * Type 0: Regular Area (Map.arc)
         * Type 1: Light Area (Design.arc)
         * Type 2: Sound Area (Sound.arc)
         */

        public AreaObject(Bcsv.Entry entry, string layer, int areaType)
        {
            Layer = layer;
            Type = areaType;

            Name = Convert.ToString(entry["name"]);
            ID = Convert.ToInt32(entry["l_id"]);

            ObjArg0 = Convert.ToInt32(entry["Obj_arg0"]);
            ObjArg1 = Convert.ToInt32(entry["Obj_arg1"]);
            ObjArg2 = Convert.ToInt32(entry["Obj_arg2"]);
            ObjArg3 = Convert.ToInt32(entry["Obj_arg3"]);
            ObjArg4 = Convert.ToInt32(entry["Obj_arg4"]);
            ObjArg5 = Convert.ToInt32(entry["Obj_arg5"]);
            ObjArg6 = Convert.ToInt32(entry["Obj_arg6"]);
            ObjArg7 = Convert.ToInt32(entry["Obj_arg7"]);

            Priority = Convert.ToInt32(entry["Priority"]);

            SWAppear = Convert.ToInt32(entry["SW_APPEAR"]);
            SW_A = Convert.ToInt32(entry["SW_A"]);
            SW_B = Convert.ToInt32(entry["SW_B"]);
            SWAwake = Convert.ToInt32(entry["SW_AWAKE"]);

            X = Convert.ToSingle(entry["pos_x"]);
            Y = Convert.ToSingle(entry["pos_y"]);
            Z = Convert.ToSingle(entry["pos_z"]);

            XRot = Convert.ToSingle(entry["dir_x"]);
            YRot = Convert.ToSingle(entry["dir_y"]);
            ZRot = Convert.ToSingle(entry["dir_z"]);

            XScale = Convert.ToSingle(entry["scale_x"]);
            YScale = Convert.ToSingle(entry["scale_y"]);
            ZScale = Convert.ToSingle(entry["scale_z"]);

            FollowID = Convert.ToInt32(entry["FollowId"]);

            AreaShapeNo = Convert.ToInt16(entry["AreaShapeNo"]);
            PathID = Convert.ToInt16(entry["CommonPath_ID"]);
            ClippingID = Convert.ToInt16(entry["ClippingGroupId"]);
            GroupID = Convert.ToInt16(entry["GroupId"]);
            DemoGroupID = Convert.ToInt16(entry["DemoGroupId"]);
            MapPartsID = Convert.ToInt16(entry["MapParts_ID"]);
            ObjID = Convert.ToInt16(entry["Obj_ID"]);
        }

        string Name;
        int ID;
        int ObjArg0, ObjArg1, ObjArg2, ObjArg3, ObjArg4, ObjArg5, ObjArg6, ObjArg7;
        int Priority;
        int SWAppear, SW_A, SW_B, SWAwake;
        float X, Y, Z, XRot, YRot, ZRot, XScale, YScale, ZScale;
        int FollowID;
        short AreaShapeNo, PathID, ClippingID, GroupID, DemoGroupID, MapPartsID, ObjID;

        string Layer;
        public int Type;

        public override string ToString() { return String.Format("{0} [{1}]", Name, Layer); }
    }
}
