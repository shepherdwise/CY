﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resign_Procedure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CYPCC_INFO_AEntities : DbContext
    {
        public CYPCC_INFO_AEntities()
            : base("name=CYPCC_INFO_AEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employ_Info> Employ_Info { get; set; }
        public virtual DbSet<History_Resign_Procedure> History_Resign_Procedure { get; set; }
        public virtual DbSet<Organization_Info> Organization_Info { get; set; }
        public virtual DbSet<Resign_Procedure_Detail> Resign_Procedure_Detail { get; set; }
        public virtual DbSet<Resign_Procedure_Header> Resign_Procedure_Header { get; set; }
        public virtual DbSet<UnderTaking_Info> UnderTaking_Info { get; set; }
    }
}
