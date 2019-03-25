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
    public partial class Views : Form
    {
        // Instance of the DatabaseConnector class we made
        DatabaseConnector dbc = new DatabaseConnector();
        public Views()
        {
            InitializeComponent();
        }

        private void Views_Load(object sender, EventArgs e)
        {
            List<string> patrons = new List<string>();

            // TODO: Create actual FullName property in the Patron object so it can be displayed everywhere, like here.
            patrons = dbc.GetPatronFirstName();
            // Populates listbox with patron info from DB
            lst_Patrons.DataSource = patrons;
        }

        private void lst_Patrons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Same principle as the update patron fields in Add.cs
            List<Patron> allPatrons = new List<Patron>();
            int selectedPatronID = lst_Patrons.SelectedIndex;

            allPatrons = dbc.GetFullPatronInfo();

            lbl_PatronID.Text = allPatrons[selectedPatronID].Id.ToString();
            lbl_Name.Text = allPatrons[selectedPatronID].patronFirstName + " " + allPatrons[selectedPatronID].patronLastName;
            lbl_email.Text = allPatrons[selectedPatronID].patronEmail;
            lbl_phone.Text = allPatrons[selectedPatronID].patronPhone;
        }
    }
}
