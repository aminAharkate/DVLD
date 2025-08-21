namespace DVLD_DesktopClient.Test
{
    partial class frmListTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTestAppointments));
            ctrlDrivingLicenseApplicationInfo1 = new DVLD_DesktopClient.Applications.Local_Driving_License.ctrlDrivingLicenseApplicationInfo();
            pbTestTypeImage = new PictureBox();
            lblTitle = new Label();
            btnAddNewAppointment = new Button();
            btnClose = new Button();
            label2 = new Label();
            lblRecordsCount = new Label();
            dgvLicenseTestAppointments = new DataGridView();
            label1 = new Label();
            cmsApplications = new ContextMenuStrip(components);
            editeToolStripMenuItem = new ToolStripMenuItem();
            takeTEstToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLicenseTestAppointments).BeginInit();
            cmsApplications.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            ctrlDrivingLicenseApplicationInfo1.BackColor = Color.FromArgb(12, 0, 69);
            ctrlDrivingLicenseApplicationInfo1.Location = new Point(23, 84);
            ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            ctrlDrivingLicenseApplicationInfo1.Size = new Size(775, 463);
            ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // pbTestTypeImage
            // 
            pbTestTypeImage.Image = (Image)resources.GetObject("pbTestTypeImage.Image");
            pbTestTypeImage.Location = new Point(213, 1);
            pbTestTypeImage.Name = "pbTestTypeImage";
            pbTestTypeImage.Size = new Size(74, 62);
            pbTestTypeImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbTestTypeImage.TabIndex = 24;
            pbTestTypeImage.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(151, 161, 176);
            lblTitle.ImeMode = ImeMode.NoControl;
            lblTitle.Location = new Point(297, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(361, 32);
            lblTitle.TabIndex = 25;
            lblTitle.Text = "Vision Test Appointments";
            // 
            // btnAddNewAppointment
            // 
            btnAddNewAppointment.BackgroundImage = (Image)resources.GetObject("btnAddNewAppointment.BackgroundImage");
            btnAddNewAppointment.FlatStyle = FlatStyle.Flat;
            btnAddNewAppointment.Location = new Point(713, 540);
            btnAddNewAppointment.Name = "btnAddNewAppointment";
            btnAddNewAppointment.Size = new Size(35, 36);
            btnAddNewAppointment.TabIndex = 26;
            btnAddNewAppointment.UseVisualStyleBackColor = true;
            btnAddNewAppointment.Click += btnAddNewAppointment_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(610, 741);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 38);
            btnClose.TabIndex = 71;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(151, 161, 176);
            label2.Location = new Point(60, 748);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 75;
            label2.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsCount.ForeColor = Color.Red;
            lblRecordsCount.Location = new Point(180, 748);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(32, 25);
            lblRecordsCount.TabIndex = 74;
            lblRecordsCount.Text = "?!";
            // 
            // dgvLicenseTestAppointments
            // 
            dgvLicenseTestAppointments.BackgroundColor = Color.FromArgb(46, 51, 73);
            dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLicenseTestAppointments.Location = new Point(55, 581);
            dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            dgvLicenseTestAppointments.Size = new Size(695, 149);
            dgvLicenseTestAppointments.TabIndex = 72;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(151, 161, 176);
            label1.Location = new Point(58, 544);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 76;
            label1.Text = "Appointments:";
            // 
            // cmsApplications
            // 
            cmsApplications.Items.AddRange(new ToolStripItem[] { editeToolStripMenuItem, takeTEstToolStripMenuItem });
            cmsApplications.Name = "cmsApplications";
            cmsApplications.Size = new Size(124, 48);
            // 
            // editeToolStripMenuItem
            // 
            editeToolStripMenuItem.Name = "editeToolStripMenuItem";
            editeToolStripMenuItem.Size = new Size(123, 22);
            editeToolStripMenuItem.Text = "Edite";
            editeToolStripMenuItem.Click += editeToolStripMenuItem_Click;
            // 
            // takeTEstToolStripMenuItem
            // 
            takeTEstToolStripMenuItem.Name = "takeTEstToolStripMenuItem";
            takeTEstToolStripMenuItem.Size = new Size(123, 22);
            takeTEstToolStripMenuItem.Text = "Take TEst";
            takeTEstToolStripMenuItem.Click += takeTEstToolStripMenuItem_Click;
            // 
            // frmListTestAppointments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(801, 791);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblRecordsCount);
            Controls.Add(dgvLicenseTestAppointments);
            Controls.Add(btnClose);
            Controls.Add(btnAddNewAppointment);
            Controls.Add(pbTestTypeImage);
            Controls.Add(lblTitle);
            Controls.Add(ctrlDrivingLicenseApplicationInfo1);
            Name = "frmListTestAppointments";
            Text = "frmLocalDrivingLicenseApplicationInfo";
            Load += frmListTestAppointments_Load;
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLicenseTestAppointments).EndInit();
            cmsApplications.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Applications.Local_Driving_License.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private PictureBox pbTestTypeImage;
        private Label lblTitle;
        private Button btnAddNewAppointment;
        private Button btnClose;
        private Label label2;
        private Label lblRecordsCount;
        private DataGridView dgvLicenseTestAppointments;
        private Label label1;
        private ContextMenuStrip cmsApplications;
        private ToolStripMenuItem editeToolStripMenuItem;
        private ToolStripMenuItem takeTEstToolStripMenuItem;
    }
}