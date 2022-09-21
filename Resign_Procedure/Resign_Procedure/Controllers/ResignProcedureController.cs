using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Resign_Procedure.Models;

namespace Resign_Procedure.Controllers
{
    public class ResignProcedureController : Controller
    {
        // GET: ResignProcedure
        public ActionResult Index(string Employ_ID)
        {
            ViewModel_Resign_Procedure_Items viewModel = new ViewModel_Resign_Procedure_Items(Employ_ID);
            viewModel.UnderTaking_Items = GetUnderTaking_Items();
            viewModel.Resign_Procedure_Headers = GetResignProcedureOrders();
            viewModel.Resign_Employ_Info = GetEmployBaseInfo(Employ_ID);
            int? organization_id = 0;
            if (null != viewModel.Resign_Employ_Info)
                organization_id = viewModel.Resign_Employ_Info.Organized_ID;

            viewModel.Resign_Employ_Organization = GetOrganization(viewModel.Resign_Employ_Info.Organized_ID);

            return View(viewModel);
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
                foreach(var selected_rec in selected_employs)
                {
                    selected_employ_info = selected_rec.base_info;
                }
                return selected_employ_info;
            }
        }

        private Organization_Info GetOrganization(int? organization_id =  0)
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

        Find_Resign_Employ
        public ActionResult Index(string Employ_ID)
    }
}