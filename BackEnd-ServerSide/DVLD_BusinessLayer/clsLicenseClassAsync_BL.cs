using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public  class clsLicenseClassAsync_BL
    {
        #region Get License Class Info By ID Async
        public static async Task<clsLicenseClassDTO> GetLicenseClassInfoByIDAsync(int licenseClassID)
        {
            return await clsLicenseClassAsync_DAL.GetLicenseClassInfoByIDAsync(licenseClassID);
        }
        #endregion

        #region Get License Class Info By Class Name Async
        public static async Task<clsLicenseClassDTO> GetLicenseClassInfoByClassNameAsync(string className)
        {
            return await clsLicenseClassAsync_DAL.GetLicenseClassInfoByClassNameAsync(className);
        }
        #endregion

        #region Get All License Classes Async
        public static async Task<List<clsLicenseClassDTO>> GetAllLicenseClassesAsync()
        {
           return await clsLicenseClassAsync_DAL.GetAllLicenseClassesAsync();
        }
        #endregion

        #region Add New License Class Async
        public static async Task<int> AddNewLicenseClassAsync(clsLicenseClassDTO licenseClass)
        {
           return await clsLicenseClassAsync_DAL.AddNewLicenseClassAsync(licenseClass);
        }
        #endregion

        #region Update License Class Async
        public static async Task<bool> UpdateLicenseClassAsync(clsLicenseClassDTO licenseClass)
        {
           return await clsLicenseClassAsync_DAL.UpdateLicenseClassAsync(licenseClass);
        }
        #endregion

    }
}
