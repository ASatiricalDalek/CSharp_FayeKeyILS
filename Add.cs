﻿using System;
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
            List<Patron> modifyPatronIDs = new List<Patron>();

            removePatronIDs = dbc.GetPatronID();
            modifyPatronIDs = dbc.GetFullPatronInfo();

            cmb_RemovePatronSelector.DataSource = removePatronIDs;
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
            cmb_UpdateLibraryID.DisplayMember = "Id";
        }

        private void cmb_UpdateLibraryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populate fields related to selected Id in cmb_UpdateLibraryId
            Patron selectedPatron = (Patron)cmb_UpdateLibraryID.SelectedItem;
            txt_UpdateFName.Text = selectedPatron.patronFirstName.ToString();
            txt_UpdateLName.Text = selectedPatron.patronLastName.ToString();
            if (selectedPatron.patronEmail == null)
            {
                txt_UpdateEmail.Text = "";
            }
            else
            {
                txt_UpdateEmail.Text = selectedPatron.patronEmail.ToString();
            }
            if (selectedPatron.patronPhone == null)
            {
                txt_UpdatePhone.Text = "";
            }
            else
            {
                txt_UpdatePhone.Text = selectedPatron.patronPhone.ToString();
            }
            
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
            List<Patron> modifyPatronIDs = new List<Patron>();
            removePatronIDs = dbc.GetPatronID(); //              **
            modifyPatronIDs = dbc.GetFullPatronInfo();
            cmb_RemovePatronSelector.DataSource = removePatronIDs; //reload combo box
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
            cmb_RemovePatronSelector.SelectedIndex = 0;  //select first member of combo box
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;

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
            List<Patron> modifyPatronIDs = new List<Patron>();
            removePatronIDs = dbc.GetPatronID(); //              **
            modifyPatronIDs = dbc.GetFullPatronInfo();
            cmb_RemovePatronSelector.DataSource = removePatronIDs; //reload combo box
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
            cmb_RemovePatronSelector.SelectedIndex = 0;  //select first member of combo box
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
        }

        private void btn_UpdatePatron_Click(object sender, EventArgs e)
        {
            Patron selectedPatron = (Patron)cmb_UpdateLibraryID.SelectedItem;
            string fName = txt_UpdateFName.Text; //get first name
            string lName = txt_UpdateLName.Text; //get last name
            string email = txt_UpdateEmail.Text; //get email
            string phone = txt_UpdatePhone.Text; //get phone
            dbc.updatePatron(selectedPatron.Id, fName, lName, email, phone);
            MessageBox.Show("Update information for " + fName + " " + lName + " was successful!");

            List<Patron> modifyPatronIDs = new List<Patron>();
            modifyPatronIDs = dbc.GetFullPatronInfo();
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
            cmb_UpdateLibraryID.DataSource = modifyPatronIDs;
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            Form viewPatron = new Views();
            viewPatron.Show();
        }
    }
}
