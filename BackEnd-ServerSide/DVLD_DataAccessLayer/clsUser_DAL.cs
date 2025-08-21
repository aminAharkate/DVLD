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
    public class clsUser_DAL
    {
        #region Get User Info By UserID
        public static clsUserDTO GetUserInfoByUserID(int userID)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_GetUserInfoByUserID]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsUserDTO
                                (
                                    (int)reader["UserID"],
                                    (int)reader["PersonID"],
                                    reader["UserName"].ToString(),
                                    reader["Password"].ToString(),
                                    (bool)reader["IsActive"]
                                );
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return null;
        }
        #endregion

        #region Get User Info By PersonID
        public static clsUserDTO GetUserInfoByPersonID(int PersonID)
        {
            

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_GetUserInfoByPersonID]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return  new clsUserDTO
                            (
                                reader["UserID"] as int? ?? 0,
                                reader["PersonID"] as int? ?? 0,
                                reader["UserName"]?.ToString() ?? string.Empty,
                                reader["Password"]?.ToString() ?? string.Empty,
                                reader["IsActive"] as bool? ?? false
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex); // Consider using a structured logging framework
                }
            }

            return null; // Returns null if no data is found
        }
       

        #endregion

        #region Get User Info By Username And Password
        public static clsUserDTO GetUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            clsUserDTO user = null;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_GetUserInfoByUsernameAndPassword]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return   new clsUserDTO
                            (
                                reader["UserID"] as int? ?? 0,
                                reader["PersonID"] as int? ?? 0,
                                reader["UserName"]?.ToString() ?? string.Empty,
                                reader["Password"]?.ToString() ?? string.Empty,
                                reader["IsActive"] as bool? ?? false
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex); // Consider a structured logging framework
                }
            }

            return user;
        }



        #endregion

        #region Get All Users
        public static List<clsUserDTO> GetAllUsers()
        {
            List<clsUserDTO> users = new List<clsUserDTO>();

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_GetAllUsers]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new clsUserDTO
                            (
                                reader["UserID"] as int? ?? 0,
                                reader["PersonID"] as int? ?? 0,
                                reader["UserName"]?.ToString() ?? string.Empty,
                                reader["Password"]?.ToString() ?? string.Empty,
                                reader["IsActive"] as bool? ?? false
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex); // Use a structured logging framework
                }
            }

            return users;
        }
        #endregion

        #region Add New User
        public static int? AddNewUser(clsUserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_AddNewUser]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PersonID", user.personID);
                command.Parameters.AddWithValue("@UserName", user.userName);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@IsActive", user.isActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        return  insertedID;
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex); // Use a structured logging framework
                }
            }

            return null;
        }
        #endregion

        #region Update User
        public static bool UpdateUser(clsUserDTO user)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_UpdateUser]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", user.userID);
                command.Parameters.AddWithValue("@PersonID", user.personID);
                command.Parameters.AddWithValue("@UserName", user.userName);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@IsActive", user.isActive);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogError(ex); // Use structured logging instead of silent catching
                    return false;
                }
            }

            return rowsAffected > 0;
        }
        #endregion

        #region Delete User
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_DeleteUser]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogError(ex); // Use structured logging instead of silent catching
                    return false;
                }
            }

            return rowsAffected > 0;
        }
        #endregion

        #region Is User Exist by ID
        public static bool IsUserExist(int  userID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_IsUserExistByID]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    isFound = result != null && (int)result == 1;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }

            return isFound;
        }
        #endregion 

        #region Is User Exist By UserName
        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_IsUserExistByUsername]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", UserName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    isFound = result != null && (int)result == 1;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }

            return isFound;
        }
        #endregion

        #region Is User Exist For PersonID
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_IsUserExistForPersonID]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    isFound = result != null && (int)result == 1;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }

            return isFound;
        }
        #endregion

        #region Change Password
        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("[UserProcedures].[SP_ChangePassword]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@Password", NewPassword);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogError(ex); // Use structured logging instead of silent catching
                    return false;
                }
            }

            return rowsAffected > 0;
        }
        #endregion

        #region
        #endregion
        #region
        #endregion

        #region logError
        // loging error by static class using delegation??!
        private static void LogError(Exception ex)
        {
            //log in file or database
            Console.WriteLine($"Error: {ex.Message}"); // Consider a logging framework like Serilog, NLog, or log4net
        }
        #endregion

    }
}
