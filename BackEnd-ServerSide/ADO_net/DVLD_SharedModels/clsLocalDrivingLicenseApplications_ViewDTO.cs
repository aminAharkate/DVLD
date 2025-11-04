using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public  class clsLocalDrivingLicenseApplications_ViewDTO
    {
        public clsLocalDrivingLicenseApplications_ViewDTO(int localDrivingLicenseApplicationID, string LicenseClassName, string  NationalID, string FullName, DateTime ApplicationDate, int PassedTestCount, string applicationStatusName)
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
        public string  FullName{ get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PassedTestCount { get; set; }
        public string ApplicationStatusName { get; set; }
    }
}
