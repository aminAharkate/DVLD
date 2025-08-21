using DVLD_DataAccessLayer;
using DVLD_SharedModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccessLayer.clsGlobalSetting;

namespace DVLD_BusinessLayer
{
    public static  class clsApplicationType_BL
    {
        #region properties +  onstructor + Mode
        //private clsGlobalSetting.EnMode _Mode { get; set; } = EnMode.Add;
        //public clsApplicationType_BL(clsApplicationTypeDTO AYDTO)
        //{
        //    this.ApplicationTypeID = AYDTO.ApplicationTypeID;
        //    this.ApplicationTypeTitle = AYDTO.ApplicationTypeTitle;
        //    this.ApplicationTypeFees = AYDTO.ApplicationTypeFees;
        //    _Mode = EnMode.Edit;
        //}
        //public int? ApplicationTypeID { set; get; }
        //public string ApplicationTypeTitle { set; get; }
        //public float ApplicationTypeFees { set; get; }
        #endregion
        public static List<clsApplicationTypeDTO> GetAllApplicationTypes()
        {
            return clsApplicationType_DAL.GetAllApplicationTypes();
        }
        public static clsApplicationTypeDTO GetApplicationTypeInfoByID(int applicationTypeID)
        {
            return clsApplicationType_DAL.GetApplicationTypeInfoByID(applicationTypeID);
        }
        public static bool UpdateApplicationType(clsApplicationTypeDTO applicationType)
        {
            return clsApplicationType_DAL.UpdateApplicationType(applicationType);
        }
    }

}
