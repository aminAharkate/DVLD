using DVLD_DesktopClient.Applications;
using DVLD_DesktopClient.Applications.ApplicationTypes;
using DVLD_DesktopClient.Applications.Local_Driving_License;
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
using static DVLD_DesktopClient.Applications.clsApplicationAsync;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;
using static DVLD_DesktopClient.Test.Test_Types.clsTestTypeAsync;

namespace DVLD_DesktopClient.Test.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {

        private clsGlobalSetting.EnMode _Mode = clsGlobalSetting.EnMode.Add;
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;
        private clsTestTypeAsync.enTestType _TestTypeID = clsTestTypeAsync.enTestType.VisionTest;
        private clsLocalDrivingLicenseApplicationAsync _LocalDrivingLicenseApplication;
        clsDTOs.clsLocalDrivingLicenseApplicationDTO2 _DTO2;
        clsLocalDrivingLicenseApplicationDTO localDrivingLicenseApplicationDTO;
        clsApplicationDTO applicationDTO;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointmentDTO _TestAppointmentDTO;
        private clsTestAppointmentAsync _TestAppointment;
        private int _TestAppointmentID = -1; 
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

                    case clsTestTypeAsync.enTestType.WrittenTest:
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


        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        public async void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = clsGlobalSetting.EnMode.Add;
            else
                _Mode = clsGlobalSetting.EnMode.Add;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            //_DTO2 = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            var obj3 = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_DTO2 == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            clsLocalDrivingLicenseApplicationAsync.convert1To2(_DTO2, this.localDrivingLicenseApplicationDTO, this.applicationDTO);
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicationAsync(this.localDrivingLicenseApplicationDTO, this.applicationDTO, _Mode);
            //decide if the createion mode is retake test or not based if the person attended this test before
            if (await _LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))

                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                var obj = await clsApplicationTypeAsync.Find((int)clsApplicationAsync.enApplicationType.RetakeTest);
                lblRetakeAppFees.Text = obj.ApplicationTypeFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            var classInfo = await clsApplicationTypeAsync.Find(_LocalDrivingLicenseApplication.LicenseClassID);
            lblDrivingClass.Text = classInfo.ApplicationTypeFees.ToString();
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;

            //this will show the trials for this test before
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();


            if (_Mode == clsGlobalSetting.EnMode.Add)
            {
                var obj = await clsTestTypeAsync.Find((int)_TestTypeID);
                lblFees.Text = obj.TestTypeFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                //_TestAppointment = new clsTestAppointment();
            }

            else
            {

                if (!await _LoadTestAppointmentData())
                    return;
            }


            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();


            if (!await _HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!await _HandlePrviousTestConstraint())
                return;



        }
        private async Task<bool> _HandleActiveTestAppointmentConstraint()
        {
            var obk = await clsLocalDrivingLicenseApplicationAsync.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
            if (_Mode == clsGlobalSetting.EnMode.Add && obk)
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        private async Task<bool> _LoadTestAppointmentData()
        {
            _TestAppointmentDTO = await clsTestAppointmentAsync.Find(_TestAppointmentID);
            _TestAppointment = new clsTestAppointmentAsync(_TestAppointmentDTO);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                var obj = await _TestAppointment.RetakeTestAppInfo;
                lblRetakeAppFees.Text = obj.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblUserMessage.Visible = false;

            return true;
        }
        private async Task<bool> _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestTypeAsync.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lblUserMessage.Visible = false;

                    return true;
                case clsTestTypeAsync.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!await _LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypeAsync.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case clsTestTypeAsync.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!await _LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypeAsync.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private async Task<bool> _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == clsGlobalSetting.EnMode.Add && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 

                int ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                DateTime ApplicationDate = DateTime.Now;
                int ApplicationTypeID = (int)clsApplicationAsync.enApplicationType.RetakeTest;
                int ApplicationStatus = (int)clsApplicationAsync.enApplicationStatus.Completed;
                DateTime LastStatusDate = DateTime.Now;
                var obj = await clsApplicationTypeAsync.Find((int)clsApplicationAsync.enApplicationType.RetakeTest);
                float PaidFees = obj.ApplicationTypeFees;
                int CreatedByUserID = clsGlobalUser.CurrentUser.userID;

                clsApplicationAsync Application = new clsApplicationAsync(
                    new clsApplicationDTO(-1, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, (float)PaidFees, CreatedByUserID
                        ), _Mode);
                if (!await Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!await _HandleRetakeApplication())
                return;
            _TestAppointmentDTO = new clsTestAppointmentDTO(_TestAppointmentID, (int)_TestTypeID, _LocalDrivingLicenseApplicationID, dtpTestDate.Value, Convert.ToDecimal(lblFees.Text), clsGlobalUser.CurrentUser.userID, false, _TestAppointment.RetakeTestApplicationID);
            //_TestAppointment.TestTypeID = _TestTypeID;
            //_TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            //_TestAppointment.AppointmentDate = dtpTestDate.Value;
            //_TestAppointment.PaidFees = Convert.ToDecimal( lblFees.Text);
            //_TestAppointment.CreatedByUserID = clsGlobalUser.CurrentUser.userID;
            _TestAppointment = new clsTestAppointmentAsync(_TestAppointmentDTO);

            if (await _TestAppointment.Save())
            {
                _Mode = clsGlobalSetting.EnMode.Edit;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
