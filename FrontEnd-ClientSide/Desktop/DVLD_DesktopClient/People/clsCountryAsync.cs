using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DesktopClient.People
{
    public  class clsCountryAsync
    {
        //static HttpClient httpClient = new HttpClient();
        //public clsCountryAsync()
        //{

        //    httpClient.BaseAddress = new Uri("http://localhost:5045/api/CountriesAPI/");
        //}
        #region Get All Countries Async Method
            public static async Task<List<clsDTOs.clsCountryDTO>> GetAllCountriesAsync()
            {
                var countryList = new List<clsDTOs.clsCountryDTO>();
           
                    var response = await clsGlobalSetting.httpClient.GetAsync("CountriesAPI/GetAllCoutries");
                    //var response = await httpClient.GetAsync("http://localhost:5045/api/CountriesAPI/GetAllCoutries");

                    if (response.IsSuccessStatusCode)
                    {
                        countryList = await response.Content.ReadFromJsonAsync<List<clsDTOs.clsCountryDTO>>();

                        return countryList;
                    }
                    else
                    {
                       return null;
                    }

            }
        #endregion

        #region Find Country by Name
            public static  async Task<clsDTOs.clsCountryDTO> FindCountryByNameAsync(string countryName)
            {
            

                var response = await clsGlobalSetting.httpClient.GetAsync($"CountriesAPI/GetCountryByCountryName/{countryName}");
                //var response = await httpClient.GetAsync($"http://localhost:5045/api/CountriesAPI/GetCountryByCountryName/{countryName}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<clsDTOs.clsCountryDTO>();
                }
                else
                {
                    return null;
                }

            }
        #endregion
        #region Find Country by ID
            public static async Task<clsDTOs.clsCountryDTO> FindCountryByIDAsync(int ID)
            {

        
                var response = await clsGlobalSetting.httpClient.GetAsync($"CountriesAPI/GetCountryByID/{ID}");
                //var response = await httpClient.GetAsync($"http://localhost:5045/api/CountriesAPI/GetCountryByID/{ID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<clsDTOs.clsCountryDTO>();
                }
                else
                {
                    return null;
                }

            }
        #endregion
    }
}
