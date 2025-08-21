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
    public class clsTestType_DAL
    {
        // clss logger is commented out to emplimented it later
        #region Get Test Type Info By ID
        public static clsTestTypeDTO GetTestTypeInfoByID(int testTypeID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestType.SP_GetTestTypeInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           return  new clsTestTypeDTO(
                                reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                                reader.GetString(reader.GetOrdinal("TestTypeTitle")),
                                reader.GetString(reader.GetOrdinal("TestTypeDescription")),
                                Convert.ToSingle(reader.GetOrdinal("TestTypeFees"))
                            );
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            return null;
        }

        #endregion

        #region Get All Test Types
        public static List<clsTestTypeDTO> GetAllTestTypes()
        {
            List<clsTestTypeDTO> testTypes = new List<clsTestTypeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestType.SP_GetAllTestTypes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            testTypes.Add(new clsTestTypeDTO(
                                reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                                reader.GetString(reader.GetOrdinal("TestTypeTitle")),
                                reader.GetString(reader.GetOrdinal("TestTypeDescription")),
                                Convert.ToSingle(reader["TestTypeFees"])
                            ));
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                //Logger.LogError("SQL error occurred while fetching all test types.", sqlEx);
            }
            catch (Exception ex)
            {
                //Logger.LogError("Unexpected error occurred while fetching all test types.", ex);
            }

            return testTypes;
        }

        #endregion

        #region Update Test Type
        public static bool UpdateTestType(clsTestTypeDTO TYDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestType.SP_UpdateTestType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeID", TYDTO.TestTypeID);
                    command.Parameters.AddWithValue("@TestTypeTitle", TYDTO.TestTypeTitle);
                    command.Parameters.AddWithValue("@TestTypeDescription", TYDTO.TestTypeDescription);
                    command.Parameters.AddWithValue("@TestTypeFees", TYDTO.TestTypeFees);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                //Logger.LogError("SQL error occurred while updating TestType.", sqlEx);
                return false;
            }
            catch (Exception ex)
            {
                //Logger.LogError("Unexpected error occurred while updating TestType.", ex);
                return false;
            }

            return rowsAffected > 0;
        }

        #endregion

        #region Add Test Type
        #endregion
    }
}
