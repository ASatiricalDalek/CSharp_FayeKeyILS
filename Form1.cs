using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FayeKeyILS
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void patronToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void viewPatronsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form viewPatron = new Views();
            viewPatron.Show();
        }

        private void viewMaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form viewMaterials = new Views();
            viewMaterials.Show();
        }

        private void addPatronsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addPatron = new Add();
            addPatron.Show();
        }

        private void btn_Return_Click(object sender, EventArgs e)
        {

        }

        private void btn_Checkout_Click(object sender, EventArgs e)
        {

        }
    }
}
