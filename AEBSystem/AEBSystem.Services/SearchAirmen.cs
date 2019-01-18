using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEBSystem.Core.Models;
using AEBSystem.Core.ViewModels;

namespace AEBSystem.Services
{

    public class SearchAirmen
    {
        CAAPDATA_MNL_DbSet1 db_mnl = new CAAPDATA_MNL_DbSet1();
        CAAPDATA_NLA_DbSet db_nla = new CAAPDATA_NLA_DbSet();
        
        public void Search(string search, string dbLists)
        {

            //var airmen = dbToUse.tblAirman.Where(x => x.PEL.Contains(search) || x.Description.Contains(search)).OrderByDescending(x => x.Code).ToList();
            ////var airmen = db.db.Where(x => x.PEL == search).OrderByDescending(x => x.Code).ToList();
            //var nationality = dbToUse.tblNationalities.ToList();
            //var airmentype = dbToUse.tblAMTypes.ToList();
            //var AirmenList = (from a in airmen
            //                  join n in nationality on a.Nationality_Id equals n.Code
            //                  join am in airmentype on a.AirmenType_Id equals am.code
            //                  select new AirmenViewModel
            //                  {
            //                      Code = a.Code,
            //                      PEL = a.PEL,
            //                      Fullname = a.Description,
            //                      LicenseTypeId = Convert.ToUInt16(a.AirmenType_Id),
            //                      LicenseType = am.description,
            //                      Address = a.Address,
            //                      Contact = a.Contact_no,
            //                      Sex = a.Sex,
            //                      DateofBirth = a.Date_Birth.Value.ToString("d"),
            //                      NationalityId = Convert.ToInt16(a.Nationality_Id),
            //                      Nationality = n.Description,
            //                      DegreeCourse = a.DegreeCourse
            //                  }
            //                  ).ToList().Take(20);

            //return AirmenList;


        }

    }

    
}
