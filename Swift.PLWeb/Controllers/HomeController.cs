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
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }

        public JsonResult CustomerList()
        {
            var db = new DemoEntities();
            var lst = db.ViewCustomerDetails.Select(x => new { x.UID, x.AccountName, x.AccountCode });
            var r = Json(lst,JsonRequestBehavior.AllowGet);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }

        public JsonResult CustomerProductList(decimal UID)
        {
            var db = new DemoEntities();
            var lst = db.SP_CustomerwiseProductList(UID).ToList();
            var r = Json(lst, JsonRequestBehavior.AllowGet);
            r.MaxJsonLength = int.MaxValue;
            return r;
        }

        public ActionResult CustomerOrder(decimal UID)
        {
            var db = new DemoEntities();            
            var cust = db.ViewCustomerDetails.Where(x => x.UID == UID).FirstOrDefault();
            return View(cust);
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult EmpLogin(string EmpName, string Password)
        {            
            try
            {
                AppLib.WriteLog("Login_Start");

                var db = new DemoEntities();
                var qry = from am in db.AccountMs
                          join amp in db.AccountMPasswords on am.UID equals amp.AccountM_UID
                          where am.AccountTypeID==800 && am.AccountName==EmpName && amp.Password==Password
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