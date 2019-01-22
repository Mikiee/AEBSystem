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
        IEnumerable<tblAirman> Airmen { get; set; }
        IEnumerable<tblTestReportApplication> TestReports { get; set; }
        IEnumerable<tblAMType> LicenseType { get; set; }
    }
}
