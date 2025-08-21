using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.People;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DesktopClient.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        clsDTOs.clsApplicationDTO _ApplicationDTO;
        private clsApplicationAsync _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public async void LoadApplicationInfo(int ApplicationID)
        {
            _ApplicationDTO = await clsApplicationAsync.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }
        public async void LoadApplicationInfo(clsApplicationDTO obj)
        {
                _ApplicationDTO = obj;
                _FillApplicationInfo();
        }
        private async void _FillApplicationInfo()
        {
            _Application = new clsApplicationAsync(_ApplicationDTO, clsGlobalSetting.EnMode.Edit);
            _ApplicationID = _ApplicationDTO.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;

            //var ApplicationTypeTitle = await _Application.ApplicationTypeInfo;
            //  lblType.Text = ApplicationTypeTitle.ApplicationTypeTitle;
            //lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblType.Text = "unknow";
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.PersonFullName;
            lblDate.Text = clsUtility.DateToShortFormat(_Application.ApplicationDate);
            lblStatusDate.Text = clsUtility.DateToShortFormat(_Application.LastStatusDate);
           // var CreatedByUserInfo = await _Application.CreatedByUserInfo;
            //lblCreatedByUser.Text = CreatedByUserInfo.userName;
            lblCreatedByUser.Text = clsGlobalUser.CurrentUser.userName;

        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();

            //Refresh
            LoadApplicationInfo(_ApplicationID);
        }

        
    }
}
