using DVLD_DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_SharedModels;

namespace DVLD_DataAccessLayer
{
    #region clsCountryDTO
    //public class clsCountryDTO
    //{
    //    public int? ID { get; set; }
    //    public string CountryName { get; set; }
    //    public clsCountryDTO(int? id, string countryName)
    //    {
    //        ID = id;
    //        CountryName = countryName;
    //    }
    //}
    #endregion
    public static  class clsCountry_DAL
    {
        #region Get Country Info By ID
        public static clsCountryDTO? GetCountryInfoByID(int CountryID)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetCountryByID", connection)) // Using Stored Procedure
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryID", CountryID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new clsCountryDTO(
                                reader.GetInt32(reader.GetOrdinal("CountryID")),
                                reader.GetString(reader.GetOrdinal("CountryName"))
                               
                            );
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                   
                }
            }

            return null;
        }
        #endregion

        #region Get Country Info By Name
        public static clsCountryDTO GetCountryInfoByName(string countryName)
        {
            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetCountryByName", connection)) // Using Stored Procedure
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CountryName", countryName);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new clsCountryDTO(
                                reader.GetInt32(reader.GetOrdinal("CountryID")),
                                reader.GetString(reader.GetOrdinal("CountryName"))

                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    
                }
            }

            return null;
        }
        #endregion

        #region Get All Countries
        public static List<clsCountryDTO> GetAllCountries()
        {
            List<clsCountryDTO> countries = new List<clsCountryDTO>();

            using (SqlConnection connection = new SqlConnection(clsGlobalSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_GetAllCountries", connection)) // Using Stored Procedure
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countries.Add(
                                new clsCountryDTO(
                                reader.GetInt32(reader.GetOrdinal("CountryID")),
                                reader.GetString(reader.GetOrdinal("CountryName"))
                                ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return countries;
        }
        #endregion

    }
}