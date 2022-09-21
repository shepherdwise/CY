using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Resign_Procedure.Models;

namespace Resign_Procedure.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Employ_Info home_model = (Employ_Info)TempData["temp_model"];
            if (null == home_model)
            {
                return View();
            }

            ViewBag.ErrorMessage = null;
            if (   home_model.Name.Length <= 0
                || null == home_model.Pwd)
            {
                return View();
            }

            if (IsLoginOK(home_model.Name, home_model.Pwd))
            {
                // enter main form.
                return RedirectToAction("Index", "ResignApply");
            }

            ViewBag.ErrorMessage = "登入帳號或密碼錯誤";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //// GET: ResignApply
        public ActionResult Login(Employ_Info home_model)
        {
            TempData["temp_model"] = home_model;

            ViewBag.Message = "Your contact page.";

            return RedirectToAction("Index");
        }

        private bool IsLoginOK(string user_name, string password)
        {
            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                var selected_records = from base_info in dbResign_Procedures.Employ_Info
                                       where base_info.Name == user_name
                                          && base_info.Pwd == password
                                       select new
                                       {
                                           base_info
                                           //base_info.Employ_ID = base_info.Employ_ID.Trim()
                                       }; //.FirstOrDefault();

                int selected_record_num = selected_records.Count();
                if (selected_records.Count() <= 0)
                    return false;

                return true;
            }
        }
    }
}