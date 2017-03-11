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
    public partial class HashGen : Form
    {
        public HashGen()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            uint hash = Bcsv.FieldNameToHash(textBox1.Text);
            label1.Text = hash.ToString("X8");
        }
    }
}
