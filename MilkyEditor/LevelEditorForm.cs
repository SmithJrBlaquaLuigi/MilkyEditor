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
        public LevelEditorForm(ExternalFilesystem filesystem, string name, bool isGalaxyZone)
        {
            InitializeComponent();
            Text = "Milky Editor v0.1 -- Editing " + name;

            gameFilesystem = filesystem;
            galaxyName = name;
            isZone = isGalaxyZone;

            LoadData();
            
        }

        private void LoadData()
        {
            if (!isZone)
            {
                bottomStatusStripLabel.Text = "Loading galaxy " + galaxyName + "...";

                Galaxy galaxy = new Galaxy(galaxyName, gameFilesystem);
                // can only edit scenarios under galaxy files
                scenarioTreeView.Enabled = true;
                scenarioEditingToolbar.Enabled = true;

                Scenario scenario = galaxy.scenario;

                foreach(ScenarioEntry entry in scenario.entries)
                {
                    string nodeName = String.Format("[{0}] {1}", entry.ScenarioNo, entry.ScenarioName);
                    TreeNode node = new TreeNode(nodeName)
                    {
                        Tag = entry
                    };

                    scenarioTreeView.Nodes.Add(node);
                }

                // first we add the ones in the actual galaxy
                foreach(Light light in galaxy.lightData)
                {
                    TreeNode node = new TreeNode(light.ToString())
                    {
                        Tag = light
                    };

                    lightDataTree.Nodes.Add(node);
                }

                // now we add the ones in the cooresponding zones
                if (galaxy.zones != null)
                {
                    foreach(Zone zone in galaxy.zones)
                    {
                        List<Light> lights = zone.lightData;
                        if (lights != null)
                        {
                            foreach (Light light in lights)
                            {
                                TreeNode node = new TreeNode(light.ToString())
                                {
                                    Tag = light
                                };

                                lightDataTree.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
            else
            {
                bottomStatusStripLabel.Text = "Loading zone " + galaxyName + "...";

                Zone zone = new Zone(galaxyName, gameFilesystem);
                scenarioTreeView.Enabled = false;
                scenarioEditingToolbar.Enabled = false;

                List<Light> lights = zone.lightData;
                if (lights != null)
                {
                    foreach (Light light in lights)
                    {
                        TreeNode node = new TreeNode(light.ToString())
                        {
                            Tag = light
                        };

                        lightDataTree.Nodes.Add(node);
                    }
                }
            }

            bottomStatusStripLabel.Text = "Done.";
        }

        private void ScenarioTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            scenarioEditorPanel.Controls.Clear();

            if (scenarioTreeView.SelectedNode != null)
            {
                ScenarioEditorWidget scenarioEditor = new ScenarioEditorWidget((ScenarioEntry)scenarioTreeView.SelectedNode.Tag);
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
        bool isZone;
    }
}
