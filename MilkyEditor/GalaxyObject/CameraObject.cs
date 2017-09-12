using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class CameraObject
    {
        public CameraObject()
        {

        }

        public CameraObject(Bcsv.Entry entry, string layer)
        {
            Layer = layer;
            name = Convert.ToString(entry["name"]);
            ID = Convert.ToInt32(entry["l_id"]);

            ObjArg0 = Convert.ToInt32(entry["Obj_arg0"]);
            ObjArg1 = Convert.ToInt32(entry["Obj_arg1"]);
            ObjArg2 = Convert.ToInt32(entry["Obj_arg2"]);
            ObjArg3 = Convert.ToInt32(entry["Obj_arg3"]);

            SWAppear = Convert.ToInt32(entry["SW_APPEAR"]);
            SW_A = Convert.ToInt32(entry["SW_A"]);
            SW_B = Convert.ToInt32(entry["SW_B"]);
            SWAwake = Convert.ToInt32(entry["SW_AWAKE"]);

            Validity = Convert.ToString(entry["Validity"]);

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
            MapPartsID = Convert.ToInt16(entry["MapParts_ID"]);
            ObjID = Convert.ToInt16(entry["Obj_ID"]);
        }

        string name;
        int ID, ObjArg0, ObjArg1, ObjArg2, ObjArg3;
        int SWAppear, SW_A, SW_B, SWAwake;
        string Validity;
        float X, Y, Z, XRot, YRot, ZRot, XScale, YScale, ZScale;
        int FollowID;
        short AreaShapeNo, MapPartsID, ObjID;

        string Layer;
    }

    /*
     * This class is for the BCAM File
     */
    class CameraEntry
    {
        public CameraEntry()
        {

        }

        public CameraEntry(Bcsv.Entry entry)
        {

        }
    }
}
