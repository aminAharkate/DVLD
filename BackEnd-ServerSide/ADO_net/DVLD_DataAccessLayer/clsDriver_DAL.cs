using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//for login this looks like it is .net framwordk we need . net core 
//using Microsoft.Extensions.Logging;

namespace DVLD_DataAccessLayer
{
    public  class clsDriver_DAL
    {
       
       
        #region CRUD
        public static  async Task<DriverDTO> GetDriverInfoByDriverIDAsync(int driverID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Driver.SPGetDriverByID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@DriverID", driverID);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new DriverDTO
                    (
                        reader.GetInt32("DriverID"),
                        reader.GetInt32("PersonID"),
                        reader.GetInt32("CreatedByUserID"),
                        reader.GetDateTime("CreatedDate")
                    );
                }

                return null;
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error retrieving driver with ID {DriverID}", driverID);
                throw new DataAccessException("Error retrieving driver information", ex);
            }
        }

        public static  async Task<DriverDTO> GetDriverInfoByPersonIDAsync(int personID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Driver.SPGetDriverByPersonID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PersonID", personID);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new DriverDTO
                    (
                        reader.GetInt32("DriverID"),
                        reader.GetInt32("PersonID"),
                        reader.GetInt32("CreatedByUserID"),
                        reader.GetDateTime("CreatedDate")
                    );
                }

                return null;
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error retrieving driver for person with ID {PersonID}", personID);
                throw new DataAccessException("Error retrieving driver information by person ID", ex);
            }
        }

        public static  async Task<int> AddNewDriverAsync(int personID, int createdByUserID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Driver.SPAddNewDriver", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                var idParam = new SqlParameter("@DriverID", SqlDbType.Int)
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
                //_logger?.LogError(ex, "Error adding new driver for person {PersonID}", personID);
                throw new DataAccessException("Error adding new driver", ex);
            }
        }

        public static  async Task<bool> UpdateDriverAsync(DriverDTO dto)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Driver.SPUpdateDriver", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@DriverID", dto.DriverID);
                command.Parameters.AddWithValue("@PersonID", dto.PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);

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
                //_logger?.LogError(ex, "Error updating driver {DriverID}", driverID);
                throw new DataAccessException("Error updating driver", ex);
            }
        }
    
        #endregion

        #region sepecile
        public static  async Task<List<Drivers_ViewDTO>> GetAllDriversAsync()
        {
            var drivers = new List<Drivers_ViewDTO>();

            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("Driver.SPGetAllDrivers", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();
               
                while (await reader.ReadAsync())
                {
                   
                    drivers.Add(new  Drivers_ViewDTO(
                                                    reader.GetInt32("DriverID"),
                                                    reader.GetInt32("PersonID"),
                                                    reader.GetDateTime("CreatedDate"),
                                                    reader.GetString("NationalNo"),
                                                    // reader.GetString("FullName"),
                                                    reader.IsDBNull("FullName") ? "amine Ahrkate" : reader.GetString("FullName"),

                                                    reader.GetInt32("NumberOfActiveLicenses")
                                                    ));
                }
            
                    




              

                return drivers;
            }
            catch (Exception ex)
            {
                // _logger?.LogError(ex, "Error retrieving all drivers");
                throw new DataAccessException("Error retrieving all drivers", ex);
            }
        }
        
        #endregion
    }
}
