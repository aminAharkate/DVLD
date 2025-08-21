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

namespace DVLD_DesktopClient.Test.Test_Types
{
    public partial class frmListTestTypes : Form
    {
        clsDTOs.clsTestTypeDTO _TYDTO;
        public frmListTestTypes()
        {
            InitializeComponent();
            gbUpdateTestType.Enabled = false;
        }

        private async void frmListTestTypes_Load(object sender, EventArgs e)
        {
            //_dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = await clsTestTypeAsync.GetAllTestTypesAsync();
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();

            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 60;

            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 130;

            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 600;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 70;
        }
        #region Update Test Type
        private void updateTestTypeToolStripMenuItem()
        {

                gbUpdateTestType.Enabled = true;
                lblID.Text = dgvTestTypes.CurrentRow.Cells[0].Value.ToString();
                txtTitle.Text = dgvTestTypes.CurrentRow.Cells[1].Value.ToString();
                txtDescription.Text = dgvTestTypes.CurrentRow.Cells[2].Value.ToString();
                txtFees.Text = dgvTestTypes.CurrentRow.Cells[3].Value.ToString();

            

            



        }
        private void editeTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTestTypeToolStripMenuItem();
        }
        #endregion

        #region validate and update test type button click


        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
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
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
            ;
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
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
            _TYDTO = new clsDTOs.clsTestTypeDTO(
                 Convert.ToInt32(lblID.Text),
                 txtTitle.Text.Trim(),
                 txtDescription.Text.Trim(),
                 Convert.ToSingle(txtFees.Text.Trim())
             );
            //bool isupdate = await clsTestTypeAsync.UpdateTestTypeAsync(_TYDTO.TestTypeID, _TYDTO);

            //if (isupdate)
            //{
            //    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    frmListTestTypes_Load(null, null);

            //}
            //else
            //    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
