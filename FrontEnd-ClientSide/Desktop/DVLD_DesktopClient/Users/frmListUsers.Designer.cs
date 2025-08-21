namespace DVLD_DesktopClient.Users
{
    partial class frmListUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListUsers));
            btnRefleshAll = new Button();
            label2 = new Label();
            lblRecordsCount = new Label();
            lblTitle = new Label();
            label3 = new Label();
            btnClose = new Button();
            cbFilterBy = new ComboBox();
            btnAddUser = new Button();
            dgvUsers = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showDetailsToolStripMenuItem = new ToolStripMenuItem();
            addNewUserToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            sendEmailToolStripMenuItem = new ToolStripMenuItem();
            phoneCallToolStripMenuItem = new ToolStripMenuItem();
            txtFilterValue = new TextBox();
            cbIsActive = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRefleshAll
            // 
            btnRefleshAll.BackColor = Color.FromArgb(74, 79, 99);
            btnRefleshAll.FlatStyle = FlatStyle.Flat;
            btnRefleshAll.ForeColor = Color.Transparent;
            btnRefleshAll.Image = (Image)resources.GetObject("btnRefleshAll.Image");
            btnRefleshAll.Location = new Point(893, 12);
            btnRefleshAll.Name = "btnRefleshAll";
            btnRefleshAll.Size = new Size(57, 37);
            btnRefleshAll.TabIndex = 25;
            btnRefleshAll.UseVisualStyleBackColor = false;
            btnRefleshAll.Click += btnRefleshAll_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(151, 161, 176);
            label2.Location = new Point(75, 602);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 24;
            label2.Text = "Records :";
            // 
            // lblRecordsCount
            // 
            lblRecordsCount.AutoSize = true;
            lblRecordsCount.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecordsCount.ForeColor = Color.Red;
            lblRecordsCount.Location = new Point(195, 602);
            lblRecordsCount.Name = "lblRecordsCount";
            lblRecordsCount.Size = new Size(32, 25);
            lblRecordsCount.TabIndex = 23;
            lblRecordsCount.Text = "?!";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(151, 161, 176);
            lblTitle.Location = new Point(359, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 32);
            lblTitle.TabIndex = 22;
            lblTitle.Text = "Manage users";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(151, 161, 176);
            label3.Location = new Point(75, 133);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 21;
            label3.Text = "Filter By :";
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(805, 601);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(91, 36);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // cbFilterBy
            // 
            cbFilterBy.BackColor = Color.FromArgb(74, 79, 99);
            cbFilterBy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFilterBy.ForeColor = SystemColors.Menu;
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "None", "User ID", "UserName", "Person ID", "Is Active" });
            cbFilterBy.Location = new Point(195, 133);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(169, 29);
            cbFilterBy.TabIndex = 19;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(74, 79, 99);
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.ForeColor = Color.Transparent;
            btnAddUser.Image = (Image)resources.GetObject("btnAddUser.Image");
            btnAddUser.Location = new Point(836, 126);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(57, 37);
            btnAddUser.TabIndex = 18;
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = Color.FromArgb(46, 51, 73);
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.ContextMenuStrip = contextMenuStrip1;
            dgvUsers.Location = new Point(74, 176);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(822, 409);
            dgvUsers.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showDetailsToolStripMenuItem, addNewUserToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem, changePasswordToolStripMenuItem, toolStripMenuItem1, sendEmailToolStripMenuItem, phoneCallToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(169, 164);
            // 
            // showDetailsToolStripMenuItem
            // 
            showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            showDetailsToolStripMenuItem.Size = new Size(168, 22);
            showDetailsToolStripMenuItem.Text = "&Show Details";
            showDetailsToolStripMenuItem.Click += showDetailsToolStripMenuItem_Click;
            // 
            // addNewUserToolStripMenuItem
            // 
            addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            addNewUserToolStripMenuItem.Size = new Size(168, 22);
            addNewUserToolStripMenuItem.Text = "Add &New User";
            addNewUserToolStripMenuItem.Click += addNewUserToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(168, 22);
            editToolStripMenuItem.Text = "&Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(168, 22);
            deleteToolStripMenuItem.Text = "&Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(168, 22);
            changePasswordToolStripMenuItem.Text = "Change &Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(165, 6);
            toolStripMenuItem1.Visible = false;
            // 
            // sendEmailToolStripMenuItem
            // 
            sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            sendEmailToolStripMenuItem.Size = new Size(168, 22);
            sendEmailToolStripMenuItem.Text = "Send E&mail";
            // 
            // phoneCallToolStripMenuItem
            // 
            phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            phoneCallToolStripMenuItem.Size = new Size(168, 22);
            phoneCallToolStripMenuItem.Text = "Phone &Call";
            // 
            // txtFilterValue
            // 
            txtFilterValue.BackColor = Color.FromArgb(74, 79, 99);
            txtFilterValue.BorderStyle = BorderStyle.None;
            txtFilterValue.Font = new Font("Andalus", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = SystemColors.ScrollBar;
            txtFilterValue.Location = new Point(381, 128);
            txtFilterValue.Multiline = true;
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "   Searsh for a Person...";
            txtFilterValue.Size = new Size(426, 37);
            txtFilterValue.TabIndex = 17;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            txtFilterValue.KeyPress += txtFilterValue_KeyPress;
            // 
            // cbIsActive
            // 
            cbIsActive.BackColor = Color.FromArgb(74, 79, 99);
            cbIsActive.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbIsActive.ForeColor = SystemColors.Menu;
            cbIsActive.FormattingEnabled = true;
            cbIsActive.Items.AddRange(new object[] { "All", "Yes", "No" });
            cbIsActive.Location = new Point(370, 133);
            cbIsActive.Name = "cbIsActive";
            cbIsActive.Size = new Size(146, 29);
            cbIsActive.TabIndex = 26;
            cbIsActive.SelectedIndexChanged += cbIsActive_SelectedIndexChanged;
            // 
            // frmListUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 0, 69);
            ClientSize = new Size(962, 649);
            Controls.Add(cbIsActive);
            Controls.Add(btnRefleshAll);
            Controls.Add(label2);
            Controls.Add(lblRecordsCount);
            Controls.Add(lblTitle);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(cbFilterBy);
            Controls.Add(btnAddUser);
            Controls.Add(dgvUsers);
            Controls.Add(txtFilterValue);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmListUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmListUsers";
            Load += frmListUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRefleshAll;
        private Label label2;
        private Label lblRecordsCount;
        private Label lblTitle;
        private Label label3;
        private Button btnClose;
        private ComboBox cbFilterBy;
        private Button btnAddUser;
        private DataGridView dgvUsers;
        private TextBox txtFilterValue;
        private ComboBox cbIsActive;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showDetailsToolStripMenuItem;
        private ToolStripMenuItem addNewUserToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem sendEmailToolStripMenuItem;
        private ToolStripMenuItem phoneCallToolStripMenuItem;
    }
}