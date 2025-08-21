namespace DVLD_DesktopClient.Users.Controles
{
    partial class ctrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlUserCard));
            lbl = new Label();
            pictureBox2 = new PictureBox();
            lblUserID = new Label();
            pictureBox47 = new PictureBox();
            lblFullName = new Label();
            cntPersonCard1 = new DVLD_DesktopClient.People.Controles.cntPersonCard();
            lblUserName = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            lblIsActive = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox47).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.FromArgb(151, 161, 176);
            lbl.Location = new Point(83, 428);
            lbl.Name = "lbl";
            lbl.Size = new Size(107, 29);
            lbl.TabIndex = 24;
            lbl.Text = "UserID :";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(273, 422);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(35, 35);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 57;
            pictureBox2.TabStop = false;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.BackColor = Color.Transparent;
            lblUserID.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserID.ForeColor = Color.Red;
            lblUserID.Location = new Point(197, 428);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(38, 29);
            lblUserID.TabIndex = 58;
            lblUserID.Text = "ID";
            // 
            // pictureBox47
            // 
            pictureBox47.BackColor = Color.Transparent;
            pictureBox47.Image = (Image)resources.GetObject("pictureBox47.Image");
            pictureBox47.Location = new Point(40, 422);
            pictureBox47.Name = "pictureBox47";
            pictureBox47.Size = new Size(35, 35);
            pictureBox47.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox47.TabIndex = 60;
            pictureBox47.TabStop = false;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.BackColor = Color.Transparent;
            lblFullName.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullName.ForeColor = Color.FromArgb(151, 161, 176);
            lblFullName.Location = new Point(318, 428);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(158, 29);
            lblFullName.TabIndex = 61;
            lblFullName.Text = "User Name :";
            // 
            // cntPersonCard1
            // 
            cntPersonCard1.BackColor = SystemColors.ActiveCaptionText;
            cntPersonCard1.BackgroundImage = (Image)resources.GetObject("cntPersonCard1.BackgroundImage");
            cntPersonCard1.Location = new Point(0, 3);
            cntPersonCard1.Name = "cntPersonCard1";
            cntPersonCard1.Size = new Size(940, 479);
            cntPersonCard1.TabIndex = 62;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.Red;
            lblUserName.Location = new Point(485, 427);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(57, 29);
            lblUserName.TabIndex = 63;
            lblUserName.Text = "[....]";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(698, 422);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(151, 161, 176);
            label2.Location = new Point(739, 425);
            label2.Name = "label2";
            label2.Size = new Size(124, 29);
            label2.TabIndex = 65;
            label2.Text = "Is Active :";
            // 
            // lblIsActive
            // 
            lblIsActive.AutoSize = true;
            lblIsActive.BackColor = Color.Transparent;
            lblIsActive.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIsActive.ForeColor = Color.Red;
            lblIsActive.Location = new Point(869, 425);
            lblIsActive.Name = "lblIsActive";
            lblIsActive.Size = new Size(58, 29);
            lblIsActive.TabIndex = 66;
            lblIsActive.Text = "Yes";
            // 
            // ctrlUserCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(lblIsActive);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(lblUserName);
            Controls.Add(lblFullName);
            Controls.Add(pictureBox47);
            Controls.Add(lblUserID);
            Controls.Add(pictureBox2);
            Controls.Add(lbl);
            Controls.Add(cntPersonCard1);
            Name = "ctrlUserCard";
            Size = new Size(940, 486);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox47).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl;
        private PictureBox pictureBox2;
        private Label lblUserID;
        private PictureBox pictureBox47;
        private Label lblFullName;
        private People.Controles.cntPersonCard cntPersonCard1;
        private Label lblUserName;
        private PictureBox pictureBox1;
        private Label label2;
        private Label lblIsActive;
    }
}
