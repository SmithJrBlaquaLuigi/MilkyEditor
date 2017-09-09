using MilkyEditor.GalaxyObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkyEditor.Widgets
{
    class LightEditorWidget : FlowLayoutPanel
    {
        public LightEditorWidget(Light light)
        {
            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.TopDown;
            AutoScroll = true; // will never be used but oh well
            WrapContents = false;

            Label idLbl = new Label
            {
                Text = "Light ID:"
            };
            Controls.Add(idLbl);

            lightID = new NumericUpDown
            {
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = light.LightID
            };
            Controls.Add(lightID);

            Label nameLbl = new Label
            {
                Text = "Light Name:"
            };
            Controls.Add(nameLbl);

            lightName = new TextBox
            {
                Width = 250,
                Text = light.AreaLightName
            };
            Controls.Add(lightName);
        }

        NumericUpDown lightID;
        TextBox lightName;
    }
}
