using DVLD_DesktopClient.Applications;
using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.Test.Test_Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Test
{
    public class clsTestAppointmentAsync
    {
        GlobalClasses.clsGlobalSetting.EnMode _Mode;
        HttpClient _httpClient;

        public int TestAppointmentID { set; get; }
        public clsTestTypeAsync.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public Task<clsApplicationDTO> RetakeTestAppInfo { set; get; }

        public int TestID
        {
            get { return  _GetTestID().Result; }

        }

        
        public clsTestAppointmentAsync(clsTestAppointmentDTO DTO)
        {
             clsTestAppointmentDTO_8Parameter_To_OBJ(DTO);
             _Mode = (this.TestAppointmentID != -1)? clsGlobalSetting.EnMode.Edit: clsGlobalSetting.EnMode.Add;
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestAppointmentAPI/") };
      
        }

        public static  async Task<clsTestAppointmentDTO> Find(int TestAppointmentID)
        {
            //   108
            //var responese = await _httpClient.GetAsync($"GetTestAppointmentByID/{TestAppointmentID}");
            var response = await new HttpClient{ BaseAddress = new Uri("http://localhost:5045/api/TestAppointmentAPI/") }.GetAsync($"GetTestAppointmentByID/{TestAppointmentID}");
            return await  _HandleResponse<clsTestAppointmentDTO>(response);

        }
        public static async Task<clsTestAppointmentDTO> GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestAppointmentAPI/") }.GetAsync($"GetLastTestAppointment/{LocalDrivingLicenseApplicationID}/{TestTypeID}");
            return await _HandleResponse<clsTestAppointmentDTO>(response);

        }
       
        private  async Task<bool> _AddNewTestAppointment()
        {
            var dto = ObjToDTO();
            var response = await _httpClient.PostAsJsonAsync($"AddNewApplicationAsync", dto);
            var added= await _HandleResponse<int>(response);
            if (added != null )
            {
                this.TestAppointmentID = added;
                //clsGlobal.LogError("Failed to add new test appointment.");
                return true;
            }


            return false;


        }

        private async Task<bool> _UpdateTestAppointment()
        {
            var dto = ObjToDTO();
            var response = await _httpClient.PutAsJsonAsync($"UpdateTestAppointment/{this.TestAppointmentID}", dto);
            var isUpdate = await _HandleResponse<bool>(response);
            


            return isUpdate;
        }



        public static async Task<List<clsTestAppointmentDTO>> GetAllTestAppointments()
        {
            var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestAppointmentAPI/") }.GetAsync($"GetAllTestAppointments");
            return await _HandleResponse<List<clsTestAppointmentDTO>>(response);
        }

        public  async Task<clsTestAppointmentDTO> GetApplicationTestAppointmentsPerTestType(clsTestTypeAsync.enTestType TestTypeID)
        {
            return await  GetLastTestAppointment(this.LocalDrivingLicenseApplicationID, TestTypeID);

        }

        public static async Task<List<clsTestAppointmentDTO>> GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/TestAppointmentAPI/") }.GetAsync($"GetTestAppointmentsByApplicationAndType/{LocalDrivingLicenseApplicationID}/{TestTypeID}");
            return await _HandleResponse<List<clsTestAppointmentDTO>>(response);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case GlobalClasses.clsGlobalSetting.EnMode.Add :
                    if (await _AddNewTestAppointment())
                    {

                        _Mode = clsGlobalSetting.EnMode.Add;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case clsGlobalSetting.EnMode.Edit :

                    return await  _UpdateTestAppointment();

            }

            return false;
        }

        private async Task<int> _GetTestID()
        {
            var response = await _httpClient.GetAsync($"GetTestIDByAppointmentID/{this.TestAppointmentID}");
            return await _HandleResponse<int>(response);
        }

        #region Helper Methods
        private clsTestAppointmentDTO ObjToDTO()
        {
            return new clsTestAppointmentDTO
            (
                this.TestAppointmentID,
                (int)this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,
                this.PaidFees ,
                this.CreatedByUserID,
                this.IsLocked,
                this.RetakeTestApplicationID

            );
        }
        private void clsTestAppointmentDTO_8Parameter_To_OBJ(clsTestAppointmentDTO DTO)
        {
            this.TestAppointmentID = DTO.TestAppointmentID;
            this.TestTypeID = (clsTestTypeAsync.enTestType)DTO.TestTypeID;
            this.LocalDrivingLicenseApplicationID = DTO.LocalDrivingLicenseApplicationID;
            this.AppointmentDate = DTO.AppointmentDate;
            this.PaidFees = DTO.PaidFees;
            this.CreatedByUserID = DTO.CreatedByUserID;
            this.IsLocked = DTO.IsLocked;
            this.RetakeTestApplicationID = DTO.RetakeTestApplicationID ?? 0;
            this.RetakeTestAppInfo = clsApplicationAsync.FindBaseApplication(RetakeTestApplicationID);
            
        }

        public bool IsNew()
        {
            return this.TestAppointmentID == -1;
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
