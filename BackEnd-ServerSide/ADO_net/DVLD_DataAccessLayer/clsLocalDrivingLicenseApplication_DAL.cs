using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class DataAccessException : Exception
    {
        public DataAccessException() { }
        public DataAccessException(string message) : base(message) { }
        public DataAccessException(string message, Exception inner) : base(message, inner) { }
    }
    public  class clsLocalDrivingLicenseApplication_DAL
    {
        /// <summary>
        /// Provides data access methods for Local Driving License Application operations
        /// </summary>
        #region Try Get Local Driving License Application By ID Async
        public static async Task<(bool found, clsLocalDrivingLicenseApplicationDTO result)> TryGetLocalDrivingLicenseApplicationByIDAsync(int applicationId)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_GetLocalDrivingLicenseApplicationByID";

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", applicationId);

                await connection.OpenAsync();

                await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);

                if (await reader.ReadAsync())
                {
                    return(true, new clsLocalDrivingLicenseApplicationDTO(
                        LocalDrivingLicenseApplicationID: reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                        ApplicationID: reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                        licenseClassID: reader.GetInt32(reader.GetOrdinal("LicenseClassID"))));
                }
            }
            catch (SqlException ex) 
            {
                // Implement retry logic here if needed for transient errors
                //Logger.Error(ex, "Transient database error while retrieving driving license application");
                throw; // Or implement retry pattern
            }
            
            catch (Exception ex)
            {
                //Logger.Error(ex, "Unexpected error while retrieving driving license application");
                throw ;//new DataAccessException("An unexpected error occurred", ex);
            }

            return (false, null); // Or consider throwing NotFoundException
        }
        #endregion

        #region Try Get Local Driving License Application Info By ApplicationID
        
        
            /// <param name="applicationId">The ID of the application to retrieve</param>
            /// <returns>
            /// A <see cref="clsLocalDrivingLicenseApplicationDTO"/> object if found, 
            /// null if not found, or throws an exception on error
            /// </returns>
            /// 
            /// <exception cref="SqlException">Thrown when a database-specific error occurs</exception>
            /// <exception cref="Exception">Thrown when an unexpected error occurs</exception>
            /// 
            /// <remarks>
            /// This method uses the stored procedure LocalDrivingLicenseApplication.SP_GetLocalDrivingLicenseApplicationByAppID
            /// </remarks>
            public static async Task<(bool found, clsLocalDrivingLicenseApplicationDTO result)> TryGetLocalDrivingLicenseApplicationByApplicationIdAsync(int applicationId , CancellationToken cancellationToken = default)
            {
                const string storedProcedureName = "LocalDrivingLicenseApplication.[SP_GetLocalDrivingLicenseApplicationByApplicationID]";

                try
                {
                    await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                    await using var command = new SqlCommand(storedProcedureName, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@ApplicationID", applicationId);

                    await connection.OpenAsync(cancellationToken);

                    await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow | CommandBehavior.SequentialAccess, cancellationToken);

                    if (await reader.ReadAsync(cancellationToken))
                    {
                        return(true, new clsLocalDrivingLicenseApplicationDTO(
                            LocalDrivingLicenseApplicationID: reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                            ApplicationID: applicationId,
                            licenseClassID: reader.GetInt32(reader.GetOrdinal("LicenseClassID"))));
                    }

                    return (false,null);
                }
                catch (SqlException ex)
                {
                    // Log error here
                    throw;//new DataAccessException("Database error while retrieving driving license application by ApplicationID", ex);
                }
                catch (Exception ex)
                {
                     // Log error here
                     throw;//new DataAccessException("Unexpected error while retrieving driving license application by ApplicationID", ex);
                }
            }




        #endregion

        #region Try Get All Local Driving License App lications Async
        public static async Task<List<clsLocalDrivingLicenseApplications_ViewDTO>> TryGetAllLocalDrivingLicenseApplicationsAsync(CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_GetAllLocalDrivingLicenseApplications";
            var applications = new List<clsLocalDrivingLicenseApplications_ViewDTO>();

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync(cancellationToken);

                await using var reader = await command.ExecuteReaderAsync(cancellationToken);

                while (await reader.ReadAsync(cancellationToken))
                {
                    applications.Add(new clsLocalDrivingLicenseApplications_ViewDTO(
                        localDrivingLicenseApplicationID: reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                        LicenseClassName: reader.GetString(reader.GetOrdinal("ClassName")),
                        NationalID: reader.GetString(reader.GetOrdinal("NationalNo")),
                       "Amin Aharkate", //FullName: reader.GetString(reader.GetOrdinal("FullName")),
                        ApplicationDate: reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                        PassedTestCount: reader.GetInt32(reader.GetOrdinal("PassedTestCount")),
                        applicationStatusName: reader.GetString(reader.GetOrdinal("Status"))
                    ));
                }
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while retrieving all driving license applications");
                throw new DataAccessException("Failed to retrieve driving license applications", ex);
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while retrieving all driving license applications");
                throw new DataAccessException("An unexpected error occurred", ex);
            }

            return applications;
        }
        #endregion

        #region Try Add New Local Driving License Application Async
        public static async Task<int> TryAddNewLocalDrivingLicenseApplicationAsync(clsLocalDrivingLicenseApplicationDTO DTO, CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_AddNewLocalDrivingLicenseApplication";
            int LocalDrivingLicenseApplicationID = -1;

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ApplicationID", DTO.ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", DTO.LicenseClassID);

                await connection.OpenAsync(cancellationToken);

                object result = await command.ExecuteScalarAsync(cancellationToken);

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
                }
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while adding new local driving license application");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while adding new local driving license application");
                throw;
            }

            return LocalDrivingLicenseApplicationID;
        }
        #endregion

        #region Try Update Local Driving License Application Async
        public static async Task<bool> TryUpdateLocalDrivingLicenseApplicationAsync(clsLocalDrivingLicenseApplicationDTO DTO ,CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_UpdateLocalDrivingLicenseApplication";
            int rowsAffected = 0;

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", DTO.LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@ApplicationID", DTO.ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", DTO.LicenseClassID);

                await connection.OpenAsync(cancellationToken);
                rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while updating local driving license application");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while updating local driving license application");
                throw;
            }

            return rowsAffected > 0;
        }
        #endregion

        #region Try Delete Local Driving License Application Async
        public static async Task<bool> TryDeleteLocalDrivingLicenseApplicationAsync(int LocalDrivingLicenseApplicationID, CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_DeleteLocalDrivingLicenseApplication";
            int rowsAffected = 0;

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                await connection.OpenAsync(cancellationToken);
                rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while deleting local driving license application");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while deleting local driving license application");
                throw;
            }

            return rowsAffected > 0;
        }
        #endregion

        #region Does Attend Test Type Async

        /// <summary>
        /// Checks if a test type has been attended for a specific local driving license application
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">The ID of the local driving license application</param>
        /// <param name="TestTypeID">The test type ID to check</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>
        /// True if the test type was attended, false otherwise
        /// </returns>
        /// <exception cref="SqlException">Thrown when a database-specific error occurs</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs</exception>
        /// <remarks>
        /// This method uses the stored procedure LocalDrivingLicenseApplication.SP_DoesAttendTestType
        /// </remarks>
        public static async Task<bool> DoesAttendTestTypeAsync(int LocalDrivingLicenseApplicationID, int TestTypeID, CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_DoesAttendTestType";

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                await connection.OpenAsync(cancellationToken);

                object result = await command.ExecuteScalarAsync(cancellationToken);

                return result != null;
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while checking test type attendance");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while checking test type attendance");
                throw;
            }
        }

        #endregion

        #region Try Does Pass Test Type Async
        public static async Task<bool> DoesPassTestTypeAsync( int LocalDrivingLicenseApplicationID,int TestTypeID, CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_DoesPassTestType";
            bool result = false;

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                await connection.OpenAsync(cancellationToken);

                var dbResult = await command.ExecuteScalarAsync(cancellationToken);

                if (dbResult != null && bool.TryParse(dbResult.ToString(), out bool returnedResult))
                {
                    result = returnedResult;
                }
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while checking test type result");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while checking test type result");
                throw;
            }

            return result;
        }
        #endregion

        #region Get Total Trials PerTest Async
        /// <summary>
        /// Gets the total number of trials taken for a specific test type in a local driving license application
        /// </summary>
        /// <param name="LocalDrivingLicenseApplicationID">The ID of the local driving license application</param>
        /// <param name="TestTypeID">The test type ID to check</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>
        /// The number of trials taken as a byte (0 if no trials found)
        /// </returns>
        /// <exception cref="SqlException">Thrown when a database-specific error occurs</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs</exception>
        /// <remarks>
        /// This method uses the stored procedure LocalDrivingLicenseApplication.SP_GetTotalTrialsPerTest
        /// </remarks>
        public static async Task<byte> GetTotalTrialsPerTestAsync(int LocalDrivingLicenseApplicationID, int TestTypeID, CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_GetTotalTrialsPerTest";

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                await connection.OpenAsync(cancellationToken);

                object result = await command.ExecuteScalarAsync(cancellationToken);

                if (result != null && byte.TryParse(result.ToString(), out byte trials))
                {
                    return trials;
                }

                return 0;
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while retrieving total trials per test");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while retrieving total trials per test");
                throw;
            }
        }
        #endregion  

        #region Try Is There An Active Scheduled Test Async
        public static async Task<bool> TryIsThereAnActiveScheduledTestAsync(int LocalDrivingLicenseApplicationID, int TestTypeID, CancellationToken cancellationToken = default)
        {
            const string storedProcedureName = "LocalDrivingLicenseApplication.SP_IsThereAnActiveScheduledTest";
            bool result = false;

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                await connection.OpenAsync(cancellationToken);

                object dbResult = await command.ExecuteScalarAsync(cancellationToken);

                if (dbResult != null)
                {
                    result = true;
                }
            }
            catch (SqlException ex)
            {
                // Logger.Error(ex, "Database error while checking for active scheduled test");
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(ex, "Unexpected error while checking for active scheduled test");
                throw;
            }

            return result;
        }
        #endregion




    }
}








#region
#endregion
#region
#endregion
