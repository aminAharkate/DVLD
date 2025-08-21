using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Test
{
    public class clsTestsAsync
    {
       
        HttpClient _HttpClient = new HttpClient();
        public clsTestsAsync(clsTestDTO TDTo)
        {
            this.TestID = -1;
            this.TestID = TDTo.TestID;
            this.TestAppointmentID = TDTo.TestAppointmentID;
            this.TestResult = TDTo.TestResult;
            this.Notes = TDTo.Notes;
            this.CreatedByUserID = TDTo.CreatedByUserID;
            _HttpClient.BaseAddress = new Uri("http://localhost:5045/api/TestsAPI/");
        }

        #region Properties
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        //public clsTestAppointmentDTO TestAppointmentInfo { set; get; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        #endregion

        #region GRUD Operations [Without DELETE]
        
        public async Task<bool> SaveAsync()
        {
            var testDTO = ToDTO();

            try
            {
                if (IsNew())
                {
                    // Add new test
                    var response = await _HttpClient.PostAsJsonAsync("AddNewTest", testDTO);
                    var createdTest = await _HandleResponse<clsTestDTO>(response);
                    if (createdTest != null)
                    {
                        this.TestID = createdTest.TestID;
                        return true;
                    }
                    return false;
                }
                else
                {
                    // Update existing test
                    var response = await _HttpClient.PutAsJsonAsync($"UpdateTest/{TestID}", testDTO);
                    return await _HandleResponse<bool>(response);
                }
            }
            catch (Exception ex)
            {
                //clsGlobal.LogError("Error saving test", ex);
                return false;
            }
        }

        public static  async Task<clsTestDTO> FindAsync(int testID)
        {
            try
            {
                var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestsAPI/") }.GetAsync($"GetTestById/{testID}");
                return await _HandleResponse<clsTestDTO>(response);
            }
            catch (Exception ex)
            {
                //clsGlobal.LogError("Error finding test", ex);
                return null;
            }
        }
        #endregion

        #region Specialized Operations
        public async Task<clsTestDTO> GetLastTestByPersonAndTestTypeAndLicenseClassAsync(
            int personID, int licenseClassID, int testTypeID)
        {
            try
            {
                var response = await _HttpClient.GetAsync(
                    $"GetLastTestByPerson/{personID}/license-class/{licenseClassID}/test-type/{testTypeID}/latest");
                return await _HandleResponse<clsTestDTO>(response);
            }
            catch (Exception ex)
            {
                //clsGlobal.LogError("Error getting last test", ex);
                return null;
            }
        }

        public async Task<List<clsTestDTO>> GetAllTestsAsync()
        {
            try
            {
                var response = await _HttpClient.GetAsync("GetAllTests");
                return await _HandleResponse<List<clsTestDTO>>(response) ?? new List<clsTestDTO>();
            }
            catch (Exception ex)
            {
                //clsGlobal.LogError("Error getting all tests", ex);
                return new List<clsTestDTO>();
            }
        }

        public static  async Task<int> GetPassedTestCountByApplicationAsync(int applicationID)
        {
            try
            {
                var response = await  new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestsAPI/") }.GetAsync($"GetPassedTestCountByApplication/{applicationID}/passed-count");

                //var response = await _HttpClient GetAsync(
                   // $"GetPassedTestCountByApplication/{applicationID}/passed-count");
                return await _HandleResponse<int>(response);
            }
            catch (Exception ex)
            {
                //clsGlobal.LogError("Error getting passed test count", ex);
                return -1;
            }
        }

        public  static async Task<bool> PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            var passNum = await GetPassedTestCountByApplicationAsync(LocalDrivingLicenseApplicationID);
            return passNum == 3;
        }
        
        #endregion

        #region Helper Methods
        private clsTestDTO ToDTO()
        {
            return new clsTestDTO
            (
                this.TestID,
                this.TestAppointmentID,
                this.TestResult,
                string.IsNullOrWhiteSpace(this.Notes) ? null : this.Notes,
                this.CreatedByUserID
            );
        }

        public bool IsNew()
        {
            return TestID == -1;
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
        #endregion




    }
}

//***********************************

















