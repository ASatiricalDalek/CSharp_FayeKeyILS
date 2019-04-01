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
    public partial class MatAdd : Form
    {
        DatabaseConnector dbc = new DatabaseConnector();
        public MatAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads the initial content for the MatAdd form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MatAdd_Load(object sender, EventArgs e)
        {
            rebuildRemoveCombo();
            rebuildUpdateCombo();
            rebuildAddCombo();
            cmb_UpdateMatId.DisplayMember = "Id";
            cmb_AddMatType.DisplayMember = "Id";
        }
        /// <summary>
        /// Click to see a view of all materials currently in the material db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewData_Click(object sender, EventArgs e)
        {
            Form viewMaterials = new MatView();
            viewMaterials.Show();
        }
        /// <summary>
        /// Rebuilds cmb_UpdateMatId combo box when changes to the Materials db have been made
        /// </summary>
        private void rebuildUpdateCombo()
        {
            List<Material> modifyMatIDs = new List<Material>(); //repopulate update combo box list
            modifyMatIDs = dbc.GetFullMatInfo();
            cmb_UpdateMatId.DataSource = modifyMatIDs;
        }
        /// <summary>
        /// Rebuilds cmb_RemoveMatSelector combo box when changes to the Materials db have been made
        /// </summary>
        private void rebuildRemoveCombo()
        {
            List<long> removePatronIDs = new List<long>(); //repopulate remove combo box list
            removePatronIDs = dbc.GetMatID();
            cmb_RemoveMatSelector.DataSource = removePatronIDs;
        }
        /// <summary>
        /// Rebuilds cmb_AddMatType combo box when changes to the Materials db have been made
        /// </summary>
        private void rebuildAddCombo()
        {
            List<string> addMatType = new List<string>(); //repopulate remove combo box list
            addMatType = dbc.GetMatType();
            cmb_AddMatType.DataSource = addMatType;
        }
        /// <summary>
        /// Updates the fields related to updating a material when a selecting different material id
        /// from cmb_UpdateMatId combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_UpdateMatId_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> addMatType = new List<string>(); //repopulate update combo box list
            addMatType = dbc.GetMatType();
            cmb_UpdateMatType.DataSource = addMatType;

            Material selectedMat = (Material)cmb_UpdateMatId.SelectedItem;
            txt_UpdateMatTitle.Text = selectedMat.materialName.ToString();
            cmb_UpdateMatType.SelectedIndex = cmb_UpdateMatType.FindStringExact(selectedMat.materialType.ToString());
            
        }
        /// <summary>
        /// Clicking allows a new material to be added to the Materials table, provided a type and
        /// material name has been entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddMat_Click(object sender, EventArgs e)
        {
            string mtype = cmb_AddMatType.GetItemText(cmb_AddMatType.SelectedItem);
            string mname = txtMTitleA.Text;
            if (String.IsNullOrEmpty(mname) == false)
            {
                dbc.addMat(mtype, mname);
                MessageBox.Show("Material: " + mname + " was Added!");
            }
            else
            {
                MessageBox.Show("Please check that 'Material Title' field is not empty.");
            }
            
            rebuildRemoveCombo();
            rebuildUpdateCombo();
        }
        /// <summary>
        /// Clicking will remove the material whose id is selected in cmb_RemoveMatSelector combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RemoveMat_Click(object sender, EventArgs e)
        {
            string id = cmb_RemoveMatSelector.SelectedValue.ToString(); //get selected id
            dbc.removeMat(Convert.ToInt64(id)); //remove patron
            MessageBox.Show("Material with ID: " + id + " was successfully removed!"); //success message
            rebuildRemoveCombo();
            rebuildUpdateCombo();
        }
        /// <summary>
        /// Clicking will update the information for the material whose id is selected in cmb_UpdateMatId
        /// provided a material type and material name has been entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateMat_Click(object sender, EventArgs e)
        {
            Material selectedMaterial = (Material)cmb_UpdateMatId.SelectedItem;
            string matTitle = txt_UpdateMatTitle.Text;
            string matType = cmb_UpdateMatType.GetItemText(cmb_UpdateMatType.SelectedItem);

            if (String.IsNullOrEmpty(matTitle) == false)
            {
                dbc.updateMaterial(selectedMaterial.Id, matTitle, matType);
                MessageBox.Show("Material: " + matTitle + " was Added!");
            }
            else
            {
                MessageBox.Show("Please check that 'Material Title' field is not empty.");
            }
            rebuildRemoveCombo();
            rebuildUpdateCombo();
        }
    }
}
