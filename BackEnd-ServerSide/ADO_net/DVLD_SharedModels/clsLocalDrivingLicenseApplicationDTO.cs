using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public  class clsLocalDrivingLicenseApplicationDTO
    {
        public clsLocalDrivingLicenseApplicationDTO(int LocalDrivingLicenseApplicationID , int ApplicationID, int  licenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = licenseClassID;   
        }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
    }
}
