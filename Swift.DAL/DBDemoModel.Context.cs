﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Swift.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DemoEntities : DbContext
    {
        public DemoEntities()
            : base("name=DemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountM> AccountMs { get; set; }
        public virtual DbSet<AccountMPassword> AccountMPasswords { get; set; }
        public virtual DbSet<ViewCustomerDetail> ViewCustomerDetails { get; set; }
    
        public virtual ObjectResult<SP_CustomerwiseProductList_Result> SP_CustomerwiseProductList(Nullable<decimal> custUId)
        {
            var custUIdParameter = custUId.HasValue ?
                new ObjectParameter("CustUId", custUId) :
                new ObjectParameter("CustUId", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_CustomerwiseProductList_Result>("SP_CustomerwiseProductList", custUIdParameter);
        }
    }
}
