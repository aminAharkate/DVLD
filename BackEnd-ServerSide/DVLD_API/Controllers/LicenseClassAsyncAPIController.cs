//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DVLD_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LicenseClassAsyncAPIController : ControllerBase
//    {
//    }
//}

using DVLD_BusinessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseClassAsyncAPIController : ControllerBase
    {
                                                                                                        #region Actions

        /// <summary>
        /// Get all license classes
        /// </summary>
        /// <returns>List of license classes</returns>
        /// <response code="200">Returns the list of license classes</response>
        /// <response code="500">If there was a server error</response>
        [HttpGet("GetAllLicenseClasses")]
        [ProducesResponseType(typeof(List<clsLicenseClassDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLicenseClasses()
        {
            try
            {
                var licenseClasses = await clsLicenseClassAsync_BL.GetAllLicenseClassesAsync();
                return Ok(licenseClasses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { ErrorMessage = "Internal server error", Details = ex.Message });
            }
        }

        /// <summary>
        /// Get a specific license class by ID
        /// </summary>
        /// <param name="id">The license class ID</param>
        /// <returns>The license class details</returns>
        /// <response code="200">Returns the requested license class</response>
        /// <response code="404">If the license class is not found</response>
        /// <response code="500">If there was a server error</response>
        [HttpGet("GetLicenseClassById/{id}")]
        [ProducesResponseType(typeof(clsLicenseClassDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLicenseClassById(int id)
        {
            try
            {
                var licenseClass = await clsLicenseClassAsync_BL.GetLicenseClassInfoByIDAsync(id);

                if (licenseClass == null)
                    return NotFound(new { ErrorMessage = $"License class with ID {id} not found" });

                return Ok(licenseClass);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { ErrorMessage = "Internal server error", Details = ex.Message });
            }
        }

        /// <summary>
        /// Get a specific license class by name
        /// </summary>
        /// <param name="name">The license class name</param>
        /// <returns>The license class details</returns>
        /// <response code="200">Returns the requested license class</response>
        /// <response code="404">If the license class is not found</response>
        /// <response code="500">If there was a server error</response>
        [HttpGet("GetLicenseClassInfoByClassNameAsync/{name}")]
        [ProducesResponseType(typeof(clsLicenseClassDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLicenseClassByName(string name)
        {
            try
            {
                var licenseClass = await clsLicenseClassAsync_BL.GetLicenseClassInfoByClassNameAsync(name);

                if (licenseClass == null)
                    return NotFound(new { ErrorMessage = $"License class with name '{name}' not found" });

                return Ok(licenseClass);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { ErrorMessage = "Internal server error", Details = ex.Message });
            }
        }

        /// <summary>
        /// Create a new license class
        /// </summary>
        /// <param name="licenseClass">License class data</param>
        /// <returns>The created license class with its ID</returns>
        /// <response code="201">Returns the newly created license class</response>
        /// <response code="400">If the input data is invalid</response>
        /// <response code="500">If there was a server error</response>
        [HttpPost("CreateLicenseClass")]
        [ProducesResponseType(typeof(clsLicenseClassDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLicenseClass([FromBody] clsLicenseClassDTO licenseClass)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int newId = await clsLicenseClassAsync_BL.AddNewLicenseClassAsync(licenseClass);

                if (newId <= 0)
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { ErrorMessage = "Failed to create license class" });

                licenseClass.LicenseClassID = newId;
                return CreatedAtAction(nameof(GetLicenseClassById),
                    new { id = newId }, licenseClass);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { ErrorMessage = "Internal server error", Details = ex.Message });
            }
        }

        /// <summary>
        /// Update an existing license class
        /// </summary>
        /// <param name="id">License class ID</param>
        /// <param name="licenseClass">Updated license class data</param>
        /// <returns></returns>
        /// <response code="204">If the update was successful</response>
        /// <response code="400">If the ID doesn't match or data is invalid</response>
        /// <response code="404">If the license class is not found</response>
        /// <response code="500">If there was a server error</response>
        [HttpPut("UpdateLicenseClass/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLicenseClass(int id, [FromBody] clsLicenseClassDTO licenseClass)
        {
            try
            {
                if (id != licenseClass.LicenseClassID)
                    return BadRequest(new { ErrorMessage = "ID mismatch" });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingClass = await clsLicenseClassAsync_BL.GetLicenseClassInfoByIDAsync(id);
                if (existingClass == null)
                    return NotFound(new { ErrorMessage = $"License class with ID {id} not found" });

                bool success = await clsLicenseClassAsync_BL.UpdateLicenseClassAsync(licenseClass);

                if (!success)
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { ErrorMessage = "Failed to update license class" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { ErrorMessage = "Internal server error", Details = ex.Message });
            }
        }

        #endregion
    }
}