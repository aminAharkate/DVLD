namespace DVLD_DesktopClient.Test
{
    partial class frmScheduleTest
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
            ctrlScheduleTest1 = new DVLD_DesktopClient.Test.Controls.ctrlScheduleTest();
            btnClose = new Button();
            SuspendLayout();
            // 
            // ctrlScheduleTest1
            // 
            ctrlScheduleTest1.BackColor = Color.FromArgb(12, 0, 69);
            ctrlScheduleTest1.Location = new Point(-1, -7);
            ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            ctrlScheduleTest1.Size = new Size(819, 497);
            ctrlScheduleTest1.TabIndex = 0;
            ctrlScheduleTest1.TestTypeID = Test_Types.clsTestTypeAsync.enTestType.VisionTest;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(650, 496);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 38);
            btnClose.TabIndex = 70;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmScheduleTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(820, 550);
            Controls.Add(btnClose);
            Controls.Add(ctrlScheduleTest1);
            Name = "frmScheduleTest";
            Text = "frmScheduleTest";
            Load += frmScheduleTest_Load;
            ResumeLayout(false);
        }

        #endregion

        private Controls.ctrlScheduleTest ctrlScheduleTest1;
        private Button btnClose;
    }
}