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
    public partial class MatView : Form
    {
        DatabaseConnector dbc = new DatabaseConnector();
        public MatView()
        {
            InitializeComponent();
        }

        private void MatView_Load(object sender, EventArgs e)
        {
            List<Material> patrons = new List<Material>();

            // TODO: Create actual FullName property in the Patron object so it can be displayed everywhere, like here.
            patrons = dbc.GetFullMatInfo();
            // Populates listbox with patron info from DB
            lst_Mat.DataSource = patrons;
            lst_Mat.DisplayMember = "patronFirstName";
        }

        private void lst_Mat_Format(object sender, ListControlConvertEventArgs e)
        {
            //Somehow updates list to display first name and last name SmileyFace
            string Id = ((Material)e.ListItem).Id.ToString();
            string patId = ((Material)e.ListItem).patronLibraryID.ToString();
            string mType = ((Material)e.ListItem).materialType.ToString();
            string matLoan = ((Material)e.ListItem).materialLoanLength.ToString();
            string matName = ((Material)e.ListItem).materialName.ToString();
            if (String.IsNullOrEmpty(patId) == true)
            {
                patId = "null";
            }
            e.Value = "ID: "+Id + " | Material Type: " + mType + " | Material Name: " + matName + " | Loan Length: " + matLoan + " | Checked Out By Patron: " + patId;
        }
    }
}
