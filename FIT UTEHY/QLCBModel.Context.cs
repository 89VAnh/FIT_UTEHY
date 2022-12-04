﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT_UTEHY
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLCBEntities : DbContext
    {
        public QLCBEntities()
            : base("name=QLCBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<NghiHuu> NghiHuus { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TrinhDo> TrinhDoes { get; set; }
        public virtual DbSet<CanBo> CanBoes { get; set; }
    
        public virtual ObjectResult<GetCanBoByMaBM_Result> GetCanBoByMaBM(Nullable<short> maBM)
        {
            var maBMParameter = maBM.HasValue ?
                new ObjectParameter("MaBM", maBM) :
                new ObjectParameter("MaBM", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCanBoByMaBM_Result>("GetCanBoByMaBM", maBMParameter);
        }
    
        public virtual ObjectResult<GetNghiHuuByMaBM_Result> GetNghiHuuByMaBM(Nullable<short> maBM)
        {
            var maBMParameter = maBM.HasValue ?
                new ObjectParameter("MaBM", maBM) :
                new ObjectParameter("MaBM", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetNghiHuuByMaBM_Result>("GetNghiHuuByMaBM", maBMParameter);
        }
    }
}
