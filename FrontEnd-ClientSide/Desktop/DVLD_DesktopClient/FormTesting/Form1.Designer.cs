namespace DVLD_DesktopClient.FormTesting
{
    partial class frmTesting
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
            lblTitleApp = new Label();
            SuspendLayout();
            // 
            // lblTitleApp
            // 
            lblTitleApp.AutoSize = true;
            lblTitleApp.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleApp.ForeColor = Color.FromArgb(151, 161, 176);
            lblTitleApp.Location = new Point(372, 9);
            lblTitleApp.Name = "lblTitleApp";
            lblTitleApp.Size = new Size(115, 32);
            lblTitleApp.TabIndex = 5;
            lblTitleApp.Text = "Testing";
            // 
            // frmTesting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(994, 727);
            Controls.Add(lblTitleApp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmTesting";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitleApp;
    }
}