using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_SharedModels
{
    public class clsCountryDTO
    {
        public int? ID { get; set; }
        public string CountryName { get; set; }
        public clsCountryDTO(int? id, string countryName)
        {
            ID = id;
            CountryName = countryName;
        }
    }
}
