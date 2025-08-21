using DVLD_DesktopClient.GlobalClasses;
using DVLD_DesktopClient.Licenses;
using DVLD_DesktopClient.People;
using DVLD_DesktopClient.Test;
using DVLD_DesktopClient.Test.Test_Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.Applications.clsApplicationAsync;
using static DVLD_DesktopClient.GlobalClasses.clsDTOs;
using static DVLD_DesktopClient.GlobalClasses.clsGlobalSetting;

namespace DVLD_DesktopClient.Applications.Local_Driving_License
{
    public class clsLocalDrivingLicenseApplicationAsync : clsApplicationAsync
    {
        
        private GlobalClasses.clsGlobalSetting.EnMode _Mode;
                                                                                   
        //static  HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") };
        //private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") };

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }

        public clsLicenseClassDTO LicenseClassInfo;

        public string PersonFullName // check region "what is the best way to get the full name " to under stand 
        {
            get
            {
                return base.PersonFullName;
            }

        }
        public clsLocalDrivingLicenseApplicationAsync(clsLocalDrivingLicenseApplicationDTO LDLADTO, clsApplicationDTO ADTO, GlobalClasses.clsGlobalSetting.EnMode mode) : base(ADTO, mode)
        {
            LocalDrivingLicenseApplicationTo(LDLADTO, ADTO);
            this._Mode = mode;
        }
        public static void convert1To2(clsLocalDrivingLicenseApplicationDTO2 dto2, clsLocalDrivingLicenseApplicationDTO LDLADTO, clsApplicationDTO ADTO)
        {
            LDLADTO = new clsLocalDrivingLicenseApplicationDTO
            (
                dto2.LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID,
                dto2.LocalDrivingLicenseApplicationDTO.ApplicationID,
                dto2.LocalDrivingLicenseApplicationDTO.LicenseClassID
            );
            ADTO = new clsApplicationDTO
            (
                dto2.ApplicationDTO.ApplicationID,
                dto2.ApplicationDTO.ApplicantPersonID,
                dto2.ApplicationDTO.ApplicationDate,
                dto2.ApplicationDTO.ApplicationTypeID,
                dto2.ApplicationDTO.ApplicationStatus,
                dto2.ApplicationDTO.LastStatusDate,
                dto2.ApplicationDTO.PaidFees,
                dto2.ApplicationDTO.CreatedByUserID
             );
        }
        public void LocalDrivingLicenseApplicationTo(clsLocalDrivingLicenseApplicationDTO LDLADTO, clsApplicationDTO ADTO)
        {
            this.LocalDrivingLicenseApplicationID = LDLADTO.LocalDrivingLicenseApplicationID;
            this.ApplicationID = LDLADTO.ApplicationID;
            this.LicenseClassID = LDLADTO.LicenseClassID;


            this.ApplicantPersonID = ADTO.ApplicantPersonID;
            this.ApplicationDate = ADTO.ApplicationDate;
            this.ApplicationTypeID = (int)ADTO.ApplicationTypeID;
            this.ApplicationStatus = ADTO.ApplicationStatus;
            this.LastStatusDate = ADTO.LastStatusDate;
            this.PaidFees = ADTO.PaidFees;
            this.CreatedByUserID = ADTO.CreatedByUserID;

        }
        #region Handle Response
        private static async Task<T?> _HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>();

            //Log errors for better debugging

            Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Resource not found.");
                    return default; // Prevents null exceptions
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    Console.WriteLine("Invalid request format.");
                    return default;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    Console.WriteLine("Server error occurred.");
                    return default;
                }

            return default;

        }
        #endregion


        private async Task<bool> _AddNewLocalDrivingLicenseApplication()
        {
            
            var response = await clsGlobalSetting.httpClient.PostAsJsonAsync("LocalDrivingLicenseApplicationAPI/TryAddNewLocalDrivingLicenseApplicationAsync", new clsLocalDrivingLicenseApplicationDTO
            (
                0,
                this.ApplicationID,
                this.LicenseClassID
            ));
            //var response = await _httpClient.PostAsJsonAsync("TryAddNewLocalDrivingLicenseApplicationAsync", new clsLocalDrivingLicenseApplicationDTO
            //(
            //    0,
            //    this.ApplicationID,
            //    this.LicenseClassID
            //));
            this.LocalDrivingLicenseApplicationID = await _HandleResponse<int>(response);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private async Task<bool> _UpdateLocalDrivingLicenseApplication()
        {


            //HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"TryUpdateLocalDrivingLicenseApplication", new clsLocalDrivingLicenseApplicationDTO
            //(
            //    this.LocalDrivingLicenseApplicationID,
            //    this.ApplicationID,
            //    this.LicenseClassID
            //));
            HttpResponseMessage response = await clsGlobalSetting.httpClient.PutAsJsonAsync($"LocalDrivingLicenseApplicationAPI/TryUpdateLocalDrivingLicenseApplication", new clsLocalDrivingLicenseApplicationDTO
            (
                this.LocalDrivingLicenseApplicationID,
                this.ApplicationID,
                this.LicenseClassID
            ));
            return await _HandleResponse<bool>(response);

        }

        public static async Task<clsLocalDrivingLicenseApplicationDTO> FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            //var (found, DTO) = await  clsLocalDrivingLicenseApplicationAsync.FindByApplicationID(LocalDrivingLicenseApplicationID);
            ////var DTO = clsLocalDrivingLicenseApplicationAsync.FindByApplicationID(LocalDrivingLicenseApplicationID);
            //var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"TryGetLocalDrivingLicenseApplicationByIDAsync/{LocalDrivingLicenseApplicationID}");
            //var result = await _HandleResponse<clsLocalDrivingLicenseApplicationDTO>(response);
            //return result;

            ////if (found)
            //if (result != null)
            //{
            //    // know later do we need data of full obj 
            //    //now we find the base application
            //    clsApplicationDTO Application = await clsApplicationAsync.FindBaseApplication(result.ApplicationID);

            //    //we return new object of that person with the right data
            //    return new clsLocalDrivingLicenseApplicationDTO2(result, Application);
            //}
            //else
            var response = await clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/TryGetLocalDrivingLicenseApplicationByIDAsync/{LocalDrivingLicenseApplicationID}");

            //var response = await _httpClient.GetAsync($"TryGetLocalDrivingLicenseApplicationByIDAsync/{LocalDrivingLicenseApplicationID}");
            return await _HandleResponse<clsLocalDrivingLicenseApplicationDTO>(response);
           // return null;


        }
        //qùslmgùqlslgùlqùdfmgùqfgù*mfù*gm*rgm:*qegr*^q:lfdeù^g:lqù*dfmlg$*qr
       
        public static async Task<clsLocalDrivingLicenseApplicationDTO2> FindByApplicationID(int ApplicationID)
        {
            var response = await clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/TryGetLocalDrivingLicenseApplicationByApplicationIdAsync/{ApplicationID}");

            //var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"TryGetLocalDrivingLicenseApplicationByApplicationIdAsync/{ApplicationID}");
            var (found, result) = await _HandleResponse<(bool, clsLocalDrivingLicenseApplicationDTO)>(response);


            if (found)
            {
                // know later do we need data of full obj 
                //now we find the base application
                clsApplicationDTO Application = await clsApplicationAsync.FindBaseApplication(result.ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplicationDTO2(result, Application);
            }
            else
                return null;



        }

        public async Task<bool> Save()
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            //base.Mode = (clsApplication.enMode)Mode;
            base._Mode = _Mode; // set the mode of the base class to the current mode

            if (!await base.Save())
                return false;


            //After we save the main application now we save the sub application.
            switch (_Mode)
            {
                case clsGlobalSetting.EnMode.Add:
                if (await _AddNewLocalDrivingLicenseApplication())
                {

                    _Mode = clsGlobalSetting.EnMode.Edit;
                    return true;
                }
                else
                {
                    return false;
                }

            case clsGlobalSetting.EnMode.Edit:

                return await _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }

        public static async Task<List<clsLocalDrivingLicenseApplications_ViewDTO>> GetAllLocalDrivingLicenseApplications()
        {

            var response = await clsGlobalSetting.httpClient.GetAsync("LocalDrivingLicenseApplicationAPI/GetAllLocalDrivingLicenseApplicationsAsync");

            // var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync("GetAllLocalDrivingLicenseApplicationsAsync");

            return await _HandleResponse<List<clsLocalDrivingLicenseApplications_ViewDTO>>(response);

        }

        public async Task<bool> Delete()
        {

            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            var response = await  clsGlobalSetting.httpClient.DeleteAsync($"LocalDrivingLicenseApplicationAPI/TryDeleteLocalDrivingLicenseApplicationAsync/{this.ApplicationID}");
            //var response = await _httpClient.DeleteAsync($"TryDeleteLocalDrivingLicenseApplicationAsync/{this.ApplicationID}");
            IsLocalDrivingApplicationDeleted = await _HandleResponse<bool>(response);


            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = await base.Delete();
            return IsBaseApplicationDeleted;

        }

        public async Task<bool> DoesPassTestType(clsTestTypeAsync.enTestType TestTypeID)
        {
            
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/DoesPassTestTypeAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = _httpClient.GetAsync($"DoesPassTestTypeAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<bool>(await response);
        }

        public async Task<bool> DoesPassPreviousTest(clsTestTypeAsync.enTestType CurrentTestType)
        {

            switch (CurrentTestType)
            {
                case clsTestTypeAsync.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    return true;

                case clsTestTypeAsync.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    // check if pass visiontest 1.

                    return await this.DoesPassTestType(clsTestTypeAsync.enTestType.VisionTest);


                case clsTestTypeAsync.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    return await this.DoesPassTestType(clsTestTypeAsync.enTestType.WrittenTest);

                default:
                    return false;
            }
        }

        public static async Task<bool> DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/DoesPassTestTypeAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"DoesPassTestTypeAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");

            return await _HandleResponse<bool>(await response);
        }

        public async Task<bool> DoesAttendTestType(clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/DoesAttendTestTypeAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = _httpClient.GetAsync($"DoesAttendTestTypeAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
            return await _HandleResponse<bool>(await response);
        }

        public async Task<bool> AttendedTest(clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/AttendedTestAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
           // var response = _httpClient.GetAsync($"AttendedTestAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<bool>(await response);
        }

        public async Task<byte> TotalTrialsPerTest(clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/TotalTrialsPerTestAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = _httpClient.GetAsync($"TotalTrialsPerTestAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<byte>(await response);
        }

        public static async Task<byte> TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/TotalTrialsPerTestAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
           // var response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"TotalTrialsPerTestAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<byte>(await response);
        }

        public static async Task<bool> AttendedTest(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/AttendedTestAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"AttendedTestAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<bool>(await response);
        }


        public static async Task<bool> IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/IsThereAnActiveScheduledTestAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"IsThereAnActiveScheduledTestAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<bool>(await response);
        }

        public async Task<bool> IsThereAnActiveScheduledTest(clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/IsThereAnActiveScheduledTestAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = _httpClient.GetAsync($"IsThereAnActiveScheduledTestAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<bool>(await response);
        }

        public async Task<clsTestTypeDTO> GetLastTestPerTestType(clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/GetLastTestPerTestTypeAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = _httpClient.GetAsync($"GetLastTestPerTestTypeAsync/{this.LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<clsTestTypeDTO>(await response);
        }
        public static async Task<clsTestTypeDTO> GetLastTestPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypeAsync.enTestType TestTypeID)
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/GetLastTestPerTestTypeAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            //var response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"GetLastTestPerTestTypeAsync/{LocalDrivingLicenseApplicationID}/{(int)TestTypeID}");
            return await _HandleResponse<clsTestTypeDTO>(await response);
        }
        public static async Task<clsTestDTO> GetLastTestPerTestType(int personID, int licenseClass, clsTestTypeAsync.enTestType TestTypeID)
        {

            var response = new HttpClient { BaseAddress = new Uri(" http://localhost:5045/api/TestsAPI/") }.GetAsync($"GetLastTestByPerson/{personID}/license-class/{licenseClass}/test-type/{TestTypeID}/latest");
            return await _HandleResponse<clsTestDTO>(await response);
        }
        public async Task<byte> GetPassedTestCount()
        {
            var response = clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/GetPassedTestCountAsync/{this.LocalDrivingLicenseApplicationID}");
            //var response = _httpClient.GetAsync($"GetPassedTestCountAsync/{this.LocalDrivingLicenseApplicationID}");
            //return clsTestTypeAsync.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
            return await _HandleResponse<byte>(await response);
        }

        public static async Task<byte> GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            var response =clsGlobalSetting.httpClient.GetAsync($"LocalDrivingLicenseApplicationAPI/GetPassedTestCountAsync/{LocalDrivingLicenseApplicationID}");
            //var response = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/LocalDrivingLicenseApplicationAPI/") }.GetAsync($"GetPassedTestCountAsync/{LocalDrivingLicenseApplicationID}");

            return await _HandleResponse<byte>(await response);
        }

        public async Task<bool> PassedAllTests()
        {
            return await clsTestsAsync.PassedAllTests(this.ApplicationID);
        }
        public static async Task<bool> PassedAllTests(int ApplicationID)
        {
            return await clsTestsAsync.PassedAllTests(ApplicationID);
        }
        //need to add lisnence class first
        public async Task<int> GetActiveLicenseID()
        {
            //this will get the license id that belongs to this application
            return await clsLicenseAsync.FindActiveLicenseByPerson(this.ApplicantPersonID, this.LicenseClassID);
            
        }
        public static  async Task<int> GetActiveLicenseID(int ApplicantPersonID, int LicenseClassID)
        {
            //this will get the license id that belongs to this application
            return await clsLicenseAsync.FindActiveLicenseByPerson(ApplicantPersonID, LicenseClassID);

        }
    }



    //public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
    //    {
    //        //if total passed test less than 3 it will return false otherwise will return true
    //        return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
    //    }

    //    public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
    //    {
    //        int DriverID = -1;

    //        clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

    //        if (Driver == null)
    //        {
    //            //we check if the driver already there for this person.
    //            Driver = new clsDriver();

    //            Driver.PersonID = this.ApplicantPersonID;
    //            Driver.CreatedByUserID = CreatedByUserID;
    //            if (Driver.Save())
    //            {
    //                DriverID = Driver.DriverID;
    //            }
    //            else
    //            {
    //                return -1;
    //            }
    //        }
    //        else
    //        {
    //            DriverID = Driver.DriverID;
    //        }
    //        //now we diver is there, so we add new licesnse

    //        clsLicense License = new clsLicense();
    //        License.ApplicationID = this.ApplicationID;
    //        License.DriverID = DriverID;
    //        License.LicenseClass = this.LicenseClassID;
    //        License.IssueDate = DateTime.Now;
    //        License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
    //        License.Notes = Notes;
    //        License.PaidFees = this.LicenseClassInfo.ClassFees;
    //        License.IsActive = true;
    //        License.IssueReason = clsLicense.enIssueReason.FirstTime;
    //        License.CreatedByUserID = CreatedByUserID;

    //        if (License.Save())
    //        {
    //            //now we should set the application status to complete.
    //            this.SetComplete();

    //            return License.LicenseID;
    //        }

    //        else
    //            return -1;
    //    }

    //    public bool IsLicenseIssued()
    //    {
    //        return (GetActiveLicenseID() != -1);
    //    }


    }


