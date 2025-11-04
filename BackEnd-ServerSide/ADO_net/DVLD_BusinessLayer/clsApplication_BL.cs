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
    public  class clsApplication_BL
    {
        #region Get Application Info By ID Async
        public static async Task<clsApplicationDTO> GetApplicationInfoByIDAsync(int applicationID)
        {
            return await clsApplication_DAL.GetApplicationInfoByIDAsync(applicationID);
        }
        #endregion

        #region Get All Applications Async
        public static async Task<List<clsApplicationDTO>> GetAllApplicationsAsync(CancellationToken cancellationToken = default)
        {
            return await clsApplication_DAL.GetAllApplicationsAsync(cancellationToken);
        }
        #endregion

        #region Add New Application Async (DTO version)
        public static async Task<int?> AddNewApplicationAsync(clsApplicationDTO applicationDto, CancellationToken cancellationToken = default)
        {
            return await clsApplication_DAL.AddNewApplicationAsync(applicationDto, cancellationToken);
        }
        #endregion

        #region Update Application Async
        public static async Task<bool> UpdateApplicationAsync(clsApplicationDTO applicationDTO, CancellationToken cancellationToken = default)
        {

            return await clsApplication_DAL.UpdateApplicationAsync(applicationDTO, cancellationToken);
        }
        #endregion

        #region Delete Application Async
        public static async Task<bool> DeleteApplicationAsync(int applicationID, CancellationToken cancellationToken = default)
        {
            return await clsApplication_DAL.DeleteApplicationAsync(applicationID, cancellationToken);
        }
        #endregion

        #region  Is Application Exist
        public static async Task<bool> IsApplicationExistAsync(int applicationId)
        {
            return await clsApplication_DAL.IsApplicationExistAsync(applicationId);
        }
        #endregion

        #region  Get Active Application ID Async
        public static async Task<int?> GetActiveApplicationIDAsync(int personId, int applicationTypeId)
        {
            return await clsApplication_DAL.GetActiveApplicationIDAsync(personId, applicationTypeId);
        }
        #endregion

        #region Does Person Have Active Application
        public static async Task<bool> DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return await clsApplication_DAL.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }
        #endregion

        #region Get Active Application ID For License Class Async
        public static async Task<int> GetActiveApplicationIDForLicenseClassAsync(int personID, int applicationTypeID, int licenseClassID,
            CancellationToken cancellationToken = default)
        {
            return await clsApplication_DAL.GetActiveApplicationIDForLicenseClassAsync(personID, applicationTypeID, licenseClassID, cancellationToken);
        }
        #endregion

        #region 
        public static async Task<bool> UpdateStatusAsync(int applicationID, short newStatus, CancellationToken cancellationToken = default)
        {
            return await clsApplication_DAL.UpdateStatusAsync(applicationID, newStatus, cancellationToken);
        }
        #endregion
    }
}
