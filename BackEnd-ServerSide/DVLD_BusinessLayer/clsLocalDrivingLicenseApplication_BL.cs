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
    public class clsLocalDrivingLicenseApplication_BL
    {
        #region Try Get Local Driving License Application By ID Async
        public static async Task<(bool found,clsLocalDrivingLicenseApplicationDTO result)> TryGetLocalDrivingLicenseApplicationByIDAsync(int applicationId)
        {
            return await clsLocalDrivingLicenseApplication_DAL.TryGetLocalDrivingLicenseApplicationByIDAsync(applicationId);
        }
        #endregion

        #region Try Get Local Driving License Application Info By ApplicationID
        public static async Task<(bool found, clsLocalDrivingLicenseApplicationDTO result)> TryGetLocalDrivingLicenseApplicationByApplicationIdAsync(int applicationId, CancellationToken cancellationToken = default)
        {
            return await clsLocalDrivingLicenseApplication_DAL.TryGetLocalDrivingLicenseApplicationByApplicationIdAsync(applicationId, cancellationToken);
        }
        #endregion

        #region Try Get All Local Driving License App lications Async
        public static async Task<List<clsLocalDrivingLicenseApplications_ViewDTO>> TryGetAllLocalDrivingLicenseApplicationsAsync(CancellationToken cancellationToken = default)
        {
           return await clsLocalDrivingLicenseApplication_DAL.TryGetAllLocalDrivingLicenseApplicationsAsync(cancellationToken);
        }
        #endregion

        #region Try Add New Local Driving License Application Async
        public static async Task<int> TryAddNewLocalDrivingLicenseApplicationAsync(clsLocalDrivingLicenseApplicationDTO DTO, CancellationToken cancellationToken = default)
        {
            return await clsLocalDrivingLicenseApplication_DAL.TryAddNewLocalDrivingLicenseApplicationAsync(DTO, cancellationToken);
        }
        #endregion

        #region Try Update Local Driving License Application Async
        public static async Task<bool> TryUpdateLocalDrivingLicenseApplicationAsync(clsLocalDrivingLicenseApplicationDTO DTO, CancellationToken cancellationToken = default)
        {
           return await clsLocalDrivingLicenseApplication_DAL.TryUpdateLocalDrivingLicenseApplicationAsync(DTO, cancellationToken);
        }
        #endregion

        #region Try Delete Local Driving License Application Async
        public static async Task<bool> TryDeleteLocalDrivingLicenseApplicationAsync(int LocalDrivingLicenseApplicationID, CancellationToken cancellationToken = default)
        {
            return await clsLocalDrivingLicenseApplication_DAL.TryDeleteLocalDrivingLicenseApplicationAsync(LocalDrivingLicenseApplicationID, cancellationToken);
        }
        #endregion

        #region Try Does Pass Test Type Async
        public static async Task<bool> DoesPassTestTypeAsync(int LocalDrivingLicenseApplicationID, int TestTypeID, CancellationToken cancellationToken = default)
        {
            return await clsLocalDrivingLicenseApplication_DAL.DoesPassTestTypeAsync(LocalDrivingLicenseApplicationID, TestTypeID, cancellationToken);
        }
        #endregion

        #region Get Total Trials Per Test Async
        public static async Task<byte> GetTotalTrialsPerTestAsync(int LocalDrivingLicenseApplicationID, int TestTypeID, CancellationToken cancellationToken = default)
        {
            return await clsLocalDrivingLicenseApplication_DAL.GetTotalTrialsPerTestAsync(LocalDrivingLicenseApplicationID, TestTypeID, cancellationToken);
        }
        #endregion

        #region Try Is There An Active Scheduled Test Async
        public static async Task<bool> TryIsThereAnActiveScheduledTestAsync(int LocalDrivingLicenseApplicationID, int TestTypeID, CancellationToken cancellationToken = default)
        {
            return await clsLocalDrivingLicenseApplication_DAL.TryIsThereAnActiveScheduledTestAsync(LocalDrivingLicenseApplicationID, TestTypeID, cancellationToken);
        }
        #endregion


    }
}
