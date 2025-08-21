using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Applications.ApplicationTypes
{
    public partial class frmListApplicationTypes : Form
    {
        #region properties + constructor 
        private int _ApplicationTypeID = 0;

        public frmListApplicationTypes()
        {
            InitializeComponent();
            gbUpdateApplicationType.Enabled = false;
        }
        #endregion

        #region button close click event
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region load application types data 

        private async void frmListApplicationTypes_Load(object sender, EventArgs e)
        {

            dgvApplicationTypes.DataSource = await clsApplicationTypeAsync.GetAllApplicationTypesAsync();
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();

            dgvApplicationTypes.Columns[0].HeaderText = "Application Type ID";
            dgvApplicationTypes.Columns[0].Width = 210;

            dgvApplicationTypes.Columns[1].HeaderText = "Application Type Title";
            dgvApplicationTypes.Columns[1].Width = 480;

            dgvApplicationTypes.Columns[2].HeaderText = "Application Type Fees";
            dgvApplicationTypes.Columns[2].Width = 150;
        }
        private void enabledApplicationType()
        {
            gbUpdateApplicationType.Enabled = true;
            _ApplicationTypeID = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
            lblID.Text = dgvApplicationTypes.CurrentRow.Cells[0].Value.ToString();
            txtTitle.Text = dgvApplicationTypes.CurrentRow.Cells[1].Value.ToString();
            txtFees.Text = dgvApplicationTypes.CurrentRow.Cells[2].Value.ToString();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledApplicationType();
            frmListApplicationTypes_Load(null, null);
        }
        #endregion

       

        #region button save click event

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
               // e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            ;

        }
        private void textFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtFees.Text))
            {
               // e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            clsDTOs.clsApplicationTypeDTO _ApplicationType = new clsDTOs.clsApplicationTypeDTO(_ApplicationTypeID, txtTitle.Text.Trim(), Convert.ToSingle(txtFees.Text.Trim()));



            if (await clsApplicationTypeAsync.UpdateApplicationTypeAsync(_ApplicationTypeID, _ApplicationType))
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            frmListApplicationTypes_Load(null, null);
        }
        #endregion

        
    }
}
