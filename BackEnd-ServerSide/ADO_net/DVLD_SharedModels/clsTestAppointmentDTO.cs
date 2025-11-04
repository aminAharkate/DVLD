using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public  class clsTestAppointmentDTO
    {
        public clsTestAppointmentDTO() { }
        public clsTestAppointmentDTO(int TestAppointmentID,DateTime AppointmentDate,decimal PaidFees,bool IsLocked) 
        {
            this.TestAppointmentID = TestAppointmentID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
        }
        public clsTestAppointmentDTO(int TestAppointmentID,int TestTypeID,int LocalDrivingLicenseApplicationID,DateTime AppointmentDate , decimal PaidFees,int CreatedByUserID ,bool IsLocked,int? RetakeTestApplicationID) 
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
        }
        public int TestAppointmentID { get; set; } = -1;
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; } // Using decimal for monetary values
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; } // Nullable for optional field
    }
}
