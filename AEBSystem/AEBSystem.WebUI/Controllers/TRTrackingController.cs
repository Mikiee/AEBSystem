using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AEBSystem.Core.Models;
using AEBSystem.Core.ViewModels;
using AEBSystem.DataAccess.InMemory;
using static AEBSystem.Core.Models.LinqGrouping;

namespace AEBSystem.WebUI.Controllers
{
    public class TRTrackingController : Controller
    {
      
        // GET: TRTracking
        CAAPDATA_MNL_DbSet1 db_mnl = new CAAPDATA_MNL_DbSet1();
        CAAPDATA_NLA_DbSet db_nla = new CAAPDATA_NLA_DbSet();

       

        public ActionResult Index(string search)
        {
            var AirmenFromSP = db_mnl.getAirmen_all(search).ToList();
            return View(AirmenFromSP);           
          
           
        }    
       
        public ActionResult Details(string PEL, int amType)
        {
            List<ExamHistoryResults> history = db_mnl.ExamHistory(PEL, amType).ToList();
            List<tblLicType2> subject = db_mnl.tblLicType2.ToList();


            new HistoryViewModel().History = history;
            new HistoryViewModel().Subject = subject;
            return View(new HistoryViewModel());
        }


    }
}