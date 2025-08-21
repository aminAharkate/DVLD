using DVLD_DesktopClient.Test;
using DVLD_DesktopClient.Test.Test_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicesnseApplications : Form
    {

        private List<clsLocalDrivingLicenseApplications_ViewDTO> _dtAllLocalDrivingLicenseApplications;
        clsLocalDrivingLicenseApplicationDTO _LDLADTO;
        clsApplicationDTO _ADTO;
        clsLocalDrivingLicenseApplicationAsync clsLocalDrivingLicenseApplicationAsync;
        //private DataTable _dtAllLocalDrivingLicenseApplications;

        public frmListLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }
        #region convert 1 DTO To 2 DTO
        public void convert(clsLocalDrivingLicenseApplicationDTO2 dto)
        {
            //_LDLADTO.LocalDrivingLicenseApplicationID = dto.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID;
            //_LDLADTO.ApplicationID = dto.LocalDrivingLicenseApplicationDTO.ApplicationID;
            //_LDLADTO.LicenseClassID = dto.LocalDrivingLicenseApplicationDTO.LicenseClassID;


            //_ADTO.ApplicantPersonID = dto.ApplicationDTO.ApplicantPersonID;
            //_ADTO.ApplicationDate = dto.ApplicationDTO.ApplicationDate;
            //_ADTO.ApplicationTypeID = dto.ApplicationDTO.ApplicationTypeID;
            //_ADTO.ApplicationStatus = dto.ApplicationDTO.ApplicationStatus;
            //_ADTO.LastStatusDate = dto.ApplicationDTO.LastStatusDate;
            //_ADTO.PaidFees = dto.ApplicationDTO.PaidFees;
            //_ADTO.CreatedByUserID = dto.ApplicationDTO.CreatedByUserID;
            _LDLADTO = new clsLocalDrivingLicenseApplicationDTO
            (
                dto.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID,
                dto.LocalDrivingLicenseApplicationDTO.ApplicationID,
                dto.LocalDrivingLicenseApplicationDTO.LicenseClassID
            );
            _ADTO = new clsApplicationDTO
            (
                dto.ApplicationDTO.ApplicationID,
                dto.ApplicationDTO.ApplicantPersonID,
                dto.ApplicationDTO.ApplicationDate,
                dto.ApplicationDTO.ApplicationTypeID,
                dto.ApplicationDTO.ApplicationStatus,
                dto.ApplicationDTO.LastStatusDate,
                dto.ApplicationDTO.PaidFees,
                dto.ApplicationDTO.CreatedByUserID
            );

        }
        #endregion

        #region CMS_ContextMenuStrip
        private async void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            //var DTO = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID
            //                                        (LocalDrivingLicenseApplicationID);
            //convert(DTO);

            //int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            //bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            ////Enabled only if person passed all tests and Does not have license. 
            //issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            //showLicenseToolStripMenuItem.Enabled = LicenseExists;
            //editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            //ScheduleTestsMenue.Enabled = !LicenseExists;

            ////Enable/Disable Cancel Menue Item
            ////We only canel the applications with status=new.
            //CancelApplicaitonToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            ////Enable/Disable Delete Menue Item
            ////We only allow delete incase the application status is new not complete or Cancelled.
            //DeleteApplicationToolStripMenuItem.Enabled =
            //    (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);



            ////Enable Disable Schedule menue and it's sub menue
            //bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
            //bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            //bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            //ScheduleTestsMenue.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //if (ScheduleTestsMenue.Enabled)
            //{
            //    //To Allow Schdule vision test, Person must not passed the same test before.
            //    scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

            //    //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
            //    scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

            //    //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
            //    scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            //}
        }
        
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalDrivingLicesnseApplication frm =
                         new frmAddUpdateLocalDrivingLicesnseApplication(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            var DTO = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (DTO == null)
            {
                MessageBox.Show("Application not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            //convert(DTO);
            var LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicationAsync(_LDLADTO, _ADTO, GlobalClasses.clsGlobalSetting.EnMode.Add);

            if (LocalDrivingLicenseApplication != null)
            {
                if (await LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            ////var DTO = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            //convert(DTO);
            //var LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicationAsync(_LDLADTO, _ADTO, GlobalClasses.clsGlobalSetting.EnMode.Add);

            //if (LocalDrivingLicenseApplication != null)
            //{
            //    if (await LocalDrivingLicenseApplication.Cancel())
            //    {
            //        MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //refresh the form again.
            //        frmListLocalDrivingLicesnseApplications_Load(null, null);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }
        //private void _ScheduleTest(clsTestType.enTestType TestType)
        //{

        //    int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
        //    frmListTestAppointments frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, TestType);
        //    frm.ShowDialog();
        //    //refresh
        //    frmListLocalDrivingLicesnseApplications_Load(null, null);

        //}
        private void _ScheduleTest(clsTestTypeAsync.enTestType TestType)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmListTestAppointments frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, TestType);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);

        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest((clsTestTypeAsync.enTestType)6);
            //frmScheduleTest frm  = new frmScheduleTest(2052, (clsTestTypeAsync.enTestType)1, 6);
            //frm.ShowDialog();
            //_ScheduleTest(clsTestType.enTestType.VisionTest);


            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            //clsTestAppointment Appointment =
            //    clsTestAppointment.GetLastTestAppointment(LocalDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest);

            //if (Appointment == null)
            //{
            //    MessageBox.Show("No Vision Test Appointment Found!", "Set Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //frmTakeTest frm = new frmTakeTest(Appointment.TestAppointmentID, clsTestType.enTestType.VisionTest);
            //frm.ShowDialog();
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;


            //if (!clsLocalDrivingLicenseApplication.DoesPassTestType(LocalDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest))
            //{
            //    MessageBox.Show("Person Should Pass the Vision Test First!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //clsTestAppointment Appointment =
            //   clsTestAppointment.GetLastTestAppointment(LocalDrivingLicenseApplicationID, clsTestType.enTestType.WrittenTest);


            //if (Appointment == null)
            //{
            //    MessageBox.Show("No Written Test Appointment Found!", "Set Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //frmTakeTest frm = new frmTakeTest(Appointment.TestAppointmentID, clsTestType.enTestType.WrittenTest);
            //frm.ShowDialog();
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            //if (!clsLocalDrivingLicenseApplication.DoesPassTestType(LocalDrivingLicenseApplicationID, clsTestType.enTestType.WrittenTest))
            //{
            //    MessageBox.Show("Person Should Pass the Written Test First!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //clsTestAppointment Appointment =
            // clsTestAppointment.GetLastTestAppointment(LocalDrivingLicenseApplicationID, clsTestType.enTestType.StreetTest);


            //if (Appointment == null)
            //{
            //    MessageBox.Show("No Street Test Appointment Found!", "Set Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //frmTakeTest frm = new frmTakeTest(Appointment.TestAppointmentID, clsTestType.enTestType.StreetTest);
            //frm.ShowDialog();
        }
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            //frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(LocalDrivingLicenseApplicationID);
            //frm.ShowDialog();
            ////refresh
            //frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            //int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
            //   LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            //if (LicenseID != -1)
            //{
            //    frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            //    frm.ShowDialog();

            //}
            //else
            //{
            //    MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            //clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            //frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);
            //frm.ShowDialog();
        }

        #endregion


        #region Load Data
        private async void LoadData()
        {

            _dtAllLocalDrivingLicenseApplications = await clsLocalDrivingLicenseApplicationAsync.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {

                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 70;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 200;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National ID";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 100;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 100;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 100;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 90;
            }

            cbFilterBy.SelectedIndex = 0;
        }
        private void frmListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
            LoadData();


        }
        #endregion

        private void txtFilterValue1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                //_dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }


            //if (FilterColumn == "LocalDrivingLicenseApplicationID")
            //    //in this case we deal with integer not string.
            //    _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            //else
            //    _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            //lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue1.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue1.Visible)
            {
                txtFilterValue1.Text = "";
                txtFilterValue1.Focus();
            }

            //_dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();



        }

        private void txtFilterValue1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase L.D.L.AppID id is selected.
            if (cbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication(-1);
            //frm.Location = new Point(200, 44);
            //frm.Location = this.Location;
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
