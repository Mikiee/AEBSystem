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


namespace AEBSystem.WebUI.Controllers
{
    public class TRTrackingController : Controller
    {

        // GET: TRTracking
        CAAPDATA_MNL_DbSet db_mnl = new CAAPDATA_MNL_DbSet();
        CAAPDATA_NLA_DbSet db_nla = new CAAPDATA_NLA_DbSet();
        CAAPDATA_MA_DbSet db_ma = new CAAPDATA_MA_DbSet();

        MockUser user = new MockUser();

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

        public ActionResult AddApp(int Id, string Loc)
        {           
            if (Loc == "MNL")
            {
                tblAirman am = db_mnl.tblAirmen.Find(Id);
                AirmenDropdownViewModel amView = new AirmenDropdownViewModel();
                amView.Airmen = am;
                amView.LicenseTypeList = db_mnl.tblAMTypes.ToList();
                if (am != null)
                {
                    return View(am);
                }
                {
                    return HttpNotFound();
                }
            }
            else if(Loc == "NLA")
            {
                tblAirman am = db_nla.tblAirmen.Find(Id);
                AirmenDropdownViewModel amView = new AirmenDropdownViewModel();
                amView.Airmen = am;
                amView.LicenseTypeList = db_nla.tblAMTypes.ToList();
                if (am != null)
                {
                    return View(am);
                }
                {
                    return HttpNotFound();
                }
            }
            else if (Loc == "MA")
            {
                tblAirman am = db_ma.tblAirmen.Find(Id);
                AirmenDropdownViewModel amView = new AirmenDropdownViewModel();
                amView.Airmen = am;
                amView.LicenseTypeList = db_ma.tblAMTypes.ToList();
                if (am != null)
                {
                    return View(am);
                }
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
            
        }

       
        public ActionResult Initial(string PEL, int amType)
        {
            db_mnl.trInitial(PEL, amType, "maabulag", DateTime.Now, "Test Remarks");
            return RedirectToAction("ViewApplications");
        }

        public ActionResult ViewApplications(string search)
        {
            var tr = db_mnl.tblTestReportApplications.Where(s => s.PEL.Contains(search) || s.ControlNo.Contains(search)).ToList(); ;
            var am = db_mnl.getAirmen_all(search);
           
            var lic = db_mnl.tblAMTypes.ToList();

            var viewModel = (from t in tr
                             join a in am on t.PEL equals a.PEL
                             join l in lic on t.amType equals l.code
                             select new TestReportStatusViewModel
                             {
                                 Id = t.Id,
                                 PEL = t.PEL,
                                 Fullname = a.Fullname,
                                 License = l.description,
                                 Status = t.Status,
                                 LastModifiedBy = t.LastModifiedBy

                             }
                             ).ToList().Take(30);
            return View(viewModel);
        }




    }
}