using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Resign_Procedure.CYPCC_Tools.Debug;
using System.Reflection;

using Resign_Procedure.Models;

namespace Resign_Procedure.Controllers
{
    [Route("[controller]")]
    public class ResignApplyController : Controller
    {
        //// GET: ResignApply
        //public ActionResult Index(string employ_ID, string department_name)
        //{
        //    ModelState.Clear();

        //    ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

        //    // 讀取資料庫.
        //    viewModel.Resign_Employ_Info = GetEmployBaseInfo(employ_ID);
        //    viewModel.Orgznization_Infos = GetOrganizations();
        //    viewModel.Resing_Procedure_Header = GetResignHeader(employ_ID);

        //    //viewModel.Seniority = Get_On_The_Job_Seniority(viewModel);
        //    ViewBag.Seniority = Get_On_The_Job_Seniority(viewModel);


        //    int? organization_id = 0;
        //    if (null != viewModel.Resign_Employ_Info)
        //    {
        //        organization_id = viewModel.Resign_Employ_Info.Organized_ID;

        //        viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
        //    }

        //    if (null != department_name)
        //    {
        //        viewModel.Selected_Organization_Titles = GetTitleIDsByDepartment(department_name);
        //        viewModel.Resign_Employ_Organization.Department = department_name;
        //    }

        //    return View(viewModel);
        //}

        // GET: ResignApply
        public ActionResult Index()
        {
            ViewModel_Resign_Apply selected_model = (ViewModel_Resign_Apply)TempData["temp_model"];

            string employ_ID    = selected_model?.Resign_Employ_Info?.Employ_ID;
            string department_name = selected_model?.Resign_Employ_Organization?.Department;

            ModelState.Clear();

            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfo(employ_ID);
            viewModel.Orgznization_Infos = GetOrganizations();
            viewModel.Resing_Procedure_Header = GetResignHeader(employ_ID);

            if (null != selected_model
                && null != selected_model.Resing_Procedure_Header)
            {
                viewModel.Resing_Procedure_Header.Resign_Date = selected_model.Resing_Procedure_Header.Resign_Date;
            }

            //viewModel.Seniority = Get_On_The_Job_Seniority(viewModel);
            ViewBag.Seniority = Get_On_The_Job_Seniority(viewModel);


            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            if (null != department_name)
            {
                viewModel.Selected_Organization_Titles = GetTitleIDsByDepartment(department_name);
                viewModel.Resign_Employ_Organization.Department = department_name;
            }

            ViewBag.Err_Message = TempData["Err_Message"];
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(string employ_ID, string employ_name, string department_name)
        {
            ModelState.Clear();

            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();
            //viewModel.UnderTaking_Items = GetUnderTaking_Items();
            //viewModel.Resign_Procedure_Orders = GetResignProcedureOrders();

            //test
            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfo(employ_ID);
            viewModel.Orgznization_Infos = GetOrganizations();
            viewModel.Resing_Procedure_Header = GetResignHeader(employ_ID);

            //viewModel.Seniority = Get_On_The_Job_Seniority(viewModel);
            ViewBag.Seniority = Get_On_The_Job_Seniority(viewModel);

            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            if (null != department_name)
            {
                viewModel.Selected_Organization_Titles = GetTitleIDsByDepartment(department_name);
                viewModel.Resign_Employ_Organization.Department = department_name;
            }

            return View(viewModel);
        }

        // GET: ResignApply
        //public ActionResult SearchByName(string search_name, string department_name)
        //{
        //    ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

        //    // 讀取資料庫.
        //    viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(search_name);

        //    int? organization_id = 0;
        //    if (null != viewModel.Resign_Employ_Info)
        //    {
        //        organization_id = viewModel.Resign_Employ_Info.Organized_ID;

        //        viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
        //    }

        //    //return View(viewModel);
        //    return RedirectToAction("Index", new { employ_ID = viewModel.Resign_Employ_Info?.Employ_ID
        //                                        , department_name = department_name });
        //}

        [Route("[action]")]
        public ActionResult SearchByName(ViewModel_Resign_Apply selected_model)
        {
            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(selected_model.Resign_Employ_Info.Name);

            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            //return View(viewModel);
            TempData["temp_model"] = viewModel;
            return RedirectToAction("Index");
            //return RedirectToAction("Index", new
            //{
            //    employ_ID = viewModel.Resign_Employ_Info?.Employ_ID
            //    ,
            //    department_name = viewModel.Resign_Employ_Organization.Department
            //});
        }

        public ActionResult Refresh_Page(ViewModel_Resign_Apply selected_model)
        {
            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(selected_model.Resign_Employ_Info.Name);

            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            if (null == viewModel.Resign_Employ_Info.Organized_ID)
            {
                viewModel.Selected_Organization_Titles = GetTitleIDsByDepartment(selected_model.Resign_Employ_Organization.Department);
            }

            viewModel.Resing_Procedure_Header.Resign_Date = selected_model.Resing_Procedure_Header.Resign_Date;
            return View(viewModel);
            //return RedirectToAction("Index", new
            //{
            //    employ_ID = viewModel.Resign_Employ_Info?.Employ_ID
            //    , department_name = viewModel.Resign_Employ_Organization.Department
            //});
        }

        public ActionResult Refresh_Page_By_TempData()
        {
            ViewModel_Resign_Apply selected_model = (ViewModel_Resign_Apply)TempData["temp_model"];

            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(selected_model.Resign_Employ_Info.Name);

            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            if (null == viewModel.Resign_Employ_Info.Organized_ID)
            {
                viewModel.Selected_Organization_Titles = GetTitleIDsByDepartment(selected_model.Resign_Employ_Organization.Department);
            }

            viewModel.Resing_Procedure_Header = selected_model.Resing_Procedure_Header;
            return View(viewModel);
            //return RedirectToAction("Index", new
            //{
            //    employ_ID = viewModel.Resign_Employ_Info?.Employ_ID
            //    , department_name = viewModel.Resign_Employ_Organization.Department
            //});
        }


        // GET: ResignApply
        public ActionResult Department_Select_Change(string employ_name, string employ_id, string department_name)
        {
            //ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();
            ViewModel_Resign_Apply viewModel = _SearchByName(employ_name);

            if (null == viewModel.Resign_Employ_Info.Organized_ID
                || department_name.Length <= 0)
            {
                // 讀取資料庫 職務列表.
                viewModel.Selected_Organization_Titles = GetTitleIDsByDepartment(department_name);
            }

            return RedirectToAction("Index", new
            {
                employ_ID = viewModel.Resign_Employ_Info?.Employ_ID
                                            ,
                employ_name = employ_name
                                            ,
                department_name = department_name
            });
        }

        private ViewModel_Resign_Apply _SearchByName(string search_name)
        {
            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(search_name);

            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            return viewModel;
        }


        [HttpPost]

        public ActionResult Assign_Resign_Date(ViewModel_Resign_Apply selected_model)
        {
            ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

            // 讀取資料庫.
            viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(selected_model.Resign_Employ_Info.Name);
            viewModel.Orgznization_Infos = GetOrganizations();
            viewModel.Resing_Procedure_Header = GetResignHeader(viewModel.Resign_Employ_Info.Employ_ID);
            viewModel.Resing_Procedure_Header.Resign_Date = selected_model.Resing_Procedure_Header.Resign_Date;

            //viewModel.Seniority = Get_On_The_Job_Seniority(selected_model);
            ViewBag.Seniority = Get_On_The_Job_Seniority(selected_model);

            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
            {
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
            }

            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                Employ_Info exist_employ = dbResign_Procedures.Employ_Info.Find(viewModel.Resign_Employ_Info.Employ_ID);
                if (null == exist_employ)
                {
                    //string message = "data found for id: " + viewModel.Resign_Employ_Info.Name;
                    //return Content("<script language='javascript' type='text/javascript'>alert(message);</script>");

                    //============add record==============
                    Employ_Info new_employ = viewModel.Resign_Employ_Info;
                    new_employ.Onboard_Date = selected_model.Resign_Employ_Info.Onboard_Date;
                    new_employ.Create_Time = DateTime.Now;
                    new_employ.Edit_Time = DateTime.Now;
                    dbResign_Procedures.Employ_Info.Add(new_employ);
                    dbResign_Procedures.SaveChanges();
                    //============add record==============
                    //if (   null == exist_employ.Onboard_Date
                    //    || exist_employ.Onboard_Date <= DateTime.MinValue)
                    //{
                    //    //============add record==============
                    //    exist_employ.Onboard_Date = selected_model.Resign_Employ_Info.Onboard_Date;
                    //    dbResign_Procedures.SaveChanges();
                    //    //============add record==============
                    //}
                    //return View(selected_model);
                }
                else if (null == viewModel.Resign_Employ_Info.Onboard_Date)
                {
                    //string message = "data found for id: " + viewModel.Resign_Employ_Info.Name;
                    //return Content("<script language='javascript' type='text/javascript'>alert(message);</script>");

                    //return View(selected_model);

                    //============update record==============
                    exist_employ.Onboard_Date = selected_model.Resign_Employ_Info.Onboard_Date;
                    dbResign_Procedures.SaveChanges();
                    //============add record==============
                }
            }

            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                Resign_Procedure_Header exist_order = dbResign_Procedures.Resign_Procedure_Header.Find(viewModel.Resign_Employ_Info.ID);
                if (null != exist_order)
                {
                    string message = "resign header data found for id: " + viewModel.Resign_Employ_Info.Name;
                    //return Content("<script language='javascript' type='text/javascript'>alert(message);</script>");

                    TempData["temp_model"] = viewModel;
                    return RedirectToAction("Index");
                    //return RedirectToAction("Refresh_Page_By_TempData", "/ResignApply");
                    //return RedirectToAction("/ResignApply/Refresh_Page_By_TempData");
                    //return RedirectToAction("Index", new { Employ_ID = viewModel.Resign_Employ_Info?.Employ_ID });
                    //return View(selected_model);
                }

                //============add resign header record==============
                Resign_Procedure_Header new_order = new Resign_Procedure_Header();
                //new_order.ID = viewModel.Resign_Employ_Info.ID;
                new_order.E_ID = viewModel.Resign_Employ_Info.ID;
                new_order.Resign_Date = selected_model.Resing_Procedure_Header.Resign_Date;
                new_order.Create_Time = DateTime.Now;
                new_order.Edit_Time = DateTime.Now;
                dbResign_Procedures.Resign_Procedure_Header.Add(new_order);
                dbResign_Procedures.SaveChanges();
                //============add record==============
            }

            TempData["temp_model"] = viewModel;
            return RedirectToAction("Index");         
            //return View(viewModel);
            //return RedirectToAction("Index", new { Employ_ID = viewModel.Resign_Employ_Info?.Employ_ID });
        }

        private TimeSpan? Get_On_The_Job_Seniority(ViewModel_Resign_Apply selected_model)
        {
            TimeSpan? seniority = null;
            if (null == selected_model
                || null == selected_model.Resign_Employ_Info
                || null == selected_model.Resing_Procedure_Header)
            {
                return seniority;
            }

            if (selected_model.Resing_Procedure_Header.Resign_Date <= DateTime.MinValue)
            {
                return seniority;
            }

            if (selected_model.Resign_Employ_Info.Onboard_Date <= DateTime.MinValue)
            {
                return seniority;
            }

            if (selected_model.Resign_Employ_Info.Onboard_Date >= selected_model.Resing_Procedure_Header.Resign_Date)
            {
                return seniority;
            }

            TimeSpan day_1 = new TimeSpan(1, 0, 0, 0);
            seniority = selected_model.Resing_Procedure_Header.Resign_Date - selected_model.Resign_Employ_Info.Onboard_Date + day_1;
            return seniority;
        }

        [HttpPost]
        //public ActionResult Apply(ViewModel_Resign_Apply resign_apply )
        public ActionResult Apply(ViewModel_Resign_Apply selected_model)
        {
            try
            {
                ViewModel_Resign_Apply viewModel = new ViewModel_Resign_Apply();

                // 讀取資料庫.
                viewModel.Resign_Employ_Info = GetEmployBaseInfoByName(selected_model.Resign_Employ_Info.Name);

                int? organization_id = 0;
                if (null != viewModel.Resign_Employ_Info)
                {
                    organization_id = viewModel.Resign_Employ_Info.Organized_ID;

                    viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);
                }

                using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
                {
                    Resign_Procedure_Header exist_order = dbResign_Procedures.Resign_Procedure_Header.Find(viewModel.Resign_Employ_Info.ID);
                    if (null != exist_order)
                    {
                        string message = "data found for id: " + viewModel.Resign_Employ_Info.Name;
                        //return Content("<script language='javascript' type='text/javascript'>alert(message);</script>");

                        TempData["temp_model"] = selected_model;
                        return RedirectToAction("Index");
                        //return View(selected_model);
                    }

                    if (viewModel.Resign_Employ_Info.ID > 0)
                    {
                        using (var ts = dbResign_Procedures.Database.BeginTransaction())
                        {
                            //============add header record==============
                            Resign_Procedure_Header new_order = new Resign_Procedure_Header();
                            new_order.ID    = viewModel.Resign_Employ_Info.ID;
                            new_order.E_ID  = viewModel.Resign_Employ_Info.ID;

                            // from selected_model not view.
                            new_order.Resign_Date = selected_model.Resing_Procedure_Header.Resign_Date;
                            new_order.Create_Time = DateTime.Now;
                            new_order.Edit_Time = DateTime.Now;

                            dbResign_Procedures.Resign_Procedure_Header.Add(new_order);
                            dbResign_Procedures.SaveChanges();
                            //============add header record==============

                            foreach (var undertaking_item in dbResign_Procedures.UnderTaking_Info)
                            {
                                Resign_Procedure_Detail new_detail = new Resign_Procedure_Detail();
                                new_detail.E_ID = viewModel.Resign_Employ_Info.ID;
                                new_detail.UnderTaking_ID = undertaking_item.ID;
                                new_detail.Create_Time = DateTime.Now;
                                dbResign_Procedures.Resign_Procedure_Detail.Add(new_detail);
                                dbResign_Procedures.SaveChanges();
                            }

                            ts.Commit();
                        }
                    }
                }

                TempData["temp_model"] = selected_model;
                return RedirectToAction("Index");

                //return View(viewModel);
                //return RedirectToAction("Index", new { Employ_ID = viewModel.Resign_Employ_Info?.Employ_ID, department_name = selected_model.Resign_Employ_Organization.Department });
            }
            //catch (System.Data.DataException dex)
            //{
            //    var excption_type = dex.InnerException.GetType();
            //    if (excption_type == typeof(UpdateException))
            //    {
            //        UpdateException update_ex = (UpdateException)dex.InnerException;

            //        if (update_ex.InnerException.GetType() == typeof(SqlException))
            //        {
            //            SqlException sql_error = (SqlException)update_ex.InnerException;
            //            string test = "sql inner:" + sql_error.Message + ", hresult:" + string.Format("{0:x}", sql_error.HResult);


            //        }
            //    }
            //}
            catch (Exception ex)
            {
                //  例外狀況處理
                TempData["Err_Message"] = MethodBase.GetCurrentMethod().DeclaringType.Name    // class name
                                 + ":" + MethodBase.GetCurrentMethod().Name                  // function name
                                 + "->" + ExceptionHandler.Get_Exception_Message(ex);        // error message

            }
            TempData["temp_model"] = selected_model;
            return RedirectToAction("Index");
        }

        private List<UnderTaking_Info> GetUnderTaking_Items()
        {
            List<UnderTaking_Info> underTaking_Items = new List<UnderTaking_Info>();

            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                foreach (UnderTaking_Info underTakingItem in dbResign_Procedures.UnderTaking_Info)
                {
                    UnderTaking_Info newUnderTakingItem = new UnderTaking_Info();
                    newUnderTakingItem.UnderTaking_Organization = underTakingItem.UnderTaking_Organization;
                    newUnderTakingItem.UnderTaking_Description = underTakingItem.UnderTaking_Description;
                    underTaking_Items.Add(newUnderTakingItem);
                }
            }

            return underTaking_Items;
        }

        private List<Resign_Procedure_Header> GetResignProcedureOrders()
        {
            List<Resign_Procedure_Header> resignProcedureOrders = new List<Resign_Procedure_Header>();
            //teachers.Add(new Teacher { TeacherId = 1, Code = "TT", Name = "Tejas Trivedi" });
            //teachers.Add(new Teacher { TeacherId = 2, Code = "JT", Name = "Jignesh Trivedi" });
            //teachers.Add(new Teacher { TeacherId = 3, Code = "RT", Name = "Rakesh Trivedi" });
            return resignProcedureOrders;
        }

        private Employ_Info GetEmployBaseInfo(string e_id)
        {
            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                var selected_employs = from base_info in dbResign_Procedures.Employ_Info
                                       where base_info.Employ_ID == e_id
                                       select new
                                       {
                                           base_info
                                           //base_info.Employ_ID = base_info.Employ_ID.Trim()
                                       }; //.FirstOrDefault();

                Employ_Info selected_employ_info = new Employ_Info();
                foreach (var selected_rec in selected_employs)
                {
                    selected_employ_info = selected_rec.base_info;
                }
                return selected_employ_info;
            }
        }

        private Employ_Info GetEmployBaseInfoByName(string employ_name)
        {
            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                var selected_employs = from base_info in dbResign_Procedures.Employ_Info
                                       where base_info.Name == employ_name
                                       select new
                                       {
                                           base_info
                                           //base_info.Employ_ID = base_info.Employ_ID.Trim()
                                       }; //.FirstOrDefault();

                Employ_Info selected_employ_info = new Employ_Info();
                foreach (var selected_rec in selected_employs)
                {
                    selected_employ_info = selected_rec.base_info;
                }
                return selected_employ_info;
            }
        }


        private List<Organization_Info> GetTitleIDsByDepartment(string department_name)
        {
            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                List<Organization_Info> selected_titles = new List<Organization_Info>();

                var selected_organiztion_records = from organizations in dbResign_Procedures.Organization_Info
                                                   where organizations.Department == department_name
                                                   select new
                                                   {
                                                       organizations
                                                       //base_info.Employ_ID = base_info.Employ_ID.Trim()
                                                   }; //.FirstOrDefault();

                foreach (var selected_rec in selected_organiztion_records)
                {
                    Organization_Info newOrganization = new Organization_Info();
                    newOrganization = selected_rec.organizations;
                    selected_titles.Add(newOrganization);
                }
                return selected_titles;
            }
        }

        private Resign_Procedure_Header GetResignHeader(string e_id)
        {
            try
            {
                if (null == e_id || e_id.Length <= 0)
                {
                    return null;
                }

                using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
                {
                    var selected_headers = from resign_header in dbResign_Procedures.Resign_Procedure_Header
                                           from employ_info in dbResign_Procedures.Employ_Info

                                           where employ_info.ID == resign_header.E_ID
                                               && e_id == employ_info.Employ_ID
                                           select new
                                           {
                                               resign_header
                                               //base_info.Employ_ID = base_info.Employ_ID.Trim()
                                           }; //.FirstOrDefault();

                    Resign_Procedure_Header selected_resign_procedure_header = new Resign_Procedure_Header();
                    foreach (var selected_rec in selected_headers)
                    {
                        selected_resign_procedure_header = selected_rec.resign_header;
                    }

                    return selected_resign_procedure_header;
                }
            }
            catch (Exception ex)
            {
                //  例外狀況處理
                string test = "Exception occurred when checking the GetResignHeader method:" + ex.Message;
            }

            return null;
        }

        private List<Organization_Info> GetOrganizations()
        {
            List<Organization_Info> organizations = new List<Organization_Info>();

            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                foreach (Organization_Info organization in dbResign_Procedures.Organization_Info)
                {
                    Organization_Info newOrganization = new Organization_Info();
                    newOrganization = organization;
                    organizations.Add(newOrganization);
                }
            }
            return organizations;
        }

        private Organization_Info GetOrganization(int? organization_id = 0)
        {
            using (CYPCC_INFO_AEntities dbResign_Procedures = new CYPCC_INFO_AEntities())
            {
                var selected_organizations = from organizations in dbResign_Procedures.Organization_Info
                                             where organizations.ID == organization_id
                                             select new
                                             {
                                                 organizations
                                                 //base_info.Employ_ID = base_info.Employ_ID.Trim()
                                             }; //.FirstOrDefault();

                Organization_Info selected_organization_info = new Organization_Info();
                foreach (var selected_rec in selected_organizations)
                {
                    selected_organization_info = selected_rec.organizations;
                }
                return selected_organization_info;
            }
        }
    }
}