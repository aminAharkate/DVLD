namespace DVLD_DesktopClient.People.Controles
{
    partial class ctrlPersonCardWithFilter
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCardWithFilter));
            cntPersonCard1 = new cntPersonCard();
            txtFilterValue = new TextBox();
            btnFind = new Button();
            btnAddPerson = new Button();
            gbFilter = new GroupBox();
            cbFilterBy = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cntPersonCard1
            // 
            cntPersonCard1.BackColor = SystemColors.ActiveCaptionText;
            cntPersonCard1.BackgroundImage = (Image)resources.GetObject("cntPersonCard1.BackgroundImage");
            cntPersonCard1.Location = new Point(24, 132);
            cntPersonCard1.Name = "cntPersonCard1";
            cntPersonCard1.Size = new Size(935, 420);
            cntPersonCard1.TabIndex = 0;
            // 
            // txtFilterValue
            // 
            txtFilterValue.BackColor = Color.FromArgb(74, 79, 99);
            txtFilterValue.BorderStyle = BorderStyle.None;
            txtFilterValue.Font = new Font("Andalus", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFilterValue.ForeColor = SystemColors.ScrollBar;
            txtFilterValue.Location = new Point(239, 16);
            txtFilterValue.Multiline = true;
            txtFilterValue.Name = "txtFilterValue";
            txtFilterValue.PlaceholderText = "   Searsh for a Person...";
            txtFilterValue.Size = new Size(511, 37);
            txtFilterValue.TabIndex = 3;
            txtFilterValue.Validating += txtFilterValue_Validating;
            // 
            // btnFind
            // 
            btnFind.BackColor = Color.FromArgb(74, 79, 99);
            btnFind.FlatStyle = FlatStyle.Flat;
            btnFind.ForeColor = Color.Transparent;
            btnFind.Image = (Image)resources.GetObject("btnFind.Image");
            btnFind.Location = new Point(765, 16);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(57, 37);
            btnFind.TabIndex = 4;
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // btnAddPerson
            // 
            btnAddPerson.BackColor = Color.FromArgb(74, 79, 99);
            btnAddPerson.FlatStyle = FlatStyle.Flat;
            btnAddPerson.ForeColor = Color.Transparent;
            btnAddPerson.Image = (Image)resources.GetObject("btnAddPerson.Image");
            btnAddPerson.Location = new Point(834, 16);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(57, 37);
            btnAddPerson.TabIndex = 5;
            btnAddPerson.UseVisualStyleBackColor = false;
            btnAddPerson.Click += btnAddPerson_Click;
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(cbFilterBy);
            gbFilter.Controls.Add(btnFind);
            gbFilter.Controls.Add(btnAddPerson);
            gbFilter.Controls.Add(txtFilterValue);
            gbFilter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbFilter.ForeColor = Color.White;
            gbFilter.Location = new Point(24, 35);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(935, 59);
            gbFilter.TabIndex = 6;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter:";
            // 
            // cbFilterBy
            // 
            cbFilterBy.BackColor = Color.FromArgb(74, 79, 99);
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Items.AddRange(new object[] { "By Person ID", "By National ID" });
            cbFilterBy.Location = new Point(76, 22);
            cbFilterBy.Name = "cbFilterBy";
            cbFilterBy.Size = new Size(131, 29);
            cbFilterBy.TabIndex = 7;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(gbFilter);
            Controls.Add(cntPersonCard1);
            Name = "ctrlPersonCardWithFilter";
            Size = new Size(978, 662);
            Load += ctrlPersonCardWithFilter_Load;
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private cntPersonCard cntPersonCard1;
        private TextBox txtFilterValue;
        private Button btnFind;
        private Button btnAddPerson;
        private GroupBox gbFilter;
        private ComboBox cbFilterBy;
        private ErrorProvider errorProvider1;
    }
}
