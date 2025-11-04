using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_SharedModels;
namespace DVLD_BusinessLayer
{
    public static  class clsCountry_BL
    {
        #region [DELETE] cstructor + attributes 

        //public int? ID { set; get; }
        //public string CountryName { set; get; }
        // may not needed
        //public clsCountry_BL()

        //{
        //    this.ID = null;
        //    this.CountryName = string.Empty;

        //}
        //private clsCountry_BL(int ID, string CountryName)
        //{
        //    this.ID = ID;
        //    this.CountryName = CountryName;
        //}
        #endregion

        #region Find by ID  
        public static clsCountryDTO Find(int CountryID)
        {
            return clsCountry_DAL.GetCountryInfoByID(CountryID);
        }
        #endregion

        #region Find by Name  
        public static clsCountryDTO Find(string CountryName)
        {
            return clsCountry_DAL.GetCountryInfoByName(CountryName);
        }
        #endregion

        #region Get All Countries
        public static List<clsCountryDTO> GetAllCountries()
        {
            return clsCountry_DAL.GetAllCountries();
        }
        #endregion


    }
}
