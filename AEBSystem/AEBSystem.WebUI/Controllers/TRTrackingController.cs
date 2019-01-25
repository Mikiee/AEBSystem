using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AEBSystem.Core.Models;
using AEBSystem.Core.ViewModels;
using CrystalDecisions.CrystalReports.Engine;
using AEBSystem.DataAccess.InMemory;
using AEBSystem.DataAccess.SQL;

namespace AEBSystem.WebUI.Controllers
{
    public class TRTrackingController : Controller 
    {

        // GET: TRTracking
        CAAPDATA_MNL_DbSet db_mnl = new CAAPDATA_MNL_DbSet();
        CAAPDATA_NLA_DbSet db_nla = new CAAPDATA_NLA_DbSet();
        CAAPDATA_MA_DbSet db_ma = new CAAPDATA_MA_DbSet();
        CAAPDATA_VA_DbSet db_va = new CAAPDATA_VA_DbSet();
       

        public ActionResult Index(string search)
        {
            var AirmenFromSP = db_mnl.getAirmen_all(search).ToList();
            return View(AirmenFromSP);           
          
           
        }    
       
        public ActionResult ExamHistory(string PEL, int amType)
        {  
            List<ExamHistoryResult> history = new List<ExamHistoryResult>();
            history = db_mnl.ExamHistory(PEL, amType).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"),"ExamHistory.rpt"));

            rd.SetDataSource(history);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", PEL + "_" + amType +"_History.pdf");
        }

        public ActionResult ViewApplications(string search)
        {
            
            var am = db_mnl.getAirmen_all(search).ToList();
            var tr = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();

            var viewModel = (from a in am
                             join t in tr on a.PEL equals t.PEL
                             join l in lic on t.amType equals l.code
                             where a.AirmenType.Equals(t.amType)    
                             orderby t.Id descending
                             select new TestReportStatusViewModel
                             {
                                 Id = t.Id,
                                 PEL = t.PEL,
                                 Fullname = a.Fullname,
                                 License = l.description,
                                 Status = t.Status,
                                 Remarks = t.Remarks,
                                 LastModifiedBy = t.LastModifiedBy
                             }
                             ).ToList();
            return View(viewModel);
        }

        public ActionResult Initial(int Id, string Loc)
        {
            if (Loc == "MNL")
            {
                var am = db_mnl.tblAirmen.ToList();
                var lic = db_mnl.tblAMTypes.ToList();
                var tr = (from a in am
                          join l in lic on a.AirmenType_Id equals l.code
                          where a.Code.Equals(Id)
                          select new TestReportStatusViewModel
                          {
                              Id = a.Code,
                              PEL = a.PEL,
                              Fullname = a.Description,
                              amType = a.AirmenType_Id,
                              License = l.description
                          }).FirstOrDefault();
                return View(tr);
            }
            else if (Loc == "NLA")
            {
                var am = db_nla.tblAirmen.ToList();
                var lic = db_mnl.tblAMTypes.ToList();
                var tr = (from a in am
                          join l in lic on a.AirmenType_Id equals l.code
                          where a.Code.Equals(Id)
                          select new TestReportStatusViewModel
                          {
                              Id = a.Code,
                              PEL = a.PEL,
                              Fullname = a.Description,
                              amType = a.AirmenType_Id,
                              License = l.description
                          }).FirstOrDefault();
                return View(tr);
            }
            else if (Loc == "VA")
            {
                var am = db_va.tblAirmen.ToList();
                var lic = db_mnl.tblAMTypes.ToList();
                var tr = (from a in am
                          join l in lic on a.AirmenType_Id equals l.code
                          where a.Code.Equals(Id)
                          select new TestReportStatusViewModel
                          {
                              Id = a.Code,
                              PEL = a.PEL,
                              Fullname = a.Description,
                              amType = a.AirmenType_Id,
                              License = l.description
                          }).FirstOrDefault();
                return View(tr);
            }
            else if (Loc == "MA")
            {
                var am = db_ma.tblAirmen.ToList();
                var lic = db_mnl.tblAMTypes.ToList();
                var tr = (from a in am
                          join l in lic on a.AirmenType_Id equals l.code
                          where a.Code.Equals(Id)
                          select new TestReportStatusViewModel
                          {
                              Id = a.Code,
                              PEL = a.PEL,
                              Fullname = a.Description,
                              amType = a.AirmenType_Id,
                              License = l.description
                          }).FirstOrDefault();
                return View(tr);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult Initial(TestReportStatusViewModel testReports)
        {
            var tr = new tblTestReportApplication
            {
                //Description = testReport.Fullname,
                
                PEL = testReports.PEL,
                amType = testReports.amType,
                Status = "Initial",
                Initial = testReports.Initial,
                iDate = DateTime.Now,
                Remarks = testReports.Remarks,
                LastModifiedBy = testReports.LastModifiedBy 
                
            };

           

            db_mnl.tblTestReportApplications.Add(tr);
            db_mnl.SaveChanges();
            
            return RedirectToAction("ViewApplications");
            


            
        }

        public ActionResult Control(int Id, string PEL)
        {
            var trList = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();
            var tr = (from a in db_mnl.getAirmen_all(PEL).ToList()
                      join l in lic on a.AirmenType equals l.code
                      join t in trList on a.PEL equals t.PEL
                      where t.Id.Equals(Id)
                      select new TestReportStatusViewModel
                      {
                          Id = t.Id,
                          PEL = t.PEL,
                          Fullname = a.Fullname,
                          amType = l.code,
                          License = l.description,
                          Remarks = t.Remarks

                      }).FirstOrDefault();
            return View(tr);
        }

        [HttpPost]
        public ActionResult Control(TestReportStatusViewModel testReports, int Id)
        {
            var tr = new tblTestReportApplication
            {
                //Description = testReport.Fullname,

               
                Status = "Controlled",
                ControlNo = testReports.ControllNo,
                ControlledBy = testReports.ControlledBy,
                cDate = DateTime.Now,
                Remarks = testReports.Remarks,
                LastModifiedBy = testReports.LastModifiedBy

            };

            tblTestReportApplication trToEdit = db_mnl.tblTestReportApplications.Find(Id);

            trToEdit.Status = tr.Status;
            trToEdit.ControlNo = tr.ControlNo;
            trToEdit.ControlledBy = tr.ControlledBy;
            trToEdit.cDate = tr.cDate;
            trToEdit.Remarks = tr.Remarks;
            trToEdit.LastModifiedBy = tr.LastModifiedBy;

            db_mnl.SaveChanges();

            return RedirectToAction("ViewApplications");

        }



    }
}
            
               
         
           

       
       


