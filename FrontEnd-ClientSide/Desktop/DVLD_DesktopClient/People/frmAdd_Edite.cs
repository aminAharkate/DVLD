using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//**



namespace DVLD_DesktopClient.Drivers
{
    public partial class frmAdd_Edite : Form
    {
        #region Attributes and constructoe + event
        public frmAdd_Edite(int? PersonID)
        {
            InitializeComponent();

            this._PersonID = PersonID;

            _Mode = PersonID == null ? clsGlobalSetting.EnMode.Add : _Mode = clsGlobalSetting.EnMode.Edit;

           // _HttpClient.BaseAddress = new Uri("http://localhost:5045/api/PersonAPI/");
        }
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        clsGlobalSetting.EnMode _Mode;

        private int? _PersonID;

       // readonly HttpClient _HttpClient = new HttpClient(); to delete 

        private clsDTOs.PersonDTO _Person;/*= new clsDTOs.PersonDTO(0, "", "", "", "", true, DateTime.Now, 0, "", "", "");*/

        #endregion


        #region _ResetDefualtValues

        #region GetAllCountries Fom Server

        #region change Person default Image
        private void _ChangeDefaulteMaleImage(bool isMalerdmCheack)
        {
            picbPersonImage.Image = isMalerdmCheack
                ? Properties.Resources.MaleDefault_Image_500
                : Properties.Resources.FemaleDefaulte_image_500;
        }
        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {

            //_ChangeDefaulteMaleImage(rdbMale.Checked);
        }
        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeDefaulteMaleImage(rdbMale.Checked);
        }
        #endregion
        //async Task _GetAllCountriesAsync()
        //{
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:5045/api/CountriesAPI/");
        //    try
        //    {
        //        var response = await httpClient.GetAsync("GetAllCoutries");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var countryList = await response.Content.ReadFromJsonAsync<List<clsDTOs.clsCountryDTO>>();

        //            if (countryList != null && countryList.Any()) // Check for null & empty list
        //            {
        //                cbCountry.DataSource = countryList;
        //                cbCountry.DisplayMember = "CountryName"; // Property to display
        //                cbCountry.ValueMember = "ID"; // Property to store the value
        //                                              //cbCountry.SelectedItem = "Morocco";
        //                                              //cbCountry.SelectedIndex = cbCountry.FindStringExact("Morocco");
        //                                              //cbCountry.SelectedValue = countryList.FirstOrDefault(c => c.CountryName == "Morocco")?.ID;

        //            }
        //            else
        //            {
        //                MessageBox.Show("No countries found.");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //        }
        //    }
        //    catch (HttpRequestException httpEx)
        //    {
        //        MessageBox.Show($"HTTP Error: {httpEx.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Unexpected Error: {ex.Message}");
        //    }

        //}

        #endregion

        private async Task _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            // u get the resoult but u do not fulling the combo box
            var CountriesList = await clsCountryAsync.GetAllCountriesAsync();
            if (CountriesList != null && CountriesList.Any()) 
            {
                            cbCountry.DataSource = CountriesList;
                            cbCountry.DisplayMember = "CountryName"; // Property to display
                            cbCountry.ValueMember = "ID"; // Property to store the value
                            cbCountry.SelectedItem = "Morocco";
                            cbCountry.SelectedIndex = cbCountry.FindStringExact("Morocco");
                            cbCountry.SelectedValue = CountriesList.FirstOrDefault(c => c.CountryName == "Morocco")?.ID;

            }
            else
            {
                MessageBox.Show("No countries found.");
            }

                if (_Mode == clsGlobalSetting.EnMode.Add)
            {
                lblChangeMode.Text = "Add New Person";
                _Person = new clsDTOs.PersonDTO(0, "", "", "", "", true, DateTime.Now, 0, "", "", ""); ;
            }
            else
            {
                lblChangeMode.Text = "Update Person";
            }

            _ChangeDefaulteMaleImage(rdbMale.Checked);

            //hide/show the remove linke incase there is no image for the person.
            btnRemeveImage.Visible = (picbPersonImage.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Morocco");

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationalID.Text = "";
            rdbMale.Checked = true;
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";


        }
        #endregion

        #region _LoadData from Server

        #region Get Person By ID From Server 
        //private async Task<clsDTOs.PersonDTO> _GetPersonByIDAsync(int personID)
        //{
        //    //HttpClient httpClient = new HttpClient();
        //    try
        //    {
        //        //var apiUrl = $"http://localhost:5045/api/PersonAPI/GetPersonByID/{personID}"; // Corrected URL
        //        var response = await _HttpClient.GetAsync($"GetPersonByID/{personID}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //            return null;
        //        }
        //    }
        //    catch (HttpRequestException httpEx)
        //    {
        //        MessageBox.Show($"HTTP Error: {httpEx.Message}");
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Unexpected Error: {ex.Message}");
        //        return null;
        //    }
        //}
        #endregion
        private async Task _LoadData()
        {

            _Person = await clsPersonAsync.GetPersonByIDAsync(_PersonID ?? 0);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtNationalID.Text = _Person.NationalID;
            // uncomment 
            //dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender)
                rdbMale.Checked = true;
            else
                rdbFemale.Checked = true;
            //rdbMale.Checked = _Person.Gender;
           // rdbMale.Checked = _Person.Gender ? true : false;


            txtAdress.Text = _Person.Address;
            txtPhoneNumber.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedValue = _Person.NationalityCountryID;


            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                picbPersonImage.ImageLocation = _Person.ImagePath;

            }

            //hide/show the remove linke incase there is no image for the person.
            btnRemeveImage.Visible = (_Person.ImagePath != "");

        }
        #endregion

        private async void frmAdd_Edite_Load_1(object sender, EventArgs e)
        {
            await _ResetDefualtValues();
            if (_Mode == clsGlobalSetting.EnMode.Edit)
                await _LoadData();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnSetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                picbPersonImage.Load(selectedFilePath);
                btnRemeveImage.Visible = true;
                // ...
            }
        }
        #region About Validation
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        //async Task<bool> isPersonExist(string NationalID)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:5045/api/PersonAPI/");
        //    try
        //    {
        //        var response = await httpClient.GetAsync($"IsPersonExist/{NationalID}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadFromJsonAsync<bool>();
        //        }
        //        else
        //        {
        //            MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //            return false;
        //        }
        //    }
        //    catch (HttpRequestException httpEx)
        //    {
        //        MessageBox.Show($"HTTP Error: {httpEx.Message}");
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Unexpected Error: {ex.Message}");
        //        return false;
        //    }
        //}

        private async void txtNationalID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalID.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalID.Text.Trim() != _Person.NationalID && await clsPersonAsync.isPersonExistAsync(txtNationalID.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);
            }
        }


        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            ;

        }
        #endregion


        #region Find Country by Name
        //private async Task<clsDTOs.clsCountryDTO> _FindCountryByNameAsync(string countryName)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:5045/api/CountriesAPI/");

        //    var response = await httpClient.GetAsync($"GetCountryByCountryName/{countryName}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadFromJsonAsync<clsDTOs.clsCountryDTO>();
        //    }
        //    else
        //    {
        //        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //        return null;
        //    }

        //}
        #endregion

        #region Add And Update Person 
        //private async Task<clsDTOs.PersonDTO> _AddNewPerson(clsDTOs.PersonDTO person)
        //{

        //    var response = await _HttpClient.PostAsJsonAsync("AddPerson", person);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var addedPerson = await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
        //        return addedPerson; // Return the added person
        //    }
        //    else
        //    {
        //        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //        return null;
        //    }

        //}
        //private async Task<clsDTOs.PersonDTO> _UpdatePerson(int perosnID)
        //{
        //    var response = await _HttpClient.PutAsJsonAsync($"UpdatePerson/{perosnID}", _Person);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var updatedPerson = await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
        //        return updatedPerson; // Return the updated person
        //    }
        //    else
        //    {
        //        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //        return null;
        //    }
        //}
        #endregion

        #region  _HandlePersonImage
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != picbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (picbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = picbPersonImage.ImageLocation.ToString();

                    if (clsUtility.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }

            return true;
        }

        #endregion
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;

            clsDTOs.clsCountryDTO NationalityCountryNameAndID = await clsCountryAsync.FindCountryByNameAsync(cbCountry.Text);

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalID = txtNationalID.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhoneNumber.Text.Trim();
            _Person.Address = txtAdress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;


            //_ChangeDefaulteMaleImage(rdbMale.Checked);
            _Person.Gender = rdbMale.Checked;
            _Person.NationalityCountryID = NationalityCountryNameAndID.ID;

            if (picbPersonImage.ImageLocation != null)
                _Person.ImagePath = picbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Mode == clsGlobalSetting.EnMode.Add)
            {
                _Person = await clsPersonAsync.AddNewPerson(_Person);
                _Mode = clsGlobalSetting.EnMode.Edit;
                lblPersonID.Text = _Person.PersonID.ToString();
                lblChangeMode.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DataBack?.Invoke(this, _Person.PersonID);
            }
            else if (_Mode == clsGlobalSetting.EnMode.Edit)
            {

                _Person = await clsPersonAsync.UpdatePerson(_Person.PersonID,_Person);
                DataBack?.Invoke(this, _Person.PersonID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, -1);
        }
    }
    #region class Country Data Transfer Object (DTO) [To Delete]
    //public class clsDTOs.clsCountryDTO
    //{
    //    public  int? ID { get; set; }
    //    public string CountryName { get; set; }
    //    public clsDTOs.clsCountryDTO(int? id, string countryName)
    //    {
    //        ID = id;
    //        CountryName = countryName;
    //    }
    //}
    #endregion

    #region class Person Data Transfer Object (DTO) [To Delete]
    //    public class clsDTOs.PersonDTO
    //{
    //    public clsDTOs.PersonDTO(int personID, string firstName, string lastName, string nationalID, string imagePath,
    //                     bool gender, DateTime dateOfBirth, int? nationalityCountryID, string phone, string email, string address)
    //    {
    //        this.PersonID = personID;
    //        this.FirstName = firstName;
    //        this.LastName = lastName;
    //        this.NationalID = nationalID;
    //        this.ImagePath = imagePath;
    //        this.Gender = gender;
    //        this.DateOfBirth = dateOfBirth;
    //        this.NationalityCountryID = nationalityCountryID;
    //        this.Phone = phone;
    //        this.Email = email;
    //        this.Address = address;
    //    }

    //    public int PersonID { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string NationalID { get; set; }
    //    public string ImagePath { get; set; }
    //    public bool Gender { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //    public int? NationalityCountryID { get; set; }
    //    public string Phone { get; set; }
    //    public string Email { get; set; }
    //    public string Address { get; set; }
    //}
    #endregion
}
