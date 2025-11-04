using DVLD_DataAccessLayer;
//using DVLD_SharedModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DVLD_BusinessLayer
//{
//    public  class clsLicenseAsync_BL
//    {

//    }
//}

using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseAsync_BL
    {
        #region CRUD Operations
        public static async Task<LicenseDTO> GetLicenseInfoByIDAsync(int licenseID)
        {
            return await clsLicenseData.GetLicenseInfoByIDAsync(licenseID);
        }

        public static async Task<int> AddNewLicenseAsync(LicenseDTO license)
        {
            return await clsLicenseData.AddNewLicenseAsync(license);
        }

        public static async Task<bool> UpdateLicenseAsync(LicenseDTO license)
        {
            return await clsLicenseData.UpdateLicenseAsync(license);
        }
        #endregion

        #region Special Operations
        public static async Task<List<LicenseViewDTO>> GetAllLicensesAsync()
        {
            return await clsLicenseData.GetAllLicensesAsync();
        }

        public static async Task<List<LicenseViewDTO>> GetDriverLicensesAsync(int driverID)
        {
            return await clsLicenseData.GetDriverLicensesAsync(driverID);
        }

        public static async Task<int> GetActiveLicenseIDByPersonIDAsync(int personID, int licenseClassID)
        {
            return await clsLicenseData.GetActiveLicenseIDByPersonIDAsync(personID, licenseClassID);
        }

        public static async Task<bool> DeactivateLicenseAsync(int licenseID)
        {
            return await clsLicenseData.DeactivateLicenseAsync(licenseID);
        }
        #endregion
    }
}