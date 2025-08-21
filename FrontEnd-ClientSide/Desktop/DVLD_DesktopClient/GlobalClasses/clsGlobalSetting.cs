using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DesktopClient.GlobalClasses
{
    public  class clsGlobalSetting
    {
         public static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5045/api/") };
        public enum EnMode
        {
            Add = 0,
            Edit = 1,
        };

    }
}
