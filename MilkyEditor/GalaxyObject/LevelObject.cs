using MilkyEditor.Filesystem;
using MilkyEditor.Rendering;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class LevelObject : AbstractObject
    {
        public LevelObject()
        {

        }

        public LevelObject(Bcsv.Entry entry, string layer, int id)
        {
            Layer = layer;

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

            CameraSetID = Convert.ToInt32(entry["CameraSetId"]);

            SWAppear = Convert.ToInt32(entry["SW_APPEAR"]);
            SWDead = Convert.ToInt32(entry["SW_DEAD"]);
            SW_A = Convert.ToInt32(entry["SW_A"]);
            SW_B = Convert.ToInt32(entry["SW_B"]);
            SWAwake = Convert.ToInt32(entry["SW_AWAKE"]);
            SWParam = Convert.ToInt32(entry["SW_PARAM"]);

            MessageID = Convert.ToInt32(entry["MessageId"]);
            ParamScale = Convert.ToSingle(entry["ParamScale"]);

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
            ClippingID = Convert.ToInt16(entry["ClippingGroupId"]);
            GroupID = Convert.ToInt16(entry["GroupId"]);
            DemoGroupID = Convert.ToInt16(entry["DemoGroupId"]);
            MapPartsID = Convert.ToInt16(entry["MapParts_ID"]);
            ObjID = Convert.ToInt16(entry["Obj_ID"]);
            GeneratorID = Convert.ToInt16(entry["GeneratorID"]);
        }

        public void Render(RenderMode mode, Vector3 posBias, Vector3 rotBias, ExternalFilesystem fs = null)
        {
            Vector3 pos = new Vector3(X, Y, Z);
            Vector3 finalPos = pos + posBias;

            GL.PushMatrix();
            GL.Translate(finalPos);
            GL.Rotate(XRot + rotBias.X, 1f, 0f, 0f);
            GL.Rotate(YRot + rotBias.Y, 0f, 1f, 0f);
            GL.Rotate(ZRot + rotBias.Z, 0f, 0f, 1f);

            if (usesModel && fs != null)
            {
                string objFile = String.Format("/ObjectData/{0}.arc", Name);
                string bmdFile = String.Format("/{0}/{0}.bdl", Name);

                RarcFilesystem rarc = new RarcFilesystem(fs.OpenFile(objFile));
                Bmd bmd = new Bmd(rarc.OpenFile(bmdFile));

                GL.Scale(XScale, YScale, ZScale);
                DrawBDL(bmd);

                rarc.Close();
                bmd.Close();
            }
            else
            {
                GL.Scale(1f, 1f, 1f);
                DrawCube(0f, 1f, 0f, true, true, false, mode);
            }

            GL.PopMatrix();
        }

        public override string ToString() { return String.Format("{0} [{1}]", Name, Layer); }

        public void SetModelExistFlag(ExternalFilesystem fs)
        {
            string objFile = String.Format("/ObjectData/{0}.arc", Name);
            string bmdFile = String.Format("/{0}/{0}.bdl", Name);
            if (fs.FileExists(objFile))
            {
                RarcFilesystem rarc = new RarcFilesystem(fs.OpenFile(objFile));

                if (rarc.FileExists(bmdFile))
                    usesModel = true;

                rarc.Close();
            }
        }

        string Name;
        int ID;
        int ObjArg0, ObjArg1, ObjArg2, ObjArg3, ObjArg4, ObjArg5, ObjArg6, ObjArg7;
        int CameraSetID, SWAppear, SWDead, SW_A, SW_B, SWAwake, SWParam;
        int MessageID;
        float ParamScale, X, Y, Z, XRot, YRot, ZRot, XScale, YScale, ZScale;
        int CastID, ViewGroupID;
        short ShapeModelNo, PathID, ClippingID, GroupID, DemoGroupID, MapPartsID, ObjID, GeneratorID;

        string Layer;
        int uniqueID;
        bool usesModel;
    }
}
