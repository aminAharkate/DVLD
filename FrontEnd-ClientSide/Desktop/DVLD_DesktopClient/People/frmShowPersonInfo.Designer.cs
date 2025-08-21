namespace DVLD_DesktopClient.People
{
    partial class frmShowPersonInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPersonInfo));
            cntPersonCard1 = new DVLD_DesktopClient.People.Controles.cntPersonCard();
            button1 = new Button();
            lblTitleApp = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // cntPersonCard1
            // 
            cntPersonCard1.BackColor = SystemColors.ActiveCaptionText;
            cntPersonCard1.BackgroundImage = (Image)resources.GetObject("cntPersonCard1.BackgroundImage");
            cntPersonCard1.Location = new Point(4, 117);
            cntPersonCard1.Name = "cntPersonCard1";
            cntPersonCard1.Size = new Size(958, 445);
            cntPersonCard1.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(847, 583);
            button1.Name = "button1";
            button1.Size = new Size(91, 36);
            button1.TabIndex = 8;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblTitleApp
            // 
            lblTitleApp.AutoSize = true;
            lblTitleApp.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleApp.ForeColor = Color.FromArgb(151, 161, 176);
            lblTitleApp.Location = new Point(361, 31);
            lblTitleApp.Name = "lblTitleApp";
            lblTitleApp.Size = new Size(213, 32);
            lblTitleApp.TabIndex = 9;
            lblTitleApp.Text = "Person Details";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(440, 501);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(391, 228);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-120, -100);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(314, 242);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(862, -48);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(160, 170);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // frmShowPersonInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            CancelButton = button1;
            ClientSize = new Size(962, 641);
            Controls.Add(pictureBox3);
            Controls.Add(lblTitleApp);
            Controls.Add(button1);
            Controls.Add(cntPersonCard1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(200, 44);
            Name = "frmShowPersonInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmShowPersonInfo";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controles.cntPersonCard cntPersonCard1;
        private Button button1;
        private Label lblTitleApp;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}