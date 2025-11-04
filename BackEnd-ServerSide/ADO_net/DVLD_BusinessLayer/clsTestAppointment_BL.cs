using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public  class clsTestAppointment_BL
    {
        public  static async Task<clsTestAppointmentDTO> GetTestAppointmentByIDAsync(int testAppointmentID)
        {
            return  await clsTestAppointment_DAL.GetTestAppointmentByIDAsync(testAppointmentID);
        }

        public static async Task<clsTestAppointmentDTO> GetLastTestAppointmentAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            return await clsTestAppointment_DAL.GetLastTestAppointmentAsync(localDrivingLicenseApplicationID, testTypeID);
        }

        public static async Task<IEnumerable<clsTestAppointmentDTO>> GetAllTestAppointmentsAsync()
        {
           return await clsTestAppointment_DAL.GetAllTestAppointmentsAsync();
        }

        public static async Task<IEnumerable<clsTestAppointmentDTO>> GetTestAppointmentsByApplicationAndTypeAsync(
            int localDrivingLicenseApplicationID, int testTypeID)
        {
            return await clsTestAppointment_DAL.GetTestAppointmentsByApplicationAndTypeAsync(localDrivingLicenseApplicationID, testTypeID);
        }

        public static async Task<int> AddTestAppointmentAsync(clsTestAppointmentDTO appointment)
        {
            return await clsTestAppointment_DAL.AddTestAppointmentAsync(appointment);
        }

        public static async Task<bool> UpdateTestAppointmentAsync(clsTestAppointmentDTO appointment)
        {
            return await clsTestAppointment_DAL.UpdateTestAppointmentAsync(appointment);
        }

        public static async Task<int?> GetTestIDByAppointmentIDAsync(int testAppointmentID)
        {
            return await clsTestAppointment_DAL.GetTestIDByAppointmentIDAsync(testAppointmentID);
        }
    }
}
