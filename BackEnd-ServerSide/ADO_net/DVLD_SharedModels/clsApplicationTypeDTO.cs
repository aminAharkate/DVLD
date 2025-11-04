using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public  class clsApplicationTypeDTO
    {
        public int? ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationTypeFees { get; set; }
        public clsApplicationTypeDTO(int? applicationTypeID, string applicationTypeTitle, float applicationTypeFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationTypeFees = applicationTypeFees;
        }
    }
}
