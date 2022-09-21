using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resign_Procedure.Models
{
    public class ViewModel_Resign_Procedure_Items
    {
        public ViewModel_Resign_Procedure_Items(string Employ_ID)
        {
            UnderTaking_Items = new List<UnderTaking_Info>();
            Resign_Procedure_Headers = new List<Resign_Procedure_Header>();
        }

        public List<UnderTaking_Info> UnderTaking_Items { get; set; }
        public List<Resign_Procedure_Header> Resign_Procedure_Headers { get; set; }

        // 指定 Employ_ID 的基本資料.
        public Employ_Info Resign_Employ_Info { get; set; }

        public Organization_Info Resign_Employ_Organization { get; set; }
    }
}