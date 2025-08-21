using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public  class clsTestTypeDTO
    {
        public clsTestTypeDTO(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

    }
}
