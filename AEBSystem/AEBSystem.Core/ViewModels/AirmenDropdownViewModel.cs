using AEBSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AEBSystem.Core.ViewModels
{
    public class AirmenDropdownViewModel
    {
        public tblAirman Airmen { get; set; }
        public IEnumerable<tblAMType> LicenseTypeList { get; set; }
        public IEnumerable<tblNationality> NationalityList { get; set; }
    }
}
