﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CAAPDATA_MNL_DbSet : DbContext
    {
        public CAAPDATA_MNL_DbSet()
            : base("name=CAAPDATA_MNL_DbSet")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAirman> tblAirmen { get; set; }
        public virtual DbSet<tblAMType> tblAMTypes { get; set; }
        public virtual DbSet<tblAnswerSheet1> tblAnswerSheet1 { get; set; }
        public virtual DbSet<tblAnswerSheet2> tblAnswerSheet2 { get; set; }
        public virtual DbSet<tblApplication> tblApplications { get; set; }
        public virtual DbSet<tblLicType1> tblLicType1 { get; set; }
        public virtual DbSet<tblLicType2> tblLicType2 { get; set; }
        public virtual DbSet<tblNationality> tblNationalities { get; set; }
        public virtual DbSet<tblQuestionnaire> tblQuestionnaires { get; set; }
        public virtual DbSet<tblSchool> tblSchools { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblTestReportApplication> tblTestReportApplications { get; set; }
    
        public virtual ObjectResult<getAirmenAll> getAirmen_all(string search)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAirmenAll>("getAirmen_all", searchParameter);
        }
    
        public virtual ObjectResult<ExamHistoryResult> ExamHistory(string pEL, Nullable<int> aM_Type)
        {
            var pELParameter = pEL != null ?
                new ObjectParameter("PEL", pEL) :
                new ObjectParameter("PEL", typeof(string));
    
            var aM_TypeParameter = aM_Type.HasValue ?
                new ObjectParameter("AM_Type", aM_Type) :
                new ObjectParameter("AM_Type", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ExamHistoryResult>("ExamHistory", pELParameter, aM_TypeParameter);
        }
    
        public virtual int trInitial(string pEL, Nullable<int> amType, string initial, Nullable<System.DateTime> iDate, string remarks)
        {
            var pELParameter = pEL != null ?
                new ObjectParameter("PEL", pEL) :
                new ObjectParameter("PEL", typeof(string));
    
            var amTypeParameter = amType.HasValue ?
                new ObjectParameter("amType", amType) :
                new ObjectParameter("amType", typeof(int));
    
            var initialParameter = initial != null ?
                new ObjectParameter("Initial", initial) :
                new ObjectParameter("Initial", typeof(string));
    
            var iDateParameter = iDate.HasValue ?
                new ObjectParameter("iDate", iDate) :
                new ObjectParameter("iDate", typeof(System.DateTime));
    
            var remarksParameter = remarks != null ?
                new ObjectParameter("Remarks", remarks) :
                new ObjectParameter("Remarks", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("trInitial", pELParameter, amTypeParameter, initialParameter, iDateParameter, remarksParameter);
        }
    }
}
