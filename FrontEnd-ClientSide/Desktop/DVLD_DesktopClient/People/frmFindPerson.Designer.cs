namespace DVLD_DesktopClient.People
{
    partial class frmFindPerson
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
            ctrlPersonCardWithFilter1 = new DVLD_DesktopClient.People.Controles.ctrlPersonCardWithFilter();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblTitleApp
            // 
            lblTitleApp.AutoSize = true;
            lblTitleApp.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleApp.ForeColor = Color.FromArgb(151, 161, 176);
            lblTitleApp.Location = new Point(376, 9);
            lblTitleApp.Name = "lblTitleApp";
            lblTitleApp.Size = new Size(178, 32);
            lblTitleApp.TabIndex = 5;
            lblTitleApp.Text = "Find Person";
            // 
            // ctrlPersonCardWithFilter1
            // 
            ctrlPersonCardWithFilter1.BackColor = Color.FromArgb(12, 0, 69);
            ctrlPersonCardWithFilter1.Dock = DockStyle.Bottom;
            ctrlPersonCardWithFilter1.FilterEnabled = true;
            ctrlPersonCardWithFilter1.Location = new Point(0, 56);
            ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            ctrlPersonCardWithFilter1.ShowAddPerson = true;
            ctrlPersonCardWithFilter1.Size = new Size(978, 632);
            ctrlPersonCardWithFilter1.TabIndex = 6;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(864, 635);
            button1.Name = "button1";
            button1.Size = new Size(91, 36);
            button1.TabIndex = 7;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmFindPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(978, 688);
            Controls.Add(button1);
            Controls.Add(ctrlPersonCardWithFilter1);
            Controls.Add(lblTitleApp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmFindPerson";
            Text = "frmFindPerson";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitleApp;
        private Controles.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private Button button1;
    }
}