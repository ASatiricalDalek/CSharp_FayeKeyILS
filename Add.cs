using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FayeKeyILS
{
    public partial class Add : Form
    {
        DatabaseConnector dbc = new DatabaseConnector();
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            List<long> removePatronIDs = new List<long>();
            List<long> modifyPatronIDs = new List<long>();

            removePatronIDs = dbc.GetPatronID();
            modifyPatronIDs = dbc.GetPatronID();

            cmb_RemovePatronSelector.DataSource = removePatronIDs;
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
        }

        private void cmb_UpdateLibraryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Grab all the info for all the patrons in a list, then split it out based on the selected index from the combo box
            List<Patron> allPatrons = new List<Patron>();
            int selectedPatronID = int.Parse(cmb_UpdateLibraryID.Text);

            allPatrons = dbc.GetFullPatronInfo();
            // -1 because the database starts at 1 where the index of the combo box starts at 0
            txt_UpdateFName.Text = allPatrons[selectedPatronID - 1].patronFirstName;
            txt_UpdateLName.Text = allPatrons[selectedPatronID - 1].patronLastName;
            txt_UpdateEmail.Text = allPatrons[selectedPatronID - 1].patronEmail;
            txt_UpdatePhone.Text = allPatrons[selectedPatronID - 1].patronPhone;

        }

        private void btn_AddPatron_Click(object sender, EventArgs e)
        {
            string fName = txtFNameAdd.Text; //get first name
            string lName = txtLNameAdd.Text; //get last name
            string email = txtEmailAdd.Text; //get email
            string phone = txtPhoneAdd.Text; //get phone
            dbc.addPatron(fName, lName, email, phone); //add to db
            MessageBox.Show("Patron: "+fName+" "+lName+" was added!"); //success message
            List<long> removePatronIDs = new List<long>(); //repopulate combo box list
            removePatronIDs = dbc.GetPatronID(); //            **
            cmb_RemovePatronSelector.DataSource = removePatronIDs; //reload combo box
            txtFNameAdd.Text = ""; // reset these fields to empty string
            txtLNameAdd.Text = "";
            txtPhoneAdd.Text = "";
            txtEmailAdd.Text = "";
        }

        private void btn_RemovePatron_Click(object sender, EventArgs e)
        {           
            string id = cmb_RemovePatronSelector.SelectedValue.ToString(); //get selected id
            dbc.removePatron(Convert.ToInt64(id)); //remove patron
            MessageBox.Show("Patron with ID: " + id + " was successfully removed!"); //success message
            List<long> removePatronIDs = new List<long>(); //repopulate combo box list
            removePatronIDs = dbc.GetPatronID(); //              **
            cmb_RemovePatronSelector.DataSource = removePatronIDs; //reload combo box
            cmb_RemovePatronSelector.SelectedIndex = 0;  //select first member of combo box
            
        }
    }
}
