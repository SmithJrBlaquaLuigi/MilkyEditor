using System;
using System.Windows.Forms;

namespace MilkyEditor.Widgets
{
    class ScenarioEditorWidget : FlowLayoutPanel
    {
        public ScenarioEditorWidget(Scenario scenarioEntry)
        {
            entry = scenarioEntry;

            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.TopDown;
            AutoScroll = true;
            WrapContents = false;
        }

        public void GeneratePanel()
        {
            Label scenarioNoLbl = new Label
            {
                Text = "Scenario Number:"
            };
            Controls.Add(scenarioNoLbl);

            scenarioNo = new NumericUpDown();
            scenarioNo.ValueChanged += new EventHandler(ScenarioNo_ValueChanged);
            scenarioNo.Minimum = int.MinValue;
            scenarioNo.Maximum = int.MaxValue;
            scenarioNo.Value = entry.ScenarioNo;
            Controls.Add(scenarioNo);

            Label scenarioNameLbl = new Label
            {
                Text = "Scenario Name:"
            };
            Controls.Add(scenarioNameLbl);

            scenarioName = new TextBox
            {
                Text = entry.ScenarioName,
                Width = 250
            };
            scenarioName.TextChanged += new EventHandler(ScenarioName_TextChanged);
            Controls.Add(scenarioName);

            bool[] Missions = new bool[8];
            for (int i = 0; i < 8; i++)
            {
                Missions[i] = ((entry.PowerStarId >> i) & 0x1) != 0x0;
            }

            star1 = new CheckBox();
            if (Missions[0])
                star1.Checked = true;
            star1.Text = "Star 1:";
            Controls.Add(star1);

            star2 = new CheckBox();
            if (Missions[1])
                star2.Checked = true;
            star2.Text = "Star 2:";
            Controls.Add(star2);

            star3 = new CheckBox();
            if (Missions[2])
                star3.Checked = true;
            star3.Text = "Star 3:";
            Controls.Add(star3);

            star4 = new CheckBox();
            if (Missions[3])
                star4.Checked = true;
            star4.Text = "Star 4:";
            Controls.Add(star4);

            star5 = new CheckBox();
            if (Missions[4])
                star5.Checked = true;
            star5.Text = "Star 5:";
            Controls.Add(star5);

            star6 = new CheckBox();
            if (Missions[5])
                star6.Checked = true;
            star6.Text = "Star 6:";
            Controls.Add(star6);

            star7 = new CheckBox();
            if (Missions[6])
                star7.Checked = true;
            star7.Text = "Star 7:";
            Controls.Add(star7);

            star8 = new CheckBox();
            if (Missions[7])
                star8.Checked = true;
            star8.Text = "Star 8:";
            Controls.Add(star8);

            Label cometLbl = new Label
            {
                Text = "Comet Type:"
            };
            Controls.Add(cometLbl);

            comet = new ComboBox();

            string[] comets = { "None", "Purple Coin", "Daredevil", "Timed", "Romp", "Cosmic Clones", "Double Time", "Cosmic Race", "Timed Purple Coin"};

            foreach(string cometType in comets)
            {
                comet.Items.Add(cometType);
            }

            int selectedIndex = 0;

            switch(entry.Comet)
            {
                case "Purple":
                    selectedIndex = 1;
                    break;
                case "Dark":
                    selectedIndex = 2;
                    break;
                case "Red":
                    selectedIndex = 3;
                    break;
                case "Exterminate":
                    selectedIndex = 4;
                    break;
                case "Mimic":
                    selectedIndex = 5;
                    break;
                case "Quick":
                    selectedIndex = 6;
                    break;
                case "Blue":
                    selectedIndex = 7;
                    break;
                case "Black":
                    selectedIndex = 8;
                    break;
                default:
                    selectedIndex = 0;
                    break;
            }

            comet.SelectedIndex = selectedIndex;
            Controls.Add(comet);

            Label timerLbl = new Label
            {
                Text = "Comet Timer:"
            };
            Controls.Add(timerLbl);

            cometTimer = new NumericUpDown
            {
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = entry.CometLimitTimer
            };
            if (entry.Comet == "")
                cometTimer.Enabled = false;
            Controls.Add(cometTimer);

            Label luigiTimerLbl = new Label
            {
                Text = "Luigi Timer(?):"
            };
            Controls.Add(luigiTimerLbl);

            luigiModeTimer = new NumericUpDown
            {
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = entry.LuigiModeTimer
            };
            Controls.Add(luigiModeTimer);

            Label typeLbl = new Label
            {
                Text = "Star Type:"
            };
            Controls.Add(typeLbl);

            string[] powerStarTypes = { "Normal Star", "Green Star", "Hidden Star" };

            powerStarType = new ComboBox();

            foreach(string psType in powerStarTypes)
            {
                powerStarType.Items.Add(psType);
            }

            switch(entry.PowerStarType)
            {
                case "Normal":
                    powerStarType.SelectedIndex = 0;
                    break;
                case "Green":
                    powerStarType.SelectedIndex = 1;
                    break;
                case "Hidden":
                    powerStarType.SelectedIndex = 2;
                    break;
                default:
                    powerStarType.SelectedIndex = 0;
                    break;
            }
            Controls.Add(powerStarType);
        }

        private void ScenarioNo_ValueChanged(object sender, EventArgs e) { entry.ScenarioNo = (int)scenarioNo.Value; }
        private void ScenarioName_TextChanged(object sender, EventArgs e) { entry.ScenarioName = scenarioName.Text; }

        Scenario entry;

        NumericUpDown scenarioNo;
        TextBox scenarioName;

        CheckBox star1, star2, star3, star4, star5, star6, star7, star8;

        ComboBox comet;
        NumericUpDown cometTimer;
        ComboBox powerStarType;
        NumericUpDown luigiModeTimer;
    }
}
