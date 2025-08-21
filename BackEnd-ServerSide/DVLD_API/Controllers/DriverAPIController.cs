
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_API.Controllers
{
    [Route("api/DriverAPI")]
    [ApiController]
    public class DriverAPIController : ControllerBase
    {

        // GET api/DriverAPI/5
        [HttpGet("GetDriverByID/{driverId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DriverDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDriverByID(int driverId)
        {
            try
            {
                var driver = await clsDriverAsync_BL.GetDriverInfoByDriverIDAsync(driverId);

                if (driver == null)
                    return NotFound();

                return Ok(driver);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/DriverAPI/ByPerson/5
        [HttpGet("GetDriverByPersonID/{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DriverDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDriverByPersonID(int personId)
        {
            try
            {
                var driver = await clsDriverAsync_BL.GetDriverInfoByPersonIDAsync(personId);

                if (driver == null)
                    return NotFound();

                return Ok(driver);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/DriverAPI
        [HttpGet("GetAllDrivers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Drivers_ViewDTO>))]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var drivers = await clsDriverAsync_BL.GetAllDriversAsync();
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/DriverAPI
        [HttpPost("CreateDriver")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateDriver([FromBody] DriverCreateDTO driverCreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var driverId = await clsDriverAsync_BL.AddNewDriverAsync(
                    driverCreateDTO.PersonID,
                    driverCreateDTO.CreatedByUserID);

                if (driverId <= 0)
                    return BadRequest("Failed to create driver");

                return CreatedAtAction(
                    nameof(GetDriverByID),
                    new { driverId = driverId },
                    new { DriverID = driverId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/DriverAPI/5
        [HttpPut("UpdateDriver/{driverId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDriver(int driverId, [FromBody] DriverDTO driverUpdateDTO)
        {
            try
            {
                if (driverId != driverUpdateDTO.DriverID)
                    return BadRequest("ID mismatch");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingDriver = await clsDriverAsync_BL.GetDriverInfoByDriverIDAsync(driverId);
                if (existingDriver == null)
                    return NotFound();

                var result = await clsDriverAsync_BL.UpdateDriverAsync(
                    driverUpdateDTO);

                if (!result)
                    return BadRequest("Update failed");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // DTO classes for API-specific needs
        public class DriverCreateDTO
        {
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
        }

        
    }
}
