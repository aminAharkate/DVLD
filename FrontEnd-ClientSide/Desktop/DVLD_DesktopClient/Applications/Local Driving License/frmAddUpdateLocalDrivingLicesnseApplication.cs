using DVLD_DesktopClient.Applications.ApplicationTypes;
using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.People.Controles;
using DVLD_DesktopClient.Users;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {


        private GlobalClasses.clsGlobalSetting.EnMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        public clsLocalDrivingLicenseApplicationDTO localDrivingLicenseApplicationDTO;
        public clsApplicationDTO applicationDTO;
       
        clsLocalDrivingLicenseApplicationDTO2 _LocalDrivingLicenseApplication;
        clsLocalDrivingLicenseApplicationAsync _LocalDrivingLicenseApplicationAsync;

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._Mode = (LocalDrivingLicenseApplicationID == -1) ? GlobalClasses.clsGlobalSetting.EnMode.Add : GlobalClasses.clsGlobalSetting.EnMode.Edit;
        }
        private async Task _FillLicenseClassesInComoboBox()
        {
           // List<clsLocalDrivingLicenseApplications_ViewDTO> lstLocalDrivingLicenseApplications = await clsLocalDrivingLicenseApplicationAsync.GetAllLocalDrivingLicenseApplicationsAsync();
            //var lstLocalDrivingLicenseApplications = await clsLocalDrivingLicenseApplicationAsync.GetAllLocalDrivingLicenseApplicationsAsync();
           // DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();
            List<clsLicenseClassDTO> list = await clsLicenseClassAsync.GetAllLicenseClasses();
            foreach (var item in list)
            {
                //cbLicenseClass.Items.Add(new clsLicenseClassDTO(item.LicenseClassID, item.LicenseClassTitle, item.LicenseClassDescription, item.LicenseClassFees));
                cbLicenseClass.Items.Add(item.ClassName.ToString());

            }
            if (cbLicenseClass.Items.Count > 0)
            {
                cbLicenseClass.SelectedIndex = 0;
            }
        }
        private async Task _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            await _FillLicenseClassesInComoboBox();


            if (_Mode == GlobalClasses.clsGlobalSetting.EnMode.Add)
            {

                lblChangeMode.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                
                ctrlPersonCardWithFilter2.FilterFocus();
                tcApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                var result = await clsApplicationTypeAsync.GetApplicationTypeByIDAsync((int)clsApplicationAsync.enApplicationType.NewDrivingLicense);
                lblFees.Text = result.ApplicationTypeFees.ToString();
                
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobalUser.CurrentUser.userName;
            }
            else
            {
                lblChangeMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tcApplicationInfo.Enabled = true;
                btnSave.Enabled = true;


            }

        }

        private async void _LoadData()
        {

            ctrlPersonCardWithFilter2.FilterEnabled = false;
            //_LocalDrivingLicenseApplication = await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            
            var obj1= await clsLocalDrivingLicenseApplicationAsync.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter2.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID);
            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsUtility.DateToShortFormat(_LocalDrivingLicenseApplication.ApplicationDTO.ApplicationDate);
            clsLicenseClassDTO result = await clsLicenseClassAsync.Find(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationDTO.LicenseClassID);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(result.ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.ApplicationDTO.PaidFees.ToString();
            clsDTOs.clsUserDTO dto = await clsUsersAsync.GetUserInfoByUserIDAsync(_LocalDrivingLicenseApplication.ApplicationDTO.CreatedByUserID);
            lblCreatedByUser.Text = dto.userName;

        }
        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter2.LoadPersonInfo(PersonID);


        }


        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == GlobalClasses.clsGlobalSetting.EnMode.Edit)
            {
                _LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == GlobalClasses.clsGlobalSetting.EnMode.Edit)
            {
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
                tControl1.SelectedTab = tControl1.TabPages["tcApplicationInfo"]; // Corrected TabPage name
                return;
            }

            // In case of add new mode.
            if (ctrlPersonCardWithFilter2.PersonID != -1)
            {
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
                tControl1.SelectedTab = tControl1.TabPages["tcApplicationInfo"]; // Corrected TabPage name
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter2.FilterFocus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            int selectedIndex = cbLicenseClass.SelectedIndex;
            var LCdto = await clsLicenseClassAsync.Find(++selectedIndex);
            int LicenseClassID = LCdto.LicenseClassID;

            //work on later
            //int ActiveApplicationID = await clsApplicationAsync.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplicationAsync.enApplicationType.NewDrivingLicense, LicenseClassID);

            //if (ActiveApplicationID != -1)
            //{
            //    MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbLicenseClass.Focus();
            //    return;
            //}

            
            applicationDTO = new clsApplicationDTO(
                                                    -1,
                                                    ctrlPersonCardWithFilter2.PersonID,
                                                    DateTime.Now,
                                                    1,
                                                    clsApplicationAsync.enApplicationStatus.New,
                                                    DateTime.Now,
                                                    Convert.ToSingle(lblFees.Text),
                                                    clsGlobalUser.CurrentUser.userID);

            localDrivingLicenseApplicationDTO = new clsLocalDrivingLicenseApplicationDTO(-1, applicationDTO.ApplicationID, LicenseClassID);

            _LocalDrivingLicenseApplicationAsync = new clsLocalDrivingLicenseApplicationAsync(this.localDrivingLicenseApplicationDTO, this.applicationDTO, this._Mode);
            if (await _LocalDrivingLicenseApplicationAsync.Save())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplicationAsync.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = clsGlobalSetting.EnMode.Edit;
                lblChangeMode.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
