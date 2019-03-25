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
    }
}
