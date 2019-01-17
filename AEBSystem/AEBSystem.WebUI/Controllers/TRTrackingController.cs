using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AEBSystem.Core.Models;
using AEBSystem.Core.ViewModels;
using AEBSystem.DataAccess.InMemory;



namespace AEBSystem.WebUI.Controllers
{
    public class TRTrackingController : Controller
    {
        CAAPDATA_NLA_DbSet db = new CAAPDATA_NLA_DbSet();
        // GET: TRTracking

       
        public ActionResult Index(string search)
        {
            var airmen = db.tblAirmen.Where(x => x.PEL.Contains(search) ||  x.Description.Contains(search)).OrderByDescending(x => x.Code).ToList();
            //var airmen = db.tblAirmen.Where(x => x.PEL == search).OrderByDescending(x => x.Code).ToList();
            var nationality = db.tblNationalities.ToList();
            var airmentype = db.tblAMTypes.ToList();
            var AirmenList = (from a in airmen
                              join n in nationality on a.Nationality_Id equals n.Code
                              join am in airmentype on a.AirmenType_Id equals am.code
                              select new AirmenViewModel
                              {
                                  Code = a.Code,
                                  PEL = a.PEL,
                                  Fullname = a.Description,
                                  LicenseTypeId = Convert.ToUInt16(a.AirmenType_Id),
                                  LicenseType = am.description,
                                  Address = a.Address,
                                  Contact = a.Contact_no,
                                  Sex = a.Sex,
                                  DateofBirth = a.Date_Birth.Value.ToString("d"),
                                  NationalityId = Convert.ToInt16(a.Nationality_Id),
                                  Nationality = n.Description,
                                  DegreeCourse = a.DegreeCourse
                              }
                              ).ToList().Take(20);

            

            return View(AirmenList);
        }

       


    }
}