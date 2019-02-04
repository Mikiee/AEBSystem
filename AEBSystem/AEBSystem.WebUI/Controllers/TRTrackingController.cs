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

       


        public TRTrackingController()
        {
            tblUser Users = new tblUser();
            if (Users == null)
            {
                 RedirectToAction("Index", "Login");
            }
        }

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
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ExamHistory.rpt"));

            rd.SetDataSource(history);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", PEL + "_" + amType + "_History.pdf");
        }

        public ActionResult ViewApplications(string search)
        {
            var am = db_mnl.getAirmen_all(search).ToList();
            var tr = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();

            var viewModel = (from t in tr
                             join a in am on t.PEL equals a.PEL
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
                                 ClaimedBy = t.ClaimedBy,
                                 ControlNo = t.ControlNo,
                                 BatchNo = t.BatchNo,
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
            var username = Session["Username"].ToString();
            var tr = new tblTestReportApplication
            {
                //Description = testReport.Fullname,

                PEL = testReports.PEL,
                amType = testReports.amType,
                Status = "Initial",
                Initial = username,
                iDate = DateTime.Now,
                Remarks = testReports.Remarks,
                LastModifiedBy = username,

                //set date for NOT NULL datetime fields
                cDate = DateTime.Now,
                rDate = DateTime.Now,
                pDate = DateTime.Now,
                Received = DateTime.Now


            };



            db_mnl.tblTestReportApplications.Add(tr);
            db_mnl.SaveChanges();

            return RedirectToAction("ViewApplications");




        }

        public ActionResult Control(int Id, string PEL)
        {
            var am = db_mnl.getAirmen_all(PEL).ToList();
            var trList = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();
            var tr = (from t in trList
                      join l in lic on t.amType equals l.code
                      join a in am on t.PEL equals a.PEL
                      where t.Id.Equals(Id)
                      select new TestReportStatusViewModel
                      {
                          Id = t.Id,
                          PEL = t.PEL,
                          Fullname = a.Fullname,
                          amType = t.amType,
                          License = l.description,
                          Remarks = t.Remarks

                      }).FirstOrDefault();
            return View(tr);
        }

        [HttpPost]
        public ActionResult Control(TestReportStatusViewModel testReports, int Id)
        {
            var username = Session["Username"].ToString();
            var tr = new tblTestReportApplication
            {
                //Description = testReport.Fullname,
                Status = "Controlled",
                BatchNo = testReports.BatchNo,
                ControlNo = testReports.ControlNo,
                ControlledBy = username,
                cDate = DateTime.Now,
                Remarks = testReports.Remarks,
                LastModifiedBy = username,

            };


            tblTestReportApplication trToEdit = db_mnl.tblTestReportApplications.Find(Id);

            trToEdit.Status = tr.Status;
            trToEdit.ControlNo = tr.ControlNo;
            trToEdit.ControlledBy = tr.ControlledBy;
            trToEdit.BatchNo = tr.BatchNo;
            trToEdit.cDate = tr.cDate;
            trToEdit.Remarks = tr.Remarks;
            trToEdit.LastModifiedBy = tr.LastModifiedBy;

            if (trToEdit.BatchNo == null && trToEdit.ControlNo == null)
            {
                return View();
            }
            db_mnl.SaveChanges();
            return RedirectToAction("ViewApplications");
        }


        public ActionResult TestReportStatusFullView(int Id, string PEL)
        {
            var am = db_mnl.getAirmen_all(PEL).ToList();
            var trList = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();
            var tr = (from t in trList
                      join l in lic on t.amType equals l.code
                      join a in am on t.PEL equals a.PEL
                      where t.Id.Equals(Id)
                      select new TestReportStatusViewModel
                      {
                          Id = t.Id,
                          PEL = t.PEL,
                          Fullname = a.Fullname,
                          amType = t.amType,
                          License = l.description,
                          Status = t.Status,
                          Remarks = t.Remarks,
                          Initial = t.Initial,
                          iDate = t.iDate,
                          ControlNo = t.ControlNo,
                          ControlledBy = t.ControlledBy,
                          BatchNo = t.BatchNo,
                          cDate = t.cDate,
                          pDate = t.pDate,
                          Recieved = t.Received,
                          ReleasedBy = t.ReleasedBy,
                          rDate = t.rDate,
                          ClaimedBy = t.ClaimedBy,
                          LastModifiedBy = t.LastModifiedBy
                          
                      }).FirstOrDefault();
            return View(tr);
        }

        public ActionResult Pending(int Id, string PEL)
        {           
            var am = db_mnl.getAirmen_all(PEL).ToList();
            var trList = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();
            var tr = (from t in trList
                      join l in lic on t.amType equals l.code
                      join a in am on t.PEL equals a.PEL
                      where t.Id.Equals(Id)
                      select new TestReportStatusViewModel
                      {
                          Id = t.Id,
                          PEL = t.PEL,
                          Fullname = a.Fullname,
                          amType = t.amType,
                          License = l.description,
                          Remarks = t.Remarks
                      }).FirstOrDefault();
            return View(tr);
        }

        [HttpPost]
        public ActionResult Pending(TestReportStatusViewModel testReports, int Id)
        {
            var username = Session["Username"].ToString();
            var tr = new tblTestReportApplication
            {
                //Description = testReport.Fullname,


                Status = "Pending",
                pDate = DateTime.Now,
                LastModifiedBy = testReports.LastModifiedBy,
               

            };

            tblTestReportApplication trToEdit = db_mnl.tblTestReportApplications.Find(Id);

            trToEdit.Status = tr.Status;           
            trToEdit.LastModifiedBy = username;

            db_mnl.SaveChanges();

            return RedirectToAction("ViewApplications");
        }

        public ActionResult BatchProcess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BatchProcess(string BatchNo, string Status)
        {
            var username = Session["Username"].ToString();

            if (Status == "Pending")
            { 
                //tag batch as Pending for Signature
                db_mnl.trTagAsPending(Status, BatchNo, username, DateTime.Now);
            }
            else
            {
                //tag batch as Recieved
                db_mnl.trTagAsRecieved(Status, BatchNo, username, DateTime.Now);
            }

            
            return RedirectToAction("ViewApplications");
        }

        public ActionResult Release(int Id, string PEL)
        {
            var am = db_mnl.getAirmen_all(PEL).ToList();
            var trList = db_mnl.tblTestReportApplications.ToList();
            var lic = db_mnl.tblAMTypes.ToList();
            var tr = (from t in trList
                      join l in lic on t.amType equals l.code
                      join a in am on t.PEL equals a.PEL
                      where t.Id.Equals(Id)
                      select new TestReportStatusViewModel
                      {
                          Id = t.Id,
                          PEL = t.PEL,
                          Fullname = a.Fullname,
                          amType = t.amType,
                          License = l.description,
                          ControlNo = t.ControlNo,
                          Remarks = t.Remarks

                      }).FirstOrDefault();
            return View(tr);
        }

        [HttpPost]
        public ActionResult Release(TestReportStatusViewModel testReports, int Id)
        {
            var username = Session["Username"].ToString();
            var tr = new tblTestReportApplication
            {
                //Description = testReport.Fullname,
                Status = "Released",
                ReleasedBy = testReports.ReleasedBy,
                ClaimedBy = testReports.ClaimedBy,
                Remarks = testReports.Remarks,
                LastModifiedBy = testReports.LastModifiedBy,

            };

            tblTestReportApplication trToEdit = db_mnl.tblTestReportApplications.Find(Id);

            trToEdit.Status = tr.Status;
            trToEdit.ReleasedBy = username;
            trToEdit.rDate = DateTime.Now;
            trToEdit.ClaimedBy = tr.ClaimedBy;
            trToEdit.Remarks = tr.Remarks;
            trToEdit.LastModifiedBy = username;

            if (trToEdit.ClaimedBy == null)
            {
                return View();
            }



            db_mnl.SaveChanges();
            return RedirectToAction("ViewApplications");

        }
    }
}
            
               
         
           

       
       


