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

        public override string ToString() { return String.Format("{0} [{1}]", name, Layer); }

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
            Entry = entry;

            Version = Convert.ToInt32(entry["version"]);
            CamEndint = Convert.ToInt32(entry["gflag.camendint"]);
            EnableEndErpFrame = Convert.ToInt16(entry["gflag.enableEndErpFrame"]);
            GFlagThru = Convert.ToInt32(entry["gflag.thru"]);
            num2 = Convert.ToInt32(entry["num2"]);
            num1 = Convert.ToInt32(entry["num1"]);

            AngleB = Convert.ToSingle(entry["angleB"]);
            AngleA = Convert.ToSingle(entry["angleA"]);
            Distance = Convert.ToSingle(entry["dist"]);

            SubjectiveOff = Convert.ToInt32(entry["flag.subjectiveoff"]);

            VPanAxisX = Convert.ToSingle(entry["vpanaxis.x"]);
            VPanAxisY = Convert.ToSingle(entry["vpanaxis.y"]);
            VPanAxisZ = Convert.ToSingle(entry["vpanaxis.z"]);

            VPanUse = Convert.ToInt32(entry["vpanuse"]);
            UDown = Convert.ToInt32(entry["udown"]);
            PushDelayLow = Convert.ToInt32(entry["pushdelaylow"]);
            PushDelay = Convert.ToInt32(entry["pushdelay"]);

            LPlay = Convert.ToSingle(entry["lplay"]);
            UPlay = Convert.ToSingle(entry["uplay"]);

            GNDint = Convert.ToInt32(entry["gndint"]);

            Lower = Convert.ToSingle(entry["lower"]);
            Upper = Convert.ToSingle(entry["upper"]);

            CamInt = Convert.ToInt32(entry["camint"]);

            Fovy = Convert.ToSingle(entry["fovy"]);
            Roll = Convert.ToSingle(entry["roll"]);
            LOffsetV = Convert.ToSingle(entry["loffsetv"]);
            LOffset = Convert.ToSingle(entry["loffset"]);

            WOffsetX = Convert.ToSingle(entry["woffset.x"]);
            WOffsetY = Convert.ToSingle(entry["woffset.y"]);
            WOffsetZ = Convert.ToSingle(entry["woffset.z"]);

            CamType = Convert.ToString(entry["camtype"]);
            ID = Convert.ToString(entry["id"]);

            AxisX = Convert.ToSingle(entry["axis.X"]);
            AxisY = Convert.ToSingle(entry["axis.Y"]);
            AxisZ = Convert.ToSingle(entry["axis.Z"]);
        }

        private bool DoesFieldExist(string name)
        {
            try { Convert.ToInt32(Entry[name]); return true; }
            catch { return false; }
        }

        Bcsv.Entry Entry;
        int Version, CamEndint, EnableEndErpFrame, GFlagThru, num2, num1;
        float AngleA, AngleB, Distance;
        int SubjectiveOff;
        float VPanAxisX, VPanAxisY, VPanAxisZ;
        int VPanUse, UDown, PushDelayLow, PushDelay;
        float LPlay, UPlay;
        int GNDint;
        float Lower, Upper;
        int CamInt;
        float Fovy, Roll, LOffsetV, LOffset, WOffsetX, WOffsetY, WOffsetZ;
        string CamType, ID;
        int CollisionOff, NoFovy, EVPriority, EVFM, EnableErpFrame, EFlag_EnableEndErpFrame;
        float AxisX, AxisY, AxisZ;
    }
}
