//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DVLD_DesktopClient.Licenses
//{
//    public  class clsLicenseAsync
//    {

//    }
//}
using DVLD_DesktopClient.Applications;
using DVLD_DesktopClient.Applications.ApplicationTypes;
using DVLD_DesktopClient.Applications.Local_Driving_License;
using DVLD_DesktopClient.Drivers;
using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;

namespace DVLD_DesktopClient.Licenses
{
    public class clsLicenseAsync

    {
        
        //static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LicenseAPI/") };

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { get; set; } = -1;
        public Task<clsLicenseClassDTO> LicenseClassIfo;

        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        //public Task<DriverDTO> DriverInfo;
        public DriverDTO DriverInfo;
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        // public clsDetainedLicense DetainedInfo { set; get; } class not add yet

        //public bool IsDetained
        //{
        //    get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); } // same
        //}
        public int CreatedByUserID { get; set; }

     
        public Task<clsApplicationDTO> ApplicationInfo { get; private set; }

        public clsLicenseAsync(LicenseDTO dto)
        {
            LicenseID = dto.LicenseID;
            ApplicationID = dto.ApplicationID;
            DriverID = dto.DriverID;
            LicenseClassID = dto.LicenseClass;
            IssueDate = dto.IssueDate;
            ExpirationDate = dto.ExpirationDate;
            Notes = dto.Notes;
            PaidFees = dto.PaidFees;
            IsActive = dto.IsActive;
            IssueReason = (enIssueReason)dto.IssueReason;
            CreatedByUserID = dto.CreatedByUserID;

            // Load related information
            //DriverInfo = clsDriverAsync.FindByDriverID(DriverID);
            ApplicationInfo = clsApplicationAsync.FindBaseApplication(ApplicationID);
            LicenseClassIfo = clsLicenseClassAsync.Find(LicenseClassID);
        }

        #region Helper Methods
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
        private LicenseDTO classToDTO()
        {
            return new LicenseDTO
            {
                LicenseID = this.LicenseID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClass = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = this.PaidFees,
                IsActive = this.IsActive,
                IssueReason = (byte)this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };
        }

        private void DTOToClass(LicenseDTO dto)
        {
            this.LicenseID = dto.LicenseID;
            this.ApplicationID = dto.ApplicationID;
            this.DriverID = dto.DriverID;
            this.LicenseClassID = dto.LicenseClass;
            this.IssueDate = dto.IssueDate;
            this.ExpirationDate = dto.ExpirationDate;
            this.Notes = dto.Notes;
            this.PaidFees = dto.PaidFees;
            this.IsActive = dto.IsActive;
            this.IssueReason = (enIssueReason)dto.IssueReason;
            this.CreatedByUserID = dto.CreatedByUserID;
        }

        public bool IsNew()
        {
            return LicenseID == -1;
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

        #region CRUD Operations 
        private async Task<bool> _AddNewLicense()
        {
            var response = await clsGlobalSetting.httpClient.PostAsJsonAsync("LicenseAPI/CreateLicense", classToDTO());
            var result = await _HandleResponse<LicenseCreationResult>(response);

            if (result?.LicenseID > 0)
            {
                LicenseID = result.LicenseID;
                return true;
            }

            return false;
        }

        private async Task<bool> _UpdateLicense()
        {
            var response = await clsGlobalSetting.httpClient.PutAsJsonAsync($"LicenseAPI/UpdateLicense/{LicenseID}", classToDTO());
            return await _HandleResponse<bool>(response);
        }

        public static async Task<LicenseDTO> FindByLicenseID(int licenseID)
        {
            var response = await clsGlobalSetting.httpClient.GetAsync($"LicenseAPI/GetLicenseByID/{licenseID}");
            //var dto = await _HandleResponse<LicenseDTO>(response);
            //return dto != null ? new LicenseDTO(dto) : null;
            return await _HandleResponse<LicenseDTO>(response) ?? new LicenseDTO();
        }

        #endregion

        #region Specialized Operations
        public static async Task<bool> IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (await FindActiveLicenseByPerson(PersonID, LicenseClassID) != -1);
        }
        public static async Task<int> FindActiveLicenseByPerson(int personID, int licenseClassID)
        {
            var response = await clsGlobalSetting.httpClient.GetAsync($"LicenseAPI/GetActiveLicenseID/{personID}/{licenseClassID}");
            //var response = await _httpClient.GetAsync($"GetActiveLicenseID/{personID}/{licenseClassID}");
             return await _HandleResponse<int>(response);
            //return licenseID > 0 ? await FindByLicenseID(licenseID) : null;
        }
        public static async Task<List<LicenseViewDTO>> GetDriverLicenses(int driverID)
        {
            var response = await clsGlobalSetting.httpClient.GetAsync($"LicenseAPI/GetDriverLicenses/{driverID}");
           // var response = await _httpClient.GetAsync($"GetDriverLicenses/{driverID}");
            return await _HandleResponse<List<LicenseViewDTO>>(response) ?? new List<LicenseViewDTO>();
        }
        public static async Task<List<LicenseViewDTO>> GetAllLicenses()
        {
            var response = await clsGlobalSetting.httpClient.GetAsync("LicenseAPI/GetAllLicenses");
            //var response = await _httpClient.GetAsync("GetAllLicenses");
            return await _HandleResponse<List<LicenseViewDTO>>(response) ?? new List<LicenseViewDTO>();
        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }
        public async Task<bool> Save()
        {
            if (IsNew())
            {
                return await _AddNewLicense();
            }
            else
            {
                return await _UpdateLicense();
            }
        }

        public async Task<bool> DeactivateCurrentLicense()
        {
            var response = await clsGlobalSetting.httpClient.DeleteAsync($"LicenseAPI/DeactivateLicense/{LicenseID}");
            //var response = await _httpClient.DeleteAsync($"DeactivateLicense/{LicenseID}");
            return await _HandleResponse<bool>(response);
        }

        /*add detain class
        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense.DetainID;

        }*/

        /* add afer 
  public bool ReleaseDetainedLicense(int ReleasedByUserID,ref int ApplicationID)
{

    //First Create Applicaiton 
    clsApplication Application = new clsApplication();

    Application.ApplicantPersonID = this.DriverInfo.PersonID;
    Application.ApplicationDate = DateTime.Now;
    Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
    Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
    Application.LastStatusDate = DateTime.Now;
    Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
    Application.CreatedByUserID = ReleasedByUserID;

    if (!Application.Save())
    {
        ApplicationID = -1;
        return false;
    }

    ApplicationID = Application.ApplicationID;


    return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

}*/

        public async Task<LicenseDTO> Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplicationAsync Application = new clsApplicationAsync();
            this.DriverInfo =  await clsDriverAsync.FindByDriverID(this.DriverID);

            var obj =  DriverInfo.PersonID;
            Application.ApplicantPersonID = obj;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplicationAsync.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplicationAsync.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplicationAsync.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            var obj2 = await  clsApplicationTypeAsync.Find(Application.ApplicationTypeID);
            Application.PaidFees = obj2.ApplicationTypeFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!await Application.Save())
            {
                return null;
            }

            LicenseDTO NewLicense = new LicenseDTO();



             

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass =  this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = (byte)IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            clsLicenseAsync ClsNewLicense = new clsLicenseAsync(NewLicense);

            if (!await ClsNewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }
        #endregion

        // Helper DTO for license creation response
        private class LicenseCreationResult
        {
            public int LicenseID { get; set; }
        }
}
}
