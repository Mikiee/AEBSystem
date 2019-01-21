using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AEBSystem.Core.Models;
using CrystalDecisions.CrystalReports.Engine;


namespace AEBSystem.WebUI.Controllers
{
    public class TRTrackingController : Controller
    {

        // GET: TRTracking
        CAAPDATA_MNL_DbSet db_mnl = new CAAPDATA_MNL_DbSet();
        CAAPDATA_NLA_DbSet db_nla = new CAAPDATA_NLA_DbSet();

       

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


    }
}