using MilkyEditor.Filesystem;
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
    public partial class HashGenerator : Form
    {
        public HashGenerator()
        {
            InitializeComponent();
        }

        private void stringInput_TextChanged(object sender, EventArgs e)
        {
            if (stringInput.Text.Contains(" "))
            {
                MessageBox.Show("You cannot have spaces in a field name.");
                stringInput.Text = "";
            }
            else
                hashOutput.Text = Bcsv.FieldNameToHash(stringInput.Text).ToString("X8");
        }
    }
}
