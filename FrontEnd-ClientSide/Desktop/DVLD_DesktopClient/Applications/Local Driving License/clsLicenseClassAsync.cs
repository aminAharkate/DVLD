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

namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    public  class clsLicenseClassAsync
    {
        GlobalClasses.clsGlobalSetting.EnMode _Mode;
        //HttpClient _httpClient = new HttpClient();
        private clsLicenseClassDTO _LSDTO { set; get; }
        

        public clsLicenseClassAsync(clsLicenseClassDTO DTO,clsGlobalSetting.EnMode mode)
        {
           
            //_httpClient.BaseAddress = new Uri("http://localhost:5045/api/LicenseClassAsyncAPI/");
            _LSDTO = DTO;
            _Mode = mode;
        }
        private async Task<T> _handleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default(T); // or throw an exception
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Bad Request: " + response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Internal Server Error: " + response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Unauthorized: " + response.ReasonPhrase);
            }
            else
            {
                throw new Exception("Unexpected error: " + response.ReasonPhrase);
            }
        }
        private async Task<bool> _AddNewLicenseClass()
        {
            var response = await clsGlobalSetting.httpClient.PostAsJsonAsync("LicenseClassAsyncAPI/CreateLicenseClass", _LSDTO);
            this._LSDTO.LicenseClassID = await _handleResponse<int>(response);
            return (this._LSDTO.LicenseClassID != -1);
        }

        private async Task<bool> _UpdateLicenseClass()
        {
            var response = await clsGlobalSetting.httpClient.PutAsJsonAsync("LicenseClassAsyncAPI/CreateLicenseClass", _LSDTO);
            return await _handleResponse<bool>(response);
        }

        public static async Task<clsLicenseClassDTO> Find(int LicenseClassID)
        {
            var response = await  clsGlobalSetting.httpClient.GetAsync($"LicenseClassAsyncAPI/GetLicenseClassById/{LicenseClassID}");
            //var response = await  new HttpClient().GetAsync($"http://localhost:5045/api/LicenseClassAsyncAPI/GetLicenseClassById/{LicenseClassID}");
            //return  _handleResponse<clsLicenseClassDTO>(  response);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<clsLicenseClassDTO>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default(clsLicenseClassDTO); // or throw an exception
            }
            return default;
        }

        public static async Task<clsLicenseClassDTO> Find(string ClassName)
        {
            var response = await clsGlobalSetting.httpClient.GetAsync($"LicenseClassAsyncAPI/GetLicenseClassInfoByClassNameAsync/{ClassName}");
            //var response = await new HttpClient().GetAsync($"http://localhost:5045/api/LicenseClassAsyncAPI/GetLicenseClassInfoByClassNameAsync/{ClassName}");
            //return  _handleResponse<clsLicenseClassDTO>(  response);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<clsLicenseClassDTO>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default(clsLicenseClassDTO); // or throw an exception
            }
            return default;

        }

        public static async Task<List<clsLicenseClassDTO>> GetAllLicenseClasses()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://localhost:5045/api/LicenseClassAsyncAPI/GetAllLicenseClasses");

                response.EnsureSuccessStatusCode(); // Throws exception for non-success codes

                return await response.Content.ReadFromJsonAsync<List<clsLicenseClassDTO>>();
            }
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case GlobalClasses.clsGlobalSetting.EnMode.Add:
                    if (await _AddNewLicenseClass())
                    {

                        _Mode = GlobalClasses.clsGlobalSetting.EnMode.Edit;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case GlobalClasses.clsGlobalSetting.EnMode.Edit:

                    return await  _UpdateLicenseClass();

            }

            return false;
        }

    }
}
