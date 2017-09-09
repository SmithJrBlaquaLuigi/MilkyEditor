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
            }
        }

        private void ScenarioTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            scenarioEditorPanel.Controls.Clear();
            layers.Clear();

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

            layers.Add("Common"); // always load common

            galaxy = new Galaxy(galaxyName, layers, gameFilesystem);

            if (scenarioTreeView.SelectedNode != null)
            {
                ScenarioEditorWidget scenarioEditor = new ScenarioEditorWidget((Scenario)scenarioTreeView.SelectedNode.Tag);
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
    }
}
