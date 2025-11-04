//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DVLD_API.Controllers
//{
//    //[Route("api/[controller]")]
//    [Route("api/LicenseAPI")]
//    [ApiController]
//    public class LicenseAPIController : ControllerBase
//    {

//    }
//}
using DVLD_BusinessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_API.Controllers
{
    [Route("api/LicenseAPI")]
    [ApiController]
    public class LicenseAPIController : ControllerBase
    {
        // GET api/LicenseAPI/5
        [HttpGet("GetLicenseByID/{licenseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LicenseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLicenseByID(int licenseId)
        {
            try
            {
                var license = await clsLicenseAsync_BL.GetLicenseInfoByIDAsync(licenseId);
                return license != null ? Ok(license) : NotFound();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/LicenseAPI
        [HttpGet("GetAllLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LicenseViewDTO>))]
        public async Task<IActionResult> GetAllLicenses()
        {
            try
            {
                var licenses = await clsLicenseAsync_BL.GetAllLicensesAsync();
                return Ok(licenses);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/LicenseAPI/Driver/5
        [HttpGet("GetDriverLicenses/{driverId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LicenseViewDTO>))]
        public async Task<IActionResult> GetDriverLicenses(int driverId)
        {
            try
            {
                var licenses = await clsLicenseAsync_BL.GetDriverLicensesAsync(driverId);
                return Ok(licenses);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/LicenseAPI
        [HttpPost("CreateLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLicense([FromBody] LicenseDTO license)
        {
            try
            {
                var licenseId = await clsLicenseAsync_BL.AddNewLicenseAsync(license);
                return licenseId > 0
                    ? CreatedAtAction(nameof(GetLicenseByID), new { licenseId }, new { LicenseID = licenseId })
                    : BadRequest("Failed to create license");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/LicenseAPI/5
        [HttpPut("UpdateLicense/{licenseId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLicense(int licenseId, [FromBody] LicenseDTO license)
        {
            try
            {
                if (licenseId != license.LicenseID)
                    return BadRequest("ID mismatch");

                var success = await clsLicenseAsync_BL.UpdateLicenseAsync(license);
                return success ? NoContent() : BadRequest("Update failed");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/LicenseAPI/Active/{personId}/{licenseClassId}
        [HttpGet("GetActiveLicenseID/{personId}/{licenseClassId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetActiveLicenseID(int personId, int licenseClassId)
        {
            try
            {
                var licenseId = await clsLicenseAsync_BL.GetActiveLicenseIDByPersonIDAsync(personId, licenseClassId);
                return licenseId > 0 ? Ok(licenseId) : NotFound();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/LicenseAPI/5
        [HttpDelete("DeactivateLicense/{licenseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeactivateLicense(int licenseId)
        {
            try
            {
                var success = await clsLicenseAsync_BL.DeactivateLicenseAsync(licenseId);
                return Ok(success);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
