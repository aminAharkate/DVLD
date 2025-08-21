using DVLD_BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DVLD_SharedModels;

namespace DVLD_API.Controllers
{
    [Route("api/CountriesAPI")]
    [ApiController]
    public class CountriesAPIController : ControllerBase
    {
        #region get all countries
        [HttpGet("GetAllCoutries",Name = "GetAllCoutries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsCountryDTO>> GetAllCountries()
        {
            var countries = clsCountry_BL.GetAllCountries();
            if (countries == null || !countries.Any())
            {
                return NotFound("No Countries found.");
            }

            return Ok(countries);
        }
        #endregion

        #region Get Country By ID
        [HttpGet("GetCountryByID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsCountryDTO> getCountryByID(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid country ID.");
            }
            try
            {
                var country = clsCountry_BL.Find(id);
                return country is null ? NotFound($"Country with ID {id} not found.") : Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }

        }
        #endregion

        #region Get Country By Country Name
        [HttpGet("GetCountryByCountryName/{CountryName}", Name = "GetCountryByCountryName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsCountryDTO> GetCountryByCountryName(string CountryName)
        {
            var country = clsCountry_BL.Find(CountryName);
            return country is null ? NotFound($"Country with ID {CountryName} not found.") : Ok(country);
        }
        #endregion
    }



    #region DTO [To DELETE]
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
}
