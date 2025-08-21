using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopClient.Users
{
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        #region button close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private DataTable ConvertToDataTable(List<clsDTOs.clsUserDTO> usersList)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("PersonID", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("IsActive", typeof(bool));

            foreach (var user in usersList)
            {
                dt.Rows.Add(user.userID, user.personID, user.userName, user.isActive);
            }

            return dt;
        }

        private async void frmListUsers_Load(object sender, EventArgs e)
        {
            List<clsDTOs.clsUserDTO> usersList = await clsUsersAsync.GetAllUsersAsync();
            _dtAllUsers = ConvertToDataTable(usersList);
            dgvUsers.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {

                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 210;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 210;


                dgvUsers.Columns[2].HeaderText = "UserName";
                dgvUsers.Columns[2].Width = 210;

                dgvUsers.Columns[3].HeaderText = "Is Active";
                dgvUsers.Columns[3].Width = 220;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                //case "Full Name":
                //    FilterColumn = "FullName";
                //    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if ( FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // complete form here

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsers Frm1 = new frmAddUpdateUsers(null);
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo Frm1 = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsers Frm1 = new frmAddUpdateUsers(null);
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUsers Frm1 = new frmAddUpdateUsers((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if (await clsUsersAsync.DeleteUserAsync(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(UserID);
            Frm1.ShowDialog();
        }

        private void btnRefleshAll_Click(object sender, EventArgs e)
        {
            frmListUsers_Load(null, null);

        }
    }
}
