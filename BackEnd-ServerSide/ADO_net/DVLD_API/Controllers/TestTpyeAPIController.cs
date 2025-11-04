using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace DVLD_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/TestTypeAPI")]

    [ApiController]
    public class TestTpyeAPIController : ControllerBase
    {
        #region attributes + Constructor + Dependency Injection + Logger + Logger + Configuration + Mapper + AutoMapper + Mapper Configuration + AutoMapper Configuration + AutoMapper Profile 
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        //public clsTestType.enTestType ID { set; get; }
        #endregion

        #region  Get Test Type Info By ID
        [HttpGet("GetTestTypeInfoByID/{testTypeID}",Name = "GetTestTypeInfoByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsTestTypeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<clsTestTypeDTO> GetTestTypeInfoByID(int testTypeID)
        {
            if (testTypeID <= 0)
            {
                return BadRequest("Invalid Test Type ID provided.");
            }
            try
            {
                var testType = DVLD_BusinessLayer.clsTestType_BL.GetTestTypeInfoByID(testTypeID);
                if (testType == null)
                {
                    return NotFound($"Test Type with ID {testTypeID} not found.");
                }
                return Ok(testType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }

        }
        #endregion

        #region Get All Test Types
        [HttpGet("GetAllTestTypes", Name = "GetAllTestTypes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<clsTestTypeDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<clsTestTypeDTO>> GetAllTestTypes(/*int? page = null, int? pageSize = null*/)
        {
            try
            {
                var testTypes = DVLD_BusinessLayer.clsTestType_BL.GetAllTestTypes();

                if (testTypes == null || testTypes.Count == 0)
                {
                    return NotFound("No test types found.");
                }

                //// Apply pagination if parameters are provided
                //if (page.HasValue && pageSize.HasValue && page > 0 && pageSize > 0)
                //{
                //    testTypes = testTypes.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
                //}

                return Ok(testTypes);
            }
            catch (SqlException sqlEx)
            {
                //Logger.LogError("SQL error occurred while fetching test types.", sqlEx);
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error occurred.");
            }
            catch (Exception ex)
            {
               // Logger.LogError("Unexpected error occurred while fetching test types.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error.");
            }
        }

        #endregion

        #region Update Test Type

        [HttpPut("UpdateTestType/{id}", Name = "UpdateTestType")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> UpdateTestType(int id,[FromBody] clsTestTypeDTO testType)
        {
            if (testType == null || id <= 0)
            {
                return BadRequest("Invalid Test Type data provided.");
            }
            try
            {
                var existingTestType = DVLD_BusinessLayer.clsTestType_BL.GetTestTypeInfoByID(id);
                if (existingTestType != null)
                {
                    existingTestType.TestTypeTitle = testType.TestTypeTitle;
                    existingTestType.TestTypeDescription = testType.TestTypeDescription;
                    existingTestType.TestTypeFees = testType.TestTypeFees;
                }
                bool isUpdated = DVLD_BusinessLayer.clsTestType_BL.UpdateTestType(existingTestType);
                if (!isUpdated)
                {
                    return NotFound($"Test Type with ID {id} not found or update failed.");
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        #endregion
    }
}

