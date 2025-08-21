using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;

namespace DVLD_DesktopClient.Test.Test_Types
{
    public class clsTestTypeAsync
    {

        static readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestTypeAPI/") };
        
        #region attrebute + Constructor
         clsGlobalSetting.EnMode _Mode= clsGlobalSetting.EnMode.Add;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestTypeAsync.enTestType ID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public float Fees { set; get; }
        private clsTestTypeDTO _TestTypeDTO 
        {
            get
            {
                return new clsTestTypeDTO((int)this.ID, this.Title, this.Description, this.Fees);
            }
        }


        public clsTestTypeAsync(clsTestTypeDTO TYDTO ,clsGlobalSetting.EnMode Mode)

        {
            this.ID = (clsTestTypeAsync.enTestType)TYDTO.TestTypeID;
            this.Title = TYDTO.TestTypeTitle;
            this.Description = TYDTO.TestTypeDescription;
            this.Fees = TYDTO.TestTypeFees;
            _Mode = Mode;
        }

        #endregion

        #region Handle Response
        private static async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();

            // Log errors for better debugging
           // Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                //Console.WriteLine("Resource not found.");
                return default; // Prevents null exceptions
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                //Console.WriteLine("Invalid request format.");
                return default;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                //Console.WriteLine("Server error occurred.");
                return default;
            }

            return default;

        }
        #endregion

        #region Get All Test Types Async
        public static async Task<List<clsDTOs.clsTestTypeDTO>> GetAllTestTypesAsync()
        {
            var response = await _client.GetAsync("GetAllTestTypes");
            return await HandleResponse<List<clsDTOs.clsTestTypeDTO>>(response);

        }
        #endregion

        #region Get Test Type By ID Async
        public static async Task<clsDTOs.clsTestTypeDTO?> Find(int id)
        {
            var response = await _client.GetAsync($"GetTestTypeByID/{id}");
            return await HandleResponse<clsDTOs.clsTestTypeDTO>(response);
        }

        #endregion

        #region update Test Type Async
        private  async Task<bool> _UpdateTestTypeAsync()
        {
            //var response = await _client.PutAsJsonAsync($"UpdateTestType/{id}", testType);// may be will error acourd cuz changing name id to this.clstesttypeID
            var response = await _client.PutAsJsonAsync($"UpdateTestType/{(int)ID}", _TestTypeDTO);// may be will error acourd cuz changing name id to ID

            return await HandleResponse<bool>(response);
        }
        #endregion

        #region Add Test Type Async
        private async Task<bool> _AddTestTypeAsync()
        {
            //var response = await _client.PutAsJsonAsync($"UpdateTestType/{id}", testType);// may be will error acourd cuz changing name id to this.clstesttypeID
            var response = await _client.PostAsJsonAsync($"GetAllTestTypes", _TestTypeDTO);// may be will error acourd cuz changing name id to ID

            return await HandleResponse<bool>(response);
        }
        #endregion


        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                //case EnMode.Add:
                //    if (await _AddTestTypeAsync())
                //    {

                //        _Mode = EnMode.Edit;
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }

                case EnMode.Edit:

                    return await _UpdateTestTypeAsync();

            }

            return false;
        }

    }
}