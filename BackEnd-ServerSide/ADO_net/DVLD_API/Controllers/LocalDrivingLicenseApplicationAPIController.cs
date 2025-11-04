using DVLD_BusinessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalDrivingLicenseApplicationAPIController : ControllerBase
    {
        #region Private Helpers
        private bool ValidateApplicationDTO(clsLocalDrivingLicenseApplicationDTO dto)
        {
            return dto != null &&
                   dto.ApplicationID > 0 &&
                   dto.LicenseClassID > 0;
        }
        #endregion

        #region Get Operations

        [HttpGet("TryGetLocalDrivingLicenseApplicationByIDAsync/{LDLID}", Name = "TryGetLocalDrivingLicenseApplicationByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsLocalDrivingLicenseApplicationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsLocalDrivingLicenseApplicationDTO>> TryGetLocalDrivingLicenseApplicationByIDAsync(int LDLID)
        {
            try
            {
                if (LDLID <= 0)
                {
                    return BadRequest(new
                    {
                        Error = "Invalid application ID",
                        Message = $"Application ID must be a positive number. Provided value: {LDLID}"
                    });
                }

                var (found, result) = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL.TryGetLocalDrivingLicenseApplicationByIDAsync(LDLID);

                return found != null ? Ok(result) : NotFound(new
                {
                    Error = "Application not found",
                    Message = $"No local driving license application found with ID: {LDLID}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }

        [HttpGet("TryGetLocalDrivingLicenseApplicationByApplicationIdAsync/{applicationId}", Name = "TryGetLocalDrivingLicenseApplicationByApplicationIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsLocalDrivingLicenseApplicationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsLocalDrivingLicenseApplicationDTO>> TryGetLocalDrivingLicenseApplicationByApplicationIdAsync(int applicationId)
        {
            try
            {
                if (applicationId <= 0)
                {
                    return BadRequest(new
                    {
                        Error = "Invalid application ID",
                        Message = $"Application ID must be a positive number. Provided value: {applicationId}"
                    });
                }

                var (found, result) = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL
                    .TryGetLocalDrivingLicenseApplicationByApplicationIdAsync(applicationId);

                return found ? Ok(result) : NotFound(new
                {
                    Error = "Application not found",
                    Message = $"No local driving license application found with application ID: {applicationId}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }


        [HttpGet("GetAllLocalDrivingLicenseApplicationsAsync")]
        [ProducesResponseType(typeof(IEnumerable<clsLocalDrivingLicenseApplications_ViewDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<clsLocalDrivingLicenseApplications_ViewDTO>>> GetAllLocalDrivingLicenseApplicationsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var applications = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL.TryGetAllLocalDrivingLicenseApplicationsAsync(cancellationToken);

                if (applications == null || !applications.Any())
                {
                    return NotFound(new ProblemDetails
                    {
                        Title = "No Applications Found",
                        Detail = "There are no driving license applications available",
                        Status = StatusCodes.Status404NotFound
                    });
                }

                return Ok(applications);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status499ClientClosedRequest);
            }
            catch (SqlException ex)
            {
                // _logger.LogError(ex, "Database error while retrieving applications");
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ProblemDetails
                {
                    Title = "Service Unavailable",
                    Detail = "Database connection error",
                    Status = StatusCodes.Status503ServiceUnavailable
                });
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Unexpected error while retrieving applications");
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }
        #endregion

        #region Create/Update/Delete Operations

        [HttpPost("TryAddNewLocalDrivingLicenseApplicationAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> TryAddNewLocalDrivingLicenseApplicationAsync([FromBody] clsLocalDrivingLicenseApplicationDTO DTO, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateApplicationDTO(DTO))
                {
                    return BadRequest(new
                    {
                        Error = "Invalid application data",
                        Message = "Application data is incomplete or invalid"
                    });
                }

                int newId = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL.TryAddNewLocalDrivingLicenseApplicationAsync(DTO, cancellationToken);

                if (newId <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        Error = "Creation failed",
                        Message = "Failed to create new application"
                    });
                }

               
                return CreatedAtRoute(
                routeName: "TryGetLocalDrivingLicenseApplicationByIDAsync", // Matches the Name in HttpGet
                routeValues: new { LDLID = newId }, // Must EXACTLY match parameter name
                value:  newId );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }

        [HttpPut("TryUpdateLocalDrivingLicenseApplicationAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TryUpdateLocalDrivingLicenseApplicationAsync([FromBody] clsLocalDrivingLicenseApplicationDTO DTO,CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateApplicationDTO(DTO))
                {
                    return BadRequest(new
                    {
                        Error = "Invalid application data",
                        Message = "Application data is incomplete or invalid"
                    });
                }

                bool success = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL.TryUpdateLocalDrivingLicenseApplicationAsync(DTO, cancellationToken);

                return success ? Ok(new { Message = "Application updated successfully" })
                    : NotFound(new { Error = "Application not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("TryDeleteLocalDrivingLicenseApplicationAsync/{applicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> TryDeleteLocalDrivingLicenseApplicationAsync(
            int applicationId,
            CancellationToken cancellationToken)
        {
            try
            {
                if (applicationId <= 0)
                {
                    return BadRequest(new
                    {
                        Error = "Invalid application ID",
                        Message = "Application ID must be a positive number"
                    });
                }

                bool success = await clsLocalDrivingLicenseApplication_BL.TryDeleteLocalDrivingLicenseApplicationAsync(applicationId, cancellationToken);

                return success ? Ok(new { Message = "Application deleted successfully" })
                    : NotFound(new { Error = "Application not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }

        #endregion

        #region Test Related Operations

        [HttpGet("DoesPassTestTypeAsync/{applicationId}/{testTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DoesPassTestTypeAsync(int applicationId, int testTypeId, CancellationToken cancellationToken)
        {
            try
            {
                if (applicationId <= 0 || testTypeId <= 0)
                {
                    return BadRequest(new
                    {
                        Error = "Invalid parameters",
                        Message = "Application ID and Test Type ID must be positive numbers"
                    });
                }

                bool result = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL.DoesPassTestTypeAsync(applicationId, testTypeId, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }

        [HttpGet("TryIsThereAnActiveScheduledTestAsync/{applicationId}/{testTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> TryIsThereAnActiveScheduledTestAsync(
            int applicationId,
            int testTypeId,
            CancellationToken cancellationToken)
        {
            try
            {
                if (applicationId <= 0 || testTypeId <= 0)
                {
                    return BadRequest(new
                    {
                        Error = "Invalid parameters",
                        Message = "Application ID and Test Type ID must be positive numbers"
                    });
                }

                bool result = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL.TryIsThereAnActiveScheduledTestAsync(applicationId, testTypeId, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Internal server error",
                    Message = ex.Message
                });
            }
        }

        #endregion

        #region Test Related Operations

        [HttpGet("GetTotalTrialsPerTestAsync/{applicationId}/{testTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<byte>> GetTotalTrialsPerTestAsync(
            int applicationId,
            int testTypeId,
            CancellationToken cancellationToken)
        {
            try
            {
                if (applicationId <= 0 || testTypeId <= 0)
                {
                    return BadRequest(new
                    {
                        Error = "Invalid parameters",
                        Message = "Application ID and Test Type ID must be positive numbers"
                    });
                }

                byte trials = await DVLD_BusinessLayer.clsLocalDrivingLicenseApplication_BL
                    .GetTotalTrialsPerTestAsync(applicationId, testTypeId, cancellationToken);

                return Ok(trials);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ProblemDetails
                {
                    Title = "Service Unavailable",
                    Detail = "Database connection error",
                    Status = StatusCodes.Status503ServiceUnavailable,
                    Extensions = { { "DatabaseError", ex.Message } }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

        #endregion
    }
}

#region
#endregion
#region
#endregion
#region
#endregion
#region
#endregion


#region
#endregion
#region
#endregion
#region
#endregion
#region
#endregion


#region
#endregion
#region
#endregion
#region
#endregion
#region
#endregion


#region
#endregion
#region
#endregion
#region
#endregion
#region
#endregion


#region
#endregion
#region
#endregion
#region
#endregion
#region
#endregion


#region
#endregion
#region
#endregion
#region
#endregion