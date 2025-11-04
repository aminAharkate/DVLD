using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static DVLD_DataAccess.clsLicenseData;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {
        public static async Task<LicenseDTO> GetLicenseInfoByIDAsync(int licenseID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_GetLicenseByID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LicenseID", licenseID);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new LicenseDTO
                    {
                        LicenseID = reader.GetInt32("LicenseID"),
                        ApplicationID = reader.GetInt32("ApplicationID"),
                        DriverID = reader.GetInt32("DriverID"),
                        LicenseClass = reader.GetInt32("LicenseClass"),
                        IssueDate = reader.GetDateTime("IssueDate"),
                        ExpirationDate = reader.GetDateTime("ExpirationDate"),
                        Notes = reader.IsDBNull("Notes") ? string.Empty : reader.GetString("Notes"),
                        PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                        IsActive = reader.GetBoolean("IsActive"),
                        IssueReason = reader.GetByte("IssueReason"),
                        CreatedByUserID = reader.GetInt32("CreatedByUserID")
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error retrieving license information", ex);
            }
        }

        public static async Task<List<LicenseViewDTO>> GetAllLicensesAsync()
        {
            var licenses = new List<LicenseViewDTO>();

            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_GetAllLicenses", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    licenses.Add(new LicenseViewDTO
                    {
                        LicenseID = reader.GetInt32("LicenseID"),
                        ApplicationID = reader.GetInt32("ApplicationID"),
                        ClassName = reader.GetString("ClassName"),
                        IssueDate = reader.GetDateTime("IssueDate"),
                        ExpirationDate = reader.GetDateTime("ExpirationDate"),
                        IsActive = reader.GetBoolean("IsActive")
                    });
                }

                return licenses;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error retrieving all licenses", ex);
            }
        }

        public static async Task<List<LicenseViewDTO>> GetDriverLicensesAsync(int driverID)
        {
            var licenses = new List<LicenseViewDTO>();

            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_GetDriverLicenses", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@DriverID", driverID);
                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    licenses.Add(new LicenseViewDTO
                    {
                        LicenseID = reader.GetInt32("LicenseID"),
                        ApplicationID = reader.GetInt32("ApplicationID"),
                        ClassName = reader.GetString("ClassName"),
                        IssueDate = reader.GetDateTime("IssueDate"),
                        ExpirationDate = reader.GetDateTime("ExpirationDate"),
                        IsActive = reader.GetBoolean("IsActive")
                    });
                }

                return licenses;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error retrieving driver licenses", ex);
            }
        }

        public static async Task<int> AddNewLicenseAsync(LicenseDTO license)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_AddNewLicense", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", license.DriverID);
                command.Parameters.AddWithValue("@LicenseClass", license.LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(license.Notes) ? DBNull.Value : (object)license.Notes);
                command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                command.Parameters.AddWithValue("@IsActive", license.IsActive);
                command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

                var idParam = new SqlParameter("@LicenseID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParam);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)idParam.Value;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error adding new license", ex);
            }
        }

        public static async Task<bool> UpdateLicenseAsync(LicenseDTO license)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_UpdateLicense", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LicenseID", license.LicenseID);
                command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", license.DriverID);
                command.Parameters.AddWithValue("@LicenseClass", license.LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(license.Notes) ? DBNull.Value : (object)license.Notes);
                command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                command.Parameters.AddWithValue("@IsActive", license.IsActive);
                command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

                var rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(rowsAffectedParam);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)rowsAffectedParam.Value > 0;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error updating license", ex);
            }
        }

        public static async Task<int> GetActiveLicenseIDByPersonIDAsync(int personID, int licenseClassID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_GetActiveLicenseIDByPersonID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@LicenseClass", licenseClassID);

                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();

                if (result != null && int.TryParse(result.ToString(), out int licenseID))
                {
                    return licenseID;
                }

                return -1;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error getting active license ID", ex);
            }
        }

        public static async Task<bool> DeactivateLicenseAsync(int licenseID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("License.SP_DeactivateLicense", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LicenseID", licenseID);

                var rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(rowsAffectedParam);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)rowsAffectedParam.Value > 0;
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error deactivating license", ex);
            }
        }

    }
}
