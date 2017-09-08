﻿using MilkyEditor.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyEditor.GalaxyObject
{
    class Light
    {
        public Light()
        {
            LightID = 0xFFFFFFFF;
            AreaLightName = "";
        }

        public Light(Bcsv.Entry entry, string name)
        {
           galaxyName = name;
           LightID = Convert.ToUInt32(entry["LightID"]);
           AreaLightName = Convert.ToString(entry["AreaLightName"]);
        }

        public override string ToString() { return String.Format("[{0}] {1} ({2})", LightID, AreaLightName, galaxyName); }

        public ulong LightID;
        public string AreaLightName;
        public string galaxyName;
    }
}