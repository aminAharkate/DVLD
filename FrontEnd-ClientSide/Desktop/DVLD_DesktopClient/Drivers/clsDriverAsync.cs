using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.Licenses;
using DVLD_DesktopClient.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Drivers
{
    public class clsDriverAsync
    {

        // public clsGlobalSetting.EnMode _Mode = clsGlobalSetting.EnMode.Add;
        static HttpClient _httpClient = new HttpClient{BaseAddress = new Uri("http://localhost:5045/api/DriverAPI/") };
        
        public Task<PersonDTO> PersonInfo { set; get; }
        public int DriverID { set; get; } =-1; // Default value for new drivers
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; set; }

        

        public clsDriverAsync(DriverDTO dto)

        {
            DriverID = dto.DriverID;
            PersonID = dto.PersonID;
            CreatedByUserID = dto.CreatedByUserID;
            CreatedDate = dto.CreatedDate;
            PersonInfo =   clsPersonAsync.GetPersonByIDAsync(PersonID);

           // _Mode = clsGlobalSetting.EnMode.Edit;
        }
        #region Helper Methods
        private DriverDTO classToDTO()
        {
            return new DriverDTO (DriverID, PersonID, CreatedByUserID, CreatedDate);
        }
        private void DTOToClass(DriverDTO dto)
        {
            DriverID = dto.DriverID;
            PersonID = dto.PersonID;
            CreatedByUserID = dto.CreatedByUserID;
            CreatedDate = dto.CreatedDate;
        }

        public bool IsNew()
        {
            return DriverID == -1;
        }

        private static async Task<T?> _HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }
                catch (Exception ex)
                {
                    //clsGlobal.LogError("Error deserializing response", ex);
                    return default;
                }
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            //clsGlobal.LogError($"API Error: {response.StatusCode} - {response.ReasonPhrase}. Content: {errorContent}");

            return response.StatusCode switch
            {
                System.Net.HttpStatusCode.NotFound => default,
                System.Net.HttpStatusCode.BadRequest => default,
                System.Net.HttpStatusCode.InternalServerError => default,
                _ => default
            };
        }
        #endregion#region Result 

        #region GRUD
        private async Task<bool> _AddNewDriver()
        {
            var responese = await _httpClient.PutAsJsonAsync("CreateDriver", classToDTO());

            DriverID = await _HandleResponse<int>(responese);


            return DriverID != -1;
        }

        private async Task<bool> _UpdateDriver()
        {
            var responese = await _httpClient.PutAsJsonAsync("UpdateDriver", DriverID);

            return await _HandleResponse<bool>(responese);
        }

        public static async Task<DriverDTO> FindByDriverID(int DriverID)
        {

            var responese = await _httpClient.GetAsync($"GetDriverByID/{DriverID}");

            return await _HandleResponse<DriverDTO>(responese);

        }

        public static async Task<DriverDTO> FindByPersonID(int PersonID)
        {

             var responese = await _httpClient.GetAsync($"GetDriverByPersonID/{PersonID}");

            return await _HandleResponse<DriverDTO>(responese);

        }
        #endregion

        #region Specialized Operations 
        public static async Task<List<Drivers_ViewDTO>> GetAllDrivers()
        {
            var responese = await _httpClient.GetAsync("GetAllDrivers");

            return await _HandleResponse<List<Drivers_ViewDTO>>(responese);

        }

        public async Task<bool> Save()
        {
         
            if( IsNew())
            {
                return await  _AddNewDriver();
            }
            else
            {
                return await  _UpdateDriver();
            }

            return false;
        }

        public  static async Task<List<LicenseViewDTO>> GetLicenses(int DriverID)
        {
            return await clsLicenseAsync.GetDriverLicenses(DriverID);
        }
        // work on it after adding  cls International License
        //public static DataTable GetInternationalLicenses(int DriverID)
        //{
        //    return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        //}
        #endregion
    }
}
