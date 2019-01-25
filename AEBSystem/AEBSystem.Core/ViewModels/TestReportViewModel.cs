using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEBSystem.Core.Models;

namespace AEBSystem.Core.ViewModels
{
    public class TestReportViewModel
    {
        public tblTestReportApplication TestReport {get;set;}
        public IEnumerable<tblAirman> Airmen { get; set; }
        public IEnumerable<tblAMType> LicenseType { get; set; }
    }
}
