using MilkyEditor.Filesystem;
using MilkyEditor.GalaxyObject;
using MilkyEditor.Widgets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkyEditor
{
    public partial class LevelEditorForm : Form
    {
        public LevelEditorForm(ExternalFilesystem filesystem, string name, List<string> galaxyLayers, bool isGalaxyZone)
        {
            InitializeComponent();
            Text = "Milky Editor v0.1 -- Editing " + name;

            gameFilesystem = filesystem;
            galaxyName = name;
            layers = galaxyLayers;
            isZone = isGalaxyZone;

            // now we create the galaxy if it's not just a zone
            // this way, we also have to enable a lot of things
            if (!isGalaxyZone)
            {
                // first we enable a few things
                scenarioEditingToolbar.Enabled = true;
                scenarioTreeView.Enabled = true;
                // now we create the galaxy
                galaxy = new Galaxy(galaxyName, layers, gameFilesystem);

                /*
                 * First we get the scenario data from the galaxy
                 */
                foreach (Scenario entry in galaxy.scenarios)
                {
                    TreeNode node = new TreeNode(entry.ToString())
                    {
                        Tag = entry
                    };

                    scenarioTreeView.Nodes.Add(node);
                }

                /*
                 * Now we add the light data
                 */
                foreach (Light light in galaxy.lights)
                {
                    TreeNode node = new TreeNode(light.ToString())
                    {
                        Tag = light
                    };

                    lightDataTree.Nodes.Add(node);
                }

                // that was just for the galaxy itself, now we have to add the data from the zones
                foreach (Zone zone in galaxy.zones)
                {
                    List<Light> lights = new List<Light>();
                    lights = zone.lights;

                    if (lights == null)
                        break;

                    foreach (Light light in lights)
                    {
                        TreeNode node = new TreeNode(light.ToString())
                        {
                            Tag = light
                        };

                        lightDataTree.Nodes.Add(node);
                    }
                }

                foreach(PathObject path in galaxy.paths)
                {
                    int index = 0;

                    TreeNode node = new TreeNode(path.ToString())
                    {
                        Tag = path
                    };

                    pathsTree.Nodes.Add(node);

                    foreach (PathPointObject pointObj in path.points)
                    {
                        TreeNode childNode = new TreeNode("Path Point " + index);
                        childNode.Tag = pointObj;

                        node.Nodes.Add(childNode);

                        ++index;
                    }
                }

                FillObjectTree();
                FillAreaTree();
            }
            // this means that the selected level is just a zone
            else
            {
                zone = new Zone(galaxyName, layers[0], gameFilesystem);

                if (zone.lights != null)
                {
                    foreach (Light light in zone.lights)
                    {
                        TreeNode node = new TreeNode(light.ToString())
                        {
                            Tag = light
                        };

                        lightDataTree.Nodes.Add(node);
                    }
                }

                FillObjectTree();
                FillAreaTree();
                FillStartTree();
            }
        }

        private void FillObjectTree()
        {
            // clear the objects first
            objectsTreeView.Nodes.Clear();

            /* first the galaxy's objects */
            if (!isZone)
            {
                foreach (LevelObject obj in galaxy.objects)
                {
                    TreeNode node = new TreeNode(obj.ToString())
                    {
                        Tag = obj
                    };

                    objectsTreeView.Nodes.Add(node);
                }
            }

            // now this is only for zones by themselves
            if (galaxy == null)
            {
                foreach (LevelObject obj in zone.objects)
                {
                    TreeNode node = new TreeNode(obj.ToString())
                    {
                        Tag = obj
                    };

                    objectsTreeView.Nodes.Add(node);
                }
                return;
            }

            /* now the zones' objects*/
            foreach (Zone zone in galaxy.zones)
            {
                foreach (LevelObject obj in zone.objects)
                {
                    TreeNode node = new TreeNode(obj.ToString())
                    {
                        Tag = obj
                    };

                    objectsTreeView.Nodes.Add(node);
                }
            }
        }

        private void FillAreaTree()
        {
            areasTreeView.Nodes[0].Nodes.Clear();
            areasTreeView.Nodes[1].Nodes.Clear();
            areasTreeView.Nodes[2].Nodes.Clear();

            if (!isZone)
            {
                foreach(AreaObject garea in galaxy.areas)
                {
                    TreeNode node = new TreeNode(garea.ToString());
                    node.Tag = garea;

                    switch (garea.Type)
                    {
                        case 0:
                            areasTreeView.Nodes[0].Nodes.Add(node);
                            break;
                        case 1:
                            areasTreeView.Nodes[1].Nodes.Add(node);
                            break;
                        case 2:
                            areasTreeView.Nodes[2].Nodes.Add(node);
                            break;
                    }
                }

                foreach (CameraObject camObj in galaxy.cameras)
                {
                    TreeNode node = new TreeNode(camObj.ToString())
                    {
                        Tag = camObj
                    };

                    areasTreeView.Nodes[3].Nodes.Add(node);
                }

                foreach(Zone zone in galaxy.zones)
                {
                    if (zone.areas == null)
                        break;

                    foreach(AreaObject area in zone.areas)
                    {
                        TreeNode node = new TreeNode(area.ToString());
                        node.Tag = area;

                        switch(area.Type)
                        {
                            case 0:
                                areasTreeView.Nodes[0].Nodes.Add(node);
                                break;
                            case 1:
                                areasTreeView.Nodes[1].Nodes.Add(node);
                                break;
                            case 2:
                                areasTreeView.Nodes[2].Nodes.Add(node);
                                break;
                        }
                    }
                }
            }
            else
            {
                foreach (AreaObject area in zone.areas)
                {
                    TreeNode node = new TreeNode(area.ToString());
                    node.Tag = area;

                    switch (area.Type)
                    {
                        case 0:
                            areasTreeView.Nodes[0].Nodes.Add(node);
                            break;
                        case 1:
                            areasTreeView.Nodes[1].Nodes.Add(node);
                            break;
                        case 2:
                            areasTreeView.Nodes[2].Nodes.Add(node);
                            break;
                    }
                }
            }
        }

        private void FillStartTree()
        {
            startingPointsTree.Nodes.Clear();

            if (!isZone)
            {
                foreach (StartObject start in galaxy.startingPoints)
                {
                    TreeNode node = new TreeNode(start.ToString())
                    {
                        Tag = start
                    };

                    startingPointsTree.Nodes.Add(node);
                }

                foreach(Zone zone in galaxy.zones)
                {
                    foreach (StartObject start in zone.startingPoints)
                    {
                        TreeNode node = new TreeNode(start.ToString())
                        {
                            Tag = start
                        };

                        startingPointsTree.Nodes.Add(node);
                    }
                }
            }
            else
            {
                foreach (StartObject start in zone.startingPoints)
                {
                    TreeNode node = new TreeNode(start.ToString())
                    {
                        Tag = start
                    };

                    startingPointsTree.Nodes.Add(node);
                }
            }
        }

        private void ScenarioTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            scenarioEditorPanel.Controls.Clear();
            layers.Clear();

            layers.Add("Common"); // always load common

            Scenario scenario = (Scenario)scenarioTreeView.SelectedNode.Tag;
            Bcsv.Entry entry = scenario.ScenarioEntry;

            int LayerMask = Convert.ToInt32(entry[galaxyName]);
            galaxy = null; // nullify the current galaxy so we can make a new one

            string[] glayers = new string[]
            {
                "LayerA",
                "LayerB",
                "LayerC",
                "LayerD",
                "LayerE",
                "LayerF",
                "LayerG",
                "LayerH",
                "LayerI",
                "LayerJ",
                "LayerK",
                "LayerL",
                "LayerM",
                "LayerN",
                "LayerO",
                "LayerP"
            };

            for (int i = 0; i < glayers.Length; i++)
            {
                if (((LayerMask >> i) & 0x1) != 0x0)
                {
                    layers.Add(glayers[i]);
                }
            }

            galaxy = new Galaxy(galaxyName, layers, gameFilesystem);

            FillObjectTree();
            FillAreaTree();
            FillStartTree();

            if (scenarioTreeView.SelectedNode != null)
            {
                ScenarioEditorWidget scenarioEditor = new ScenarioEditorWidget(scenario);
                scenarioEditor.GeneratePanel();

                scenarioEditorPanel.Controls.Add(scenarioEditor);
            }
        }

        private void LightDataTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lightViewPanel.Controls.Clear();

            if (lightDataTree.SelectedNode != null)
            {
                LightEditorWidget lightEditor = new LightEditorWidget((Light)lightDataTree.SelectedNode.Tag);

                lightViewPanel.Controls.Add(lightEditor);
            }
        }

        ExternalFilesystem gameFilesystem;
        string galaxyName;
        List<string> layers;
        bool isZone;
        Galaxy galaxy;
        Zone zone;

        private void pathsPage_Click(object sender, EventArgs e)
        {

        }
    }
}
