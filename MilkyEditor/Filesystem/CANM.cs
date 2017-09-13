using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.Filesystem
{
    class CANM
    {
        public CANM(FileBase file)
        {
            file.BigEndian = true;
            file.Stream.Position = 0;

            magic = Encoding.ASCII.GetString(file.Reader.ReadBytes(8));
            unk1 = file.Reader.ReadInt32();
            unk2 = file.Reader.ReadInt32();
            unk3 = file.Reader.ReadInt32();
            unk4 = file.Reader.ReadInt32();
            unk5 = file.Reader.ReadInt32();

            keyFrameIndicies = new List<KeyFrameIndex>();

            string[] names = { "pos_x", "pos_y", "pos_z", "dir_x", "dir_y", "dir_z", "unk1", "cameraZoom" };

            file.Reader.BaseStream.Position = 0x80;
            int numFloats = file.Reader.ReadInt32() / 0x04;

            // padding
            file.Reader.ReadInt32();

            float[] floatTable = new float[numFloats];

            // fill up float table
            for (int f = 0; f < numFloats; f++)
                floatTable[f] = file.Reader.ReadSingle();

            int currentFloatTableIndex = 0;

            // now we jump back and assign the floats to their keys
            file.Reader.BaseStream.Position = 0x20;

            for (int i = 0; i < 8; i++)
            {
                KeyFrameIndex keyFrameIndex = new KeyFrameIndex();
                keyFrameIndex.name = names[i];
                keyFrameIndex.elementCount = file.Reader.ReadInt32();
                keyFrameIndex.tableStartIndex = file.Reader.ReadInt32();
                keyFrameIndex.padding = file.Reader.ReadInt32();

                List<KeyFrame> curKeyFrames = new List<KeyFrame>();

                for (int c = 0; c < keyFrameIndex.elementCount; c++)
                {
                    KeyFrame keyFrame = new KeyFrame();
                    if (keyFrameIndex.tableStartIndex == 0)
                    {
                        keyFrame.Value = floatTable[keyFrameIndex.tableStartIndex + currentFloatTableIndex];
                        ++currentFloatTableIndex;
                        keyFrame.Velocity = floatTable[keyFrameIndex.tableStartIndex + currentFloatTableIndex];
                        ++currentFloatTableIndex;
                        keyFrame.Time = floatTable[keyFrameIndex.tableStartIndex + currentFloatTableIndex];
                        ++currentFloatTableIndex;
                    }
                    else
                    {
                        keyFrame.Time = floatTable[keyFrameIndex.tableStartIndex];
                        keyFrame.Value = floatTable[keyFrameIndex.tableStartIndex + 1];
                        keyFrame.Velocity = floatTable[keyFrameIndex.tableStartIndex + 2];
                    }

                    curKeyFrames.Add(keyFrame);
                }

                keyFrameIndex.keyFrames = curKeyFrames;
                keyFrameIndicies.Add(keyFrameIndex);
            }

            floatTableOffset = file.Reader.ReadInt32();
        }

        string magic;
        int unk1, unk2, unk3, unk4, unk5, floatTableOffset;
        List<KeyFrameIndex> keyFrameIndicies;
    }

    public struct KeyFrameIndex
    {
        public int elementCount;
        public int tableStartIndex;
        public int padding;
        public List<KeyFrame> keyFrames;
        public string name;
    }

    public struct KeyFrame
    {
        public float Time;
        public float Value;
        public float Velocity;
    }
}
