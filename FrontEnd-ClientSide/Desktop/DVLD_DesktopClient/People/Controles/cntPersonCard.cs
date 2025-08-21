using DVLD_DesktopClient.Drivers;
using DVLD_DesktopClient.GlobalClasses;
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

namespace DVLD_DesktopClient.People.Controles
{
    public partial class cntPersonCard : UserControl
    {
        private clsDTOs.PersonDTO _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsDTOs.PersonDTO SelectedPersonInfo
        {
            get { return _Person; }
        }
        public string GetPersonFirstName()
        {
            return _Person?.FirstName ?? "No data available";
        }
        public cntPersonCard()
        {
            InitializeComponent();
        }
        #region load person info by ID or National No.
        private void _LoadPersonImage()
        {

            //if (_Person.Gender == true)
            //    picbPersonImage.Image = Resources.MaleDefaultImage;
            //else
            //    picbPersonImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    picbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private async void _FillPersonInfo()
        {
            btnEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalID.Text = _Person.NationalID;
            lblFullName.Text = _Person.FirstName+ " " + _Person.LastName;
            lblGender.Text = _Person.Gender == true ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDate.Text = _Person.DateOfBirth.ToShortDateString();
            var countryDTO = await clsCountryAsync.FindCountryByIDAsync(_Person.NationalityCountryID); //clsCountry.Find(_Person.NationalityCountryID).CountryName
            lblCountry.Text = countryDTO.CountryName;
            lblAdress.Text = _Person.Address;
            _LoadPersonImage();
        }
        public async void LoadPersonInfo(int personID)
        {
            _Person = await clsPersonAsync.GetPersonByIDAsync(personID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with ID  = " + personID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public async void LoadPersonInfo(string NationalNo)
        {
            _Person = await clsPersonAsync.GetPersonByNationalIDAsync(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }
        #endregion




        



        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalID.Text = "[????]";
            lblFullName.Text = "[????]";

            picbPersonImage.Image = Properties.Resources.MaleDefault_Image_500;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDate.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAdress.Text = "[????]";
            picbPersonImage.Image = Properties.Resources.MaleDefault_Image_500;
            
              

        }
        private void btnEditPersonInfo_Click(object sender, EventArgs e)
        {
            frmAdd_Edite frm = new frmAdd_Edite(_PersonID);
            frm.ShowDialog();
            // handle showing form
            //refresh
            LoadPersonInfo(_PersonID);
        }
    }
}
