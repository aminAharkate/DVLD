using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using DVLD_SharedModels;

namespace DVLD_API.Controllers
{

    [Route("api/PersonAPI")]
    [ApiController]
    public class PersonAPIController : ControllerBase
    {
        #region Get All People
        [HttpGet("AllPeople", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<clsPersonDTO> GetAllPeople()
        {
            // var People =  clsPerson_BL.GetAllPersons();
            List<clsPersonDTO> People = clsPerson_BL.GetAllPersons();
            if (People.Count == 0 || People == null || !People.Any())
            {
                return NotFound("No People found.");
            }

            return Ok(People);
        }
        #endregion

        #region Get Person By ID
        [HttpGet("GetPersonByID/{id}", Name = "GetPersonByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPersonDTO> GetPersonByID(int id)
        {
            if (id < 1)
                return BadRequest("Invalid ID provided.");

            clsPersonDTO person = clsPerson_BL.GetPersonInfo(id);
            return person == null ? NotFound($"Person with ID {id} not found.") : Ok(person);
        }
        #endregion

        #region Get Person By National ID
        [HttpGet("GetPersonByNationalID/{nationalID}", Name = "GetPersonByNationalID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPersonDTO> GetPersonByNationalID(string nationalID)
        {
            if (string.IsNullOrWhiteSpace(nationalID))
                return BadRequest("National ID cannot be null or empty.");
            clsPersonDTO person = clsPerson_BL.GetPersonInfo(nationalID);
            return person == null ? NotFound($"Person with National ID {nationalID} not found.") : Ok(person);
        }
        #endregion

        #region Add Person
        [HttpPost("AddPerson", Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<clsPersonDTO> AddPerson(clsPersonDTO personDTO)
        {
            //if (clsPerson_BL.IsValidPerson(personDTO))
            //    return BadRequest("Person data cannot be null.");

            
                clsPerson_BL personBL = new clsPerson_BL(personDTO, clsGlobalSetting.EnMode.Add);
                if (personBL.Save())
                {
                    personDTO.PersonID = personBL.PersonID;
                    return CreatedAtRoute("GetPersonByID", new { id = personBL.PersonID }, personDTO);
                }
                else
                {
                    return BadRequest("Failed to add person. Please check the provided data.");
                }
            


        }
        #endregion

        #region Update Person
        [HttpPut("UpdatePerson/{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPersonDTO> UpdatePerson(int id, clsPersonDTO personDTO)
        {
            
            if (id<0)
                return BadRequest("enter a valid Person ID.");

            clsPersonDTO FoundPersonDTO = clsPerson_BL.GetPersonInfo(id);
            if (FoundPersonDTO == null)
                return NotFound("Person not found.");
            FoundPersonDTO.FirstName = personDTO.FirstName;
            FoundPersonDTO.LastName = personDTO.LastName;
            FoundPersonDTO.NationalID = personDTO.NationalID;
            FoundPersonDTO.ImagePath = personDTO.ImagePath;
            FoundPersonDTO.Gender = personDTO.Gender;
            FoundPersonDTO.DateOfBirth = personDTO.DateOfBirth;
            FoundPersonDTO.NationalityCountryID = personDTO.NationalityCountryID;
            FoundPersonDTO.Phone = personDTO.Phone;
            FoundPersonDTO.Email = personDTO.Email;
            FoundPersonDTO.Address = personDTO.Address;
            clsPerson_BL personBL = new clsPerson_BL(FoundPersonDTO, clsGlobalSetting.EnMode.Edit);
            return personBL.Save()? Ok(personBL.PersonDTO): BadRequest("Failed to update person. Please check the provided data.");
        }
        #endregion

        #region Delete Perosn
        [HttpDelete("DeletePerson",Name ="DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePerson(int id)
        {
            if (id < 1)
                return BadRequest("Invalid ID provided.");
            clsPersonDTO person = clsPerson_BL.GetPersonInfo(id);
            if (person == null)
                return NotFound($"Person with ID {id} not found.");
            bool isDeleted = clsPerson_BL.DeletePerson(id);
            return isDeleted ? Ok($"Person with ID {id} deleted successfully.") : BadRequest("Failed to delete person.");
        }
        #endregion

        #region Is Person Exist by ID or national ID 
        [HttpGet("IsPersonExist/{NationalID}", Name = "IsPersonExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPersonExist( string NationalID)
        {
            if (string.IsNullOrEmpty(NationalID) )
                return BadRequest("Either ID or National ID must be provided.");
            bool exists = clsPerson_BL.IsPersonExist(0, NationalID);
            return Ok(exists);
        }
        #endregion

        #region class Person Data Transfer Object (DTO)
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
        //    public bool Gender { get; set; }
        //    public DateTime DateOfBirth { get; set; }
        //    public int NationalityCountryID { get; set; }
        //    public string Phone { get; set; }
        //    public string Email { get; set; }
        //    public string Address { get; set; }
        //}
        #endregion
    }
}

