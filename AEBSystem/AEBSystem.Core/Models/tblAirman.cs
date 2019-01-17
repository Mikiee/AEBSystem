//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AEBSystem.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tblAirman
    {
        [Key]
        public int Code { get; set; }
        [DisplayName("Fullname")]
        [Required]
        public string Description { get; set; }
        [DisplayName("License Type ID")]
        [Required]
        public Nullable<int> AirmenType_Id { get; set; }
        [DisplayName("Address / School / Company")]
        public string Address { get; set; }
        public string Contact_no { get; set; }
        public string Occupation { get; set; }
        
        [Required]
        public string Sex { get; set; }
        [DisplayName("Nationality ID")]
        [Required]
        public Nullable<int> Nationality_Id { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Hair_Color { get; set; }
        public string Build { get; set; }
        public string Realtionship { get; set; }
        public Nullable<System.DateTime> Date_Naturalized { get; set; }
        public string Rel_Address { get; set; }
        public Nullable<int> CivilStatus_Id { get; set; }
        public string Relative { get; set; }

        [DisplayName("Date of Birth")]
        [Required]
        
        public Nullable<System.DateTime> Date_Birth { get; set; }
        public string Complexion { get; set; }
        public Nullable<int> Citizenship_Id { get; set; }
        public string Employer { get; set; }
        public string Eye_Color { get; set; }
        public string Job_Title { get; set; }
        public string Rel_Contact { get; set; }

        [Required]
        public string PEL { get; set; }
        [DisplayName("Degree / Course")]
        public string DegreeCourse { get; set; }
    }
}
