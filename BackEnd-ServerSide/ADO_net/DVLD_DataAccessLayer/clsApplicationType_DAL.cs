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
    public  class clsApplicationType_DAL
    {
        #region Get Application Type Info
        public static clsApplicationTypeDTO GetApplicationTypeInfoByID(int applicationTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ApplicationType.SP_GetApplicationTypeInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsApplicationTypeDTO
                                (
                                    reader["ApplicationTypeID"] as int?,
                                    reader["ApplicationTypeTitle"].ToString(),
                                    Convert.ToSingle(reader["ApplicationFees"]) // Corrected conversion
                                );
                            }
                            else
                            {
                                return null; // If no record is found, return null
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error if necessary
                        return null;
                    }
                }
            }
        }



        #endregion

        #region Get AllApplication Types
        public static List<clsApplicationTypeDTO> GetAllApplicationTypes()
        {
            List<clsApplicationTypeDTO> applicationTypes = new List<clsApplicationTypeDTO>();

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ApplicationType.SP_GetAllApplicationTypes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                applicationTypes.Add(new clsApplicationTypeDTO(
                                    reader["ApplicationTypeID"] as int?,
                                    reader["ApplicationTypeTitle"].ToString(),
                                    Convert.ToSingle(reader["ApplicationFees"])
                                ));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error if necessary
                    }
                }
            }

            return applicationTypes;
        }


        #endregion

        #region  Add New Application Type
        public static int? AddNewApplicationType(clsApplicationTypeDTO applicationType)
        {
            int applicationTypeID = -1;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ApplicationType.SP_AddNewApplicationType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationType.ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", applicationType.ApplicationTypeFees);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            applicationTypeID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error if necessary
                    }
                }
            }

            return applicationTypeID;
        }

        #endregion

        #region Update Application Type
        public static bool UpdateApplicationType(clsApplicationTypeDTO applicationType)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ApplicationType.SP_UpdateApplicationType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationType.ApplicationTypeID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationType.ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", applicationType.ApplicationTypeFees);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log error if necessary
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }

        #endregion


    }
}
