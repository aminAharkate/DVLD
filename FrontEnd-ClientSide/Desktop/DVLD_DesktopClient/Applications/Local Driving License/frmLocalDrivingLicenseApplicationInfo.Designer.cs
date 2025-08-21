namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    partial class frmLocalDrivingLicenseApplicationInfo
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
            button1 = new Button();
            ctrlDrivingLicenseApplicationInfo1 = new ctrlDrivingLicenseApplicationInfo();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(629, 473);
            button1.Name = "button1";
            button1.Size = new Size(136, 38);
            button1.TabIndex = 70;
            button1.Text = "CLOSE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            ctrlDrivingLicenseApplicationInfo1.BackColor = Color.FromArgb(12, 0, 69);
            ctrlDrivingLicenseApplicationInfo1.Location = new Point(12, 12);
            ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            ctrlDrivingLicenseApplicationInfo1.Size = new Size(771, 458);
            ctrlDrivingLicenseApplicationInfo1.TabIndex = 71;
            // 
            // frmLocalDrivingLicenseApplicationInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(786, 525);
            Controls.Add(ctrlDrivingLicenseApplicationInfo1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "frmLocalDrivingLicenseApplicationInfo";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "frmLocalDrivingLicenseApplicationInfo";
            Load += frmLocalDrivingLicenseApplicationInfo_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
    }
}