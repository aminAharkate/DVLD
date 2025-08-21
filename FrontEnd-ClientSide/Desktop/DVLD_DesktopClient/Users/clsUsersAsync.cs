using DVLD_DesktopClient.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DesktopClient.Users
{
    public class clsUsersAsync
    {
        /* v001
        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/UsersAPi/") };
        #region  Get User Info By UserID
        public static async Task<clsDTOs.clsUserDTO> GetUserInfoByUserIDAsync(int userID)
        {

            var response = await _httpClient.GetAsync($"GetUserInfoByUserID/{userID}");
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<clsDTOs.clsUserDTO>();
                 return user ?? throw new InvalidOperationException("User data is null."); ;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error fetching user data: {errorMessage}");
            }
        }
        #endregion

        #region  Get User Info By PersonID
        public static async Task<clsDTOs.clsUserDTO> GetUserInfoByPersonIDAsync(int personID)
        {
            var response = await _httpClient.GetAsync($"GetUserInfoByPersonID/{personID}");
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<clsDTOs.clsUserDTO>();
                return  user ?? throw new InvalidOperationException("User data is null."); ;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error fetching user data: {errorMessage}");
            }
        }
        #endregion
        */

        static HttpClient httpClient = new HttpClient();

        #region  Get User Info By UserID
        public static async Task<clsDTOs.clsUserDTO> GetUserInfoByUserIDAsync(int userID)
        {
            var response = await httpClient.GetAsync($"http://localhost:5045/api/UsersAPi/GetUserInfoByUserID/{userID}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<clsDTOs.clsUserDTO>();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region  Get User Info By PersonID
        public static async Task<clsDTOs.clsUserDTO> GetUserInfoByPersonIDAsync(int personID)
        {
            var response = await httpClient.GetAsync($"http://localhost:5045/api/UsersAPi/GetUserInfoByPersonID/{personID}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<clsDTOs.clsUserDTO>();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region  Get User Info By Username And Password
        public static async Task<clsDTOs.clsUserDTO> GetUserInfoByUsernameAndPasswordAsync(string userName, string password)
        {
            
            var response = await httpClient.GetAsync($"http://localhost:5045/api/UsersAPi/GetUserInfoByUsernameAndPassword/{userName}/{password}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<clsDTOs.clsUserDTO>();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Get All Users
        public static async Task<List<clsDTOs.clsUserDTO>> GetAllUsersAsync()
        {
            var response = await httpClient.GetAsync("http://localhost:5045/api/UsersAPi/GetAllUsers");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<clsDTOs.clsUserDTO>>();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Add New User
        public static async Task<bool> AddNewUserAsync(clsDTOs.clsUserDTO user)
        {
            var response = await httpClient.PostAsJsonAsync("http://localhost:5045/api/UsersAPi/AddNewUser", user);
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region Update User
        public static async Task<bool> UpdateUserAsync(clsDTOs.clsUserDTO user)
        {
            var response = await httpClient.PutAsJsonAsync("http://localhost:5045/api/UsersAPi/UpdateUser", user);
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region delete user
        public static async Task<bool> DeleteUserAsync(int userID)
        {
            var response = await httpClient.DeleteAsync($"http://localhost:5045/api/UsersAPi/DeleteUser/{userID}");
            return response.IsSuccessStatusCode;
        }
        #endregion

        #region save user
        #endregion

        #region Is User Exist by ID
        public static async Task<bool> IsUserExistByIDAsync(int userID)
        {
            var response = await httpClient.GetAsync($"http://localhost:5045/api/UsersAPi/IsUserExistByID/{userID}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Is User Exist by UserName
        public static async Task<bool> IsUserExistByUserNameAsync(string userName)
        {
            var response = await httpClient.GetAsync($"http://localhost:5045/api/UsersAPi/IsUserExistByUserName/{userName}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Is User Exist For PersonID
        public static async Task<bool> IsUserExistForPersonIDAsync(int personID)
        {
            var response = await httpClient.GetAsync($"http://localhost:5045/api/UsersAPi/IsUserExistForPersonID/{personID}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Change Password need ur handling 
        public static async Task<bool> ChangePasswordAsync(int userID, string newPassword)
        {
        
            //var response = await httpClient.PutAsJsonAsync($"http://localhost:5045/api/UsersAPi/ChangePassword/{userID}/{0}/{newPassword}");
           //var response = await new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/UsersAPi/")}.PutAsJsonAsync($"ChangePassword/{userID}/{0}/{newPassword}");
           // return response.IsSuccessStatusCode;
           return false;
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


        #region
        #endregion

        #region
        #endregion


        #region
        #endregion
    }
}

