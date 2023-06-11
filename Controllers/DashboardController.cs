using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HMS_Project.Models;

namespace HMS_Project.Controllers
{
    public class DashboardController : Controller
    {

        // GET: Dashboard
        public DBHMSEntities db = new DBHMSEntities();
        public ActionResult Index()
        {
            var tBLRooms = db.TBLRooms.Include(t => t.TBLCategory);
            return View(tBLRooms.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLUser login, string ReturnUrl)
        {
            
            if (isvalid(login) == true)
            {
                FormsAuthentication.SetAuthCookie(login.User_Name, false);
                Session["UserName"] = login.User_Name.ToString();
                if (ReturnUrl != null)
                {
                    return View(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                return View();
            }
        }
        public bool isvalid(TBLUser login)
        {
            var verify = db.TBLUsers.Where(TBLUser => TBLUser.User_Name == login.User_Name && TBLUser.User_Password == login.User_Password).FirstOrDefault();
            return (login.User_Name == verify.User_Name && login.User_Password == verify.User_Password);
        }
    }
}