using DVLD_DataAccessLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDriverAsync_BL
    {

        #region CRUD
        public static async Task<DriverDTO> GetDriverInfoByDriverIDAsync(int driverID)
        {
           return await clsDriver_DAL.GetDriverInfoByDriverIDAsync(driverID);
        }

        public static async Task<DriverDTO> GetDriverInfoByPersonIDAsync(int personID)
        {
            return await clsDriver_DAL.GetDriverInfoByPersonIDAsync (personID);
        }

        public static async Task<int> AddNewDriverAsync(int personID, int createdByUserID)
        {
            return await clsDriver_DAL.AddNewDriverAsync(personID, createdByUserID);
        }

        public static async Task<bool> UpdateDriverAsync(DriverDTO dto)
        {
            return await clsDriver_DAL.UpdateDriverAsync(dto);
        }

        #endregion

        #region sepecile
        public static async Task<List<Drivers_ViewDTO>> GetAllDriversAsync()
        {
           return await clsDriver_DAL.GetAllDriversAsync();
        }
      
        #endregion

    }
}
