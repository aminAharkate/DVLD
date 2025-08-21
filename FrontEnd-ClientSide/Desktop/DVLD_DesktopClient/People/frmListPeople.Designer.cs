namespace DVLD_DesktopClient.People
{
    partial class frmListPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPeople));
            dgvPeople = new DataGridView();
            cmsPeople = new ContextMenuStrip(components);
            showDetelsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            addNewPersonToolStripMenuItem = new ToolStripMenuItem();
            editePersonToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            sendEmailToolStripMenuItem = new ToolStripMenuItem();
            phoneToolStripMenuItem = new ToolStripMenuItem();
            cbFilterBy = new ComboBox();
            txtFilterValue = new TextBox();
            btnAddPerson = new Button();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            lblRecordsCount = new Label();
            label2 = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvPeople).BeginInit();
            cmsPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dgvPeople
            // 
            dgvPeople.AllowUserToAddRows = false;
            dgvPeople.AllowUserToDeleteRows = false;
            dgvPeople.BackgroundColor = Color.FromArgb(46, 51, 73);
            dgvPeople.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeople.ContextMenuStrip = cmsPeople;
            dgvPeople.GridColor = Color.FromArgb(46, 51, 73);
            resources.ApplyResources(dgvPeople, "dgvPeople");
            dgvPeople.Name = "dgvPeople";
            dgvPeople.ReadOnly = true;
            dgvPeople.DoubleClick += dgvPeople_DoubleClick;
            // 
            // cmsPeople
            // 
            cmsPeople.Items.AddRange(new ToolStripItem[] { showDetelsToolStripMenuItem, toolStripMenuItem1, addNewPersonToolStripMenuItem, editePersonToolStripMenuItem, deleteToolStripMenuItem, toolStripMenuItem2, sendEmailToolStripMenuItem, phoneToolStripMenuItem });
            cmsPeople.Name = "cmsPeople";
            resources.ApplyResources(cmsPeople, "cmsPeople");
            // 
            // showDetelsToolStripMenuItem
            // 
            showDetelsToolStripMenuItem.Name = "showDetelsToolStripMenuItem";
            resources.ApplyResources(showDetelsToolStripMenuItem, "showDetelsToolStripMenuItem");
            showDetelsToolStripMenuItem.Click += showDetelsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // addNewPersonToolStripMenuItem
            // 
            addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            resources.ApplyResources(addNewPersonToolStripMenuItem, "addNewPersonToolStripMenuItem");
            addNewPersonToolStripMenuItem.Click += addNewPersonToolStripMenuItem_Click;
            // 
            // editePersonToolStripMenuItem
            // 
            editePersonToolStripMenuItem.Name = "editePersonToolStripMenuItem";
            resources.ApplyResources(editePersonToolStripMenuItem, "editePersonToolStripMenuItem");
            editePersonToolStripMenuItem.Click += editePersonToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(deleteToolStripMenuItem, "deleteToolStripMenuItem");
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click_1;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            resources.ApplyResources(sendEmailToolStripMenuItem, "sendEmailToolStripMenuItem");
            // 
            // phoneToolStripMenuItem
            // 
            phoneToolStripMenuItem.Name = "phoneToolStripMenuItem";
            resources.ApplyResources(phoneToolStripMenuItem, "phoneToolStripMenuItem");
            // 
            // cbFilterBy
            // 
            cbFilterBy.BackColor = Color.FromArgb(74, 79, 99);
            resources.ApplyResources(cbFilterBy, "cbFilterBy");
            cbFilterBy.ForeColor = SystemColors.Menu;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { resources.GetString("cbFilterBy.Items"), resources.GetString("cbFilterBy.Items1"), resources.GetString("cbFilterBy.Items2"), resources.GetString("cbFilterBy.Items3"), resources.GetString("cbFilterBy.Items4"), resources.GetString("cbFilterBy.Items5"), resources.GetString("cbFilterBy.Items6"), resources.GetString("cbFilterBy.Items7"), resources.GetString("cbFilterBy.Items8") });
            cbFilterBy.Name = "cbFilterBy";
            // 
            // txtFilterValue
            // 
            txtFilterValue.BackColor = Color.FromArgb(74, 79, 99);
            txtFilterValue.BorderStyle = BorderStyle.None;
            resources.ApplyResources(txtFilterValue, "txtFilterValue");
            txtFilterValue.ForeColor = SystemColors.ScrollBar;
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // btnAddPerson
            // 
            btnAddPerson.BackColor = Color.FromArgb(74, 79, 99);
            resources.ApplyResources(btnAddPerson, "btnAddPerson");
            btnAddPerson.ForeColor = Color.Transparent;
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.UseVisualStyleBackColor = false;
            btnAddPerson.Click += btnAddPerson_Click_1;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.ForeColor = Color.Red;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.FromArgb(151, 161, 176);
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = Color.FromArgb(151, 161, 176);
            label4.Name = "label4";
            // 
            // lblRecordsCount
            // 
            resources.ApplyResources(lblRecordsCount, "lblRecordsCount");
            lblRecordsCount.ForeColor = Color.Red;
            lblRecordsCount.Name = "lblRecordsCount";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(151, 161, 176);
            label2.Name = "label2";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(74, 79, 99);
            resources.ApplyResources(button2, "button2");
            button2.ForeColor = Color.Transparent;
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // frmListPeople
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(lblRecordsCount);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(cbFilterBy);
            Controls.Add(btnAddPerson);
            Controls.Add(dgvPeople);
            Controls.Add(txtFilterValue);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmListPeople";
            Load += frmListPeople_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPeople).EndInit();
            cmsPeople.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPeople;
        private ComboBox cbFilterBy;
        private TextBox txtFilterValue;
        private Button btnAddPerson;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label lblRecordsCount;
        private Label label2;
        private ContextMenuStrip cmsPeople;
        private ToolStripMenuItem showDetelsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem addNewPersonToolStripMenuItem;
        private ToolStripMenuItem editePersonToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem sendEmailToolStripMenuItem;
        private ToolStripMenuItem phoneToolStripMenuItem;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}