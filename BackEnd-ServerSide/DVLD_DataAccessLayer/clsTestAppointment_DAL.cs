
using Azure.Core;
using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Microsoft.Extensions.Logging;

namespace DVLD_DataAccessLayer
{
    public class clsTestAppointment_DAL
    {
        //private readonly string _connectionString;
        //private readonly ILogger<clsTestAppointment_DAL> _logger;

        //public clsTestAppointment_DAL(string connectionString, ILogger<clsTestAppointment_DAL> logger = null)
        //{
        //    _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        //    _logger = logger;
        //}

        
        public static  async Task<clsTestAppointmentDTO> GetTestAppointmentByIDAsync(int testAppointmentID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_GetTestAppointmentByID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new clsTestAppointmentDTO
                    (
                        reader.GetInt32("TestAppointmentID"),
                        reader.GetInt32("TestTypeID"),
                        reader.GetInt32("LocalDrivingLicenseApplicationID"),
                        reader.GetDateTime("AppointmentDate"),
                        reader.GetDecimal("PaidFees"),
                        reader.GetInt32("CreatedByUserID"),
                        reader.GetBoolean("IsLocked"),
                        reader.IsDBNull("RetakeTestApplicationID") ?
                        null : (int?)reader.GetInt32("RetakeTestApplicationID")
                    );
                }

            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error retrieving test appointment with ID {TestAppointmentID}", testAppointmentID);
               // throw new DataAccessException("Error retrieving test appointment", ex);
            }
                return null;
        }

        public static  async Task<clsTestAppointmentDTO> GetLastTestAppointmentAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_GetLastTestAppointment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new clsTestAppointmentDTO
                    (
                        reader.GetInt32("TestAppointmentID"),
                        reader.GetInt32("TestTypeID"),
                        reader.GetInt32("LocalDrivingLicenseApplicationID"),
                        reader.GetDateTime("AppointmentDate"),
                        reader.GetDecimal("PaidFees"),
                        reader.GetInt32("CreatedByUserID"),
                        reader.GetBoolean("IsLocked"),
                        reader.IsDBNull("RetakeTestApplicationID") ?
                        null : (int?)reader.GetInt32("RetakeTestApplicationID")
                    );
                }

            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex,
                //    "Error retrieving last test appointment for ApplicationID {ApplicationID} and TestTypeID {TestTypeID}",
                //    localDrivingLicenseApplicationID, testTypeID);
                //throw new DataAccessException("Error retrieving last test appointment", ex);
            }
                return null;
        }

        public static  async Task<IEnumerable<clsTestAppointmentDTO>> GetAllTestAppointmentsAsync()
        {
            var appointments = new List<clsTestAppointmentDTO>();

            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_GetAllTestAppointments", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    appointments.Add(new clsTestAppointmentDTO
                    (
                        reader.GetInt32("TestAppointmentID"),
                        reader.GetInt32("TestTypeID"),
                        reader.GetInt32("LocalDrivingLicenseApplicationID"),
                        reader.GetDateTime("AppointmentDate"),
                        reader.GetDecimal("PaidFees"),
                        reader.GetInt32("CreatedByUserID"),
                        reader.GetBoolean("IsLocked"),
                        reader.IsDBNull("RetakeTestApplicationID") ?
                        null : (int?)reader.GetInt32("RetakeTestApplicationID")
                    ));
                }

            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error retrieving all test appointments");
                //throw new DataAccessException("Error retrieving all test appointments", ex);
            }
                return appointments;
        }
        
        //GetApplicationTestAppointmentsPerTestType
        public static  async Task<IEnumerable<clsTestAppointmentDTO>> GetTestAppointmentsByApplicationAndTypeAsync(
            int localDrivingLicenseApplicationID, int testTypeID)
        {
            var appointments = new List<clsTestAppointmentDTO>();

            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_GetTestAppointmentsByApplicationAndType", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    appointments.Add(new clsTestAppointmentDTO
                    (
                        reader.GetInt32("TestAppointmentID"),
                        reader.GetDateTime("AppointmentDate"),
                        reader.GetDecimal("PaidFees"),
                        reader.GetBoolean("IsLocked")
                    ));
                }

            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex,
                //    "Error retrieving test appointments for ApplicationID {ApplicationID} and TestTypeID {TestTypeID}",
                //    localDrivingLicenseApplicationID, testTypeID);
                //throw new DataAccessException("Error retrieving test appointments by application and type", ex);
            }
                return appointments;
        }

        public static  async Task<int> AddTestAppointmentAsync(clsTestAppointmentDTO appointment)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_AddTestAppointment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@TestTypeID", appointment.TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", appointment.LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", appointment.PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", appointment.CreatedByUserID);
                command.Parameters.AddWithValue("@RetakeTestApplicationID",
                    appointment.RetakeTestApplicationID ?? (object)DBNull.Value);

                var idParam = new SqlParameter("@TestAppointmentID", SqlDbType.Int)
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
                //_logger?.LogError(ex, "Error adding new test appointment");
                //throw new DataAccessException("Error adding new test appointment", ex);
            }
            return -1; // Indicating failure
        }

        public static  async Task<bool> UpdateTestAppointmentAsync(clsTestAppointmentDTO appointment)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_UpdateTestAppointment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@TestAppointmentID", appointment.TestAppointmentID);
                command.Parameters.AddWithValue("@TestTypeID", appointment.TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", appointment.LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", appointment.PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", appointment.CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", appointment.IsLocked);
                command.Parameters.AddWithValue("@RetakeTestApplicationID",
                    appointment.RetakeTestApplicationID ?? (object)DBNull.Value);

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
                //_logger?.LogError(ex, "Error updating test appointment {TestAppointmentID}", appointment.TestAppointmentID);
                //throw new DataAccessException("Error updating test appointment", ex);
            }
            return false;
        }

        //GetTestID
        public static  async Task<int?> GetTestIDByAppointmentIDAsync(int testAppointmentID)
        {
            try
            {
                using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
                using var command = new SqlCommand("TestAppointment.SP_GetTestIDByAppointmentID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                var testIdParam = new SqlParameter("@TestID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(testIdParam);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return testIdParam.Value == DBNull.Value ? null : (int?)testIdParam.Value;
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error getting TestID for appointment {TestAppointmentID}", testAppointmentID);
                //throw new DataAccessException("Error getting TestID by appointment ID", ex);
            }
            return null;
        }
    }

    //public class DataAccessException : Exception
    //{
    //    public DataAccessException() { }
    //    public DataAccessException(string message) : base(message) { }
    //    public DataAccessException(string message, Exception inner) : base(message, inner) { }
    //}
}