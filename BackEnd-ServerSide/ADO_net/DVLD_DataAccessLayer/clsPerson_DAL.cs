using Microsoft.Data.SqlClient; // Use Microsoft.Data.SqlClient for .NET Core and .NET 5+
using System;
using System.Data;
using System.Reflection;
using DVLD_SharedModels;
////using System.Data.SqlClient; not needed

namespace DVLD_DataAccessLayer
{
    #region class Person Data Transfer Object (DTO)[to DELETE]
    //public class PersonDTO
    //{
    //    public PersonDTO(int? personID, string firstName, string lastName, string nationalID, string imagePath,
    //                     bool gender, DateTime dateOfBirth, int nationalityCountryID, string phone, string email, string address)
    //    {
    //        this.PersonID = personID;
    //        this.FirstName = firstName;
    //        this.LastName = lastName;
    //        this.NationalID = nationalID;
    //        this.ImagePath = imagePath;
    //        this.Gender = gender;
    //        this.DateOfBirth = dateOfBirth;
    //        this.NationalityCountryID = nationalityCountryID;
    //        this.Phone = phone;
    //        this.Email = email;
    //        this.Address = address;
    //    }

    //    public int? PersonID { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string NationalID { get; set; }
    //    public string ImagePath { get; set; }
    //    public bool  Gender { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //    public int NationalityCountryID { get; set; }
    //    public string Phone { get; set; }
    //    public string Email { get; set; }
    //    public string Address { get; set; }
    //}
    #endregion

    #region  class People data access layer             
    public class clsPerson_DAL
    {
        #region Get Person Info By ID
        public static clsPersonDTO GetPersonInfo(int personID)
        {
            

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPersonByID", connection)) // Assuming a stored procedure
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", personID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new clsPersonDTO(
                                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                                    reader.GetString(reader.GetOrdinal("LastName")),
                                                    reader.GetString(reader.GetOrdinal("NationalNo")),
                                                    reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagePath")),
                                                    reader.GetByte(reader.GetOrdinal("Gendor")) == 1, // Convert Byte to Boolean
                                                    reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                                    reader.GetInt32(reader.GetOrdinal("NationalityCountryID")),
                                                    reader.GetString(reader.GetOrdinal("Phone")),
                                                    reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                                                    reader.GetString(reader.GetOrdinal("Address"))
                                                    );
                        }
                        else
                            return null; 
                    }
                }
            }
        }
        #endregion

        #region Get Person Info By National ID
        public static clsPersonDTO GetPersonInfo(string nationalID)
        {
            using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
            using var command = new SqlCommand("SP_GetPersonByNationalID", connection) { CommandType = CommandType.StoredProcedure };

            command.Parameters.AddWithValue("@NationalID", nationalID);

            connection.Open();
            using var reader = command.ExecuteReader();

            return reader.Read() ?
                                    new clsPersonDTO(
                                                        reader.GetInt32(reader.GetOrdinal("PersonID")),
                                                        reader.GetString(reader.GetOrdinal("FirstName")),
                                                        reader.GetString(reader.GetOrdinal("LastName")),
                                                        reader.GetString(reader.GetOrdinal("NationalNo")),
                                                        reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagePath")),
                                                        reader.GetByte(reader.GetOrdinal("Gendor")) == 1, // Convert Byte to Boolean
                                                        reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                                        reader.GetInt32(reader.GetOrdinal("NationalityCountryID")),
                                                        reader.GetString(reader.GetOrdinal("Phone")),
                                                        reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                                                        reader.GetString(reader.GetOrdinal("Address"))
                                                    )

                                 : null;
        }
        #endregion

        #region get all People (Optimized by )
        public static List<clsPersonDTO> GetAllPersons()
        {
            var PeopleList = new List<clsPersonDTO>();
            // using Var cuz readonly == faster
            using var conn = new SqlConnection(clsGlobalSetting.ConnectionString);
            using var cmd = new SqlCommand("SP_GetAllPeople", conn) { CommandType = CommandType.StoredProcedure };

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PeopleList.Add(
                                new clsPersonDTO(
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("FirstName")),
                                    reader.GetString(reader.GetOrdinal("LastName")),
                                    reader.GetString(reader.GetOrdinal("NationalNo")),
                                    //reader.GetString(reader.GetOrdinal("ImagePath")) ?? string.Empty,
                                    reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagePath")),
                                    reader.GetByte(reader.GetOrdinal("Gendor"))==1, // Corrected
                                    reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    reader.GetInt32(reader.GetOrdinal("NationalityCountryID")),
                                    reader.GetString(reader.GetOrdinal("Phone")),
                                   // reader.GetString(reader.GetOrdinal("Email")) ?? string.Empty,
                                    reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("Address"))
                                                )           
                                );
            }

            return PeopleList;
        }

        #endregion

        #region Add New Person (ABoHD)
        
        public static int? AddNewPerson(clsPersonDTO person)
        {
            using var connection = new SqlConnection(clsGlobalSetting.ConnectionString);
            using var command = new SqlCommand("SP_AddNewPerson", connection) { CommandType = CommandType.StoredProcedure };

            // Adding parameters in a cleaner way
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@NationalNo", person.NationalID);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", person.Gender);//handling the gender
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(person.Email) ? DBNull.Value : person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(person.ImagePath) ? DBNull.Value : person.ImagePath);

            //var outputIdParam = new SqlParameter("@NewPersonId", SqlDbType.Int)
            //{
            //    Direction = ParameterDirection.Output
            //};
            //command.Parameters.Add(outputIdParam);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                return result != null && int.TryParse(result.ToString(), out int insertedID) ? insertedID : null;
            }
            catch (Exception ex)
            {
                // Log error if needed
                //return -1;
                Console.Write(ex.ToString());
            }
            return null;
        }

        #endregion

        #region Update Person 
        public static bool UpdatePerson(clsPersonDTO person)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", person.PersonID);
                    command.Parameters.AddWithValue("@FirstName", person.FirstName);
                    command.Parameters.AddWithValue("@LastName", person.LastName);
                    command.Parameters.AddWithValue("@NationalID", person.NationalID);
                    command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", person.Gender);
                    command.Parameters.AddWithValue("@Address", person.Address);
                    command.Parameters.AddWithValue("@Phone", person.Phone);
                    command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);

                    command.Parameters.AddWithValue("@Email",
                        !string.IsNullOrEmpty(person.Email) ? person.Email : DBNull.Value);

                    command.Parameters.AddWithValue("@ImagePath",
                        !string.IsNullOrEmpty(person.ImagePath) ? person.ImagePath : DBNull.Value);

                    // Define Output Parameter
                    SqlParameter outputParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                    {
                            Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);
                    try
                    {
                        //connection.Open();
                        //rowsAffected = command.ExecuteNonQuery();
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve output value (number of rows affected)
                        rowsAffected = (int)command.Parameters["@RowsAffected"].Value;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }
        #endregion

        #region Delete Person
        public static bool DeletePerson(int personID)
        {
            int rowsAffected = 0;

            // Use 'using' to ensure the connection is closed properly
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", personID);

                    try
                    {
                        connection.Open();

                        // Execute the stored procedure and get the affected rows
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    //catch (SqlException sqlEx)
                    //{
                    //    // Log SQL-specific errors properly
                    //    //Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    //    return false;
                    //}
                    catch (Exception ex)
                    {
                        // Log general errors for further analysis
                        Console.WriteLine($"General Error: {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        // Ensure connection is closed manually (not strictly necessary since 'using' handles it)
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }

            return rowsAffected > 0; // Returns true if rows were affected
        }
        #endregion

        #region Is Person Exist by ID (Updated to accept national ID too)
        public static bool IsPersonExist(int PersonID =0,string? NationalID = null)
        {
            bool isFound = false;

            using (var connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            {
                using (var command = new SqlCommand("SP_IsPersonExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID > 0 ? PersonID : DBNull.Value);
                    command.Parameters.AddWithValue("@NationalID",
                        !string.IsNullOrEmpty(NationalID) ? NationalID : DBNull.Value);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        #endregion


    }
    #endregion
}

           

