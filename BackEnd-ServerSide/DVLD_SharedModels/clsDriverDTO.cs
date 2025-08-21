using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
   
    public class DriverDTO
    {
        public DriverDTO(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Drivers_ViewDTO
    {
        public Drivers_ViewDTO(int DriverID, int PersonID, DateTime CreatedDate, string nationalID, string fullName, int numOfActiveLicense)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            NationalID = nationalID;
            FullName = fullName;
            NumOfActiveLicense = numOfActiveLicense;
        }
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string NationalID { get; set; }
        public string FullName { get; set; }
        public int NumOfActiveLicense { get; set; }

    }
}
