using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public  class clsTestType_BL
    {
        #region Get Test Type Info By ID
        public static clsTestTypeDTO GetTestTypeInfoByID(int testTypeID)
        {
            return clsTestType_DAL.GetTestTypeInfoByID(testTypeID);
        }
        #endregion

        #region Get All Test Types
        public static List<clsTestTypeDTO> GetAllTestTypes()
        {
            return clsTestType_DAL.GetAllTestTypes();
        }
        #endregion

        #region update Test Type
        public static bool UpdateTestType(clsTestTypeDTO testType)
        {
            return clsTestType_DAL.UpdateTestType(testType);
        }
        #endregion

    }
}
