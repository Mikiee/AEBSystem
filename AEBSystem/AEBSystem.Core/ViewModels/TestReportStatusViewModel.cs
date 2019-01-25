using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AEBSystem.Core.Models;

namespace AEBSystem.Core.ViewModels
{
    public class TestReportStatusViewModel
    {
        [Key]
        public int Id { get; set; }
        public string PEL { get; set; }
        public string Fullname {get;set;}
        [DisplayName("License Type")]
        public int amType { get; set; }
        public string License { get; set; }
        public string Status { get; set; }
        public string Initial { get; set; }
        public DateTime iDate { get; set; }
        public string ControlledBy { get; set; }
        public string ControllNo { get; set; }
        public DateTime cDate { get; set; }
        public string ReleasedBy { get; set; }
        public DateTime rDate { get; set; }
        public string Remarks { get; set; }
        public string LastModifiedBy { get; set; }

       
    }
}
