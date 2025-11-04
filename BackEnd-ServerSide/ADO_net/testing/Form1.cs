using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using System.Data;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using static DVLD_DataAccessLayer.clsGlobalSetting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // working
            // dataGridView1.DataSource = clsPerson_BL.GetAllPersons();
            //dataGridView1.DataSource = clsLocalDrivingLicenseApplication_DAL.TryGetAllLocalDrivingLicenseApplicationsAsync();
            //dataGridView1.DataSource = await clsTestAsync_BL.GetAllTestsAsync();
            dataGridView1.DataSource = await clsDriverAsync_BL.GetAllDriversAsync();

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            
           var dto= await clsDriverAsync_BL.GetDriverInfoByDriverIDAsync(8);
            if (dto != null)
            {
                MessageBox.Show($"Person found:{dto.CreatedDate}  {dto.PersonID}");
            }
            else
            {
                MessageBox.Show("Person not found.");
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
           // await clsTestAppointment_BL.AddTestAppointmentAsync(appointmentDTO)
            clsTestAppointmentDTO DTO = new clsTestAppointmentDTO(0, 3, 41,DateTime.Now,1,1,true,null);
;           
            int id = await DVLD_BusinessLayer.clsTestAppointment_BL.AddTestAppointmentAsync(DTO);
            MessageBox.Show($"Xxx added. {id}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async  void button1_Click(object sender, EventArgs e)
        {
            
            DriverDTO dto = new DriverDTO(15,1069,1,DateTime.Now);
            //clsDriverAsync_BL clsDriverAsync_BL = new clsDriverAsync_BL();
            if (await clsDriverAsync_BL.UpdateDriverAsync( dto))
            {
                MessageBox.Show($"Person update. {dto.PersonID}");
            }
            else
            {
                MessageBox.Show("Person does not update.");
            }
        }

        private  async void button3_Click(object sender, EventArgs e)
        {
            //if (clsPerson_BL.DeletePerson(10310))
            if(await clsLocalDrivingLicenseApplication_DAL.TryDeleteLocalDrivingLicenseApplicationAsync(46))
            {
                MessageBox.Show("Person deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete person.");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // working
            //dataGridView1.DataSource = clsCountry_BL.GetAllCountries();
            // var dtCountries = clsCountry_BL.GetAllCountries();
            _FillComboBox(comboBox1);


        }
        #region working for the desgin
        private void _FillComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = clsCountry_BL.GetAllCountries();
            comboBox.DisplayMember = "CountryName"; // Property to display
            comboBox.ValueMember = "ID"; // Property to store the value
        }
        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            var selectedCountry = clsCountry_BL.Find("Niger");
            if (selectedCountry != null)
            {
                MessageBox.Show($"Country found: {selectedCountry.CountryName}");
            }
            else
            {
                MessageBox.Show("Country not found.");
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            bool var = await clsApplication_BL.DeleteApplicationAsync(131);
            MessageBox.Show(var ? "Application deleted successfully." : "Failed to delete application.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
