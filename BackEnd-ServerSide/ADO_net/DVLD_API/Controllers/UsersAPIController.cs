using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/UsersAPi")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        #region Get User Info By UserID
        [HttpGet("GetUserInfoByUserID/{UserID}",Name = "GetUserInfoByUserID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DVLD_SharedModels.clsUserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> GetUserInfoByUserID(int UserID)
        {
            if (UserID <= 0)
            {
                return BadRequest("Invalid UserID provided.");
            }
            var user = DVLD_BusinessLayer.clsUser_BL.GetUserInfoByUserID(UserID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        #endregion

        #region Get User Info By PersonID
        [HttpGet("GetUserInfoByPersonID/{PersonID}", Name = "GetUserInfoByPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DVLD_SharedModels.clsUserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> GetUserInfoByPersonID(int PersonID)
        {
            if (PersonID <= 0)
            {
                return BadRequest("Invalid PersonID provided.");
            }
            clsUserDTO user = DVLD_BusinessLayer.clsUser_BL.GetUserInfoByPersonID(PersonID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        #endregion

        #region Get User Info By Username And Password
        [HttpGet("GetUserInfoByUsernameAndPassword/{UserName}/{Password}", Name = "GetUserInfoByUsernameAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DVLD_SharedModels.clsUserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> GetUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return BadRequest("Username and Password cannot be empty.");
            }
            var user = DVLD_BusinessLayer.clsUser_BL.GetUserInfoByUsernameAndPassword(UserName, Password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        #endregion

        #region Get All Users
        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DVLD_SharedModels.clsUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsUserDTO>> GetAllUsers()
        {
            List<clsUserDTO> users = DVLD_BusinessLayer.clsUser_BL.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        #endregion

        #region Add New User
        [HttpPost("AddNewUser", Name = "AddNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> AddNewUser(clsUserDTO userInfo)
        {
            var newID = DVLD_BusinessLayer.clsUser_BL.AddNewUser(userInfo);
            if (newID!= null)
            {
                int ID = (int)newID;
                userInfo.userID = ID;
                return CreatedAtRoute("GetUserInfoByUserID", new { UserID = ID }, userInfo);
            }
            else
            {
                return BadRequest("Failed to add person. Please check the provided data.");
            }
        }

        #endregion

        #region Update User
            [HttpPut("UpdateUser/{id}", Name = "UpdateUser")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult UpdateUser(int id,[FromBody] clsUserDTO userInfo)
            {
                if (userInfo == null || id <= 0 )
                {
                    return BadRequest("Invalid user information provided.");
                }
                clsUserDTO user = clsUser_BL.GetUserInfoByUserID(id);
                if (user!=null)
                {
                    user.userID = id;
                    user.userName = userInfo.userName;
                    user.password = userInfo.password;
                    user.isActive = userInfo.isActive;
                    user.personID = userInfo.personID;
                }
                else
                {
                    return NotFound("User not found.");
                }
                bool isUpdated = DVLD_BusinessLayer.clsUser_BL.UpdateUser(user);
                if (isUpdated)
                {
                    return Ok("User updated successfully.");
                }
                return NotFound("User update failed.");
            }
        #endregion

        #region delete user
        [HttpDelete("DeleteUser/{ID}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK ,Type = typeof(bool) )]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int ID) {
            if (ID <= 0)
            {
                return BadRequest("Invalid UserID provided.");
            }
            bool isDeleted = DVLD_BusinessLayer.clsUser_BL.DeleteUser(ID);
            if (isDeleted)
            {
                return Ok(true);
            }
            return NotFound("User not found or delete failed.");
        }
        #endregion

        #region save user
        //[HttpPost("SaveUser/{ID}", Name = "SaveUser")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult SaveUser([FromBody] clsUserDTO userInfo)
        //{
        //    if (userInfo == null || string.IsNullOrEmpty(userInfo.UserName) || string.IsNullOrEmpty(userInfo.Password))
        //    {
        //        return BadRequest("Invalid user information provided.");
        //    }
        //    DVLD_BusinessLayer.clsUser_BL objUers = new clsUser_BL(userInfo,true);

        //    if (objUers.SaveUser())
        //    {
        //        return Ok("User saved successfully.");
        //    }
        //    return NotFound("User not found or save failed.");
        //}
        #endregion

        #region Is User Exist by ID
        [HttpGet("IsUserExistByID/{id}",Name = "IsUserExistByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsUserExist(int id) {
            if (id <= 0)
            {
                return BadRequest("Invalid UserID provided.");
            }
            bool isExist = DVLD_BusinessLayer.clsUser_BL.IsUserExist(id);
            if (isExist)
            {
                return Ok(true);
            }
            return NotFound("User not found.");
        }
        #endregion 

        #region Is User Exist by UserName
        [HttpGet("IsUserExistByUserName/{UserName}", Name = "IsUserExistByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsUserNotExist(string UserName) {
            if (string.IsNullOrEmpty(UserName))
            {
                return BadRequest("Invalid UserName provided.");
            }
            bool isExist = DVLD_BusinessLayer.clsUser_BL.IsUserExist(UserName);
            if (isExist)
            {
                return Ok(true);
            }
            return NotFound("User not found.");
        }
        #endregion

        #region Is User Exist For PersonID
        [HttpGet("IsUserExistForPersonID/{PersonID}", Name = "IsUserExistForPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult IsUserExistForPersonID(int PersonID)
        {
            if (PersonID <= 0)
            {
                return BadRequest("Invalid PersonID provided.");
            }
            bool isExist = DVLD_BusinessLayer.clsUser_BL.IsUserExistForPersonID(PersonID);
            if (isExist)
            {
                return Ok(true);
            }
            return NotFound("User not found for the provided PersonID.");
        }
        #endregion

        #region Change Password
        [HttpGet("ChangePassword/{UserID}/{OldPassword}/{NewPassword}", Name = "ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> ChangePassword(int UserID, string OldPassword, string NewPassword)
        {
            if (UserID <= 0 ||  string.IsNullOrEmpty(NewPassword))
            {
                return BadRequest("Invalid input provided.");
            }
            bool isChanged = DVLD_BusinessLayer.clsUser_BL.ChangePassword(UserID, OldPassword, NewPassword);
            if (isChanged)
            {
                return Ok(true);
            }
            return NotFound("Failed to change password. Please check the provided information.");
        }
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
    }
}
