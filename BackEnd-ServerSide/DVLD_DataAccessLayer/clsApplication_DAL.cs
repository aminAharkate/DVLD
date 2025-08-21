using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public  class clsApplication_DAL
    {
        #region Get Application Info By ID Async
        public static async Task<clsApplicationDTO> GetApplicationInfoByIDAsync(int applicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("Application.SP_GetApplicationByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicationID", applicationID);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new clsApplicationDTO(
                            applicationID,
                            (int)reader["ApplicantPersonID"],
                            (DateTime)reader["ApplicationDate"],
                            (int)reader["ApplicationTypeID"],
                            (byte)reader["ApplicationStatus"],
                            (DateTime)reader["LastStatusDate"],
                            Convert.ToSingle(reader["PaidFees"]),
                            (int)reader["CreatedByUserID"]
                        );
                    }
                }
            }
            return null;
        }
        #endregion

        #region Get All Applications Async
        public static async Task<List<clsApplicationDTO>> GetAllApplicationsAsync(CancellationToken cancellationToken = default)
        {
            var applications = new List<clsApplicationDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (SqlCommand command = new SqlCommand("Application.SP_GetAllApplications", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync(cancellationToken);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken))
                    {
                        int applicationIDOrdinal = reader.GetOrdinal("ApplicationID");
                        int applicantPersonIDOrdinal = reader.GetOrdinal("ApplicantPersonID");
                        int applicationDateOrdinal = reader.GetOrdinal("ApplicationDate");
                        // ... get other column ordinals

                        while (await reader.ReadAsync(cancellationToken))
                        {
                            applications.Add(new clsApplicationDTO(
                                ApplicationID: reader.GetInt32(applicationIDOrdinal),
                                ApplicantPersonID: reader.GetInt32(applicantPersonIDOrdinal),
                                ApplicationDate: reader.GetDateTime(applicationDateOrdinal),
                                ApplicationTypeID: reader.GetInt32(reader.GetOrdinal("ApplicationTypeID")),
                                ApplicationStatus: reader.GetByte(reader.GetOrdinal("ApplicationStatus")),
                                LastStatusDate: reader.GetDateTime(reader.GetOrdinal("LastStatusDate")),
                                PaidFees: Convert.ToSingle(reader["PaidFees"]), // Keeping as float per your DTO
                                CreatedByUserID: reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                            ));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log database-specific errors
               // clsLogger.Error(ex, "Database error while fetching applications");
                throw new ApplicationException("Failed to retrieve applications due to database error", ex);
            }
            catch (Exception ex)
            {
                // Log general errors
               // clsLogger.Error(ex, "Unexpected error while fetching applications");
                throw;
            }

            return applications;
        }
        #endregion

        #region Add New Application Async (DTO version)
        public static async Task<int?> AddNewApplicationAsync(clsApplicationDTO applicationDto, CancellationToken cancellationToken = default)
        {

            try
            {
                await  using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                await  using (SqlCommand command = new SqlCommand("Application.SP_AddNewApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Map DTO properties to stored procedure parameters
                    command.Parameters.AddWithValue("@ApplicantPersonID", applicationDto.ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", applicationDto.ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationDto.ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", applicationDto.ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", applicationDto.LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", applicationDto.PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", applicationDto.CreatedByUserID);

                    await connection.OpenAsync(cancellationToken);
                    object result = await command.ExecuteScalarAsync(cancellationToken);

                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : (int?)null; // Return null if no ID is generated

                }
            }
            catch (SqlException ex)
            {
                // clsLogger.Error(ex, "Database error while adding new application");
                throw new ApplicationException("Failed to add new application due to database error", ex);
            }
            catch (Exception ex)
            {
                // clsLogger.Error(ex, "Unexpected error while adding new application");
                throw;
            }

        }
        #endregion

        #region Update Application Async
        public static async Task<bool> UpdateApplicationAsync(clsApplicationDTO applicationDTO,CancellationToken cancellationToken = default)
        {

            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Application.SP_UpdateApplication", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Map DTO properties to stored procedure parameters
                command.Parameters.AddWithValue("@ApplicationID", applicationDTO.ApplicationID);
                command.Parameters.AddWithValue("@ApplicantPersonID", applicationDTO.ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", applicationDTO.ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationDTO.ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", applicationDTO.ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", applicationDTO.LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", applicationDTO.PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", applicationDTO.CreatedByUserID);

                await connection.OpenAsync(cancellationToken);
                int rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);

                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                //clsLogger.Error(ex, $"Database error updating application {applicationDTO?.ApplicationID}");
                return false;
            }
            catch (OperationCanceledException)
            {
                //clsLogger.Warning($"Update operation for application {applicationDTO?.ApplicationID} was cancelled");
                return false;
            }
            catch (Exception ex)
            {
                //clsLogger.Error(ex, $"Unexpected error updating application {applicationDTO?.ApplicationID}");
                return false;
            }
        }
        #endregion

        #region Delete Application Async
        public static async Task<bool> DeleteApplicationAsync(int applicationID, CancellationToken cancellationToken = default)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Application.SP_DeleteApplication", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ApplicationID", applicationID);

                await connection.OpenAsync(cancellationToken);
                int rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);

                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                //clsLogger.Error(ex, $"Database error deleting application {applicationID}");
                return false;
            }
            catch (OperationCanceledException)
            {
                //clsLogger.Warning($"Delete operation for application {applicationID} was cancelled");
                return false;
            }
            catch (Exception ex)
            {
                //clsLogger.Error(ex, $"Unexpected error deleting application {applicationID}");
                return false;
            }
        }
        #endregion

        #region  Is Application Exist
        public static async Task<bool>  IsApplicationExistAsync(int applicationId)
        {
            

            const string storedProcedureName = "Application.SP_IsApplicationExist";

            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", applicationId);
                  
                   await connection.OpenAsync();


                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToBoolean(result ?? false);

                   
                }
            }
            catch (SqlException sqlEx)
            {
                // Log specific SQL exceptions
                // Consider using a proper logging framework in production
                //Debug.WriteLine($"SQL Error checking application existence: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log general exceptions
                //Debug.WriteLine($"Error checking application existence: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region  Get Active Application ID Async
        public static async Task<int?> GetActiveApplicationIDAsync(int personId, int applicationTypeId)
        {
            const int activeStatus = 1; // Could also be configurable or parameterized

            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("Application.SP_GetActiveApplicationID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 30; // Explicit timeout

                    command.Parameters.AddWithValue("@ApplicantPersonID", personId);
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
                    command.Parameters.AddWithValue("@ActiveStatus", activeStatus);

                    await connection.OpenAsync();

                    var result = await command.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int activeApplicationId))
                    {
                        // Optional: Cache the result if appropriate
                        // CacheManager.Set($"ActiveApp_{personId}_{applicationTypeId}", activeApplicationId, TimeSpan.FromMinutes(10));
                        return activeApplicationId;
                    }

                    return null; // Explicit null for "not found"
                }
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 1205) // Deadlock victim
            {
                // Special handling for deadlocks
                //Logger.Warning($"Deadlock occurred while retrieving active application: {sqlEx.Message}");
                // Consider retry logic here
                throw;
            }
            catch (SqlException sqlEx)
            {
                //Logger.Error(sqlEx, $"SQL Error retrieving active application for PersonID {personId}");
                throw; // Re-throw to let caller handle
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, $"Unexpected error retrieving active application");
                throw;
            }
        }
        #endregion

        #region Does Person Have Active Application
        public  static async Task<bool> DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationIDAsync(PersonID, ApplicationTypeID) != null);
        }
        #endregion

        #region Get Active Application ID For License Class Async
        public static async Task<int> GetActiveApplicationIDForLicenseClassAsync(int personID,int applicationTypeID, int licenseClassID,
            CancellationToken cancellationToken = default)
        {
            int activeApplicationID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (SqlCommand command = new SqlCommand("Application.SP_GetActiveApplicationIDForLicenseClass", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@ApplicantPersonID", personID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    await connection.OpenAsync(cancellationToken);
                    object result = await command.ExecuteScalarAsync(cancellationToken);

                    if (result != null && int.TryParse(result.ToString(), out int appID))
                    {
                        activeApplicationID = appID;
                    }
                }
            }
            catch (SqlException ex)
            {
                // clsLogger.Error(ex, "Database error while fetching active application ID");
                throw new ApplicationException("Failed to retrieve active application ID due to database error", ex);
            }
            catch (Exception ex)
            {
                // clsLogger.Error(ex, "Unexpected error while fetching active application ID");
                throw;
            }

            return activeApplicationID;
        }
        #endregion

        #region Update Status Async
        public static async Task<bool> UpdateStatusAsync(int applicationID, short newStatus, CancellationToken cancellationToken = default)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("Application.SP_UpdateApplicationStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                    try
                    {
                        await connection.OpenAsync(cancellationToken);
                        int rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        // Consider logging the exception here
                        return false;
                    }
                }
            }
        }
        #endregion


    }
}
