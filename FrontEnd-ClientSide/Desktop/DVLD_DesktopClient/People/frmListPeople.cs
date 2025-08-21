using DVLD_DesktopClient.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopClient.People
{
    public partial class frmListPeople : Form
    {
        #region Load People Data Async
        // get all people asynchronously and convert it to data table 
        private static Task<DataTable> _dtAllPeople = GetAllPeopleDataTableAsync();
        private static async Task<DataTable> GetAllPeopleDataTableAsync()
        {
            // Ensure clsPersonAsync is used instead of clsPerson  
            var peopleList = await clsPersonAsync.GetAllPeopleAsync(); // Await the task  
            if (peopleList == null || peopleList.Count == 0) return new DataTable(); // Handle null case  

            DataTable dt = new DataTable();
            dt.Columns.Add("PersonID", typeof(int));
            dt.Columns.Add("NationalID", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dt.Columns.Add("CountryName", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Email", typeof(string));

            foreach (var person in peopleList)
            {
                var CountryInfo = await clsCountryAsync.FindCountryByIDAsync(person.NationalityCountryID); // Ensure async call is awaited  

                string gender = person.Gender == true ? "Male" : "Female";
                dt.Rows.Add(person.PersonID, person.NationalID, person.FirstName,
                            person.LastName, gender, person.DateOfBirth, CountryInfo.CountryName,
                            person.Phone, person.Email);
            }

            return dt;
        }

        private DataTable _dtPeople;
        private async void LoadPeopleDataAsync()
        {
            _dtPeople = await _dtAllPeople;
            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 90;

                dgvPeople.Columns[1].HeaderText = "NationalID";
                dgvPeople.Columns[1].Width = 90;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 90;



                dgvPeople.Columns[3].HeaderText = "Last Name";
                dgvPeople.Columns[3].Width = 90;

                dgvPeople.Columns[4].HeaderText = "Gender";
                dgvPeople.Columns[4].Width = 70;

                dgvPeople.Columns[5].HeaderText = "DateOfBirth";
                dgvPeople.Columns[5].Width = 90;

                dgvPeople.Columns[6].HeaderText = "Nationality";
                dgvPeople.Columns[6].Width = 80;


                dgvPeople.Columns[7].HeaderText = "Phone";
                dgvPeople.Columns[7].Width = 90;


                dgvPeople.Columns[8].HeaderText = "Email";
                dgvPeople.Columns[8].Width = 150;
            }
        }
        #endregion
        public frmListPeople()
        {
            InitializeComponent();
            LoadPeopleDataAsync();
        }

        #region _Refresh People List
        private async void _RefreshPeoplList()
        {
            _dtAllPeople = GetAllPeopleDataTableAsync();
            dgvPeople.DataSource = await _dtAllPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }
        #endregion
        private void frmListPeople_Load(object sender, EventArgs e)
        {
        }






        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmAdd_Edite((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            // _RefreshPeoplList();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var isDeleted = await clsPersonAsync.DeletePersonAsync((int)dgvPeople.CurrentRow.Cells[0].Value); // Ensure async call is awaited  
                // Perform Delete and refresh  
                if (isDeleted)
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAdd_Edite(null);
            frm.ShowDialog();

            _RefreshPeoplList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAdd_Edite(null);
            frm1.ShowDialog();
            //_RefreshPeoplList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National ID":
                    FilterColumn = "NationalID";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void PersonAddedDataBack(object sender, int personID)
        {
            if (personID == -1)
            {
                _RefreshPeoplList();
                //LoadPeopleDataAsync(); 
                //lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
            }
        }
        private void btnAddPerson_Click_1(object sender, EventArgs e)
        {
            frmAdd_Edite frm = new frmAdd_Edite(null);
            frm.DataBack += PersonAddedDataBack;
            frm.ShowDialog();

        }
        #region re-open form event
        public delegate void ReOpenFormEventHandler(Form frm);
        public event ReOpenFormEventHandler ReOpenFormEvent;
        private void button2_Click(object sender, EventArgs e)
        {
            ReOpenFormEvent?.Invoke(new frmListPeople());
        }
        #endregion

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showDetelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAdd_Edite(-1);
            frm.ShowDialog();

            _RefreshPeoplList();
        }

        private void editePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAdd_Edite((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeoplList();
        }

        private async void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (await clsPersonAsync.DeletePersonAsync((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
