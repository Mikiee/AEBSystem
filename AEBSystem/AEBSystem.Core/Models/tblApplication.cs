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
    
    public partial class tblApplication
    {
        public Nullable<System.DateTime> Application_Date { get; set; }
        public int Code { get; set; }
        public Nullable<int> Airmen_Id { get; set; }
        public Nullable<int> ExamSched_Id { get; set; }
        public Nullable<int> Subject_id { get; set; }
        public Nullable<System.DateTime> Exam_date { get; set; }
        public string Loc { get; set; }
    }
}
