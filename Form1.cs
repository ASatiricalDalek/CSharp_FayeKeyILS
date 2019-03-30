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
            long processedMaterialId;
            try
            {
                processedMaterialId = Convert.ToInt64(txt_ReturnRenew.Text);

                List <Checkout> allCheckouts = dbc.GetFullCheckoutInfo();

                if(allCheckouts.Any(i => i.materialID == processedMaterialId) == true)
                {
                    dbc.Return(processedMaterialId);

                    // Clear textbox for next entry and provide feedback to user
                    txt_ReturnRenew.Text = "";
                    MessageBox.Show("Material returned!");
                }
                else
                {
                    MessageBox.Show("Error: Item is not checked out");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Please enter a numeric value for the item you wish to renew");
            }
        }

        private void btn_Checkout_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
            long processedMaterialId, processedPatronId;
            try
            {
                // Long is Int64
                processedMaterialId = Convert.ToInt64(txt_MaterialID.Text);
                processedPatronId = Convert.ToInt64(txt_LibraryID.Text);

                List<Checkout> allCheckouts = dbc.GetFullCheckoutInfo();
                List<Patron> allPatrons = dbc.GetFullPatronInfo();
                // The material should NOT be present in the checkout table already
                if (allCheckouts.Any(i => i.materialID == processedMaterialId) == false)
                {
                    // The patron ID SHOULD exist
                    if (allPatrons.Any(i => i.Id == processedPatronId) == true)
                    {
                        dbc.checkoutMaterial(processedMaterialId, processedPatronId);

                        txt_LibraryID.Text = "";
                        txt_MaterialID.Text = "";
                        MessageBox.Show("Item checked out!");
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

        private void btn_Renew_Click(object sender, EventArgs e)
        {
            long processedMaterialId;
            try
            {
                processedMaterialId = Convert.ToInt64(txt_ReturnRenew.Text);

                List<Checkout> allCheckouts = dbc.GetFullCheckoutInfo();

                if (allCheckouts.Any(i => i.materialID == processedMaterialId) == true)
                {
                    dbc.Renew(processedMaterialId);

                    // Clear textbox for next entry and provide feedback to user
                    txt_ReturnRenew.Text = "";
                    MessageBox.Show("Material renewed!");
                }
                else
                {
                    MessageBox.Show("Error: Item is not checked out");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Please enter a numeric value for the item you wish to renew");
            }
        
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
