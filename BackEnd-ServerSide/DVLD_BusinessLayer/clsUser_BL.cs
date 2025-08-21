using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsUser_BL
    {
        #region cstructor and properties
        public clsUser_BL(clsUserDTO userDTO, bool mode)
        {
            this.UserDTO = userDTO;
            this.UserID = userDTO.userID;
            this.PersonID = userDTO.personID;
            this.UserName = userDTO.userName;
            this.Password = userDTO.password;
            this.IsActive = userDTO.isActive;
            this.PersonInfo = clsPerson_DAL.GetPersonInfo(UserID);
            _Mode = mode==true? clsGlobalSetting.EnMode.Add:clsGlobalSetting.EnMode.Edit;
        }
        clsGlobalSetting.EnMode _Mode;
        public clsUserDTO UserDTO { get;  }
        public int UserID { set; get; }
        public int PersonID { set; get; }

        public clsPersonDTO PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        #endregion

        #region Get User Info By UserID
        public static  clsUserDTO GetUserInfoByUserID(int UserID)
        {
           var clsUser = clsUser_DAL.GetUserInfoByUserID(UserID);
            //if (clsUser != null)
            //    clsUser.PersonInfo = clsPerson_DAL.GetPersonInfo(clsUser.UserID);
            return clsUser;
        }
        #endregion

        #region Get User Info By PersonID
        public static clsUserDTO GetUserInfoByPersonID(int PersonID)
        {
            var clsUser = clsUser_DAL.GetUserInfoByPersonID(PersonID);
            //if (clsUser != null)
            //    clsUser.PersonInfo = clsPerson_DAL.GetPersonInfo(PersonID);
            return clsUser;
        }
        #endregion

        #region Get User Info By Username And Password
        public static  clsUserDTO GetUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            var clsUser = clsUser_DAL.GetUserInfoByUsernameAndPassword(UserName, Password);
            //if (clsUser != null)
            //    clsUser.PersonInfo = clsPerson_DAL.GetPersonInfo(clsUser.PersonID);
            return clsUser;
        }
        #endregion

        #region Get All Users
        public static List<clsUserDTO> GetAllUsers()
        {
            return clsUser_DAL.GetAllUsers();
        }
        #endregion

        #region Add New User
        public static int?  AddNewUser(clsUserDTO UserInfo)
        {
            return clsUser_DAL.AddNewUser(UserInfo);
        }
        #endregion

        #region Update User
        public static bool UpdateUser(clsUserDTO UserInfo)
        {
            return clsUser_DAL.UpdateUser(UserInfo);
        }
        #endregion

        #region Delete User
        public static bool DeleteUser(int UserID)
        {
            return clsUser_DAL.DeleteUser(UserID);
        }
        #endregion

        #region Save User
        //public bool SaveUser()
        //{
        //    switch(_Mode)
        //    {
        //        case clsGlobalSetting.EnMode.Add:
        //            if (_AddNewUser(UserDTO) == null)
        //                return false;
        //            break;
        //        case clsGlobalSetting.EnMode.Edit:
        //            if (!_UpdateUser(UserDTO))
        //                return false;
        //            break;
        //        default:
        //            return false;
        //    }

        //   return true;
        //}
        #endregion

        #region Is User Exist by ID
        public static  bool IsUserExist(int UserID)
        {
            return clsUser_DAL.IsUserExist(UserID);
        }
        #endregion

        #region Is User Exist By UserName
        public static  bool IsUserExist(string UserName)
        {
            return clsUser_DAL.IsUserExist(UserName);
        }
        #endregion 

        #region Is User Exist For PersonID
        public static  bool IsUserExistForPersonID(int PersonID)
        {
            return clsUser_DAL.IsUserExistForPersonID(PersonID);
        }
        #endregion

        #region Change Password
        public static  bool ChangePassword(int UserID,string  OldPassword, string NewPassword)
        {
            return clsUser_DAL.ChangePassword(UserID,  NewPassword);
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


    }
}
