namespace DVLD_DesktopClient.Users
{
    partial class frmUserInfo
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
            ctrlUserCard1 = new DVLD_DesktopClient.Users.Controles.ctrlUserCard();
            button1 = new Button();
            SuspendLayout();
            // 
            // ctrlUserCard1
            // 
            ctrlUserCard1.BackColor = Color.FromArgb(12, 0, 69);
            ctrlUserCard1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ctrlUserCard1.Location = new Point(21, 45);
            ctrlUserCard1.Name = "ctrlUserCard1";
            ctrlUserCard1.Size = new Size(940, 506);
            ctrlUserCard1.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(870, 628);
            button1.Name = "button1";
            button1.Size = new Size(91, 36);
            button1.TabIndex = 9;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmUserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(978, 688);
            Controls.Add(button1);
            Controls.Add(ctrlUserCard1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmUserInfo";
            Text = "frmUserInfo";
            Load += frmUserInfo_Load;
            ResumeLayout(false);
        }

        #endregion

        private Controles.ctrlUserCard ctrlUserCard1;
        private Button button1;
    }
}