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
        DatabaseConnector dbc = new DatabaseConnector();
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
            //NEED TO FINISH
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
            long processedMaterialId, processedPatronId;
            try
            {
                // Long is Int64
                processedMaterialId = Convert.ToInt64(txt_MaterialID.Text);
                processedPatronId = Convert.ToInt64(txt_LibraryID.Text);

                List<Checkout> allCheckouts = dbc.GetFullCheckoutInfo();
                List<Patron> allPatrons = dbc.GetFullPatronInfo();
                if (allCheckouts.Any(i => i.materialID == processedMaterialId) == false)
                {
                    if (allPatrons.Any(i => i.Id == processedPatronId) == true)
                    {
                        dbc.checkoutMaterial(processedMaterialId, processedPatronId);
                    }
                }
                else
                {
                    MessageBox.Show("Error: Item already checked out");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Please enter a numeric value for both Patron and Material ID");
            }

        }
    }
}
