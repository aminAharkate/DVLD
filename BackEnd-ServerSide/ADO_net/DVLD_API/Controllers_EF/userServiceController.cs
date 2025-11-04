using DVLD_BusinessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_API.Controllers_EF
{
    //[Route("api/[controller]")]
    [Route("api/userService")]

    [ApiController]
    public class userServiceController : ControllerBase
    {
        #region Get User Info By Username And Password
        [HttpGet("GetUserInfoByUsernameAndPassword/{UserName}/{Password}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(clsUserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> GetUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            // Input validation
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return BadRequest("Username and Password cannot be empty.");
            }

            // Business logic
            var user = clsUser_BL.GetUserInfoByUsernameAndPassword(UserName, Password);

            if (user == null)
            {
                return NotFound("Invalid username or password.");
            }

            return Ok(user);
        }
        #endregion
    }
}
