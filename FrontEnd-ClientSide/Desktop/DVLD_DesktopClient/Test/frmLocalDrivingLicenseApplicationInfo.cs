using DVLD_DesktopClient.Applications;
using DVLD_DesktopClient.Applications.Local_Driving_License;
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
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypeAsync.enTestType _TestType = clsTestTypeAsync.enTestType.VisionTest;
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypeAsync.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        //pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestTypeAsync.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        //pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestTypeAsync.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        // pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }
        private async void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();


            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            var obj = await clsTestAppointmentAsync.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvLicenseTestAppointments.DataSource = obj;
            lblRecordsCount.Text = dgvLicenseTestAppointments.Rows.Count.ToString();

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            var obj = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            //clsLocalDrivingLicenseApplicationAsync obj = new clsLocalDrivingLicenseApplicationAsync(localDrivingLicenseApplication);
            //if (await clsLocalDrivingLicenseApplicationAsync.IsThereAnActiveScheduledTest(obj.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID, _TestType))
            //{
            //    MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}



            
            //var LastTestDTO = await clsLocalDrivingLicenseApplicationAsync.GetLastTestPerTestType(
            //    obj.ApplicationDTO.ApplicantPersonID,
            //    obj.LocalDrivingLicenseApplicationDTO.LicenseClassID,
            //    _TestType);

            //if (LastTestDTO == null)
            //{
            //    frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            //    frm1.ShowDialog();
            //    frmListTestAppointments_Load(null, null);
            //    return;
            //}

            ////if person already passed the test s/he cannot retak it.
            //if (LastTestDTO.TestResult == true)
            //{
            //    MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //var apointment = await clsTestAppointmentAsync.Find(LastTestDTO.TestAppointmentID);
            //frmScheduleTest frm2 = new frmScheduleTest
            //    (apointment.LocalDrivingLicenseApplicationID, _TestType);
            //frm2.ShowDialog();
            frmListTestAppointments_Load(null, null);

        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;


            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void takeTEstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }
    }
}
