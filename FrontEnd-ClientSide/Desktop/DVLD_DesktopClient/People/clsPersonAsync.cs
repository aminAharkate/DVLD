using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DesktopClient.People
{
    public  class clsPersonAsync
    {
        //static   HttpClient httpClient = new HttpClient();
        clsGlobalSetting.EnMode _Mode = clsGlobalSetting.EnMode.Add;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        public string NationalID { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        public Task<clsDTOs.clsCountryDTO> CountryInfo;

        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        public  clsPersonAsync(int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, string NationalNo, DateTime DateOfBirth, short Gendor,
             string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NationalID = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountryAsync.FindCountryByIDAsync(NationalityCountryID);
            _Mode = clsGlobalSetting.EnMode.Edit;
        }

        //public clsPersonAsync() 
        //{
        //    httpClient.BaseAddress = new Uri("http://localhost:5045/api/PersonAPI/"); 
        //}


        #region Get Person By ID From Server 
        public static  async Task<clsDTOs.PersonDTO> GetPersonByIDAsync(int personID)
        {
            var response = await clsGlobalSetting.httpClient.GetAsync($"PersonAPI/GetPersonByID/{personID}");

            //var response = await new HttpClient { BaseAddress =new Uri("http://localhost:5045/api/PersonAPI/") }.GetAsync($"GetPersonByID/{personID}");
            if (response.IsSuccessStatusCode)
                {
                   return await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
                }
                else
                {
                   return null;
                }
            //var response = await new HttpClient().GetAsync($"http://localhost:5045/api/LicenseClassAsyncAPI/GetLicenseClassInfoByClassNameAsync/{ClassName}");

        }
        #endregion

        #region Get Person By National ID From Server 
        public static async Task<clsDTOs.PersonDTO> GetPersonByNationalIDAsync(string  NationalID)
            {
                var response = await clsGlobalSetting.httpClient.GetAsync($"PersonAPI/GetPersonByNationalID/{NationalID}");
                //var response = await httpClient.GetAsync($"http://localhost:5045/api/PersonAPI/GetPersonByNationalID/{NationalID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
                }
                else
                {
                    return null;
                }

            }
        #endregion

        #region is person Exist
        public static async Task<bool> isPersonExistAsync(string NationalID)
            {
                var response = await clsGlobalSetting.httpClient.GetAsync($"PersonAPI/IsPersonExist/{NationalID}");
                //var response = await httpClient.GetAsync($"http://localhost:5045/api/PersonAPI/IsPersonExist/{NationalID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
                }
                else
                {
                    return false;
                }
            
            }
        #endregion

        #region Add Person 
            public static  async Task<clsDTOs.PersonDTO> AddNewPerson(clsDTOs.PersonDTO person)
            {
                var response = await clsGlobalSetting.httpClient.PostAsJsonAsync("PersonAPI/AddPerson", person);
            //var response = await httpClient.PostAsJsonAsync("http://localhost:5045/api/PersonAPI/AddPerson", person);
            if (response.IsSuccessStatusCode)
                {
                    var addedPerson = await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
                    return addedPerson; // Return the added person
                }
                else
                {
                    return null;
                }

            }
        #endregion

        #region  Update Person
            public static  async Task<clsDTOs.PersonDTO> UpdatePerson(int perosnID,clsDTOs.PersonDTO _Person)
            {
                var response = await clsGlobalSetting.httpClient.PutAsJsonAsync($"PersonAPI/UpdatePerson/{perosnID}", _Person);
            //var response = await httpClient.PutAsJsonAsync($"http://localhost:5045/api/PersonAPI/UpdatePerson/{perosnID}", _Person);
            if (response.IsSuccessStatusCode)
                {
                    var updatedPerson = await response.Content.ReadFromJsonAsync<clsDTOs.PersonDTO>();
                    return updatedPerson; // Return the updated person
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        #endregion

        #region Get All people
            public static async Task<List<clsDTOs.PersonDTO>> GetAllPeopleAsync()
            {
                var response = await clsGlobalSetting.httpClient.GetAsync("PersonAPI/AllPeople");
                //var response = await httpClient.GetAsync("http://localhost:5045/api/PersonAPI/AllPeople");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<clsDTOs.PersonDTO>>();
                }
                else
                {
                    return null;
                }
            }
        #endregion

        #region Delete Person
            public static async Task<bool> DeletePersonAsync(int personID)
            {
                var response = await clsGlobalSetting.httpClient.DeleteAsync($"PersonAPI/DeletePerson?id={personID}");
                //var response = await httpClient.DeleteAsync($"http://localhost:5045/api/PersonAPI/DeletePerson?id={personID}");
                if (response.IsSuccessStatusCode)
                {
                    return true; // Person deleted successfully
                }
                else
                {
                    return false; // Failed to delete person
                }
            }
        #endregion
    }
}
// ******************************************************************************************==Try to Use Dependency Injection ==*******************************************************************