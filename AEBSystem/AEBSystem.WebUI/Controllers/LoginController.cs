using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AEBSystem.Core.Models;
using AEBSystem.Core.ViewModels;
using AEBSystem.Services;
using AEBSystem.Core.Interface;

namespace AEBSystem.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        CAAPDATA_MNL_DbSet db_mnl = new CAAPDATA_MNL_DbSet();  
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblUser Users)
        {
            string User = Users.Username;
            string Pass = Users.Password;
            var user = db_mnl.tblUsers.ToList();
            var userlogin = (from u in user
                             where u.Username.Equals(User) && u.Password.Equals(Pass)
                             select new tblUser
                             {
                                 Fullname = u.Fullname,
                                 Username = u.Username,
                                 Role = u.Role,
                                 Position = u.Position,
                             }
                             ).FirstOrDefault();

            if (userlogin == null)
            {
                return View();
            }
            SaveUserLoginDetails.SaveUserDetails(userlogin.Fullname, userlogin.Role, userlogin.Position);
            HttpContext.Session["Username"] = User;
            HttpContext.Session["Fullname"] = userlogin.Fullname;
            HttpContext.Session["Role"] = userlogin.Role;
            return RedirectToAction("Index", "Dashboard");


        }
    }
}