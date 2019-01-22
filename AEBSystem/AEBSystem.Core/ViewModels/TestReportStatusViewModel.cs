using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBSystem.Core.ViewModels
{
    public class TestReportStatusViewModel
    {
        public int Id { get; set; }
        public string PEL { get; set; }
        public string  Fullname {get;set;}
        public string License { get; set; }
        public string Status { get; set; }
        public string Initial { get; set; }
        public string iDate { get; set; }
        public string ControlledBy { get; set; }
        public string ControllNo { get; set; }
        public string cDate { get; set; }
        public string ReleasedBy { get; set; }
        public string rDate { get; set; }
        public string Remarks { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
