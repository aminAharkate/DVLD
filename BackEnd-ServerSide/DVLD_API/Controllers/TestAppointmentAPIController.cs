//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DVLD_API.Controllers
//{
//    //[Route("api/[controller]")]
//    [Route("api/TestAppointmentAPI")]
//    [ApiController]
//    public class TestAppointmentAPIController : ControllerBase
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
    [Route("api/TestAppointmentAPI")]
    [ApiController]
    public class TestAppointmentAPIController : ControllerBase
    {
        private readonly clsTestAppointment_BL clsTestAppointment_BL;

        //public TestAppointmentAPIController()
        //{
        //    //clsTestAppointment_BL = new clsTestAppointment_BL();
        //}

        // GET api/TestAppointmentAPI/5
        [HttpGet("GetTestAppointmentByID/{id}",Name = "GetTestAppointmentByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsTestAppointmentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTestAppointment(int id)
        {
            try
            {
                var appointment = await clsTestAppointment_BL.GetTestAppointmentByIDAsync(id);

                if (appointment == null)
                    return NotFound();

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/TestAppointmentAPI/Last/5/1
        [HttpGet("GetLastTestAppointment/{applicationId}/{testTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsTestAppointmentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastTestAppointment(int applicationId, int testTypeId)
        {
            try
            {
                var appointment = await clsTestAppointment_BL.GetLastTestAppointmentAsync(applicationId, testTypeId);

                if (appointment == null)
                    return NotFound();

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/TestAppointmentAPI
        [HttpGet("GetAllTestAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<clsTestAppointmentDTO>))]
        public async Task<IActionResult> GetAllTestAppointments()
        {
            try
            {
                var appointments = await clsTestAppointment_BL.GetAllTestAppointmentsAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/TestAppointmentAPI/ByApplicationAndType/5/1
        [HttpGet("GetTestAppointmentsByApplicationAndType/{applicationId}/{testTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<clsTestAppointmentDTO>))]
        public async Task<IActionResult> GetTestAppointmentsByApplicationAndType(int applicationId, int testTypeId)
        {
            try
            {
                var appointments = await clsTestAppointment_BL.GetTestAppointmentsByApplicationAndTypeAsync(applicationId, testTypeId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/TestAppointmentAPI
        [HttpPost("AddTestAppointment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTestAppointment([FromBody] clsTestAppointmentDTO appointmentDTO)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return BadRequest(ModelState);
                //working
                var appointmentId = await clsTestAppointment_BL.AddTestAppointmentAsync(appointmentDTO);

                if (appointmentId <= 0)
                    return BadRequest("Failed to create test appointment");

                return CreatedAtAction(nameof(GetTestAppointment), new { id = appointmentId }, appointmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/TestAppointmentAPI/5
        [HttpPut("UpdateTestAppointment/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTestAppointment(int id, [FromBody] clsTestAppointmentDTO appointmentDTO)
        {
            try
            {
                if (id != appointmentDTO.TestAppointmentID)
                    return BadRequest("ID mismatch");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingAppointment = await clsTestAppointment_BL.GetTestAppointmentByIDAsync(id);
                if (existingAppointment == null)
                    return NotFound();

                var result = await clsTestAppointment_BL.UpdateTestAppointmentAsync(appointmentDTO);

                if (!result)
                    return BadRequest("Update failed");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/TestAppointmentAPI/TestID/5
        [HttpGet("GetTestIDByAppointmentID/{appointmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int?))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTestIDByAppointmentID(int appointmentId)
        {
            try
            {
                var testId = await clsTestAppointment_BL.GetTestIDByAppointmentIDAsync(appointmentId);

                if (testId == null)
                    return NotFound();

                return Ok(testId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
       
        // no need just delete the commanted one 
        /*
        // Additional endpoints could be added here
        // For example:

        // GET api/TestAppointmentAPI/IsLocked/5
        [HttpGet("IsLocked/{appointmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> IsAppointmentLocked(int appointmentId)
        {
            try
            {
                var isLocked = await clsTestAppointment_BL.IsAppointmentLockedAsync(appointmentId);
                return Ok(isLocked);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        */
        /*
        // POST api/TestAppointmentAPI/Cancel/5
        [HttpPost("Cancel/{appointmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            try
            {
                var result = await clsTestAppointment_BL.CancelTestAppointmentAsync(appointmentId);

                if (!result)
                    return BadRequest("Cancellation failed");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        */
    }
}