using DVLD_DesktopClient.Applications.ApplicationTypes;
using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.People;
using DVLD_DesktopClient.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;

namespace DVLD_DesktopClient.Applications
{
    public class clsApplicationAsync
    {
        public clsDTOs.clsApplicationDTO ADTO;                                                                           
       // private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(" http://localhost:5045/api/applicationsAsync/") };
       // private  HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(" http://localhost:5045/api/applicationsAsync/") };

        public GlobalClasses.clsGlobalSetting.EnMode _Mode = GlobalClasses.clsGlobalSetting.EnMode.Add;

        public enum enApplicationType { NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3, ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7};
        //public Task<clsDTOs.clsApplicationTypeDTO> ApplicationTypeInfo { set; get; }
        public clsApplicationTypeDTO ApplicationTypeInfo { set; get; }
        public int ApplicationTypeID { set; get; }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }
        public DateTime LastStatusDate { set; get; }
        public int ApplicationID { set; get; }
        private static  int _personID;
        public  int ApplicantPersonID { set; get; }
        
        public clsDTOs.PersonDTO PersonInfo { set; get; }
        public string PersonFullName
        {
            get
            {
                //var personifno = clsPersonAsync.GetPersonByIDAsync(ApplicantPersonID);
                //return personifno.Result.FirstName + " " + personifno.Result.LastName;
                return "amine test hh";

            }
        }
        public DateTime ApplicationDate { set; get; }

        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public Task<clsDTOs.clsUserDTO> CreatedByUserInfo;
        public clsApplicationAsync() { }
        public  clsApplicationAsync(clsDTOs.clsApplicationDTO ADTO, GlobalClasses.clsGlobalSetting.EnMode Mode)
        {
            this.ApplicationID = ADTO.ApplicationID;
            this.ApplicantPersonID = ADTO.ApplicantPersonID;
            _personID = ADTO.ApplicantPersonID;
            //this.PersonInfo =  clsPersonAsync.GetPersonByIDAsync(ApplicantPersonID).Result;
            this.ApplicationDate = ADTO.ApplicationDate;
            this.ApplicationTypeID = ADTO.ApplicationTypeID;
            // .result is not the best solution  
            //this.ApplicationTypeInfo =  clsApplicationTypeAsync.GetApplicationTypeByIDAsync(ApplicationTypeID).Result;
            this.ApplicationStatus = ADTO.ApplicationStatus;
            this.LastStatusDate = ADTO.LastStatusDate;
            this.PaidFees = ADTO.PaidFees;
            this.CreatedByUserID = ADTO.CreatedByUserID;
            // this.CreatedByUserInfo = clsUsersAsync.GetUserInfoByUserIDAsync(CreatedByUserID);
            _Mode = Mode;
        }

        #region Handle Response
        private static async Task<T?> _HandleResponse<T>(HttpResponseMessage response)
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
        async Task<bool> _AddNewApplication()
        {
            //call DataAccess Layer 
            //HttpResponseMessage response = await _httpClient.PostAsJsonAsync("AddNewApplicationAsync", new clsDTOs.clsApplicationDTO
            //(
            //    this.ApplicantPersonID,
            //    this.ApplicantPersonID,
            //    this.ApplicationDate,
            //    this.ApplicationTypeID,
            //    this.ApplicationStatus,
            //    this.LastStatusDate,
            //    this.PaidFees,
            //    this.CreatedByUserID
            //));
            HttpResponseMessage response = await clsGlobalSetting.httpClient.PostAsJsonAsync("applicationsAsync/AddNewApplicationAsync", new clsDTOs.clsApplicationDTO
           (
               this.ApplicantPersonID,
               this.ApplicantPersonID,
               this.ApplicationDate,
               this.ApplicationTypeID,
               this.ApplicationStatus,
               this.LastStatusDate,
               this.PaidFees,
               this.CreatedByUserID
           ));

            ADTO = await _HandleResponse<clsApplicationDTO>(response);
            this.ApplicationID = ADTO.ApplicationID;
            return ADTO != null;
        }

        private async Task<bool> _UpdateApplication()
        {
            HttpResponseMessage responseMessage =  clsGlobalSetting.httpClient.PutAsJsonAsync($"applicationsAsync/UpdateApplicationAsync/{this.ApplicationID}", new clsDTOs.clsApplicationDTO
            (
                this.ApplicantPersonID,
                this.ApplicantPersonID,
                this.ApplicationDate,
                this.ApplicationTypeID,
                this.ApplicationStatus,
                this.LastStatusDate,
                this.PaidFees,
                this.CreatedByUserID
            )).Result;

            
            return await _HandleResponse<bool>(responseMessage);

        }

        public  static async Task <clsApplicationDTO> FindBaseApplication(int ApplicationID)
        {
                                                        
            HttpResponseMessage responseMessage = await clsGlobalSetting.httpClient.GetAsync($"applicationsAsync/GetApplicationByIDAsync/{ApplicationID}");
            //HttpResponseMessage responseMessage = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/applicationsAsync/") }.GetAsync($"GetApplicationByIDAsync/{ApplicationID}");   
            return await _HandleResponse<clsApplicationDTO>(responseMessage); ;
        }

        public async Task<bool> Cancel()
        {
            enApplicationStatus newStatus = enApplicationStatus.Cancelled;
            var response = await clsGlobalSetting.httpClient.PutAsync($"applicationsAsync/UpdateStatusAsync/{this.ApplicationID}/{(int)newStatus}", null);
           
            return await _HandleResponse<bool>(response);
            
        }

        public async Task<bool> SetComplete()
        {
            enApplicationStatus newStatus = enApplicationStatus.Completed;
            var response = await clsGlobalSetting.httpClient.PutAsync($"applicationsAsync/UpdateStatusAsync/{this.ApplicationID}/{(int)newStatus}", null);

            return await _HandleResponse<bool>(response);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case GlobalClasses.clsGlobalSetting.EnMode.Add:
                    if ( await  _AddNewApplication())
                    {

                        _Mode = clsGlobalSetting.EnMode.Edit;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case GlobalClasses.clsGlobalSetting.EnMode.Edit:

                    return await _UpdateApplication();

            }

            return false;
        }

        public async Task<bool> Delete()
        {
            HttpResponseMessage response = await clsGlobalSetting.httpClient.DeleteAsync($"applicationsAsync/DeleteApplicationAsync/{this.ApplicationID}");
            return await _HandleResponse<bool>(response);

        }

        public static async Task<bool> IsApplicationExist(int ApplicationID)
        {
            HttpResponseMessage response = await  clsGlobalSetting.httpClient.GetAsync($"applicationsAsync/ApplicationExistsAsync/{ApplicationID}");
            return await _HandleResponse<bool>(response);
        }

        public static async Task<bool> DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            HttpResponseMessage response =  await clsGlobalSetting.httpClient.GetAsync($"applicationsAsync/DoesPersonHaveActiveApplication/{PersonID}/{ApplicationTypeID}");
            //HttpResponseMessage response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/applicationsAsync/") }.GetAsync($"DoesPersonHaveActiveApplication/{PersonID}/{ApplicationTypeID}").Result;
            return await _HandleResponse<bool>(response);
        }

        public  async Task<bool> DoesPersonHaveActiveApplication( int ApplicationTypeID)
        {
            return await DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }


        public static async Task<int> GetActiveApplicationID(int PersonID, clsApplicationAsync.enApplicationType ApplicationTypeID)
        {
            HttpResponseMessage response = await clsGlobalSetting.httpClient.GetAsync($"applicationsAsync/GetActiveApplicationIDAsync/{PersonID}/{ApplicationTypeID}");
            //HttpResponseMessage response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/applicationsAsync/") }.GetAsync($"GetActiveApplicationIDAsync/1029/131/{PersonID}/{ApplicationTypeID}").Result;
            return await _HandleResponse<int>(response);
        }

        public static async Task<int> GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            HttpResponseMessage response = await clsGlobalSetting.httpClient.GetAsync($"applicationsAsync/GetActiveApplicationIDForLicenseClassAsync/{PersonID}/{ApplicationTypeID}/{LicenseClassID}");
            //HttpResponseMessage response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/applicationsAsync/") }.GetAsync($"GetActiveApplicationIDForLicenseClassAsync/1029/131/1{PersonID}/{ApplicationTypeID}/{LicenseClassID}").Result;
            return await _HandleResponse<int>(response);
        }
        public static async Task<int> GetActiveApplicationID(clsApplicationAsync.enApplicationType ApplicationTypeID)
        {
            HttpResponseMessage response = await clsGlobalSetting.httpClient.GetAsync($"applicationsAsync/GetActiveApplicationIDAsync/{_personID}/{ApplicationTypeID}");
            //HttpResponseMessage response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/applicationsAsync/") }.GetAsync($"GetActiveApplicationIDAsync/1029/131/{_personID}/{ApplicationTypeID}").Result;
            return await _HandleResponse<int>(response);
        }

    }
}
