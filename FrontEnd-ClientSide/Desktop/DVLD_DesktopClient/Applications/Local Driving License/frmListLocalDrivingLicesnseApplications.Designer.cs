namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    partial class frmListLocalDrivingLicesnseApplications
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListLocalDrivingLicesnseApplications));
            label2 = new Label();
            lblRecordsCount = new Label();
            lblTitle = new Label();
            label3 = new Label();
            btnClose = new Button();
            btnAddNewApplication = new Button();
            dgvLocalDrivingLicenseApplications = new DataGridView();
            cmsApplications = new ContextMenuStrip(components);
            showApplicationDetailsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            editApplicationToolStripMenuItem = new ToolStripMenuItem();
            deleteApplicationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            cancelApplicationToolStripMenuItem = new ToolStripMenuItem();
            sechduleTestsToolStripMenuItem = new ToolStripMenuItem();
            scheduleVisionTestToolStripMenuItem = new ToolStripMenuItem();
            scheduleWrittenTestToolStripMenuItem = new ToolStripMenuItem();
            scheduleStreetTestToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            issueDrivingLicenseFirstTimeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            showLicenseToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            cbFilterBy = new ComboBox();
            txtFilterValue1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvLocalDrivingLicenseApplications).BeginInit();
            cmsApplications.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(151, 161, 176);
            label2.Location = new Point(79, 619);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 35;
            label2.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsCount.ForeColor = Color.Red;
            lblRecordsCount.Location = new Point(199, 619);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(32, 25);
            lblRecordsCount.TabIndex = 34;
            lblRecordsCount.Text = "?!";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(151, 161, 176);
            lblTitle.Location = new Point(230, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(482, 32);
            lblTitle.TabIndex = 33;
            lblTitle.Text = "Local Driving License Applications";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(151, 161, 176);
            label3.Location = new Point(76, 150);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 32;
            label3.Text = "Filter By :";
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(809, 618);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(91, 36);
            btnClose.TabIndex = 31;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnAddNewApplication
            // 
            btnAddNewApplication.BackColor = Color.FromArgb(74, 79, 99);
            btnAddNewApplication.FlatStyle = FlatStyle.Flat;
            btnAddNewApplication.ForeColor = Color.Transparent;
            btnAddNewApplication.Image = (Image)resources.GetObject("btnAddNewApplication.Image");
            btnAddNewApplication.Location = new Point(840, 143);
            btnAddNewApplication.Name = "btnAddNewApplication";
            btnAddNewApplication.Size = new Size(57, 37);
            btnAddNewApplication.TabIndex = 29;
            btnAddNewApplication.UseVisualStyleBackColor = false;
            btnAddNewApplication.Click += btnAddNewApplication_Click;
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            dgvLocalDrivingLicenseApplications.BackgroundColor = Color.FromArgb(46, 51, 73);
            dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocalDrivingLicenseApplications.ContextMenuStrip = cmsApplications;
            dgvLocalDrivingLicenseApplications.Location = new Point(79, 186);
            dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            dgvLocalDrivingLicenseApplications.Size = new Size(822, 409);
            dgvLocalDrivingLicenseApplications.TabIndex = 27;
            // 
            // cmsApplications
            // 
            cmsApplications.BackColor = Color.FromArgb(12, 0, 69);
            cmsApplications.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmsApplications.Items.AddRange(new ToolStripItem[] { showApplicationDetailsToolStripMenuItem, toolStripMenuItem1, editApplicationToolStripMenuItem, deleteApplicationToolStripMenuItem, toolStripMenuItem2, cancelApplicationToolStripMenuItem, sechduleTestsToolStripMenuItem, toolStripMenuItem3, issueDrivingLicenseFirstTimeToolStripMenuItem, toolStripMenuItem4, showLicenseToolStripMenuItem, toolStripMenuItem5, showPersonLicenseHistoryToolStripMenuItem });
            cmsApplications.Name = "cmsApplications";
            cmsApplications.Size = new Size(358, 296);
            cmsApplications.Opening += cmsApplications_Opening;
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            showApplicationDetailsToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            showApplicationDetailsToolStripMenuItem.Size = new Size(357, 30);
            showApplicationDetailsToolStripMenuItem.Text = "&Show Application Details";
            showApplicationDetailsToolStripMenuItem.Click += showApplicationDetailsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(354, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            editApplicationToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            editApplicationToolStripMenuItem.Size = new Size(357, 30);
            editApplicationToolStripMenuItem.Text = "&Edit Application";
            editApplicationToolStripMenuItem.Click += editApplicationToolStripMenuItem_Click;
            // 
            // deleteApplicationToolStripMenuItem
            // 
            deleteApplicationToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            deleteApplicationToolStripMenuItem.Size = new Size(357, 30);
            deleteApplicationToolStripMenuItem.Text = "&Delete Application";
            deleteApplicationToolStripMenuItem.Click += deleteApplicationToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(354, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            cancelApplicationToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            cancelApplicationToolStripMenuItem.Size = new Size(357, 30);
            cancelApplicationToolStripMenuItem.Text = "&Cancel Application";
            cancelApplicationToolStripMenuItem.Click += cancelApplicationToolStripMenuItem_Click;
            // 
            // sechduleTestsToolStripMenuItem
            // 
            sechduleTestsToolStripMenuItem.BackColor = Color.FromArgb(12, 0, 69);
            sechduleTestsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scheduleVisionTestToolStripMenuItem, scheduleWrittenTestToolStripMenuItem, scheduleStreetTestToolStripMenuItem });
            sechduleTestsToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            sechduleTestsToolStripMenuItem.Size = new Size(357, 30);
            sechduleTestsToolStripMenuItem.Text = "Sechdule &Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            scheduleVisionTestToolStripMenuItem.BackColor = Color.FromArgb(12, 0, 69);
            scheduleVisionTestToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            scheduleVisionTestToolStripMenuItem.Size = new Size(266, 30);
            scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            scheduleVisionTestToolStripMenuItem.Click += scheduleVisionTestToolStripMenuItem_Click;
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            scheduleWrittenTestToolStripMenuItem.BackColor = Color.FromArgb(12, 0, 69);
            scheduleWrittenTestToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            scheduleWrittenTestToolStripMenuItem.Size = new Size(266, 30);
            scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            scheduleWrittenTestToolStripMenuItem.Click += scheduleWrittenTestToolStripMenuItem_Click;
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            scheduleStreetTestToolStripMenuItem.BackColor = Color.FromArgb(12, 0, 69);
            scheduleStreetTestToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            scheduleStreetTestToolStripMenuItem.Size = new Size(266, 30);
            scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            scheduleStreetTestToolStripMenuItem.Click += scheduleStreetTestToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(354, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            issueDrivingLicenseFirstTimeToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new Size(357, 30);
            issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "&Issue Driving License (First Time)";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Click += issueDrivingLicenseFirstTimeToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(354, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            showLicenseToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            showLicenseToolStripMenuItem.Size = new Size(357, 30);
            showLicenseToolStripMenuItem.Text = "Show &License";
            showLicenseToolStripMenuItem.Click += showLicenseToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(354, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.ForeColor = Color.FromArgb(223, 50, 197);
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(357, 30);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.BackColor = Color.FromArgb(74, 79, 99);
            cbFilterBy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilterBy.ForeColor = SystemColors.Menu;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "L.D.L.AppID", "National ID", "Full Name", "Status" });
            cbFilterBy.Location = new Point(190, 149);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(169, 29);
            cbFilterBy.TabIndex = 30;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // txtFilterValue1
            // 
            txtFilterValue1.BackColor = Color.FromArgb(74, 79, 99);
            txtFilterValue1.BorderStyle = BorderStyle.None;
            txtFilterValue1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFilterValue1.ForeColor = SystemColors.Window;
            txtFilterValue1.Location = new Point(365, 144);
            txtFilterValue1.Multiline = true;
            txtFilterValue1.Name = "txtFilterValue1";
            txtFilterValue1.PlaceholderText = "  Searsh for a Local Driving License Applications...";
            txtFilterValue1.Size = new Size(469, 37);
            txtFilterValue1.TabIndex = 37;
            txtFilterValue1.KeyPress += txtFilterValue1_KeyPress;
            // 
            // frmListLocalDrivingLicesnseApplications
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(978, 688);
            Controls.Add(txtFilterValue1);
            Controls.Add(label2);
            Controls.Add(lblRecordsCount);
            Controls.Add(lblTitle);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(cbFilterBy);
            Controls.Add(btnAddNewApplication);
            Controls.Add(dgvLocalDrivingLicenseApplications);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmListLocalDrivingLicesnseApplications";
            Text = "frmListLocalDrivingLicesnseApplications";
            Load += frmListLocalDrivingLicesnseApplications_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLocalDrivingLicenseApplications).EndInit();
            cmsApplications.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox txtFilterValue;
        private Label label2;
        private Label lblRecordsCount;
        private Label lblTitle;
        private Label label3;
        private Button btnClose;
        private Button btnAddNewApplication;
        private DataGridView dgvLocalDrivingLicenseApplications;
        private ContextMenuStrip cmsApplications;
        private ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem editApplicationToolStripMenuItem;
        private ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem showLicenseToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue1;
    }
}