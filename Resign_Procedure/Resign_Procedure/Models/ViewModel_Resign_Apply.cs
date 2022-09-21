using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resign_Procedure.Models
{
    public class ViewModel_Resign_Apply
    {
        public ViewModel_Resign_Apply()
        {
            Orgznization_Infos = new List<Organization_Info>();
            Selected_Organization_Titles = new List<Organization_Info>();

            Resign_Employ_Info = new Employ_Info();
            Resign_Employ_Organization = new Organization_Info();
        }

        public ViewModel_Resign_Apply(ViewModel_Resign_Apply src_vm_resign_apply)
        {
            Orgznization_Infos = new List<Organization_Info>();
            Selected_Organization_Titles = new List<Organization_Info>();

            Resign_Employ_Info = new Employ_Info();
            Resign_Employ_Organization = new Organization_Info();

            Orgznization_Infos = src_vm_resign_apply.Orgznization_Infos;
            Selected_Organization_Titles = src_vm_resign_apply.Selected_Organization_Titles;

            Resign_Employ_Info = src_vm_resign_apply.Resign_Employ_Info;
            Resign_Employ_Organization = src_vm_resign_apply.Resign_Employ_Organization;

            Resing_Procedure_Header = src_vm_resign_apply.Resing_Procedure_Header;
            Test_Name = src_vm_resign_apply.Test_Name;
        }

        public List<Organization_Info> Selected_Organization_Titles { get; set; }

        public List<Organization_Info> Orgznization_Infos { get; set; }


        // 已存在的 Employ_ID 的基本資料.
        public Employ_Info Resign_Employ_Info { get; set; }

        public Organization_Info Resign_Employ_Organization { get; set; }


        public Resign_Procedure_Header Resing_Procedure_Header { get; set; }

        //在職年資
        //public TimeSpan? Seniority { get; set; }

        public string Test_Name { get; set; }
    }
}