//using DVLD_DesktopClient.ContexMenuFile;
using DVLD_DesktopClient.Resources.ContexMenuFile;


namespace DVLD_DesktopClient
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            panel1 = new Panel();
            btnUser = new Button();
            pnlSetting = new Panel();
            btnSignOut = new Button();
            btnChangePassword = new Button();
            btnUserInfo = new Button();
            btnSetting = new Button();
            btnDrivers = new Button();
            btnPeople = new Button();
            btnApplication = new Button();
            rjDropdownMenuCore1 = new RJDropdownMenuCore(components);
            drivingLicensesServicesToolStripMenuItem = new ToolStripMenuItem();
            newDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            localLicenseToolStripMenuItem = new ToolStripMenuItem();
            internationalLicenseToolStripMenuItem = new ToolStripMenuItem();
            renewDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            replacementForLostOrDamagedLicenseToolStripMenuItem = new ToolStripMenuItem();
            releaseDetainedDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            retakeTestToolStripMenuItem = new ToolStripMenuItem();
            manageApplicationsToolStripMenuItem = new ToolStripMenuItem();
            localDrivingLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            internationalLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            detainLicensesToolStripMenuItem = new ToolStripMenuItem();
            manageDetainedLicensesToolStripMenuItem = new ToolStripMenuItem();
            detainLicenseToolStripMenuItem = new ToolStripMenuItem();
            releaseDetainedLicenseToolStripMenuItem = new ToolStripMenuItem();
            manageApplicationTypesToolStripMenuItem = new ToolStripMenuItem();
            manageTestTypesToolStripMenuItem = new ToolStripMenuItem();
            PnlNav = new Panel();
            button4 = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            lblUserPermentions = new Label();
            not = new Label();
            lblUserName = new Label();
            pbUserImage = new PictureBox();
            label3 = new Label();
            textBox1 = new TextBox();
            btncloseApp = new Button();
            panelChildForm = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pnlHeader = new Panel();
            lblTitleApp = new Label();
            qsdfToolStripMenuItem = new ToolStripMenuItem();
            qsdfToolStripMenuItem1 = new ToolStripMenuItem();
            qsdfToolStripMenuItem2 = new ToolStripMenuItem();
            qsdfToolStripMenuItem3 = new ToolStripMenuItem();
            qsdfToolStripMenuItem4 = new ToolStripMenuItem();
            qsfdToolStripMenuItem = new ToolStripMenuItem();
            qsfqsfdToolStripMenuItem = new ToolStripMenuItem();
            qsdfqsdfToolStripMenuItem = new ToolStripMenuItem();
            qsdfToolStripMenuItem6 = new ToolStripMenuItem();
            qsdfToolStripMenuItem7 = new ToolStripMenuItem();
            qsdfToolStripMenuItem8 = new ToolStripMenuItem();
            qsdfqsdfToolStripMenuItem3 = new ToolStripMenuItem();
            qsdfqdsfToolStripMenuItem = new ToolStripMenuItem();
            qsdfqsfdToolStripMenuItem = new ToolStripMenuItem();
            qsdfToolStripMenuItem5 = new ToolStripMenuItem();
            qsdfToolStripMenuItem9 = new ToolStripMenuItem();
            sdToolStripMenuItem = new ToolStripMenuItem();
            qsdfqsdfToolStripMenuItem1 = new ToolStripMenuItem();
            ffToolStripMenuItem = new ToolStripMenuItem();
            ssToolStripMenuItem = new ToolStripMenuItem();
            qqqToolStripMenuItem = new ToolStripMenuItem();
            qsdfqsdfToolStripMenuItem2 = new ToolStripMenuItem();
            qsfqsfdToolStripMenuItem1 = new ToolStripMenuItem();
            panel1.SuspendLayout();
            pnlSetting.SuspendLayout();
            rjDropdownMenuCore1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUserImage).BeginInit();
            panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(btnUser);
            panel1.Controls.Add(pnlSetting);
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnDrivers);
            panel1.Controls.Add(btnPeople);
            panel1.Controls.Add(btnApplication);
            panel1.Controls.Add(PnlNav);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(panel2);
            panel1.Name = "panel1";
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnUser, "btnUser");
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.ForeColor = Color.FromArgb(0, 126, 246);
            btnUser.Name = "btnUser";
            btnUser.Tag = "User";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += button7_Click;
            btnUser.Leave += btnUser_Leave;
            // 
            // pnlSetting
            // 
            pnlSetting.BackColor = Color.FromArgb(46, 51, 73);
            pnlSetting.Controls.Add(btnSignOut);
            pnlSetting.Controls.Add(btnChangePassword);
            pnlSetting.Controls.Add(btnUserInfo);
            resources.ApplyResources(pnlSetting, "pnlSetting");
            pnlSetting.Name = "pnlSetting";
            // 
            // btnSignOut
            // 
            btnSignOut.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnSignOut, "btnSignOut");
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.ForeColor = Color.FromArgb(0, 126, 246);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.UseVisualStyleBackColor = false;
            btnSignOut.Click += button6_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnChangePassword, "btnChangePassword");
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.ForeColor = Color.FromArgb(0, 126, 246);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnUserInfo
            // 
            btnUserInfo.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnUserInfo, "btnUserInfo");
            btnUserInfo.FlatAppearance.BorderSize = 0;
            btnUserInfo.ForeColor = Color.FromArgb(0, 126, 246);
            btnUserInfo.Name = "btnUserInfo";
            btnUserInfo.UseVisualStyleBackColor = false;
            btnUserInfo.Click += btnUserInfo_Click;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnSetting, "btnSetting");
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.ForeColor = Color.FromArgb(0, 126, 246);
            btnSetting.Name = "btnSetting";
            btnSetting.UseVisualStyleBackColor = false;
            btnSetting.Click += button3_Click;
            btnSetting.Leave += btnSetting_Leave;
            // 
            // btnDrivers
            // 
            btnDrivers.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnDrivers, "btnDrivers");
            btnDrivers.FlatAppearance.BorderSize = 0;
            btnDrivers.ForeColor = Color.FromArgb(0, 126, 246);
            btnDrivers.Name = "btnDrivers";
            btnDrivers.UseVisualStyleBackColor = false;
            btnDrivers.Click += button2_Click;
            btnDrivers.Leave += btnDrivers_Leave;
            // 
            // btnPeople
            // 
            btnPeople.BackColor = Color.FromArgb(12, 0, 69);
            resources.ApplyResources(btnPeople, "btnPeople");
            btnPeople.FlatAppearance.BorderSize = 0;
            btnPeople.ForeColor = Color.FromArgb(0, 126, 246);
            btnPeople.Name = "btnPeople";
            btnPeople.UseVisualStyleBackColor = false;
            btnPeople.Click += btnPeople_Click;
            btnPeople.Leave += btnPeople_Leave;
            // 
            // btnApplication
            // 
            btnApplication.BackColor = Color.FromArgb(12, 0, 69);
            btnApplication.ContextMenuStrip = rjDropdownMenuCore1;
            resources.ApplyResources(btnApplication, "btnApplication");
            btnApplication.FlatAppearance.BorderSize = 0;
            btnApplication.ForeColor = Color.FromArgb(0, 126, 246);
            btnApplication.Name = "btnApplication";
            btnApplication.UseVisualStyleBackColor = false;
            btnApplication.Click += btnApplication_Click;
            btnApplication.Leave += btnApplication_Leave;
            btnApplication.MouseHover += btnApplication_MouseHover;
            // 
            // rjDropdownMenuCore1
            // 
            resources.ApplyResources(rjDropdownMenuCore1, "rjDropdownMenuCore1");
            rjDropdownMenuCore1.Items.AddRange(new ToolStripItem[] { drivingLicensesServicesToolStripMenuItem, manageApplicationsToolStripMenuItem, detainLicensesToolStripMenuItem, manageApplicationTypesToolStripMenuItem, manageTestTypesToolStripMenuItem });
            rjDropdownMenuCore1.Name = "rjDropdownMenuCore1";
            rjDropdownMenuCore1.RenderMode = ToolStripRenderMode.Professional;
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newDrivingLicenseToolStripMenuItem, renewDrivingLicenseToolStripMenuItem, replacementForLostOrDamagedLicenseToolStripMenuItem, releaseDetainedDrivingLicenseToolStripMenuItem, retakeTestToolStripMenuItem });
            drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            resources.ApplyResources(drivingLicensesServicesToolStripMenuItem, "drivingLicensesServicesToolStripMenuItem");
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localLicenseToolStripMenuItem, internationalLicenseToolStripMenuItem });
            newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            resources.ApplyResources(newDrivingLicenseToolStripMenuItem, "newDrivingLicenseToolStripMenuItem");
            // 
            // localLicenseToolStripMenuItem
            // 
            localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            resources.ApplyResources(localLicenseToolStripMenuItem, "localLicenseToolStripMenuItem");
            localLicenseToolStripMenuItem.Click += localLicenseToolStripMenuItem_Click;
            // 
            // internationalLicenseToolStripMenuItem
            // 
            internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            resources.ApplyResources(internationalLicenseToolStripMenuItem, "internationalLicenseToolStripMenuItem");
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            resources.ApplyResources(renewDrivingLicenseToolStripMenuItem, "renewDrivingLicenseToolStripMenuItem");
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            resources.ApplyResources(replacementForLostOrDamagedLicenseToolStripMenuItem, "replacementForLostOrDamagedLicenseToolStripMenuItem");
            replacementForLostOrDamagedLicenseToolStripMenuItem.Click += replacementForLostOrDamagedLicenseToolStripMenuItem_Click;
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            resources.ApplyResources(releaseDetainedDrivingLicenseToolStripMenuItem, "releaseDetainedDrivingLicenseToolStripMenuItem");
            // 
            // retakeTestToolStripMenuItem
            // 
            retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            resources.ApplyResources(retakeTestToolStripMenuItem, "retakeTestToolStripMenuItem");
            retakeTestToolStripMenuItem.Click += retakeTestToolStripMenuItem_Click;
            // 
            // manageApplicationsToolStripMenuItem
            // 
            manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localDrivingLicenseApplicationsToolStripMenuItem, internationalLicenseApplicationsToolStripMenuItem });
            manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            resources.ApplyResources(manageApplicationsToolStripMenuItem, "manageApplicationsToolStripMenuItem");
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            resources.ApplyResources(localDrivingLicenseApplicationsToolStripMenuItem, "localDrivingLicenseApplicationsToolStripMenuItem");
            localDrivingLicenseApplicationsToolStripMenuItem.Click += localDrivingLicenseApplicationsToolStripMenuItem_Click;
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            resources.ApplyResources(internationalLicenseApplicationsToolStripMenuItem, "internationalLicenseApplicationsToolStripMenuItem");
            // 
            // detainLicensesToolStripMenuItem
            // 
            detainLicensesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageDetainedLicensesToolStripMenuItem, detainLicenseToolStripMenuItem, releaseDetainedLicenseToolStripMenuItem });
            detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            resources.ApplyResources(detainLicensesToolStripMenuItem, "detainLicensesToolStripMenuItem");
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            resources.ApplyResources(manageDetainedLicensesToolStripMenuItem, "manageDetainedLicensesToolStripMenuItem");
            // 
            // detainLicenseToolStripMenuItem
            // 
            detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            resources.ApplyResources(detainLicenseToolStripMenuItem, "detainLicenseToolStripMenuItem");
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            resources.ApplyResources(releaseDetainedLicenseToolStripMenuItem, "releaseDetainedLicenseToolStripMenuItem");
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            resources.ApplyResources(manageApplicationTypesToolStripMenuItem, "manageApplicationTypesToolStripMenuItem");
            manageApplicationTypesToolStripMenuItem.Click += manageApplicationTypesToolStripMenuItem_Click;
            // 
            // manageTestTypesToolStripMenuItem
            // 
            manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            resources.ApplyResources(manageTestTypesToolStripMenuItem, "manageTestTypesToolStripMenuItem");
            manageTestTypesToolStripMenuItem.Click += manageTestTypesToolStripMenuItem_Click_1;
            // 
            // PnlNav
            // 
            PnlNav.BackColor = Color.FromArgb(0, 126, 249);
            resources.ApplyResources(PnlNav, "PnlNav");
            PnlNav.Name = "PnlNav";
            // 
            // button4
            // 
            resources.ApplyResources(button4, "button4");
            button4.FlatAppearance.BorderSize = 0;
            button4.ForeColor = Color.FromArgb(0, 126, 246);
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(12, 0, 69);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(lblUserPermentions);
            panel2.Controls.Add(not);
            panel2.Controls.Add(lblUserName);
            panel2.Controls.Add(pbUserImage);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(24, 30, 54);
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // lblUserPermentions
            // 
            resources.ApplyResources(lblUserPermentions, "lblUserPermentions");
            lblUserPermentions.ForeColor = Color.Red;
            lblUserPermentions.Name = "lblUserPermentions";
            lblUserPermentions.Tag = "";
            // 
            // not
            // 
            resources.ApplyResources(not, "not");
            not.ForeColor = Color.FromArgb(0, 126, 246);
            not.Name = "not";
            not.Tag = "";
            // 
            // lblUserName
            // 
            resources.ApplyResources(lblUserName, "lblUserName");
            lblUserName.ForeColor = Color.FromArgb(0, 126, 246);
            lblUserName.Name = "lblUserName";
            lblUserName.Tag = "";
            // 
            // pbUserImage
            // 
            pbUserImage.BackColor = Color.FromArgb(24, 30, 54);
            pbUserImage.Image = Properties.Resources.businessman;
            resources.ApplyResources(pbUserImage, "pbUserImage");
            pbUserImage.Name = "pbUserImage";
            pbUserImage.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.FromArgb(151, 161, 176);
            label3.Name = "label3";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(74, 79, 99);
            textBox1.BorderStyle = BorderStyle.None;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Name = "textBox1";
            // 
            // btncloseApp
            // 
            btncloseApp.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(btncloseApp, "btncloseApp");
            btncloseApp.ForeColor = Color.Red;
            btncloseApp.Name = "btncloseApp";
            btncloseApp.UseVisualStyleBackColor = true;
            btncloseApp.Click += button2_Click_1;
            // 
            // panelChildForm
            // 
            panelChildForm.BackColor = Color.FromArgb(12, 0, 69);
            panelChildForm.Controls.Add(textBox1);
            panelChildForm.Controls.Add(pictureBox4);
            panelChildForm.Controls.Add(label3);
            panelChildForm.Controls.Add(pictureBox2);
            panelChildForm.Controls.Add(pictureBox3);
            resources.ApplyResources(panelChildForm, "panelChildForm");
            panelChildForm.Name = "panelChildForm";
            // 
            // pictureBox4
            // 
            resources.ApplyResources(pictureBox4, "pictureBox4");
            pictureBox4.Name = "pictureBox4";
            pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(12, 0, 69);
            pnlHeader.Controls.Add(btncloseApp);
            pnlHeader.Controls.Add(lblTitleApp);
            resources.ApplyResources(pnlHeader, "pnlHeader");
            pnlHeader.Name = "pnlHeader";
            // 
            // lblTitleApp
            // 
            resources.ApplyResources(lblTitleApp, "lblTitleApp");
            lblTitleApp.ForeColor = Color.FromArgb(223, 50, 197);
            lblTitleApp.Name = "lblTitleApp";
            // 
            // qsdfToolStripMenuItem
            // 
            qsdfToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { qsdfToolStripMenuItem1 });
            qsdfToolStripMenuItem.Name = "qsdfToolStripMenuItem";
            resources.ApplyResources(qsdfToolStripMenuItem, "qsdfToolStripMenuItem");
            // 
            // qsdfToolStripMenuItem1
            // 
            qsdfToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { qsdfToolStripMenuItem2 });
            qsdfToolStripMenuItem1.Name = "qsdfToolStripMenuItem1";
            resources.ApplyResources(qsdfToolStripMenuItem1, "qsdfToolStripMenuItem1");
            // 
            // qsdfToolStripMenuItem2
            // 
            qsdfToolStripMenuItem2.Name = "qsdfToolStripMenuItem2";
            resources.ApplyResources(qsdfToolStripMenuItem2, "qsdfToolStripMenuItem2");
            // 
            // qsdfToolStripMenuItem3
            // 
            qsdfToolStripMenuItem3.Name = "qsdfToolStripMenuItem3";
            resources.ApplyResources(qsdfToolStripMenuItem3, "qsdfToolStripMenuItem3");
            // 
            // qsdfToolStripMenuItem4
            // 
            qsdfToolStripMenuItem4.Name = "qsdfToolStripMenuItem4";
            resources.ApplyResources(qsdfToolStripMenuItem4, "qsdfToolStripMenuItem4");
            // 
            // qsfdToolStripMenuItem
            // 
            qsfdToolStripMenuItem.Name = "qsfdToolStripMenuItem";
            resources.ApplyResources(qsfdToolStripMenuItem, "qsfdToolStripMenuItem");
            // 
            // qsfqsfdToolStripMenuItem
            // 
            qsfqsfdToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            qsfqsfdToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { qsdfqsdfToolStripMenuItem, qsdfToolStripMenuItem8, qsdfqsdfToolStripMenuItem3, qsdfqdsfToolStripMenuItem, qsdfqsfdToolStripMenuItem });
            qsfqsfdToolStripMenuItem.ForeColor = Color.White;
            qsfqsfdToolStripMenuItem.Name = "qsfqsfdToolStripMenuItem";
            resources.ApplyResources(qsfqsfdToolStripMenuItem, "qsfqsfdToolStripMenuItem");
            qsfqsfdToolStripMenuItem.Click += qsfqsfdToolStripMenuItem_Click;
            // 
            // qsdfqsdfToolStripMenuItem
            // 
            qsdfqsdfToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            qsdfqsdfToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { qsdfToolStripMenuItem6, qsdfToolStripMenuItem7 });
            qsdfqsdfToolStripMenuItem.ForeColor = Color.White;
            qsdfqsdfToolStripMenuItem.Name = "qsdfqsdfToolStripMenuItem";
            resources.ApplyResources(qsdfqsdfToolStripMenuItem, "qsdfqsdfToolStripMenuItem");
            // 
            // qsdfToolStripMenuItem6
            // 
            qsdfToolStripMenuItem6.BackColor = Color.FromArgb(46, 51, 73);
            qsdfToolStripMenuItem6.ForeColor = Color.White;
            qsdfToolStripMenuItem6.Name = "qsdfToolStripMenuItem6";
            resources.ApplyResources(qsdfToolStripMenuItem6, "qsdfToolStripMenuItem6");
            // 
            // qsdfToolStripMenuItem7
            // 
            qsdfToolStripMenuItem7.BackColor = Color.FromArgb(46, 51, 73);
            qsdfToolStripMenuItem7.ForeColor = Color.White;
            qsdfToolStripMenuItem7.Name = "qsdfToolStripMenuItem7";
            resources.ApplyResources(qsdfToolStripMenuItem7, "qsdfToolStripMenuItem7");
            // 
            // qsdfToolStripMenuItem8
            // 
            qsdfToolStripMenuItem8.BackColor = Color.FromArgb(46, 51, 73);
            qsdfToolStripMenuItem8.ForeColor = Color.White;
            qsdfToolStripMenuItem8.Name = "qsdfToolStripMenuItem8";
            resources.ApplyResources(qsdfToolStripMenuItem8, "qsdfToolStripMenuItem8");
            // 
            // qsdfqsdfToolStripMenuItem3
            // 
            qsdfqsdfToolStripMenuItem3.BackColor = Color.FromArgb(46, 51, 73);
            qsdfqsdfToolStripMenuItem3.ForeColor = Color.White;
            qsdfqsdfToolStripMenuItem3.Name = "qsdfqsdfToolStripMenuItem3";
            resources.ApplyResources(qsdfqsdfToolStripMenuItem3, "qsdfqsdfToolStripMenuItem3");
            // 
            // qsdfqdsfToolStripMenuItem
            // 
            qsdfqdsfToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            qsdfqdsfToolStripMenuItem.ForeColor = Color.White;
            qsdfqdsfToolStripMenuItem.Name = "qsdfqdsfToolStripMenuItem";
            resources.ApplyResources(qsdfqdsfToolStripMenuItem, "qsdfqdsfToolStripMenuItem");
            // 
            // qsdfqsfdToolStripMenuItem
            // 
            qsdfqsfdToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            qsdfqsfdToolStripMenuItem.ForeColor = Color.White;
            qsdfqsfdToolStripMenuItem.Name = "qsdfqsfdToolStripMenuItem";
            resources.ApplyResources(qsdfqsfdToolStripMenuItem, "qsdfqsfdToolStripMenuItem");
            // 
            // qsdfToolStripMenuItem5
            // 
            qsdfToolStripMenuItem5.BackColor = Color.FromArgb(46, 51, 73);
            qsdfToolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { qsdfToolStripMenuItem9, sdToolStripMenuItem });
            qsdfToolStripMenuItem5.ForeColor = Color.White;
            qsdfToolStripMenuItem5.Name = "qsdfToolStripMenuItem5";
            resources.ApplyResources(qsdfToolStripMenuItem5, "qsdfToolStripMenuItem5");
            // 
            // qsdfToolStripMenuItem9
            // 
            qsdfToolStripMenuItem9.BackColor = Color.FromArgb(46, 51, 73);
            qsdfToolStripMenuItem9.Name = "qsdfToolStripMenuItem9";
            resources.ApplyResources(qsdfToolStripMenuItem9, "qsdfToolStripMenuItem9");
            // 
            // sdToolStripMenuItem
            // 
            sdToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            sdToolStripMenuItem.Name = "sdToolStripMenuItem";
            resources.ApplyResources(sdToolStripMenuItem, "sdToolStripMenuItem");
            // 
            // qsdfqsdfToolStripMenuItem1
            // 
            qsdfqsdfToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ffToolStripMenuItem, ssToolStripMenuItem, qqqToolStripMenuItem });
            qsdfqsdfToolStripMenuItem1.ForeColor = Color.White;
            qsdfqsdfToolStripMenuItem1.Name = "qsdfqsdfToolStripMenuItem1";
            resources.ApplyResources(qsdfqsdfToolStripMenuItem1, "qsdfqsdfToolStripMenuItem1");
            // 
            // ffToolStripMenuItem
            // 
            ffToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            ffToolStripMenuItem.Name = "ffToolStripMenuItem";
            resources.ApplyResources(ffToolStripMenuItem, "ffToolStripMenuItem");
            // 
            // ssToolStripMenuItem
            // 
            ssToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            ssToolStripMenuItem.Name = "ssToolStripMenuItem";
            resources.ApplyResources(ssToolStripMenuItem, "ssToolStripMenuItem");
            // 
            // qqqToolStripMenuItem
            // 
            qqqToolStripMenuItem.BackColor = Color.FromArgb(46, 51, 73);
            qqqToolStripMenuItem.Name = "qqqToolStripMenuItem";
            resources.ApplyResources(qqqToolStripMenuItem, "qqqToolStripMenuItem");
            // 
            // qsdfqsdfToolStripMenuItem2
            // 
            qsdfqsdfToolStripMenuItem2.ForeColor = Color.White;
            qsdfqsdfToolStripMenuItem2.Name = "qsdfqsdfToolStripMenuItem2";
            resources.ApplyResources(qsdfqsdfToolStripMenuItem2, "qsdfqsdfToolStripMenuItem2");
            qsdfqsdfToolStripMenuItem2.Click += qsdfqsdfToolStripMenuItem2_Click;
            // 
            // qsfqsfdToolStripMenuItem1
            // 
            qsfqsfdToolStripMenuItem1.ForeColor = Color.White;
            qsfqsfdToolStripMenuItem1.Name = "qsfqsfdToolStripMenuItem1";
            resources.ApplyResources(qsfqsfdToolStripMenuItem1, "qsfqsfdToolStripMenuItem1");
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(panelChildForm);
            Controls.Add(pnlHeader);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "frmMain";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            pnlSetting.ResumeLayout(false);
            rjDropdownMenuCore1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUserImage).EndInit();
            panelChildForm.ResumeLayout(false);
            panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pbUserImage;
        private Label not;
        private Label lblUserName;
        private Button btnApplication;
        private Button button4;
        private Button btnSetting;
        private Button btnDrivers;
        private Button btnPeople;
        private Panel PnlNav;
        private Label label3;
        private TextBox textBox1;
        private Button btncloseApp;
        private Panel pnlSetting;
        private Button btnChangePassword;
        private Button btnUserInfo;
        private Button btnSignOut;
        private Button btnUser;
        private Panel panelChildForm;
        private Panel pnlHeader;
        private ToolStripMenuItem qsdfToolStripMenuItem;
        private ToolStripMenuItem qsdfToolStripMenuItem1;
        private ToolStripMenuItem qsdfToolStripMenuItem2;
        private ToolStripMenuItem qsdfToolStripMenuItem3;
        private ToolStripMenuItem qsdfToolStripMenuItem4;
        private ToolStripMenuItem qsfdToolStripMenuItem;
 //       private RJDropdownMenu rjDropdownMenu1;
        private ToolStripMenuItem qsfqsfdToolStripMenuItem;
        private ToolStripMenuItem qsdfqsdfToolStripMenuItem;
        private ToolStripMenuItem qsdfToolStripMenuItem6;
        private ToolStripMenuItem qsdfToolStripMenuItem7;
        private ToolStripMenuItem qsdfToolStripMenuItem8;
        private ToolStripMenuItem qsdfqsdfToolStripMenuItem3;
        private ToolStripMenuItem qsdfqdsfToolStripMenuItem;
        private ToolStripMenuItem qsdfqsfdToolStripMenuItem;
        private ToolStripMenuItem qsdfToolStripMenuItem5;
        private ToolStripMenuItem qsdfToolStripMenuItem9;
        private ToolStripMenuItem sdToolStripMenuItem;
        private ToolStripMenuItem qsdfqsdfToolStripMenuItem1;
        private ToolStripMenuItem ffToolStripMenuItem;
        private ToolStripMenuItem ssToolStripMenuItem;
        private ToolStripMenuItem qqqToolStripMenuItem;
        private ToolStripMenuItem qsdfqsdfToolStripMenuItem2;
        private ToolStripMenuItem qsfqsfdToolStripMenuItem1;
        private PictureBox pictureBox2;
        private RJDropdownMenu rjDropdownMenu1;
        private Label lblTitleApp;
        private Label lblUserPermentions;
        private PictureBox pictureBox1;
        private RJDropdownMenuCore rjDropdownMenuCore1;
        private ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem localLicenseToolStripMenuItem;
        private ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem retakeTestToolStripMenuItem;
        private ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private ToolStripMenuItem detainLicensesToolStripMenuItem;
        private ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private ToolStripMenuItem detainLicenseToolStripMenuItem;
        private ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}
