using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public  class clsUserDTO
    {
        //public clsUserDTO(int userID, int personID ,string userName , string passwoed, bool isActive) 
        public clsUserDTO(int userID, int personID, string userName, string password, bool isActive)

        {
            this.userID = userID;
            this.personID = personID;
            this.userName = userName;
            this.password = password;
            this.isActive = isActive;
        }
        public int userID { set; get; }
        public int personID { set; get; }

       // public clsPersonDTO PersonInfo { set; get; }
        public string userName { set; get; }
        public string password { set; get; }
        public bool isActive { set; get; }
    }
}
