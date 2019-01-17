using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEBSystem.Core.ViewModels
{
     public class AirmenViewModel
    {
        [Key]
        public int Code { get; set; }
        public string PEL { get; set; }
        public string Fullname { get; set; }
        [DisplayName("License")]
        public int LicenseTypeId { get; set; }
        public string LicenseType { get; set; }
        [DisplayName("Address/School/Company")]
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Sex { get; set; }
        [DisplayName("Date of Birth")]
        public string DateofBirth { get; set; }
        [DisplayName("Nationality")]
        public int NationalityId { get; set; }
        public string Nationality { get; set; }
        [DisplayName("Degree/Course")]
        public string DegreeCourse { get; set; }
    }
}
