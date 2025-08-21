using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;

namespace DVLD_DesktopClient.Applications.ApplicationTypes
{
    public   class clsApplicationTypeAsync
    {
        static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/ApplicationType/") };
        clsGlobalSetting.EnMode _Mode = clsGlobalSetting.EnMode.Add;
        public clsApplicationTypeDTO _AYDTO;
        public clsApplicationTypeAsync(clsApplicationTypeDTO _AYDTO , clsGlobalSetting.EnMode Mode)

        {
            this._AYDTO.ApplicationTypeID = _AYDTO.ApplicationTypeID;
            this._AYDTO.ApplicationTypeTitle = _AYDTO.ApplicationTypeTitle;
            this._AYDTO.ApplicationTypeFees = _AYDTO.ApplicationTypeFees;
            _Mode = Mode;
        }


        #region Get All Application Types Async
        public static async Task<List<clsDTOs.clsApplicationTypeDTO>> GetAllApplicationTypesAsync()
        {
            try
            {
                Console.WriteLine("\nFetching all application types...\n");
                var response = await _httpClient.GetAsync("GetAllApplicationTypes");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<clsDTOs.clsApplicationTypeDTO>>() ?? new List<clsDTOs.clsApplicationTypeDTO>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("No application types found.");
                    return new List<clsDTOs.clsApplicationTypeDTO>(); // Prevents returning null
                }

                throw new HttpRequestException($"Unexpected response: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new HttpRequestException($"Error fetching application types", ex);
            }
        }
        #endregion

        #region Get Application Type By ID Async
        public static async Task<clsDTOs.clsApplicationTypeDTO?> GetApplicationTypeByIDAsync(int id)
        {
            try
            {
                Console.WriteLine($"\nFetching application type with ID: {id}...\n");
                var response = await _httpClient.GetAsync($"GetApplicationTypeByID/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<clsDTOs.clsApplicationTypeDTO>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Application type with ID {id} not found.");
                    return null; // Prevents returning null
                }
                throw new HttpRequestException($"Unexpected response: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new HttpRequestException($"Error fetching application type by ID", ex);
            }
        }
        #endregion

        #region Find
        public static async Task<clsDTOs.clsApplicationTypeDTO?> Find(int id)
        {
            try
            {
                Console.WriteLine($"\nFetching application type with ID: {id}...\n");
                var response = await _httpClient.GetAsync($"GetApplicationTypeByID/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<clsDTOs.clsApplicationTypeDTO>();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"Application type with ID {id} not found.");
                    return null; // Prevents returning null
                }
                throw new HttpRequestException($"Unexpected response: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new HttpRequestException($"Error fetching application type by ID", ex);
            }

        }
        #endregion

        #region static  Update Application Type async
        public static async Task<bool> UpdateApplicationTypeAsync(int id, clsDTOs.clsApplicationTypeDTO applicationType)
        {
            try
            {
                //Console.WriteLine($"\nUpdating application type with ID: {applicationType.ApplicationTypeID}...\n");
                var response = await _httpClient.PutAsJsonAsync($"UpdateApplicationType/{id}", applicationType);
                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("Application type updated successfully.");
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                   // Console.WriteLine($"Application type with ID {id} not found.");
                    return false; // Prevents returning null
                }
                throw new HttpRequestException($"Unexpected response: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new HttpRequestException($"Error updating application type", ex);
            }
        }
        #endregion

        #region Update Application Type async
        private  async Task<bool> _UpdateApplicationTypeAsync()
        {
            try
            {
                //Console.WriteLine($"\nUpdating application type with ID: {applicationType.ApplicationTypeID}...\n");
                var response = await _httpClient.PutAsJsonAsync($"UpdateApplicationType/{_AYDTO.ApplicationTypeID}", _AYDTO);
                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("Application type updated successfully.");
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Console.WriteLine($"Application type with ID {id} not found.");
                    return false; // Prevents returning null
                }
                throw new HttpRequestException($"Unexpected response: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new HttpRequestException($"Error updating application type", ex);
            }
        }
        #endregion

        #region add new Applicatin Type Async
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            //this.ID = clsApplicationTypeData.AddNewApplicationType(this.Title, this.Fees);


            //return (this.ID != -1);
            return true;
        }
        #endregion

        #region save Application Type Async
        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case clsGlobalSetting.EnMode.Add:
                    if (_AddNewApplicationType())
                    {

                        _Mode = clsGlobalSetting.EnMode.Edit;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case clsGlobalSetting.EnMode.Edit:

                    return await _UpdateApplicationTypeAsync();

            }

            return false;
        }
        #endregion
    }
}














