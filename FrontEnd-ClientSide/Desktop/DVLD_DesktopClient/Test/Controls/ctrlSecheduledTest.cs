using DVLD_DesktopClient.Applications.Local_Driving_License;
using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.People;
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

namespace DVLD_DesktopClient.Test.Controls
{
    public partial class ctrlSecheduledTest : UserControl
    {
        private clsTestTypeAsync.enTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingLicenseApplicationAsync _LocalDrivingLicenseApplication;

        public clsTestTypeAsync.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestTypeAsync.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            //pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypeAsync   .enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            //pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypeAsync.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            //pbTestTypeImage.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointmentAsync _TestAppointment;

        public async void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;


           var _TestAppointment = await clsTestAppointmentAsync.Find(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestAppointmentID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            var _LocalDrivingLicenseApplication = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID.ToString();
            //var obk = await clsLicenseClassAsync.Find(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationDTO.LicenseClassID);
            //lblDrivingClass.Text = obk.ClassName;
            //var obj = await clsPersonAsync.GetPersonByIDAsync(_LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID);
            //lblFullName.Text = obj.FirstName + " " + obj.LastName;


            ////this will show the trials for this test before
            //lblTrial.Text = await clsLocalDrivingLicenseApplicationAsync.TotalTrialsPerTest(_TestTypeID).ToString();



            lblDate.Text = clsUtility.DateToShortFormat(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestAppointmentID == -1) ? "Not Taken Yet" : _TestAppointment.TestAppointmentID.ToString();



        }

        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
