using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public  class clsTestAsync_DAL
    {
        #region Additional things
        //private readonly ILogger _logger;
        #endregion

        #region DTO + Constructor
        //private clsTestDTO _TestDTO;

        //clsTestAsync_DAL(clsTestDTO testDTO)
        //{
        //    _TestDTO = testDTO;
        //}
        #endregion

        #region Mapping Method
        private static  clsTestDTO MapReaderToTestInfo(SqlDataReader reader)
        {
            return new clsTestDTO
            (
                reader.GetInt32(reader.GetOrdinal("TestID")),
                reader.GetInt32(reader.GetOrdinal("TestAppointmentID")),
                reader.GetBoolean(reader.GetOrdinal("TestResult")),
                reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
            );
        }
        #endregion

        #region GRUD Operations [Without DELETE]
        public static  async Task<clsTestDTO> GetTestInfoByIDAsync(int testID)
        {
            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("[Tests].[SP_GetTestInfoByID]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestID", testID);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToTestInfo(reader);
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error retrieving test info for TestID {TestID}", testID);
                throw;
            }
        }

        public static  async Task<int> AddNewTestAsync(clsTestDTO testDTO)
        {
            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("[Tests].[SP_AddNewTest]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", testDTO.TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", testDTO.TestResult);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(testDTO.Notes) ? (object)DBNull.Value : testDTO.Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", testDTO.CreatedByUserID);
                    command.Parameters.Add("@TestID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (int)command.Parameters["@TestID"].Value;
                }
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error adding new test for appointment {TestAppointmentID}", testInfo.TestAppointmentID);
                throw;
            }
        }

        public static async Task<bool> UpdateTestAsync(clsTestDTO testDTO)
        {
            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("[Tests].[sp_UpdateTest]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestID", testDTO.TestID);
                    command.Parameters.AddWithValue("@TestAppointmentID", testDTO.TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", testDTO.TestResult);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(testDTO.Notes) ? (object)DBNull.Value : testDTO.Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", testDTO.CreatedByUserID);
                    command.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (int)command.Parameters["@RowsAffected"].Value > 0;
                }
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error updating test {TestID}", testInfo.TestID);
                throw;
            }
        }


        #endregion

        #region other Methods 
        public static  async Task<clsTestDTO> GetLastTestByPersonAndTestTypeAndLicenseClassAsync(int personID, int licenseClassID, int testTypeID)
        {
            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("[Tests].[SP_GetLastTestByPersonAndTestTypeAndLicenseClass]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToTestInfo(reader);
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex,
                //  "Error retrieving last test for PersonID {PersonID}, LicenseClassID {LicenseClassID}, TestTypeID {TestTypeID}",
                //  personID, licenseClassID, testTypeID);
                throw;
            }
        }

        public static  async Task<List<clsTestDTO>> GetAllTestsAsync()
        {
            var tests = new List<clsTestDTO>();

            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("[Tests].[sp_GetAllTests]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tests.Add(MapReaderToTestInfo(reader));
                        }
                    }
                }
                return tests;
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex, "Error retrieving all tests");
                throw;
            }
        }

        public static  async Task<int> GetPassedTestCountAsync(int localDrivingLicenseApplicationID)
        {
            try
            {
                using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (var command = new SqlCommand("[Tests].[SP_GetPassedTestCount]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.Add("@PassedCount", SqlDbType.Int).Direction = ParameterDirection.Output;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (int)command.Parameters["@PassedCount"].Value;
                }
            }
            catch (Exception ex)
            {
                //_logger?.LogError(ex,
                //"Error getting passed test count for application {LocalDrivingLicenseApplicationID}",
                //localDrivingLicenseApplicationID);
                throw;
            }
        }
        #endregion

    }
}
