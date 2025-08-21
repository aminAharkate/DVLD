using DVLD_DesktopClient.GlobalClasses;
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
using System.Xml.Linq;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;

namespace DVLD_DesktopClient.Users
{
    public partial class frmAddUpdateUsers : Form
    {
        #region constructor + attributes

        clsGlobalSetting.EnMode _mode;
        clsDTOs.clsUserDTO _user;

        private int? _UserID = -1;

        public frmAddUpdateUsers(int? userID)
        {
            InitializeComponent();
            _UserID = userID;

            _mode = userID == null ? clsGlobalSetting.EnMode.Add : clsGlobalSetting.EnMode.Edit;
        }
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion


        #region Load Form + DATA

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_mode == clsGlobalSetting.EnMode.Add)
            {
                lblChangeMode.Text = "Add New User";
                this.Text = "Add New User";
                _user = new clsDTOs.clsUserDTO(0, 0, "", "", true);

                tpLoginInfo.Enabled = false;

               // ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblChangeMode.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            rbIsActiveyes.Checked = true;


        }
        private async void _LoadData()
        {
            _user = await clsUsersAsync.GetUserInfoByPersonIDAsync(_UserID ?? 0);

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _user, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lbluserID.Text = _user.userID.ToString();
            txtUserName.Text = _user.userName;
            txtPassword.Text = _user.password;
            txtConfirmPassword.Text = _user.password;
            if (_user.isActive)
                rbIsActiveyes.Checked = true;
            else
                rbIsActiveno.Checked = true;

            ctrlPersonCardWithFilter1.LoadPersonInfo(_user.personID);
        }
        private void frmAddUpdateUsers_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_mode == clsGlobalSetting.EnMode.Edit)
                _LoadData();
        }
        #endregion

        #region button close
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region button Next
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_mode == clsGlobalSetting.EnMode.Edit)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                //tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter2 == null)
            {
                MessageBox.Show("Person card control is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ////incase of add new mode.
            if (ctrlPersonCardWithFilter2.PersonID != -1)
            {
                var isExist =  clsUsersAsync.IsUserExistForPersonIDAsync((int)ctrlPersonCardWithFilter2.PersonID);
                bool isExistResult = await isExist; // Awaiting the task to get the result
            if (isExistResult)
            {

                MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter2.FilterFocus();
            }

            else
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tpLoginInfo"];
            }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter2.FilterFocus();

            }

        }
        #endregion

        #region the custom events for the person card control
        private void ctrlPersonCardWithFilter2_OnPersonSelected(int obj)
        {

        }
        #endregion

        #region validating textboxes


        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }
        #endregion
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _user.personID = ctrlPersonCardWithFilter2.PersonID;
            _user.userName = txtUserName.Text.Trim();
            _user.password = txtPassword.Text.Trim();
            if (rbIsActiveyes.Checked)
                _user.isActive = true;
            else
                _user.isActive = false;

            var result = await clsUsersAsync.AddNewUserAsync(_user);
            if (result)
            {

                //lbluserID.Text = _user.userID.ToString();
                lbluserID.Text = "Saved!";
                //change form mode to update.
                _mode = clsGlobalSetting.EnMode.Edit;
                lblChangeMode.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmAddUpdateUsers_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter2.FilterFocus();
        }
    }
}
