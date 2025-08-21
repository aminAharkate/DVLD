namespace DVLD_DesktopClient.Test
{
    partial class frmTakeTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakeTest));
            pbTestTypeImage = new PictureBox();
            lblTitle = new Label();
            ctrlSecheduledTest1 = new DVLD_DesktopClient.Test.Controls.ctrlSecheduledTest();
            lblUserMessage = new Label();
            label2 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            label1 = new Label();
            rbPass = new RadioButton();
            txtNotes = new TextBox();
            rbFail = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).BeginInit();
            SuspendLayout();
            // 
            // pbTestTypeImage
            // 
            pbTestTypeImage.Image = (Image)resources.GetObject("pbTestTypeImage.Image");
            pbTestTypeImage.Location = new Point(242, -3);
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
            lblTitle.Location = new Point(334, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(209, 32);
            lblTitle.TabIndex = 25;
            lblTitle.Text = "Schedule Test";
            // 
            // ctrlSecheduledTest1
            // 
            ctrlSecheduledTest1.BackColor = Color.FromArgb(12, 0, 69);
            ctrlSecheduledTest1.Location = new Point(41, 58);
            ctrlSecheduledTest1.Name = "ctrlSecheduledTest1";
            ctrlSecheduledTest1.Size = new Size(796, 277);
            ctrlSecheduledTest1.TabIndex = 26;
            // 
            // lblUserMessage
            // 
            lblUserMessage.AutoSize = true;
            lblUserMessage.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserMessage.ForeColor = Color.Red;
            lblUserMessage.ImeMode = ImeMode.NoControl;
            lblUserMessage.Location = new Point(236, 339);
            lblUserMessage.Name = "lblUserMessage";
            lblUserMessage.Size = new Size(628, 29);
            lblUserMessage.TabIndex = 27;
            lblUserMessage.Text = "Cannot Sechule, Vision Test Should be Passed First.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(223, 50, 197);
            label2.Location = new Point(12, 338);
            label2.Name = "label2";
            label2.Size = new Size(82, 28);
            label2.TabIndex = 28;
            label2.Text = "Result :";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(535, 454);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 38);
            btnClose.TabIndex = 71;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnSave.ForeColor = Color.Lime;
            btnSave.ImeMode = ImeMode.NoControl;
            btnSave.Location = new Point(694, 454);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(136, 38);
            btnSave.TabIndex = 72;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(223, 50, 197);
            label1.Location = new Point(12, 391);
            label1.Name = "label1";
            label1.Size = new Size(121, 28);
            label1.TabIndex = 73;
            label1.Text = "D.L.App.ID :";
            // 
            // rbPass
            // 
            rbPass.AutoSize = true;
            rbPass.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbPass.ForeColor = Color.FromArgb(223, 50, 197);
            rbPass.Location = new Point(100, 335);
            rbPass.Name = "rbPass";
            rbPass.Size = new Size(72, 34);
            rbPass.TabIndex = 74;
            rbPass.TabStop = true;
            rbPass.Text = "Pass";
            rbPass.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.FromArgb(74, 79, 99);
            txtNotes.BorderStyle = BorderStyle.None;
            txtNotes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNotes.ForeColor = Color.FromArgb(223, 50, 197);
            txtNotes.Location = new Point(139, 395);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = " Enter ur Notes Here...";
            txtNotes.Size = new Size(691, 28);
            txtNotes.TabIndex = 76;
            // 
            // rbFail
            // 
            rbFail.AutoSize = true;
            rbFail.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbFail.ForeColor = Color.FromArgb(223, 50, 197);
            rbFail.Location = new Point(178, 335);
            rbFail.Name = "rbFail";
            rbFail.Size = new Size(64, 34);
            rbFail.TabIndex = 77;
            rbFail.TabStop = true;
            rbFail.Text = "Fail";
            rbFail.UseVisualStyleBackColor = true;
            // 
            // frmTakeTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(862, 519);
            Controls.Add(rbFail);
            Controls.Add(txtNotes);
            Controls.Add(rbPass);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(label2);
            Controls.Add(lblUserMessage);
            Controls.Add(ctrlSecheduledTest1);
            Controls.Add(pbTestTypeImage);
            Controls.Add(lblTitle);
            Name = "frmTakeTest";
            Text = "frmTakeTest";
            Load += frmTakeTest_Load;
            ((System.ComponentModel.ISupportInitialize)pbTestTypeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbTestTypeImage;
        private Label lblTitle;
        private Controls.ctrlSecheduledTest ctrlSecheduledTest1;
        private Label lblUserMessage;
        private Label label2;
        private Button btnClose;
        private Button btnSave;
        private Label label1;
        private RadioButton rbPass;
        private TextBox txtNotes;
        private RadioButton rbFail;
    }
}