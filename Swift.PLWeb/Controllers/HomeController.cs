using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Swift.Common;
using Swift.DAL;

namespace Swift.PLWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult Login(string EmpName, string Password)
        {            
            try
            {
                AppLib.WriteLog("Login_Start");

                var db = new DemoEntities();
                var qry = from am in db.AccountMs
                          join amp in db.AccountMPasswords on am.UID equals amp.AccountM_UID
                          select new { am.UID, am.AccountCode};

                var d = qry.FirstOrDefault();
                if (d == null)
                {
                    var r = Json(new { IsLogin = false, ErrMsg = "Invalid User" }, JsonRequestBehavior.AllowGet);
                    AppLib.WriteLog("Login_Failed");
                    return r;
                }
                else
                {
                    var r = Json(new { IsLogin = true,EmpCode=d.AccountCode, ErrMsg = "" }, JsonRequestBehavior.AllowGet);
                    AppLib.WriteLog("Login_End");
                    return r;
                }                
            }
            catch(Exception ex)
            {
                AppLib.WriteLog(ex);
                var r = Json(new { IsLogin = false, ErrMsg = "Invalid User" }, JsonRequestBehavior.AllowGet);
                return r;
            }            
        }
    }
}