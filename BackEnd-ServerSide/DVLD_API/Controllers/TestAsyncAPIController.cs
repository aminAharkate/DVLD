//using DVLD_DataAccessLayer;
//using DVLD_SharedModels;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DVLD_API.Controllers
//{
//    //[Route("api/[controller]")]
//    [Route("api/TestAsyncAPI")]
//    [ApiController]
//    public class TestAsyncAPIController : ControllerBase
//    {
//        #region GRUD Operations [Without DELETE]
//        [HttpGet("GetTestInfoByIDAsync{TestID}", Name = "GetTestInfoByIDAsync")]
//        [ProducesResponseType(typeof(clsTestDTO), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<clsTestDTO>> GetTestInfoByIDAsync(int TestID)
//        {
//            if (TestID <= 0)
//            {
//                return BadRequest("Invalid Test ID provided.");
//            }

//            try
//            {
//                var testInfo = await clsTestAsync_BL.GetTestInfoByIDAsync(TestID);
//                if (testInfo == null)
//                {
//                    return NotFound();
//                }
//                return Ok(testInfo);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception (not implemented here)
//                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
//            }
//        }




//        #endregion
//    }
//}
//*********************************************************************************
using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/TestsAPI")]
    [ApiController]
    public class TestsAsyncController : ControllerBase
    {
        #region CRUD Operations

        [HttpGet("GetTestById/{id}", Name = "GetTestById")]
        [ProducesResponseType(typeof(clsTestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsTestDTO>> GetTestById(int id)
        {
            if (id <= 0)
                return BadRequest("Test ID must be positive");

            try
            {
                var test = await clsTestAsync_BL.GetTestInfoByIDAsync(id);
                return test == null ? NotFound() : Ok(test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddNewTest")]
        [ProducesResponseType(typeof(clsTestDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsTestDTO>> CreateTest([FromBody] clsTestDTO testDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var testId = await clsTestAsync_BL.AddNewTestAsync(testDTO);
                if (testId <= 0)
                    return StatusCode(500, "Failed to create test");

                var createdTest = await clsTestAsync_BL.GetTestInfoByIDAsync(testId);
                return CreatedAtRoute("GetTestById", new { id = testId }, createdTest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateTest/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTest(int id, [FromBody] clsTestDTO testDTO)
        {
            if (id <= 0 || id != testDTO.TestID)
                return BadRequest("Invalid Test ID");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingTest = await clsTestAsync_BL.GetTestInfoByIDAsync(id);
                if (existingTest == null)
                    return NotFound();

                var success = await clsTestAsync_BL.UpdateTestAsync(testDTO);
                return success ? NoContent() : StatusCode(500, "Failed to update test");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region Specialized Operations

        [HttpGet("GetLastTestByPerson/{personId}/license-class/{licenseClassId}/test-type/{testTypeId}/latest")]
        [ProducesResponseType(typeof(clsTestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<clsTestDTO>> GetLastTest(int personId, int licenseClassId, int testTypeId)
        {
            if (personId <= 0 || licenseClassId <= 0 || testTypeId <= 0)
                return BadRequest("All IDs must be positive");

            try
            {
                var test = await clsTestAsync_BL.GetLastTestByPersonAndTestTypeAndLicenseClassAsync(
                    personId, licenseClassId, testTypeId);
                return test == null ? NotFound() : Ok(test);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetAllTests")]
        [ProducesResponseType(typeof(IEnumerable<clsTestDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<clsTestDTO>>> GetAllTests()
        {
            try
            {
                var tests = await clsTestAsync_BL.GetAllTestsAsync();
                return Ok(tests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetPassedTestCountByApplication/{applicationId}/passed-count")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetPassedTestCount(int applicationId)
        {
            if (applicationId <= 0)
                return BadRequest("Application ID must be positive");

            try
            {
                var count = await clsTestAsync_BL.GetPassedTestCountAsync(applicationId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion
    }
}