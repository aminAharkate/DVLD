using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.Test.Test_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Test
{
    public partial class frmTakeTest : Form
    {

        private int _AppointmentID;
        private clsTestTypeAsync.enTestType _TestType;

        private int _TestID = -1;
        private clsTestsAsync _Test;
        private clsDTOs.clsTestDTO _clsTestDTO;
        public frmTakeTest(int AppointmentID, clsTestTypeAsync.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }

        private async void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID = _TestType;

            ctrlSecheduledTest1.LoadInfo(_AppointmentID);

            if (ctrlSecheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;


            int _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1)
            {
                _clsTestDTO = await  clsTestsAsync.FindAsync(_TestID);
                _Test = new clsTestsAsync(_clsTestDTO);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;
                txtNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }

            //else
                //_Test = new clsTest();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
            )
            {
                return;
            }

            //_Test.TestAppointmentID = _AppointmentID;
            //_Test.TestResult = rbPass.Checked;
            //_Test.Notes = txtNotes.Text.Trim();
            //_Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Test = new clsTestsAsync( new clsTestDTO
            (
                -1,
                _AppointmentID,
                this.rbPass.Checked,
                string.IsNullOrWhiteSpace(txtNotes.Text) ? null : this.txtNotes.Text.Trim(),
                clsGlobalUser.CurrentUser.userID
            ));
            

            if (await  _Test.SaveAsync())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
