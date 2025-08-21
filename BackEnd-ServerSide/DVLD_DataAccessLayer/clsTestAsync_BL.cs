using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public  class clsTestAsync_BL
    {

        #region GRUD Operations [Without DELETE]
        public static async Task<clsTestDTO> GetTestInfoByIDAsync(int testID)
        {
            return await clsTestAsync_DAL.GetTestInfoByIDAsync(testID);
        }

        public static async Task<int> AddNewTestAsync(clsTestDTO testDTO)
        {
            return await clsTestAsync_DAL.AddNewTestAsync(testDTO);
        }

        public static async Task<bool> UpdateTestAsync(clsTestDTO testDTO)
        {
            return await clsTestAsync_DAL.UpdateTestAsync(testDTO);
        }


        #endregion

        #region other Methods 
        public static async Task<clsTestDTO> GetLastTestByPersonAndTestTypeAndLicenseClassAsync(int personID, int licenseClassID, int testTypeID)
        {
           return await clsTestAsync_DAL.GetLastTestByPersonAndTestTypeAndLicenseClassAsync(personID, licenseClassID, testTypeID);
        }

        public static async Task<List<clsTestDTO>> GetAllTestsAsync()
        {
            return await clsTestAsync_DAL.GetAllTestsAsync();
        }

        public static async Task<int> GetPassedTestCountAsync(int localDrivingLicenseApplicationID)
        {
            return await clsTestAsync_DAL.GetPassedTestCountAsync(localDrivingLicenseApplicationID);
        }
        #endregion

    }
}
