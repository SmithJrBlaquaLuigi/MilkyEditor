using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using MilkyEditor.GalaxyObjects;

namespace MilkyEditor
{
    public partial class EditorWindow : Form
    {

        // DISPLAYLISTS
        int objs = 0; // objects
        int strt = 0; // starting points
        int map_parts = 0; // map parts

        // galaxy name
        public string path;
        // all objects in the level
        List<LevelObject> objects = new List<LevelObject>();
        // all MapParts in the level
        List<MapParts> mapParts = new List<MapParts>();
        // all starts in the level
        List<StartObject> starts = new List<StartObject>();

        // storing models for nice caching
        private Dictionary<string, Bmd> modelList = new Dictionary<string, Bmd>();

        public EditorWindow()
        {
            InitializeComponent();
        }

        private RarcFilesystem archive_zones = null;
        private Bcsv bcsv_map = null;
        private Bcsv bcsv_zones_info = null;
        private Bcsv bcsv_zones = null;

        /// <summary>
        /// Loads the galaxy and fills the lists, as well as setting up the GL
        /// </summary>
        /// <param name="path">Level name</param>
        /// <param name="layer">The layer to load. Default is Common</param>
        public void loadGalaxy(string level_path, string layer, bool isZone)
        {
            ///////////////////
            /// Variables
            ///////////////////
            path = level_path;
            // RARCs to load
            RarcFilesystem arc_map, arc_scenario, arc_light;
            // BCSVs to load
            Bcsv bcsv_map, bcsv_scenario, bcsv_light;

            Dictionary<string, Zone> zones = new Dictionary<string, Zone>();

            Program.GameArchive = new ExternalFilesystem(Properties.Settings.Default.baseFolder);

            string new_path_map = "";
            string new_path_scenario = "";
            string new_path_light = "";

            if (Program.GameVersion == SMGVersion.SMG1)
            {
                // BaseFolder/StageData/LevelMap.arc
                new_path_map = "/StageData/" + path + ".arc";

                // BaseFolder/StageData/Level/LevelScenario.arc
                new_path_scenario = "/StageData/" + path + "/" + path + "Scenario.arc";

                Console.WriteLine(new_path_map);

                if (!File.Exists(Properties.Settings.Default.baseFolder + "/StageData/" + path + ".arc"))
                {
                    MessageBox.Show("Fatal error -- map doesn't have a map file. Aborting.");
                    return;
                }
            }
            else
            {
                // BaseFolder/StageData/Level/LevelMap.arc
                new_path_map = "/StageData/" + path + "/" + path + "Map.arc";
                // BaseFolder/StageData/Level/LevelLight.arc
                new_path_light = "/StageData/" + path + "/" + path + "Light.arc";
                // BaseFolder/StageData/Level/LevelScenario.arc
                new_path_scenario = "/StageData/" + path + "/" + path + "Scenario.arc";

                if (!File.Exists(Properties.Settings.Default.baseFolder + "/StageData/" + path + "/" + path + "Map.arc"))
                {
                    MessageBox.Show("Fatal error -- map doesn't have a Map.arc file. Aborting.");
                    return;
                }
            }

            ///////////////////
            /// Map Loading
            ///////////////////

            arc_map = new RarcFilesystem(Program.GameArchive.OpenFile(new_path_map));

            // this will give us the chance to see what layers this galaxy uses.
            string[] layers_map = arc_map.GetDirectories("/Stage/jmp/Placement");
            string[] layers_map_parts = arc_map.GetDirectories("/Stage/jmp/MapParts");
            string[] layers_start = arc_map.GetDirectories("/Stage/jmp/Start");

            // load stuff from zones inherited by the level
            loadLevelObjects(arc_map, layers_map);
            loadLevelMapParts(arc_map, layers_map_parts);
            loadLevelStarts(arc_map, layers_start);

            // now we just load the galaxy objects
            loadGalaxyMap(arc_map, layers_map);

            ///////////////////
            /// Light Code
            ///////////////////
            // first we check to see if the file even exists
            if (File.Exists(Properties.Settings.Default.baseFolder + new_path_light))
            {
                // now we open up the arc with the light info
                arc_light = new RarcFilesystem(Program.GameArchive.OpenFile(new_path_light));
                // ...and grab our bcsv from the light archive (there's only 1)
                bcsv_light = new Bcsv(arc_light.OpenFile("/Stage/csv/"+ path + "Light.bcsv"));

                foreach (Bcsv.Entry entry in bcsv_light.Entries)
                {
                    Light light = new Light();
                    light.lightID = (int)entry["LightID"];
                    light.lightName = (string)entry["AreaLightName"];

                    TreeNode lightNode = new TreeNode("[" + light.lightID + "] " + light.lightName);
                    lightNode.Tag = light;

                    // ...and we add them to the treeview
                    lightEntries.Nodes.Add(lightNode);

                }
            }

            ///////////////////
            /// Scenario Code
            ///////////////////
            // First we check to see if even the folder has a scenario. Zones do not have scenarios, galaxies do.
            if (File.Exists(Properties.Settings.Default.baseFolder + new_path_scenario))
            {
                // now we open up the arc with the scenario
                arc_scenario = new RarcFilesystem(Program.GameArchive.OpenFile(new_path_scenario));
                // ...and grab our ScenarioData.bcsv, which contains star information
                bcsv_scenario = new Bcsv(arc_scenario.OpenFile("/" + path + "Scenario/ScenarioData.bcsv"));

                // after we load it, we go through each entry and take its properties
                foreach (Bcsv.Entry entry in bcsv_scenario.Entries)
                {
                    string name = (string)entry["ScenarioName"];

                    ScenarioData scenario_data = new ScenarioData();
                    scenario_data.scenarioName = name;
                    scenario_data.scenarioNo = (int)entry["ScenarioNo"];
                    scenario_data.powerStarID = (int)entry["PowerStarId"];
                    scenario_data.appearStarObj = (string)entry["AppearPowerStarObj"];
                    scenario_data.comet = (string)entry["Comet"];
                    scenario_data.timer = (int)entry["LuigiModeTimer"];

                    if (Program.GameVersion == SMGVersion.SMG2)
                        scenario_data.powerStarType = (string)entry["PowerStarType"];

                    TreeNode scenarioNode = new TreeNode("[" + scenario_data.scenarioNo + "] " + name);
                    scenarioNode.Tag = scenario_data;

                    // ...and we add them to the treeview
                    treeView1.Nodes.Add(scenarioNode);

                }

                arc_scenario.Close();
                bcsv_scenario.Close();
            }

            doRendering(layer);
        }

        private Bcsv bcsv_map_entries = null;
        private Bcsv bcsv_map_start = null;
        private Bcsv bcsv_map_parts = null;

        public void loadGalaxyMap(RarcFilesystem level, string[] layers)
        {
            foreach (string layer in layers)
            {
                bcsv_map_entries = new Bcsv(level.OpenFile("/Stage/jmp/Placement/" + layer + "/ObjInfo"));

                foreach (Bcsv.Entry entry in bcsv_map_entries.Entries)
                {
                    // each entry needs it's own specific casting :/
                    LevelObject obj = new LevelObject();

                    // basic info
                    obj.name = (string)entry["name"];
                    obj.id = (int)entry["l_id"];
                    obj.layer = layer; // this is NOT included in original data!

                    // object settings
                    obj.obj_arg0 = (int)entry["Obj_arg0"];
                    obj.obj_arg1 = (int)entry["Obj_arg1"];
                    obj.obj_arg2 = (int)entry["Obj_arg2"];
                    obj.obj_arg3 = (int)entry["Obj_arg3"];
                    obj.obj_arg4 = (int)entry["Obj_arg4"];
                    obj.obj_arg5 = (int)entry["Obj_arg5"];
                    obj.obj_arg6 = (int)entry["Obj_arg6"];
                    obj.obj_arg7 = (int)entry["Obj_arg7"];

                    // Camera
                    obj.cameraSetID = (int)entry["CameraSetId"];

                    // Events / SWitch
                    obj.sw_appear = (int)entry["SW_APPEAR"];
                    obj.sw_dead = (int)entry["SW_DEAD"];
                    obj.sw_a = (int)entry["SW_A"];
                    obj.sw_b = (int)entry["SW_B"];

                    if (Program.GameVersion == SMGVersion.SMG1)
                    {
                        obj.sw_sleep = (int)entry["SW_SLEEP"];
                    }
                    else
                    {
                        obj.sw_awake = (int)entry["SW_AWAKE"];
                        obj.sw_param = (int)entry["SW_PARAM"];
                    }

                    // Message
                    obj.messageID = (int)entry["MessageId"];

                    // ParamScale
                    if (Program.GameVersion == SMGVersion.SMG2)
                        obj.paramScale = (float)entry["ParamScale"];

                    // Translate, Rotate, Scale
                    obj.x = (float)entry["pos_x"];
                    obj.y = (float)entry["pos_y"];
                    obj.z = (float)entry["pos_z"];

                    obj.rotX = (float)entry["dir_x"];
                    obj.rotY = (float)entry["dir_y"];
                    obj.rotZ = (float)entry["dir_z"];

                    obj.scaleX = (float)entry["scale_x"];
                    obj.scaleY = (float)entry["scale_y"];
                    obj.scaleZ = (float)entry["scale_z"];

                    // Misc
                    obj.castID = (int)entry["CastId"];
                    obj.viewGroupID = (int)entry["ViewGroupId"];
                    // the following have a max of 0xFFFF
                    obj.shapeModelNo = (short)entry["ShapeModelNo"];
                    // why go from Id --> ID ??
                    obj.commonPathID = (short)entry["CommonPath_ID"];
                    obj.clipGroupID = (short)entry["ClippingGroupId"];
                    obj.groupID = (short)entry["GroupId"];
                    obj.demoGroupID = (short)entry["DemoGroupId"];
                    obj.mapPartsID = (short)entry["MapParts_ID"];

                    if (Program.GameVersion == SMGVersion.SMG2)
                    {
                        obj.objID = (short)entry["Obj_ID"];
                        obj.generatorID = (short)entry["GeneratorID"];
                    }

                    objects.Add(obj);
                }

                bcsv_map_start = new Bcsv(level.OpenFile("/Stage/jmp/Start/" + layer + "/StartInfo"));

                foreach (Bcsv.Entry entry in bcsv_map_start.Entries)
                {
                    StartObject start = new StartObject();
                    start.name = (string)entry["name"];
                    start.layer = layer;
                    start.marioNo = (int)entry["MarioNo"];
                    start.arg0 = (int)entry["Obj_arg0"];
                    start.cameraID = (int)entry["Camera_id"];
                    start.x = (float)entry["pos_x"];
                    start.y = (float)entry["pos_y"];
                    start.z = (float)entry["pos_z"];
                    start.rotX = (float)entry["dir_x"];
                    start.rotY = (float)entry["dir_y"];
                    start.rotZ = (float)entry["dir_z"];
                    start.scaleX = (float)entry["scale_x"];
                    start.scaleY = (float)entry["scale_y"];
                    start.scaleZ = (float)entry["scale_z"];

                    starts.Add(start);
                }

                bcsv_map_parts = new Bcsv(level.OpenFile("/Stage/jmp/MapParts/" + layer + "/MapPartsInfo"));

                foreach (Bcsv.Entry entry in bcsv_map_parts.Entries)
                {
                    MapParts mapPart = new MapParts();
                    mapPart.name = (string)entry["name"];
                    mapPart.layer = layer;
                    mapPart.x = (float)entry["pos_x"];
                    mapPart.y = (float)entry["pos_y"];
                    mapPart.z = (float)entry["pos_z"];
                    mapPart.rotX = (float)entry["dir_x"];
                    mapPart.rotY = (float)entry["dir_y"];
                    mapPart.rotZ = (float)entry["dir_z"];
                    mapPart.scaleX = (float)entry["scale_x"];
                    mapPart.scaleY = (float)entry["scale_y"];
                    mapPart.scaleZ = (float)entry["scale_z"];

                    mapParts.Add(mapPart);
                }
            }
        }

        public void doRendering(string layer)
        {
            objs = GL.GenLists(1);
            GL.NewList(objs, ListMode.Compile);

            RarcFilesystem bmd_archive;
            Bmd model;

            treeView3.Nodes.Add("DebugMoveInfo");
            treeView3.Nodes.Add("GeneralPos");
            treeView3.Nodes.Add("ChangeSceneList");
            treeView3.Nodes.Add("StageInfo");
            treeView3.Nodes.Add("Map Parts");
            treeView3.Nodes.Add("Paths");
            treeView3.Nodes.Add("Objects");
            treeView3.Nodes.Add("Starting Positions");

            TreeNodeCollection nodes = treeView3.Nodes;

            treeView3.SelectedNode = nodes[6];

            foreach (LevelObject obj in objects)
            {

                if (obj.zone == "")
                    obj.zone = path;

                if (obj.layer == layer || obj.layer == layer.ToLower() || obj.layer == "Common" || obj.layer == "common")
                {

                    TreeNode objNode = new TreeNode(obj.name + " [" + obj.layer + "]");
                    objNode.Tag = obj;

                    // ...and we add them to the treeview
                    treeView3.SelectedNode.Nodes.Add(objNode);

                    GL.PushMatrix();
                    GL.Translate(obj.x, obj.y, obj.z);
                    GL.Rotate(obj.rotX, 1f, 0f, 0f);
                    GL.Rotate(obj.rotY, 0f, 1f, 0f);
                    GL.Rotate(obj.rotZ, 0f, 0f, 1f);

                    bool doesExist = doesModelExist(obj.name);

                    if (doesExist)
                    {
                        GL.Scale(obj.scaleX, obj.scaleY, obj.scaleZ);

                        if (modelList.ContainsKey(obj.name) || modelList.ContainsKey(ObjectModelSubstitution.returnModelName(obj.name)))
                        {
                            modelList.TryGetValue(obj.name, out model);
                            DrawBMD(model);
                        }
                        else
                        {
                            string name = ObjectModelSubstitution.returnModelName(obj.name);
                            string path_new = "/ObjectData/" + name + ".arc";

                            bmd_archive = new RarcFilesystem(Program.GameArchive.OpenFile(path_new));
                            model = new Bmd(bmd_archive.OpenFile("/" + name + "/" + name + ".bdl"));

                            modelList.Add(name, model);

                            DrawBMD(model);

                            bmd_archive.Close();
                        }
                    }
                    else
                    {
                        // cubes don't get scale
                        GL.Scale(1f, 1f, 1f);
                        DrawCube();
                    }

                    GL.PopMatrix();
                }
            }

            GL.EndList();

            strt = GL.GenLists(1);
            GL.NewList(strt, ListMode.Compile);

            treeView3.SelectedNode = nodes[7];

            Bmd marioModel;

            foreach (StartObject start in starts)
            {
                if (start.layer == layer || start.layer == "Common")
                {
                    TreeNode startNode = new TreeNode("Starting Point " + start.marioNo + " [" + start.layer + "]");
                    startNode.Tag = start;

                    // ...and we add them to the treeview
                    treeView3.SelectedNode.Nodes.Add(startNode);

                    GL.PushMatrix();
                    GL.Translate(start.x, start.y, start.z);
                    GL.Rotate(start.rotX, 1f, 0f, 0f);
                    GL.Rotate(start.rotY, 0f, 1f, 0f);
                    GL.Rotate(start.rotZ, 0f, 0f, 1f);
                    GL.Scale(1f, 1f, 1f);

                    bool doesExist = doesModelExist("Mario");

                    if (doesExist)
                    {
                        if (modelList.ContainsKey("Mario"))
                        {
                            modelList.TryGetValue(start.name, out marioModel);
                            DrawBMD(marioModel);
                        }
                        else
                        {
                            string path_new = "/ObjectData/Mario.arc";

                            bmd_archive = new RarcFilesystem(Program.GameArchive.OpenFile(path_new));
                            marioModel = new Bmd(bmd_archive.OpenFile("/Mario/Mario.bdl"));

                            modelList.Add("Mario", marioModel);

                            DrawBMD(marioModel);

                            bmd_archive.Close();
                        }
                    }
                    else
                    {
                        DrawCube();
                    }

                    GL.PopMatrix();
                }
            }

            GL.EndList();

            map_parts = GL.GenLists(1);
            GL.NewList(map_parts, ListMode.Compile);

            treeView3.SelectedNode = nodes[4];

            foreach (MapParts mapPart in mapParts)
            {
                if (mapPart.layer == layer || mapPart.layer == "Common")
                {
                    TreeNode mapNode = new TreeNode(mapPart.name + " [" + mapPart.layer + "]");
                    mapNode.Tag = mapPart;

                    // ...and we add them to the treeview
                    treeView3.SelectedNode.Nodes.Add(mapNode);

                    GL.PushMatrix();
                    GL.Translate(mapPart.x, mapPart.y, mapPart.z);
                    GL.Rotate(mapPart.rotX, 1f, 0f, 0f);
                    GL.Rotate(mapPart.rotY, 0f, 1f, 0f);
                    GL.Rotate(mapPart.rotZ, 0f, 0f, 1f);
                    GL.Scale(mapPart.scaleX, mapPart.scaleY, mapPart.scaleZ);

                    bool doesExist = doesModelExist(mapPart.name);

                    if (doesExist)
                    {
                        if (modelList.ContainsKey(mapPart.name))
                        {
                            modelList.TryGetValue(mapPart.name, out model);
                            DrawBMD(model);
                        }
                        else
                        {
                            string path_new = "/ObjectData/" + mapPart.name + ".arc";

                            bmd_archive = new RarcFilesystem(Program.GameArchive.OpenFile(path_new));
                            model = new Bmd(bmd_archive.OpenFile("/" + mapPart.name + "/" + mapPart.name + ".bdl"));

                            modelList.Add(mapPart.name, model);

                            DrawBMD(model);

                            bmd_archive.Close();
                        }
                    }
                    else
                    {
                        DrawCube();
                    }

                    GL.PopMatrix();
                }
            }

            GL.EndList();
        }

        /// <summary>
        /// Loads level objects so it can be put into a view.
        /// Only loads things in the cooresponding zones, however
        /// </summary>
        /// <param name="level">Input BCSV to return objects for.</param>
        public void loadLevelObjects(RarcFilesystem level, string[] layers)
        {

            foreach (string layer in layers)
            {
                bcsv_map = new Bcsv(level.OpenFile("/Stage/jmp/Placement/" + layer + "/ObjInfo"));
                bcsv_zones_info = new Bcsv(level.OpenFile("/Stage/jmp/Placement/" + layer + "/StageObjInfo"));

                foreach (Bcsv.Entry zone_entry in bcsv_zones_info.Entries)
                {
                    Zone zone = new Zone();

                    zone.name = (string)zone_entry["name"];
                    zone.id = (int)zone_entry["l_id"];

                    zone.x = (float)zone_entry["pos_x"];
                    zone.y = (float)zone_entry["pos_y"];
                    zone.z = (float)zone_entry["pos_z"];

                    zone.rotX = (float)zone_entry["dir_x"];
                    zone.rotY = (float)zone_entry["dir_y"];
                    zone.rotZ = (float)zone_entry["dir_z"];

                    if (Program.GameVersion == SMGVersion.SMG1)
                        archive_zones = new RarcFilesystem(Program.GameArchive.OpenFile("/StageData/" + zone.name + ".arc"));
                    else
                        archive_zones = new RarcFilesystem(Program.GameArchive.OpenFile("/StageData/" + zone.name + "/" + zone.name + "Map.arc"));

                    if (archive_zones.DirectoryExists("/Stage/jmp/Placement/" + layer))
                        bcsv_zones = new Bcsv(archive_zones.OpenFile("/Stage/jmp/Placement/" + layer + "/ObjInfo"));
                    else
                        bcsv_zones = new Bcsv(archive_zones.OpenFile("/Stage/jmp/Placement/Common/ObjInfo"));

                    TreeNode zoneNode = new TreeNode("[" + zone.id + "] " + zone.name);
                    zoneNode.Tag = zone;

                    // ...and we add them to the treeview
                    treeView2.Nodes.Add(zoneNode);

                    // now we go through each and every entry in the BCSV we extracted
                    // after that, we add each levelobject instance to a list
                    foreach (Bcsv.Entry entry in bcsv_zones.Entries)
                    {
                        // each entry needs it's own specific casting :/
                        LevelObject obj = new LevelObject();

                        // basic info
                        obj.name = (string)entry["name"];
                        obj.id = (int)entry["l_id"];
                        obj.layer = layer; // this is NOT included in original data!


                        // object settings
                        obj.obj_arg0 = (int)entry["Obj_arg0"];
                        obj.obj_arg1 = (int)entry["Obj_arg1"];
                        obj.obj_arg2 = (int)entry["Obj_arg2"];
                        obj.obj_arg3 = (int)entry["Obj_arg3"];
                        obj.obj_arg4 = (int)entry["Obj_arg4"];
                        obj.obj_arg5 = (int)entry["Obj_arg5"];
                        obj.obj_arg6 = (int)entry["Obj_arg6"];
                        obj.obj_arg7 = (int)entry["Obj_arg7"];

                        // Camera
                        obj.cameraSetID = (int)entry["CameraSetId"];

                        if (Program.GameVersion == SMGVersion.SMG1)
                        {
                            obj.sw_sleep = (int)entry["SW_SLEEP"];
                        }
                        else
                        {
                            obj.sw_awake = (int)entry["SW_AWAKE"];
                            obj.sw_param = (int)entry["SW_PARAM"];
                        }

                        // Message
                        obj.messageID = (int)entry["MessageId"];

                        // ParamScale
                        if (Program.GameVersion == SMGVersion.SMG2)
                            obj.paramScale = (float)entry["ParamScale"];

                        // Translate, Rotate, Scale
                        obj.x = (float)entry["pos_x"] + zone.x;
                        obj.y = (float)entry["pos_y"] + zone.y;
                        obj.z = (float)entry["pos_z"] + zone.z;

                        obj.rotX = (float)entry["dir_x"];
                        obj.rotY = (float)entry["dir_y"];
                        obj.rotZ = (float)entry["dir_z"];

                        obj.scaleX = (float)entry["scale_x"];
                        obj.scaleY = (float)entry["scale_y"];
                        obj.scaleZ = (float)entry["scale_z"];

                        // Misc
                        obj.castID = (int)entry["CastId"];
                        obj.viewGroupID = (int)entry["ViewGroupId"];
                        // the following have a max of 0xFFFF
                        obj.shapeModelNo = (short)entry["ShapeModelNo"];
                        // why go from Id --> ID ??
                        obj.commonPathID = (short)entry["CommonPath_ID"];
                        obj.clipGroupID = (short)entry["ClippingGroupId"];
                        obj.groupID = (short)entry["GroupId"];
                        obj.demoGroupID = (short)entry["DemoGroupId"];
                        obj.mapPartsID = (short)entry["MapParts_ID"];

                        if (Program.GameVersion == SMGVersion.SMG2)
                        {
                            obj.objID = (short)entry["Obj_ID"];
                            obj.generatorID = (short)entry["GeneratorID"];
                        }

                        objects.Add(obj);
                    }

                    archive_zones.Close();
                }

                bcsv_map.Close();
            }
        }

        public void loadLevelStarts(RarcFilesystem level, string[] layers)
        {
            foreach (string layer in layers)
            {
                bcsv_map = new Bcsv(level.OpenFile("/Stage/jmp/Start/" + layer + "/StartInfo"));
                bcsv_zones_info = new Bcsv(level.OpenFile("/Stage/jmp/Placement/" + layer + "/StageObjInfo"));

                foreach (Bcsv.Entry zone_entry in bcsv_zones_info.Entries)
                {
                    Zone zone = new Zone();

                    zone.name = (string)zone_entry["name"];
                    zone.id = (int)zone_entry["l_id"];

                    zone.x = (float)zone_entry["pos_x"];
                    zone.y = (float)zone_entry["pos_y"];
                    zone.z = (float)zone_entry["pos_z"];

                    zone.rotX = (float)zone_entry["dir_x"];
                    zone.rotY = (float)zone_entry["dir_y"];
                    zone.rotZ = (float)zone_entry["dir_z"];

                    if (Program.GameVersion == SMGVersion.SMG1)
                        archive_zones = new RarcFilesystem(Program.GameArchive.OpenFile("/StageData/" + zone.name + ".arc"));
                    else
                        archive_zones = new RarcFilesystem(Program.GameArchive.OpenFile("/StageData/" + zone.name + "/" + zone.name + "Map.arc"));

                    if (archive_zones.DirectoryExists("/Stage/jmp/Start/" + layer))
                        bcsv_zones = new Bcsv(archive_zones.OpenFile("/Stage/jmp/Start/" + layer + "/StartInfo"));
                    else
                        bcsv_zones = new Bcsv(archive_zones.OpenFile("/Stage/jmp/Start/Common/StartInfo"));

                    // now we go through each and every entry in the BCSV we extracted
                    // after that, we add each levelobject instance to a list
                    foreach (Bcsv.Entry entry in bcsv_zones.Entries)
                    {
                        StartObject start = new StartObject();

                        start.name = (string)entry["name"];
                        start.layer = layer;
                        start.marioNo = (int)entry["MarioNo"];
                        start.arg0 = (int)entry["Obj_arg0"];
                        start.cameraID = (int)entry["Camera_id"];
                        start.x = (float)entry["pos_x"] + zone.x;
                        start.y = (float)entry["pos_y"] + zone.y;
                        start.z = (float)entry["pos_z"] + zone.z;
                        start.rotX = (float)entry["dir_x"];
                        start.rotY = (float)entry["dir_y"];
                        start.rotZ = (float)entry["dir_z"];
                        start.scaleX = (float)entry["scale_x"];
                        start.scaleY = (float)entry["scale_y"];
                        start.scaleZ = (float)entry["scale_z"];

                        starts.Add(start);
                    }

                    archive_zones.Close();
                }

                bcsv_map.Close();
            }
        }

        public void loadLevelMapParts(RarcFilesystem level, string[] layers)
        {
            foreach (string layer in layers)
            {
                bcsv_map = new Bcsv(level.OpenFile("/Stage/jmp/MapParts/" + layer + "/MapPartsInfo"));
                bcsv_zones_info = new Bcsv(level.OpenFile("/Stage/jmp/Placement/" + layer + "/StageObjInfo"));

                foreach (Bcsv.Entry zone_entry in bcsv_zones_info.Entries)
                {
                    Zone zone = new Zone();

                    zone.name = (string)zone_entry["name"];
                    zone.id = (int)zone_entry["l_id"];

                    zone.x = (float)zone_entry["pos_x"];
                    zone.y = (float)zone_entry["pos_y"];
                    zone.z = (float)zone_entry["pos_z"];

                    zone.rotX = (float)zone_entry["dir_x"];
                    zone.rotY = (float)zone_entry["dir_y"];
                    zone.rotZ = (float)zone_entry["dir_z"];

                    if (Program.GameVersion == SMGVersion.SMG1)
                        archive_zones = new RarcFilesystem(Program.GameArchive.OpenFile("/StageData/" + zone.name + ".arc"));
                    else
                        archive_zones = new RarcFilesystem(Program.GameArchive.OpenFile("/StageData/" + zone.name + "/" + zone.name + "Map.arc"));


                    if (archive_zones.DirectoryExists("/Stage/jmp/MapParts/" + layer))
                        bcsv_zones = new Bcsv(archive_zones.OpenFile("/Stage/jmp/MapParts/" + layer + "/MapPartsInfo"));
                    else
                        bcsv_zones = new Bcsv(archive_zones.OpenFile("/Stage/jmp/MapParts/Common/MapPartsInfo"));

                    // now we go through each and every entry in the BCSV we extracted
                    // after that, we add each levelobject instance to a list
                    foreach (Bcsv.Entry entry in bcsv_zones.Entries)
                    {
                        MapParts mapPart = new MapParts();
                        mapPart.name = (string)entry["name"];
                        mapPart.layer = layer;
                        mapPart.x = (float)entry["pos_x"] + zone.x;
                        mapPart.y = (float)entry["pos_y"] + zone.y;
                        mapPart.z = (float)entry["pos_z"] + zone.z;
                        mapPart.rotX = (float)entry["dir_x"];
                        mapPart.rotY = (float)entry["dir_y"];
                        mapPart.rotZ = (float)entry["dir_z"];
                        mapPart.scaleX = (float)entry["scale_x"];
                        mapPart.scaleY = (float)entry["scale_y"];
                        mapPart.scaleZ = (float)entry["scale_z"];

                        mapParts.Add(mapPart);
                    }

                    archive_zones.Close();
                }

                bcsv_map.Close();
            }
        }

        /////////////////////////////////////////
        /// RENDERING CODE
        /////////////////////////////////////////

        private bool loaded;
        private float m_AspectRatio;
        private Vector2 m_CamRotation;
        private Vector3 m_CamPosition;
        private Vector3 m_CamTarget;
        private float m_CamDistance;
        private bool m_UpsideDown;
        private Matrix4 m_CamMatrix, m_SkyboxMatrix;
        private RenderInfo m_RenderInfo;

        private MouseButtons m_MouseDown;
        private Point m_LastMouseMove, m_LastMouseClick;
        private float m_PixelFactorX, m_PixelFactorY;

        private const float k_FOV = (float)((70f * Math.PI) / 180f);
        private const float k_zNear = 0.01f;
        private const float k_zFar = 1000f;

        private void glControl1_Load(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();

            GL.Enable(EnableCap.DepthTest);
            GL.ClearDepth(1f);

            GL.FrontFace(FrontFaceDirection.Cw);

            m_CamRotation = new Vector2(0.0f, 0.0f);
            m_CamTarget = new Vector3(0.0f, 0.0f, 0.0f);
            m_CamDistance = 1f;

            m_RenderInfo = new RenderInfo();

            UpdateViewport();
            UpdateCamera();

            loaded = true;
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
                return;

            glControl1.MakeCurrent();

            UpdateViewport();
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_MouseDown != MouseButtons.None)
                return;
            
            m_MouseDown = e.Button;
            m_LastMouseMove = m_LastMouseClick = e.Location;
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != m_MouseDown)
                return;

            m_MouseDown = MouseButtons.None;
            m_LastMouseMove = e.Location;
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float xdelta = (float)(e.X - m_LastMouseMove.X);
            float ydelta = (float)(e.Y - m_LastMouseMove.Y);

            m_LastMouseMove = e.Location;

            if (m_MouseDown != MouseButtons.None)
            {
                if (m_MouseDown == MouseButtons.Right)
                {
                    if (m_UpsideDown)
                        xdelta = -xdelta;

                    m_CamRotation.X -= xdelta * 0.002f;
                    m_CamRotation.Y -= ydelta * 0.002f;
                }
                else if (m_MouseDown == MouseButtons.Left)
                {
                    xdelta *= 0.005f;
                    ydelta *= 0.005f;

                    m_CamTarget.X -= xdelta * (float)Math.Sin(m_CamRotation.X);
                    m_CamTarget.X -= ydelta * (float)Math.Cos(m_CamRotation.X) * (float)Math.Sin(m_CamRotation.Y);
                    m_CamTarget.Y += ydelta * (float)Math.Cos(m_CamRotation.Y);
                    m_CamTarget.Z += xdelta * (float)Math.Cos(m_CamRotation.X);
                    m_CamTarget.Z -= ydelta * (float)Math.Sin(m_CamRotation.X) * (float)Math.Sin(m_CamRotation.Y);
                }

                UpdateCamera();
            }

            glControl1.Refresh();
        }

        private void glControl1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void selectGalaxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog galaxyFolderDlg = new FolderBrowserDialog();

            if (galaxyFolderDlg.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                treeView2.Nodes.Clear();
                treeView3.Nodes.Clear();

                objects.Clear();
                mapParts.Clear();
                starts.Clear();

                GL.DeleteLists(objs, 1);
                GL.DeleteLists(strt, 1);
                GL.DeleteLists(map_parts, 1);

                string path = galaxyFolderDlg.SelectedPath;

                loadGalaxy(Path.GetFileName(path), "LayerA", false);
            }
        }

        private void bCSVEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCSVEditorForm form = new BCSVEditorForm();
            form.Show();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

            glControl1.MakeCurrent();

            GL.DepthMask(true); // ensures that GL.Clear() will successfully clear the buffers

            GL.ClearColor(0f, 0f, 0.125f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref m_CamMatrix);

            GL.Disable(EnableCap.Texture2D);

            GL.CallList(objs);
            GL.CallList(map_parts);
            GL.CallList(strt);

            GL.Begin(BeginMode.Lines);
            GL.Color4(1f, 0f, 0f, 1f);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(100000f, 0f, 0f);
            GL.Color4(0f, 1f, 0f, 1f);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(0, 100000f, 0f);
            GL.Color4(0f, 0f, 1f, 1f);
            GL.Vertex3(0f, 0f, 0f);
            GL.Vertex3(0f, 0f, 100000f);
            GL.End();

            GL.Color4(1f, 1f, 1f, 1f);

            glControl1.SwapBuffers();
        }

        private void UpdateViewport()
        {
            GL.Viewport(glControl1.ClientRectangle);

            m_AspectRatio = (float)glControl1.Width / (float)glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projmtx = Matrix4.CreatePerspectiveFieldOfView(k_FOV, m_AspectRatio, k_zNear, k_zFar);
            GL.LoadMatrix(ref projmtx);

            m_PixelFactorX = ((2f * (float)Math.Tan(k_FOV / 2f) * m_AspectRatio) / (float)(glControl1.Width));
            m_PixelFactorY = ((2f * (float)Math.Tan(k_FOV / 2f)) / (float)(glControl1.Height));
        }

        private void UpdateCamera()
        {
            Vector3 up;

            if (Math.Cos(m_CamRotation.Y) < 0)
            {
                m_UpsideDown = true;
                up = new Vector3(0.0f, -1.0f, 0.0f);
            }
            else
            {
                m_UpsideDown = false;
                up = new Vector3(0.0f, 1.0f, 0.0f);
            }

            m_CamPosition.X = m_CamDistance * (float)Math.Cos(m_CamRotation.X) * (float)Math.Cos(m_CamRotation.Y);
            m_CamPosition.Y = m_CamDistance * (float)Math.Sin(m_CamRotation.Y);
            m_CamPosition.Z = m_CamDistance * (float)Math.Sin(m_CamRotation.X) * (float)Math.Cos(m_CamRotation.Y);

            Vector3 skybox_target;
            skybox_target.X = -(float)Math.Cos(m_CamRotation.X) * (float)Math.Cos(m_CamRotation.Y);
            skybox_target.Y = -(float)Math.Sin(m_CamRotation.Y);
            skybox_target.Z = -(float)Math.Sin(m_CamRotation.X) * (float)Math.Cos(m_CamRotation.Y);

            Vector3.Add(ref m_CamPosition, ref m_CamTarget, out m_CamPosition);

            m_CamMatrix = Matrix4.LookAt(m_CamPosition, m_CamTarget, up);
            m_SkyboxMatrix = Matrix4.LookAt(Vector3.Zero, skybox_target, up);

            m_CamMatrix = Matrix4.Mult(Matrix4.Scale(0.0001f), m_CamMatrix);
        }

        private void hashGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HashGen hash = new HashGen();
            hash.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //propertyGrid1.SelectedObject = (ScenarioData)listBox1.SelectedItem;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
                propertyGrid1.SelectedObject = (ScenarioData)treeView1.SelectedNode.Tag;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView2.SelectedNode != null)
                propertyGrid2.SelectedObject = (Zone)treeView2.SelectedNode.Tag;
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // to make sure it isn't a root node is selected
            if (treeView3.SelectedNode.Parent != null)
            {
                if (treeView3.SelectedNode.Parent.Text == "Objects")
                {
                    propertyGrid3.SelectedObject = (LevelObject)treeView3.SelectedNode.Tag;
                }
                else if (treeView3.SelectedNode.Parent.Text == "Starting Positions")
                {
                    propertyGrid3.SelectedObject = (StartObject)treeView3.SelectedNode.Tag;
                }
            }
        }

        private void lightEntries_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (lightEntries.SelectedNode != null)
                lightProperties.SelectedObject = (Light)lightEntries.SelectedNode.Tag;
        }

        public static void DrawCube(RenderMode rnd = RenderMode.Opaque)
        {
            RenderInfo ri = new RenderInfo();
            ri.Mode = rnd;
            RendererBase cubeRender;

            cubeRender = new ColorCubeRenderer(250f, new Vector4(1f, 1f, 1f, 1f), new Vector4(1f, 0f, 1f, 1f), true);
            cubeRender.Render(ri);
        }

        public static void DrawBMD(Bmd model, RenderMode rnd = RenderMode.Opaque)
        {
            RenderInfo ri = new RenderInfo();
            ri.Mode = rnd;

            try
            {
                BmdRenderer br = new BmdRenderer(model);
                br.Render(ri);
            }
            catch
            {
                // so if the above fails, draw a cube.
                RendererBase cubeRender;

                cubeRender = new ColorCubeRenderer(250f, new Vector4(1f, 1f, 1f, 1f), new Vector4(1f, 0f, 1f, 1f), true);
                cubeRender.Render(ri);
            }
        }


        // updated to make sure ObjectModelSubstitution.returnModelName(name) is taken into account
        // not all objects' filenames are their object names :c
        bool doesModelExist(string name)
        {
            if (File.Exists(Properties.Settings.Default.baseFolder + "/ObjectData/" + name + ".arc"))
            {
                RarcFilesystem archive;

                // fuck stuff like InvisibleWall10x10.arc man
                archive = new RarcFilesystem(Program.GameArchive.OpenFile("/ObjectData/" + name + ".arc"));
                if (archive.FileExists("/" + name + "/" + name + ".bdl"))
                {
                    archive.Close();
                    return true;
                }
                else
                {
                    archive.Close();
                    return false;
                }
            }
            else
            {
                if (File.Exists(Properties.Settings.Default.baseFolder + "/ObjectData/" + ObjectModelSubstitution.returnModelName(name) + ".arc"))
                {
                    RarcFilesystem archive;

                    // fuck stuff like InvisibleWall10x10.arc man
                    archive = new RarcFilesystem(Program.GameArchive.OpenFile("/ObjectData/" + ObjectModelSubstitution.returnModelName(name) + ".arc"));
                    if (archive.FileExists("/" + ObjectModelSubstitution.returnModelName(name) + "/" + ObjectModelSubstitution.returnModelName(name) + ".bdl"))
                    {
                        archive.Close();
                        return true;
                    }
                    else
                    {
                        archive.Close();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
    }
}
