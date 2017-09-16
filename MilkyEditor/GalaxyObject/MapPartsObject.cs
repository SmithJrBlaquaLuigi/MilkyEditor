using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class MapPartsObject
    {
        public MapPartsObject()
        {

        }

        public MapPartsObject(Bcsv.Entry entry, string layer, int curID)
        {
            uniqueID = curID;

            name = Convert.ToString(entry["name"]);
            ID = Convert.ToInt32(entry["l_id"]);
            MoveConditionType = Convert.ToInt32(entry["MoveConditionType"]);
            RotateSpeed = Convert.ToInt32(entry["RotateSpeed"]);
            RotateAngle = Convert.ToInt32(entry["RotateAngle"]);
            RotateAxis = Convert.ToInt32(entry["RotateAxis"]);
            RotateAccelType = Convert.ToInt32(entry["RotateAccelType"]);
            RotateStopTime = Convert.ToInt32(entry["RotateStopTime"]);
            RotateType = Convert.ToInt32(entry["RotateType"]);
            ShadowType = Convert.ToInt32(entry["ShadowType"]);
            SignMotionType = Convert.ToInt32(entry["SignMotionType"]);
            PressType = Convert.ToInt32(entry["PressType"]);

            ParamScale = Convert.ToSingle(entry["ParamScale"]);
            CameraID = Convert.ToInt32(entry["CameraSetId"]);
            FarClip = Convert.ToInt32(entry["FarClip"]);

            ObjArg0 = Convert.ToInt32(entry["Obj_arg0"]);
            ObjArg1 = Convert.ToInt32(entry["Obj_arg1"]);
            ObjArg2 = Convert.ToInt32(entry["Obj_arg2"]);
            ObjArg3 = Convert.ToInt32(entry["Obj_arg3"]);

            SWAppear = Convert.ToInt32(entry["SW_APPEAR"]);
            SW_A = Convert.ToInt32(entry["SW_A"]);
            SW_B = Convert.ToInt32(entry["SW_B"]);
            SWAwake = Convert.ToInt32(entry["SW_AWAKE"]);
            SWDead = Convert.ToInt32(entry["SW_DEAD"]);
            SWParam = Convert.ToInt32(entry["SW_PARAM"]);

            X = Convert.ToSingle(entry["pos_x"]);
            Y = Convert.ToSingle(entry["pos_y"]);
            Z = Convert.ToSingle(entry["pos_z"]);

            XRot = Convert.ToSingle(entry["dir_x"]);
            YRot = Convert.ToSingle(entry["dir_y"]);
            ZRot = Convert.ToSingle(entry["dir_z"]);

            XScale = Convert.ToSingle(entry["scale_x"]);
            YScale = Convert.ToSingle(entry["scale_y"]);
            ZScale = Convert.ToSingle(entry["scale_z"]);

            CastID = Convert.ToInt32(entry["CastId"]);
            ViewGroupID = Convert.ToInt32(entry["ViewGroupId"]);

            ShapeModelNo = Convert.ToInt16(entry["ShapeModelNo"]);
            PathID = Convert.ToInt16(entry["CommonPath_ID"]);
            ClippingGroupID = Convert.ToInt16(entry["ClippingGroupId"]);
            GroupID = Convert.ToInt16(entry["GroupId"]);
            DemoGroupID = Convert.ToInt16(entry["DemoGroupId"]);
            MapPartsID = Convert.ToInt16(entry["MapParts_ID"]);
            ObjID = Convert.ToInt16(entry["Obj_ID"]);
            ParentID = Convert.ToInt16(entry["ParentId"]);
        }

        string name;
        int ID;
        int MoveConditionType, RotateSpeed, RotateAngle, RotateAxis;
        int RotateAccelType, RotateStopTime, RotateType, ShadowType;
        int SignMotionType, PressType;
        float ParamScale;
        int CameraID, FarClip;
        int ObjArg0, ObjArg1, ObjArg2, ObjArg3;
        int SWAppear, SWDead, SW_A, SW_B, SWAwake, SWParam;
        float X, Y, Z, XRot, YRot, ZRot, XScale, YScale, ZScale;
        int CastID, ViewGroupID;
        short ShapeModelNo, PathID, ClippingGroupID, GroupID;
        short DemoGroupID, MapPartsID, ObjID, ParentID;
        int uniqueID;
    }
}
