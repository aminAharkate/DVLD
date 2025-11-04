


using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DVLD_API.Controllers
{
    [Route("api/applicationsAsync")]
    [ApiController]
    public class ApplicationAPIController : ControllerBase
    {
        private readonly ILogger<ApplicationAPIController> _logger;

        public ApplicationAPIController(ILogger<ApplicationAPIController> logger)
        {
            _logger = logger;
        }

        #region CRUD Operations

        /// <summary>
        /// Retrieves application information by application ID
        /// </summary>
        [HttpGet("GetApplicationByIDAsync/{applicationID:int}", Name = "GetApplicationByID")]
        [ProducesResponseType(typeof(clsApplicationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsApplicationDTO>> GetApplicationByIDAsync(int applicationID)
        {
            try
            {
                _logger.LogInformation("Retrieving application {ApplicationID}", applicationID);

                if (applicationID <= 0)
                {
                    _logger.LogError("Invalid application ID {ApplicationID}", applicationID);
                    //_logger.LogWarning("Invalid application ID {ApplicationID}", applicationID);
                    return BadRequest(new { Message = "Application ID must be positive" });
                }

                var application = await clsApplication_BL.GetApplicationInfoByIDAsync(applicationID);

                if (application == null)
                {
                    _logger.LogWarning("Application {ApplicationID} not found", applicationID);
                    return NotFound(new { Message = $"Application {applicationID} not found" });
                }

                return Ok(application);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving application {ApplicationID}", applicationID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Creates a new application
        /// </summary>
        [HttpPost("AddNewApplicationAsync")]
        [ProducesResponseType(typeof(clsApplicationDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsApplicationDTO>> CreateApplicationAsync([FromBody] clsApplicationDTO applicationDTO)
        {
            try
            {
                _logger.LogInformation("Creating new application");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Invalid application data");
                    return BadRequest(ModelState);
                }

                var applicationId = await clsApplication_BL.AddNewApplicationAsync(applicationDTO);

                if (!applicationId.HasValue)
                {
                    _logger.LogError("Failed to create application");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Message = "Failed to create application" });
                }

                var createdApplication = await clsApplication_BL.GetApplicationInfoByIDAsync(applicationId.Value);

                return CreatedAtRoute("GetApplicationByID",
                    new { applicationID = applicationId },
                    createdApplication);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating application");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Updates an existing application
        /// </summary>
        [HttpPut("UpdateApplicationAsync/{applicationID:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateApplicationAsync(int applicationID, [FromBody] clsApplicationDTO applicationDTO)
        {
            try
            {
                _logger.LogInformation("Updating application {ApplicationID}", applicationID);

                if (applicationID <= 0 || applicationID != applicationDTO.ApplicationID)
                {
                    _logger.LogWarning("Invalid application ID {ApplicationID}", applicationID);
                    return BadRequest(new { Message = "Invalid application ID" });
                }

                if (!await clsApplication_BL.IsApplicationExistAsync(applicationID))
                {
                    _logger.LogWarning("Application {ApplicationID} not found", applicationID);
                    return NotFound(new { Message = $"Application {applicationID} not found" });
                }
                applicationDTO.ApplicationID = applicationID;
                var success = await clsApplication_BL.UpdateApplicationAsync(applicationDTO);

                if (!success)
                {
                    _logger.LogError("Failed to update application {ApplicationID}", applicationID);
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Message = "Failed to update application" });
                }

                //return NoContent();
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating application {ApplicationID}", applicationID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Deletes an application
        /// </summary>
        [HttpDelete("DeleteApplicationAsync/{applicationID:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteApplicationAsync(int applicationID)
        {
            try
            {
                _logger.LogInformation("Deleting application {ApplicationID}", applicationID);

                if (applicationID <= 0)
                {
                    _logger.LogWarning("Invalid application ID {ApplicationID}", applicationID);
                    return BadRequest(new { Message = "Invalid application ID" });
                }

                if (!await clsApplication_BL.IsApplicationExistAsync(applicationID))
                {
                    _logger.LogWarning("Application {ApplicationID} not found", applicationID);
                    return NotFound(new { Message = $"Application {applicationID} not found" });
                }

                var success = await clsApplication_BL.DeleteApplicationAsync(applicationID);

                if (!success)
                {
                    _logger.LogError("Failed to delete application {ApplicationID}", applicationID);
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Message = "Failed to delete application" });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting application {ApplicationID}", applicationID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        #endregion

        #region Query Operations

        /// <summary>
        /// Gets all applications with pagination
        /// </summary>
        [HttpGet("GetAllApplicationsAsync")]
        [ProducesResponseType(typeof(PaginatedList<clsApplicationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllApplicationsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Getting all applications - Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);

                var applications = await clsApplication_BL.GetAllApplicationsAsync();
                var paginatedList = PaginatedList<clsApplicationDTO>.Create(applications, pageNumber, pageSize);

                return Ok(paginatedList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all applications");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Checks if an application exists
        /// </summary>
        [HttpGet("ApplicationExistsAsync/{applicationID:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ApplicationExistsAsync(int applicationID)
        {
            try
            {
                _logger.LogInformation("Checking if application {ApplicationID} exists", applicationID);

                if (applicationID <= 0)
                {
                    _logger.LogWarning("Invalid application ID {ApplicationID}", applicationID);
                    return BadRequest(new { Message = "Invalid application ID" });
                }

                var exists = await clsApplication_BL.IsApplicationExistAsync(applicationID);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if application {ApplicationID} exists", applicationID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Gets active application ID for a person and application type
        /// </summary>
        [HttpGet("GetActiveApplicationIDAsync/{personID:int}/{applicationTypeID:int}")]
        [ProducesResponseType(typeof(int?), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActiveApplicationIDAsync(int personID, int applicationTypeID)
        {
            try
            {
                _logger.LogInformation("Getting active application for person {PersonID}, type {ApplicationTypeID}",
                    personID, applicationTypeID);

                if (personID <= 0 || applicationTypeID <= 0)
                {
                    _logger.LogWarning("Invalid person ID {PersonID} or application type ID {ApplicationTypeID}",
                        personID, applicationTypeID);
                    return BadRequest(new { Message = "Invalid IDs" });
                }

                var activeAppID = await clsApplication_BL.GetActiveApplicationIDAsync(personID, applicationTypeID);
                return Ok(activeAppID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active application for person {PersonID}", personID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Gets active application ID for license class
        /// </summary>
        [HttpGet("GetActiveApplicationIDForLicenseClassAsync/{personID:int}/{applicationTypeID:int}/{licenseClassID:int}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetActiveApplicationIDForLicenseClassAsync(int personID, int applicationTypeID, int licenseClassID)
        {
            try
            {
                _logger.LogInformation(
                    "Getting active application for person {PersonID}, type {ApplicationTypeID}, license class {LicenseClassID}",
                    personID, applicationTypeID, licenseClassID);

                if (personID <= 0 || applicationTypeID <= 0 || licenseClassID <= 0)
                {
                    _logger.LogWarning(
                        "Invalid person ID {PersonID}, application type ID {ApplicationTypeID} or license class ID {LicenseClassID}",
                        personID, applicationTypeID, licenseClassID);
                    return BadRequest(new { Message = "Invalid IDs" });
                }

                var activeAppID = await clsApplication_BL.GetActiveApplicationIDForLicenseClassAsync(
                    personID, applicationTypeID, licenseClassID);
                return Ok(activeAppID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error getting active application for person {PersonID}, license class {LicenseClassID}",
                    personID, licenseClassID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }

        #endregion 
        #region Update Status Async
        /// <summary>
        /// Updates application status
        /// </summary>
        [HttpPut("UpdateStatusAsync/{applicationID:int}/{newStatus}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateStatusAsync(int applicationID, short newStatus)
        {
            try
            {
                _logger.LogInformation("Updating status for application {ApplicationID} to {NewStatus}",
                    applicationID, newStatus);

                if (applicationID <= 0)
                {
                    _logger.LogWarning("Invalid application ID {ApplicationID}", applicationID);
                    return BadRequest(new { Message = "Invalid application ID" });
                }

                if (!await clsApplication_BL.IsApplicationExistAsync(applicationID))
                {
                    _logger.LogWarning("Application {ApplicationID} not found", applicationID);
                    return NotFound(new { Message = $"Application {applicationID} not found" });
                }

                var success = await clsApplication_BL.UpdateStatusAsync(applicationID, newStatus);

                if (!success)
                {
                    _logger.LogError("Failed to update status for application {ApplicationID}", applicationID);
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Message = "Failed to update application status" });
                }

                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for application {ApplicationID}", applicationID);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error" });
            }
        }
        #endregion
        #region Does Person Have Active Application
        [HttpGet("DoesPersonHaveActiveApplication/{PersonID:int}/{ApplicationTypeID:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  async Task<ActionResult<bool>> DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            try
            {
               
                if (PersonID <= 0 || ApplicationTypeID <= 0 )
                {
                    _logger.LogWarning("Invalid person ID {PersonID}, application type ID {ApplicationTypeID} or license class ID {LicenseClassID}", PersonID, ApplicationTypeID);
                    return BadRequest("bad Request");
                }

                var activeAppID = await clsApplication_BL.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
                if (!activeAppID)
                {
                    _logger.LogWarning("No active application found for person {PersonID}, type {ApplicationTypeID}", PersonID, ApplicationTypeID);
                    return NotFound(new { Message = $"No active application found for person {PersonID} and type {ApplicationTypeID}" });
                }
                return Ok(activeAppID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error getting active application for person {PersonID}, license class {LicenseClassID}",PersonID, ApplicationTypeID);
                return StatusCode(StatusCodes.Status500InternalServerError,new { Message = "Internal server error" });
            }
        }
        #endregion
            
    }

    // Pagination helper class
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}