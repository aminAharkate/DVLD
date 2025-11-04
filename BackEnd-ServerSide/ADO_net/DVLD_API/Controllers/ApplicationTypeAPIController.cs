using DVLD_BusinessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_API.Controllers
{
    //[Route("api/[controller]")]

    [Route("api/ApplicationType")]
    [ApiController]
    public class ApplicationTypeController : ControllerBase
    {
        #region Get AllApplication Types
        [HttpGet("GetAllApplicationTypes", Name = "GetAllApplicationTypes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof( clsUserDTO) )]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<clsApplicationTypeDTO>> GetAllApplicationTypes()
        {
            try
            {
                List<clsApplicationTypeDTO>  applicationTypes = clsApplicationType_BL.GetAllApplicationTypes();
                if (applicationTypes.Count == 0)
                {
                    return NotFound("No application types found.");
                }
                return Ok(applicationTypes);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        #endregion

        #region Get Application Type By ID
        [HttpGet("GetApplicationTypeByID/{id}", Name = "GetApplicationTypeByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsApplicationTypeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsApplicationTypeDTO> GetApplicationTypeByID(int id)
        {
            if (id <=0 )
                return BadRequest("Invalid ID provided.");
            clsApplicationTypeDTO applicationType = clsApplicationType_BL.GetApplicationTypeInfoByID(id);
            return applicationType == null ? NotFound($"Application Type with ID {id} not found.") : Ok(applicationType);
        }
        #endregion

        #region Update Application Type
        [HttpPut("UpdateApplicationType/{id}", Name = "UpdateApplicationType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateApplicationType(int id, [FromBody] clsApplicationTypeDTO applicationType)
        {
            if (id <= 0 || applicationType == null)
                return BadRequest("Invalid application type data provided or ID.");
            var applicationTypeFromDB = clsApplicationType_BL.GetApplicationTypeInfoByID(id);
            if (applicationTypeFromDB != null)
            {
                applicationTypeFromDB.ApplicationTypeTitle = applicationType.ApplicationTypeTitle;
                applicationTypeFromDB.ApplicationTypeFees = applicationType.ApplicationTypeFees;

            }
            else
            {
                return NotFound($"Application Type with ID {id} not found.");
            }

            bool isUpdated = clsApplicationType_BL.UpdateApplicationType(applicationTypeFromDB);
            if (isUpdated)
            {
                return Ok(applicationTypeFromDB);
            }
            else
            {
                return StatusCode(500, "Error updating application type.");
            }
        }
        #endregion
    }
}
