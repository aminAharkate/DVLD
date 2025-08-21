using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
#region v001
using System.Runtime.InteropServices;
using DVLD_DesktopClient.Drivers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using DVLD_DesktopClient.FormTesting;
using DVLD_DesktopClient.People;
using DVLD_DesktopClient.Users;
using DVLD_DesktopClient.Login;
using DVLD_DesktopClient.Applications.ApplicationTypes;
using DVLD_DesktopClient.Test.Test_Types;
using DVLD_DesktopClient.Resources.ContexMenuFile;
using System.Drawing;
# endregion
using Timer = System.Windows.Forms.Timer; // Add this with other using directives
using DVLD_DesktopClient.Applications.Local_Driving_License;
using DVLD_DesktopClient.GlobalClasses;
namespace DVLD_DesktopClient
{
    public partial class frmMain : Form
    {


        #region BorderRadius will be delete 
        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        //private static extern IntPtr CreateRoundRectRgn(

        //int nLeftRect,
        //int nTopRect,
        //int nRightRect,
        //int nBottomRect,
        //int nWidthEllipse,
        //int nHeightEllipse
        //);
        #endregion

        frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            _frmLogin = frm;
            InitializeComponent();
            #region v001
            clsUtility.BorderFormRadius(this, 50, 50);
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25)); //will be delete 
            PnlNav.Height = btnApplication.Height;
            PnlNav.Top = btnApplication.Top;
            PnlNav.Left = btnApplication.Left;
            btnApplication.BackColor = Color.FromArgb(46, 51, 73);

            #endregion

            #region v002 hide Sub Menu
            hideSubMenu();
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region v001 event leave

        private void btnApplication_Leave(object sender, EventArgs e)
        {
            btnApplication.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPeople_Leave(object sender, EventArgs e)
        {
            btnPeople.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnDrivers_Leave(object sender, EventArgs e)
        {
            btnDrivers.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnSetting_Leave(object sender, EventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnUser_Leave(object sender, EventArgs e)
        {
            // btnUser.BackColor = Color.FromArgb(46, 51, 73);
            btnUser.BackColor = Color.FromArgb(24, 30, 54);

        }
        #endregion

        #region v001 nav effects
        private void btnApplication_Click(object sender, EventArgs e)
        {
            //panelChildForm = null;
            //panelChildForm.Controls.Add(null);

        }
        private void btnPeople_Click(object sender, EventArgs e)
        {
            #region v001
            PnlNav.BringToFront();
            PnlNav.Height = btnPeople.Height;
            PnlNav.Top = btnPeople.Top;
            btnPeople.BackColor = Color.FromArgb(46, 51, 73);
            #endregion

            #region v002 hide Sub Menu
            hideSubMenu();
            #endregion

            #region testing to delete later [open event]
            frmListPeople frmListPeopl = new frmListPeople();
            frmListPeopl.ReOpenFormEvent += openChildForm;
            // Form frmListPeopl = new frmAddUpdateLocalDrivingLicesnseApplication(-1);
            openChildForm(frmListPeopl);

            #endregion
        }



        private void button2_Click(object sender, EventArgs e)
        {
            #region v001
            PnlNav.Height = btnDrivers.Height;
            PnlNav.Top = btnDrivers.Top;
            btnDrivers.BackColor = Color.FromArgb(46, 51, 73);
            #endregion

            #region v002 hide Sub Menu
            hideSubMenu();
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region v001
            PnlNav.Height = btnSetting.Height;
            PnlNav.Top = btnSetting.Top;
            btnSetting.BackColor = Color.FromArgb(46, 51, 73);
            #endregion
            #region show Sub Menu
            showSubMenu((Panel)pnlSetting);
            #endregion
        }
        private void button7_Click(object sender, EventArgs e)
        {
            #region v001
            PnlNav.Height = btnUser.Height;
            PnlNav.Top = btnUser.Top;
            btnUser.BackColor = Color.FromArgb(46, 51, 73);
            #endregion

            #region v002 hide Sub Menu
            hideSubMenu();
            #endregion

            openChildForm(new frmListUsers());
        }
        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            clsGlobalUser.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        #region v002 Code

        #region hide Sub Menu
        void hideSubMenu()
        {
            pnlSetting.Visible = false;
            pnlSetting.Visible = false;
            pnlSetting.Visible = false;
        }
        #endregion

        #region show Sub Menu
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #endregion

        #region handle showing forms
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            clsUtility.RoundPanelCorners(panelChildForm, 15);
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        #endregion

        #endregion

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            openChildForm(new frmUserInfo(clsGlobalUser.CurrentUser.userID));
        }

        private void rjDropdownMenu1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void drivingLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qsfqsfdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void qsdfqsdfToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        void _setUserInfo()
        {

            pbUserImage.Image = Properties.Resources.businessman;
            //lblUserName.Text  = clsGlobalUser.CurrentUser.userName;
            lblUserName.Text  = "Amine Aharkate";

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            _setUserInfo();
            StartLabelAnimation();

            rjDropdownMenuCore1.IsMainMenu = true;
            rjDropdownMenuCore1.IsMainMenu = true;
            rjDropdownMenuCore1.PrimaryColor = Color.DarkOrange;
            //rjDropdownMenuCore1.MenuItemTextColor = Color.OrangeRed;
            rjDropdownMenuCore1.MenuItemTextColor = System.Drawing.Color.FromArgb(223, 50, 197);
        }
        #region label title animation
        private System.Windows.Forms.Timer animationTimer;
        private int animationStep = 3;

        private void StartLabelAnimation()
        {
            if (animationTimer == null)
            {
                animationTimer = new System.Windows.Forms.Timer();
                animationTimer.Interval = 20;
                animationTimer.Tick += AnimationTimer_Tick;
            }

            // Start from left side (just outside the form)
            lblTitleApp.Left = -lblTitleApp.Width;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Move label right
            lblTitleApp.Left += animationStep;

            // When completely exits right side, reset to left
            if (lblTitleApp.Left > this.ClientSize.Width)
            {
                lblTitleApp.Left = -lblTitleApp.Width;
            }
        }
        #endregion

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region openChildForm
            openChildForm(new frmAddUpdateLocalDrivingLicesnseApplication(-1));
            #endregion
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmListLocalDrivingLicesnseApplications());
        }

        private void btnApplication_MouseHover(object sender, EventArgs e)
        {
            #region v001
            PnlNav.Height = btnApplication.Height;
            PnlNav.Top = btnApplication.Top;
            PnlNav.Left = btnApplication.Left;
            btnApplication.BackColor = Color.FromArgb(46, 51, 73);
            #endregion

            #region v002 hide Sub Menu
          //  hideSubMenu();
            #endregion

            rjDropdownMenuCore1.Show(btnApplication, btnApplication.Width, 0);

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

            openChildForm(new frmChangePassword(clsGlobalUser.CurrentUser.userID));
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            #region Mosttodelet
            //rjDropdownMenuCore1.IsMainMenu = true;
            //rjDropdownMenuCore1.IsMainMenu = true;
            //rjDropdownMenuCore1.PrimaryColor = Color.DarkOrange;
            ////rjDropdownMenuCore1.MenuItemTextColor = Color.OrangeRed;
            //rjDropdownMenuCore1.MenuItemTextColor = System.Drawing.Color.FromArgb(223, 50, 197);
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
            openChildForm(new frmListApplicationTypes());


            #endregion

        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Mosttodelet
            //rjDropdownMenuCore1.IsMainMenu = true;
            //rjDropdownMenuCore1.IsMainMenu = true;
            //rjDropdownMenuCore1.PrimaryColor = Color.DarkOrange;
            ////rjDropdownMenuCore1.MenuItemTextColor = Color.OrangeRed;
            //rjDropdownMenuCore1.MenuItemTextColor = System.Drawing.Color.FromArgb(223, 50, 197);
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
            #endregion
        }
    }
}

#region v001
#endregion

#region v002
#endregion

#region v003

#endregion

#region testing to delete later
//openChildForm(new frmListTestTypes());
#endregion