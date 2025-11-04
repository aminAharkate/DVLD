using DVLD_DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.Numerics;
using System.Reflection;
using static DVLD_DataAccessLayer.clsGlobalSetting;
using DVLD_SharedModels;

namespace DVLD_BusinessLayer
{
    public class clsPerson_BL
    {
        
        #region onstructor + attrubes
        public clsPerson_BL(clsPersonDTO PDTO, clsGlobalSetting.EnMode Mode = EnMode.Add)
        {
            this.PersonID = PDTO.PersonID;
            this.FirstName = PDTO.FirstName;
            this.LastName = PDTO.LastName;
            this.NationalID = PDTO.NationalID;
            this.ImagePath = PDTO.ImagePath;
            this.Gender = PDTO.Gender;
            this.DateOfBirth =PDTO.DateOfBirth;
            this.NationalityCountryID = PDTO.NationalityCountryID;
            this.Phone = PDTO.Phone;
            this.Email = PDTO.Email;
            this.Address = PDTO.Address;
            this.Courtryinfo = clsCountry_BL.Find(this.NationalityCountryID);
            this.Mode = Mode;
        }

        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalID { get; set; }
        public string ImagePath { get; set; }
        public bool  Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityCountryID { get; set; }
        
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public clsGlobalSetting.EnMode Mode { get; set; } = EnMode.Add;
        public clsPersonDTO PersonDTO
        {
            get
            {
                return new clsPersonDTO(
                                        this.PersonID, this.FirstName, this.LastName,
                                        this.NationalID, this.ImagePath,
                                        this.Gender, this.DateOfBirth, this.NationalityCountryID,
                                        this.Phone, this.Email, this.Address);
            }
        }
        public clsCountryDTO Courtryinfo;
        #endregion

        #region Get Person Info By ID
        public static clsPersonDTO GetPersonInfo(int personID)
        {
            return DVLD_DataAccessLayer.clsPerson_DAL.GetPersonInfo(personID);
        }
        #endregion

        #region Get Person Info By National ID
        public static clsPersonDTO GetPersonInfo(string nationalID)
        {
            return DVLD_DataAccessLayer.clsPerson_DAL.GetPersonInfo(nationalID);
        }

        #endregion

        #region get all People (Optimized by )
        public static List<clsPersonDTO> GetAllPersons()
        {
            return DVLD_DataAccessLayer.clsPerson_DAL.GetAllPersons();
        }
        #endregion

        #region Private _Add person
        private bool _AddPerson()
        {

            this.PersonID = DVLD_DataAccessLayer.clsPerson_DAL.AddNewPerson(PersonDTO);
            return (this.PersonID != null);
        }
        #endregion

        #region Private Update Person
        private bool _UpdatePerson()
        {

            return DVLD_DataAccessLayer.clsPerson_DAL.UpdatePerson(PersonDTO);

        }
        #endregion

        #region Save
        
        public bool Save()
        {
            switch (Mode)
            {
                case EnMode.Add:
                    if (_AddPerson())
                    {
                        Mode = EnMode.Edit;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case EnMode.Edit:
                    return _UpdatePerson();
            }

            return false;
        }
        #endregion

        #region Delete Person
        public static bool DeletePerson(int personID)
        {
            return DVLD_DataAccessLayer.clsPerson_DAL.DeletePerson(personID);
        }

        #endregion

        #region Is Person Exist by ID (Updated to accept national ID too)
        public static bool IsPersonExist(int PersonID = 0, string NationalID = null)
        {
            return DVLD_DataAccessLayer.clsPerson_DAL.IsPersonExist(PersonID, NationalID);
        }

        #endregion

        #region Is Valid Person DTO
        public static  bool IsValidPerson(clsPersonDTO personDTO)
        {

            return 
                   !string.IsNullOrWhiteSpace(personDTO.FirstName) &&
                   !string.IsNullOrWhiteSpace(personDTO.LastName) &&
                   !string.IsNullOrWhiteSpace(personDTO.NationalID) &&
                   (personDTO.Gender == true || personDTO.Gender == false) &&
                   //personDTO.DateOfBirth != default(DateTime) &&
                   personDTO.NationalityCountryID > 0 &&
                   !string.IsNullOrWhiteSpace(personDTO.NationalID) &&
                   !string.IsNullOrWhiteSpace(personDTO.Phone) &&
                   !string.IsNullOrWhiteSpace(personDTO.Address);

        }

        #endregion
    }
}
