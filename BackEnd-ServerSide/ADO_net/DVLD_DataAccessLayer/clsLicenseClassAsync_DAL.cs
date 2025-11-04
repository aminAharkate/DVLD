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
    public  class clsLicenseClassAsync_DAL
    {
        #region Get License Class Info By ID Async
        public static async Task<clsLicenseClassDTO> GetLicenseClassInfoByIDAsync(int licenseClassID)
        {
            

            const string storedProcedureName = "LicenseClass.SP_GetLicenseClassByID";

            await using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            await using (var command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                try
                {
                    await connection.OpenAsync();

                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new clsLicenseClassDTO(
                                licenseClassID: licenseClassID,
                                className: reader["ClassName"].ToString(),
                                classDescription: reader["ClassDescription"].ToString(),
                                minimumAllowedAge: (byte)reader["MinimumAllowedAge"],
                                defaultValidityLength: (byte)reader["DefaultValidityLength"],
                                classFees: Convert.ToSingle(reader["ClassFees"])
                            );
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Log error (e.g., Serilog, NLog)
                    throw new DataAccessException("Database error occurred while fetching license class.", ex);
                }
            }

            return null;
        }
        #endregion

        #region Get License Class Info By Class Name Async
        public static async Task<clsLicenseClassDTO> GetLicenseClassInfoByClassNameAsync(string className)
        {
            const string SP_NAME = "LicenseClass.SP_GetLicenseClassByClassName";

            await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
            await using var command = new SqlCommand(SP_NAME, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@ClassName", className.Trim());

            try
            {
                await connection.OpenAsync();

                await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);

                if (!await reader.ReadAsync())
                    return null;

                return new clsLicenseClassDTO(
                    licenseClassID: reader.GetInt32("LicenseClassID"),
                    className: className,
                    classDescription: reader.GetString("ClassDescription"),
                    minimumAllowedAge: reader.GetByte("MinimumAllowedAge"),
                    defaultValidityLength: reader.GetByte("DefaultValidityLength"),
                    classFees: reader.GetFloat("ClassFees")
                );
            }
            catch (SqlException ex)
            {
                // Log error here (e.g., Serilog/NLog)
                throw new DataAccessException($"Failed to retrieve license class '{className}'", ex);
            }
        }
        #endregion

        #region Get All License Classes Async
        public static async Task<List<clsLicenseClassDTO>> GetAllLicenseClassesAsync()
        {
            const string SP_NAME = "LicenseClass.SP_GetAllLicenseClasses";
            var licenseClasses = new List<clsLicenseClassDTO>();

            try
            {
                await using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                await using var command = new SqlCommand(SP_NAME, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();

                await using var reader = await command.ExecuteReaderAsync();
                var licenseClassIDOrdinal = reader.GetOrdinal("LicenseClassID");
                var classNameOrdinal = reader.GetOrdinal("ClassName");
                var classDescriptionOrdinal = reader.GetOrdinal("ClassDescription");
                var minimumAllowedAgeOrdinal = reader.GetOrdinal("MinimumAllowedAge");
                var defaultValidityLengthOrdinal = reader.GetOrdinal("DefaultValidityLength");
                var classFeesOrdinal = reader.GetOrdinal("ClassFees");

                while (await reader.ReadAsync())
                {
                    var dto = new clsLicenseClassDTO(
                        licenseClassID: reader.GetInt32(licenseClassIDOrdinal),
                        className: reader.GetString(classNameOrdinal),
                        classDescription: reader.GetString(classDescriptionOrdinal),
                        minimumAllowedAge: reader.GetByte(minimumAllowedAgeOrdinal),
                        defaultValidityLength: reader.GetByte(defaultValidityLengthOrdinal),
                        classFees: Convert.ToSingle(reader.GetValue(classFeesOrdinal))
                    );

                    licenseClasses.Add(dto);
                }
            }
            catch (SqlException ex)
            {
                // Logging can be added here
                throw new DataAccessException("Failed to retrieve license classes list", ex);
            }

            return licenseClasses;
        }
        #endregion

        #region Add New License Class Async
        public static async Task<int> AddNewLicenseClassAsync(clsLicenseClassDTO licenseClass)
        {
            const string SP_NAME = "LicenseClass.SP_AddNewLicenseClass";
            int licenseClassID = -1;

            await using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            await using (var command = new SqlCommand(SP_NAME, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClassName", licenseClass.ClassName);
                command.Parameters.AddWithValue("@ClassDescription", licenseClass.ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", licenseClass.MinimumAllowedAge);
                command.Parameters.AddWithValue("@DefaultValidityLength", licenseClass.DefaultValidityLength);
                command.Parameters.AddWithValue("@ClassFees", licenseClass.ClassFees);

                // Output parameter for the new ID
                var idParam = new SqlParameter("@NewLicenseClassID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParam);

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (idParam.Value != DBNull.Value)
                    {
                        licenseClassID = Convert.ToInt32(idParam.Value);
                    }
                }
                catch (SqlException ex)
                {
                    // Log error (e.g., Serilog, NLog)
                    throw new DataAccessException("Database error occurred while adding new license class.", ex);
                }
            }

            return licenseClassID;
        }
        #endregion

        #region Update License Class Async
        public static async Task<bool> UpdateLicenseClassAsync(clsLicenseClassDTO licenseClass)
        {
            const string SP_NAME = "LicenseClass.SP_UpdateLicenseClass";
            int rowsAffected = 0;

            await using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            await using (var command = new SqlCommand(SP_NAME, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@LicenseClassID", licenseClass.LicenseClassID);
                command.Parameters.AddWithValue("@ClassName", licenseClass.ClassName);
                command.Parameters.AddWithValue("@ClassDescription", licenseClass.ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", licenseClass.MinimumAllowedAge);
                command.Parameters.AddWithValue("@DefaultValidityLength", licenseClass.DefaultValidityLength);
                command.Parameters.AddWithValue("@ClassFees", licenseClass.ClassFees);

                try
                {
                    await connection.OpenAsync();
                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    // Log error (e.g., Serilog, NLog)
                    throw new DataAccessException("Database error occurred while updating license class.", ex);
                }
            }

            return rowsAffected > 0;
        }
        #endregion



    }
}

#region
#endregion
#region
#endregion
#region
#endregion
#region
#endregion