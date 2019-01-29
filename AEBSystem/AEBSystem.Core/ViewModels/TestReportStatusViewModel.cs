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
        [DisplayName("Initial Date of Application")]
        public DateTime iDate { get; set; }
        [DisplayName("Controlled By")]
        public string ControlledBy { get; set; }
        [DisplayName("Control No.")]
        public string ControlNo { get; set; }
        [DisplayName("Controlled Date")]
        public DateTime cDate { get; set; }
        [DisplayName("Released By")]
        public string ReleasedBy { get; set; }
        [DisplayName("Released Date")]
        public DateTime rDate { get; set; }
        public string Remarks { get; set; }
        public string LastModifiedBy { get; set; }

       
    }
}
