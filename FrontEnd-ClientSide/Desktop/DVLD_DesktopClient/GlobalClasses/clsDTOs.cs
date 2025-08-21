using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DesktopClient.Applications.clsApplicationAsync;

namespace DVLD_DesktopClient.GlobalClasses
{
    public class clsDTOs
    {
        #region class Country Data Transfer Object (DTO)
        public class clsCountryDTO
        {
            public int ID { get; set; }
            public string CountryName { get; set; }
            public clsCountryDTO(int id, string countryName)
            {
                ID = id;
                CountryName = countryName;
            }
        }
        #endregion

        #region class Person Data Transfer Object (DTO)
        public class PersonDTO
        {
            public PersonDTO(int personID, string firstName, string lastName, string nationalID, string imagePath,
                             bool gender, DateTime dateOfBirth, int nationalityCountryID, string phone, string email, string address)
            {
                this.PersonID = personID;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.NationalID = nationalID;
                this.ImagePath = imagePath;
                this.Gender = gender;
                this.DateOfBirth = dateOfBirth;
                this.NationalityCountryID = nationalityCountryID;
                this.Phone = phone;
                this.Email = email;
                this.Address = address;
            }

            public int PersonID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string NationalID { get; set; }
            public string ImagePath { get; set; }
            public bool Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int NationalityCountryID { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
        }
        #endregion

        #region class user Data Transfer Object (DTO)
        public class clsUserDTO
        {

            public clsUserDTO(int userID, int personID, string userName, string password, bool isActive)

            {
                this.userID = userID;
                this.personID = personID;
                this.userName = userName;
                this.password = password;
                this.isActive = isActive;
            }
            public int userID { set; get; }
            public int personID { set; get; }

            // public clsPersonDTO PersonInfo { set; get; }
            public string userName { set; get; }
            public string password { set; get; }
            public bool isActive { set; get; }

        }
        #endregion

        #region class Application Type Data Transfer Object (DTO)
        public class clsApplicationTypeDTO
        {
            public int? ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; }
            public float ApplicationTypeFees { get; set; }
            public clsApplicationTypeDTO(int? applicationTypeID, string applicationTypeTitle, float applicationTypeFees)
            {
                this.ApplicationTypeID = applicationTypeID;
                this.ApplicationTypeTitle = applicationTypeTitle;
                this.ApplicationTypeFees = applicationTypeFees;
            }
        }
        #endregion

        #region class Test Type Data Transfer Object (DTO)
        public class clsTestTypeDTO
        {
            public clsTestTypeDTO(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
            {
                TestTypeID = testTypeID;
                TestTypeTitle = testTypeTitle;
                TestTypeDescription = testTypeDescription;
                TestTypeFees = testTypeFees;
            }
            public int TestTypeID { get; set; }
            public string TestTypeTitle { get; set; }
            public string TestTypeDescription { get; set; }
            public float TestTypeFees { get; set; }

        }
        #endregion

        #region class Application Data Transfer Object (DTO)
        public class clsApplicationDTO
        {
            public clsApplicationDTO(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
            {
                ApplicationID = applicationID;
                ApplicantPersonID = applicantPersonID;
                ApplicationDate = applicationDate;
                ApplicationTypeID = applicationTypeID;
                ApplicationStatus = applicationStatus;
                LastStatusDate = lastStatusDate;
                PaidFees = paidFees;
                CreatedByUserID = createdByUserID;
            }
            public int ApplicationID { get; set; }
            public int ApplicantPersonID { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int ApplicationTypeID { get; set; }
            public enApplicationStatus ApplicationStatus { get; set; }
            public DateTime LastStatusDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
        }

        #endregion

        #region class Local Driving License Application (DTO)
        public class clsLocalDrivingLicenseApplicationDTO
        {
            public clsLocalDrivingLicenseApplicationDTO(int LocalDrivingLicenseApplicationID, int ApplicationID, int licenseClassID)
            {
                this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
                this.ApplicationID = ApplicationID;
                this.LicenseClassID = licenseClassID;
            }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public int ApplicationID { get; set; }
            public int LicenseClassID { get; set; }
        }
        #endregion

        #region  class Local Driving License Applications  View (DTO)
        public class clsLocalDrivingLicenseApplications_ViewDTO
        {
            public clsLocalDrivingLicenseApplications_ViewDTO(int localDrivingLicenseApplicationID, string LicenseClassName, string NationalID, string FullName, DateTime ApplicationDate, int PassedTestCount, string applicationStatusName)
            {
                this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
                this.LicenseClassName = LicenseClassName;
                this.NationalID = NationalID;
                this.FullName = FullName;
                this.ApplicationDate = ApplicationDate;
                this.PassedTestCount = PassedTestCount;
                this.ApplicationStatusName = applicationStatusName;
            }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public string LicenseClassName { get; set; }
            public string NationalID { get; set; }
            public string FullName { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int PassedTestCount { get; set; }
            public string ApplicationStatusName { get; set; }
        }
        #endregion

        #region class Local Driving License Applicatio + view (DTO)
        public class clsLocalDrivingLicenseApplicationDTO2
        {
            public clsLocalDrivingLicenseApplicationDTO2(clsLocalDrivingLicenseApplicationDTO localDrivingLicenseApplicationDTO, clsApplicationDTO applicationDTO)
            {
                this.LocalDrivingLicenseApplicationDTO = localDrivingLicenseApplicationDTO;
                this.ApplicationDTO = applicationDTO;
            }
            public clsLocalDrivingLicenseApplicationDTO LocalDrivingLicenseApplicationDTO { get; set; }
            public clsApplicationDTO ApplicationDTO { get; set; }
        }
        #endregion

        #region class License Class (DTO)
        public class clsLicenseClassDTO
        {
            public clsLicenseClassDTO(int licenseClassID, string className, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, float classFees)
            {
                LicenseClassID = licenseClassID;
                ClassName = className;
                ClassDescription = classDescription;
                MinimumAllowedAge = minimumAllowedAge;
                DefaultValidityLength = defaultValidityLength;
                ClassFees = classFees;
            }
            public int LicenseClassID { set; get; }
            public string ClassName { set; get; }
            public string ClassDescription { set; get; }
            public byte MinimumAllowedAge { set; get; }
            public byte DefaultValidityLength { set; get; }
            public float ClassFees { set; get; }
        }
        #endregion

        #region class Tests (DTO)
        public class clsTestDTO
        {
            public clsTestDTO(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
            {
                TestID = testID;
                TestAppointmentID = testAppointmentID;
                TestResult = testResult;
                Notes = notes;
                CreatedByUserID = createdByUserID;
            }


            public int TestID { get; set; }
            public int TestAppointmentID { get; set; }
            public bool TestResult { get; set; }
            public string Notes { get; set; }
            public int CreatedByUserID { get; set; }

        }
        #endregion

        #region class Test Appointment (DTO)    
        public class clsTestAppointmentDTO
        {
            public clsTestAppointmentDTO(int TestAppointmentID, DateTime AppointmentDate, decimal PaidFees, bool IsLocked)
            {
                this.TestAppointmentID = TestAppointmentID;
                this.AppointmentDate = AppointmentDate;
                this.PaidFees = PaidFees;
                this.IsLocked = IsLocked;
            }
            public clsTestAppointmentDTO(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID)
            {
                this.TestAppointmentID = TestAppointmentID;
                this.TestTypeID = TestTypeID;
                this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
                this.AppointmentDate = AppointmentDate;
                this.PaidFees = PaidFees;
                this.CreatedByUserID = CreatedByUserID;
                this.IsLocked = IsLocked;
                this.RetakeTestApplicationID = RetakeTestApplicationID;
            }
            public int TestAppointmentID { get; set; } = -1;
            public int TestTypeID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public decimal PaidFees { get; set; } // Using decimal for monetary values
            public int CreatedByUserID { get; set; }
            public bool IsLocked { get; set; }
            public int? RetakeTestApplicationID { get; set; } // Nullable for optional field
        }
        #endregion

        #region class Driver (DTO)
        public class DriverDTO
        {
            public DriverDTO(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
            {
                this.DriverID = DriverID;
                this.PersonID = PersonID;
                this.CreatedByUserID = CreatedByUserID;
                this.CreatedDate = CreatedDate;
            }
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
            public DateTime CreatedDate { get; set; }
        }
        public class Drivers_ViewDTO
        {
            public Drivers_ViewDTO(int DriverID, int PersonID, DateTime CreatedDate, string nationalID, string fullName, int numOfActiveLicense)
            {
                this.DriverID = DriverID;
                this.PersonID = PersonID;
                this.CreatedByUserID = CreatedByUserID;
                this.CreatedDate = CreatedDate;

                NationalID = nationalID;
                FullName = fullName;
                NumOfActiveLicense = numOfActiveLicense;
            }
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
            public DateTime CreatedDate { get; set; }
            public string NationalID { get; set; }
            public string FullName { get; set; }
            public int NumOfActiveLicense { get; set; }

        }
        #endregion

        #region class License (DTO)
        public class LicenseDTO
        {
            public int LicenseID { get; set; }
            public int ApplicationID { get; set; }
            public int DriverID { get; set; }
            public int LicenseClass { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string Notes { get; set; }
            public decimal PaidFees { get; set; }
            public bool IsActive { get; set; }
            public byte IssueReason { get; set; }
            public int CreatedByUserID { get; set; }
        }
        #endregion

        #region  class LicenseView (DTO)
        public class LicenseViewDTO
        {
            public int LicenseID { get; set; }
            public int ApplicationID { get; set; }
            public string ClassName { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
        }
        #endregion,
    }
}