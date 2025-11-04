using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsGlobalSetting
    {

        public static string ConnectionString = "Server=.;Database=DVLD_V2;User Id=sa;Password=123456789;TrustServerCertificate=True";
        public enum EnMode
        {
            Edit = 0,
            Add = 1,
        };
    }
}
