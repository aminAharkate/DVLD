//using DVLD_DesktopClient.GlobalClasses;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

//namespace DVLD_DesktopClient.Applications.Local_Driving_License
//{
//    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
//    {
//        public ctrlDrivingLicenseApplicationInfo()
//        {
//            InitializeComponent();
//        }
//        private clsLocalDrivingLicenseApplicationAsync _LocalDrivingLicenseApplication;
//        clsDTOs.clsLocalDrivingLicenseApplicationDTO2 _LocalDrivingLicenseApplicationDTO;
//        clsLocalDrivingLicenseApplicationDTO _LDLADTO;
//        clsApplicationDTO _clsApplicationDTO;

//        private int _LocalDrivingLicenseApplicationID = -1;

//        private int _LicenseID;

//        public int LocalDrivingLicenseApplicationID
//        {
//            get { return _LocalDrivingLicenseApplicationID; }
//        }



//        public async  void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
//        {
//            //_LocalDrivingLicenseApplicationDTO = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
//            var obj2 = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
//            if (_LocalDrivingLicenseApplicationDTO == null)
//            {
//                _ResetLocalDrivingLicenseApplicationInfo();


//                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//            if (_LDLADTO == null)
//            {
//                _ResetLocalDrivingLicenseApplicationInfo();


//                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
//            _clsApplicationDTO = await clsApplicationAsync.FindBaseApplication(_LDLADTO.ApplicationID);

//            _FillLocalDrivingLicenseApplicationInfo();
//        }
//        // find only by  LocalDrivingAppID
//        public async void LoadApplicationInfoByApplicationID(int ApplicationID)
//        {
//            _LocalDrivingLicenseApplicationDTO = await clsLocalDrivingLicenseApplicationAsync.FindByApplicationID(ApplicationID);
//            if (_LocalDrivingLicenseApplication == null)
//            {
//                _ResetLocalDrivingLicenseApplicationInfo();


//                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            _FillLocalDrivingLicenseApplicationInfo();
//        }

//        private async Task _FillLocalDrivingLicenseApplicationInfo()
//        {
//            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicationAsync(
//                                                    new clsDTOs.clsLocalDrivingLicenseApplicationDTO(
//                                                        _LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID,
//                                                        _LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationDTO.ApplicationID,
//                                                        _LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationDTO.LicenseClassID
//                                                        ),
//                                                    new clsDTOs.clsApplicationDTO(
//                                                        _LocalDrivingLicenseApplicationDTO.ApplicationDTO.ApplicationID,
//                                                        _LocalDrivingLicenseApplicationDTO.ApplicationDTO.ApplicantPersonID,
//                                                        _LocalDrivingLicenseApplicationDTO.ApplicationDTO.ApplicationDate,
//                                                        _LocalDrivingLicenseApplicationDTO.ApplicationDTO.ApplicationTypeID,
//                                                       _LocalDrivingLicenseApplicationDTO.ApplicationDTO.ApplicationStatus,
//                                                       _LocalDrivingLicenseApplicationDTO.ApplicationDTO.LastStatusDate,
//                                                        _LocalDrivingLicenseApplicationDTO.ApplicationDTO.PaidFees,
//                                                        _LocalDrivingLicenseApplicationDTO.ApplicationDTO.CreatedByUserID),
//                                                    clsGlobalSetting.EnMode.Edit);

//            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();


//            //incase there is license enable the show link.
//            llShowLicenceInfo.Enabled = (_LicenseID != -1);


//            lblLocalDrivingLicenseApplicationID.Text = _LDLADTO.LocalDrivingLicenseApplicationID.ToString();
//            var LicenseClass = await clsLicenseClassAsync.Find(_LDLADTO.LicenseClassID);
//            lblAppliedFor.Text = LicenseClass.ClassName;
//            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
//            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LDLADTO.ApplicationID);

//        }

//        private void _ResetLocalDrivingLicenseApplicationInfo()
//        {
//            _LocalDrivingLicenseApplicationID = -1;
//            ctrlApplicationBasicInfo1.ResetApplicationInfo();
//            lblLocalDrivingLicenseApplicationID.Text = "[????]";
//            lblAppliedFor.Text = "[????]";


//        }

//        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            //frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
//            //frm.ShowDialog();

//        }
//    }
//}
//****************************************************************************
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
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }


        private int _LocalDrivingLicenseApplicationID = -1;

        private int _LicenseID;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }



        public async Task LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            //_LocalDrivingLicenseApplicationDTO = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            var obj2 = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (obj2 == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var objall = await clsApplicationAsync.FindBaseApplication(obj2.ApplicationID);

            _FillLocalDrivingLicenseApplicationInfo(obj2, objall);
        }
        // find only by  LocalDrivingAppID
        public async void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            //_LocalDrivingLicenseApplicationDTO = await clsLocalDrivingLicenseApplicationAsync.FindByApplicationID(ApplicationID);
            //if (_LocalDrivingLicenseApplication == null)
            //{
            //    _ResetLocalDrivingLicenseApplicationInfo();


            //    MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //_FillLocalDrivingLicenseApplicationInfo();
        }

        private async Task _FillLocalDrivingLicenseApplicationInfo(clsLocalDrivingLicenseApplicationDTO obj, clsApplicationDTO obj1)
        {


            _LicenseID = await clsLocalDrivingLicenseApplicationAsync.GetActiveLicenseID(obj1.ApplicationID, obj.LicenseClassID);


            //incase there is license enable the show link.
            llShowLicenceInfo.Enabled = (_LicenseID != -1);


            lblLocalDrivingLicenseApplicationID.Text = obj.LocalDrivingLicenseApplicationID.ToString();
            var LicenseClass = await clsLicenseClassAsync.Find(obj.LicenseClassID);
            lblAppliedFor.Text = LicenseClass.ClassName;
            lblPassedTests.Text = clsLocalDrivingLicenseApplicationAsync.GetPassedTestCount(obj.LocalDrivingLicenseApplicationID).ToString() + "/3";
            //ctrlApplicationBasicInfo1.LoadApplicationInfo(obj1.ApplicationID);
            ctrlApplicationBasicInfo1.LoadApplicationInfo(obj1);
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";


        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            //frm.ShowDialog();

        }

        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
