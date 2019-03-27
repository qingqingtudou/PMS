using Microsoft.EntityFrameworkCore;
using PMS.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public partial class PMSDbContext:DbContext
    {
        public PMSDbContext(DbContextOptions<PMSDbContext> options): base(options)
        {

        }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Module> Modules { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RoleModule> RoleModules { get; set; }

        public virtual DbSet<Org> Orgs { get; set; }

        public virtual DbSet<SysUser> SysUsers { get; set; }

        public virtual DbSet<Medicine> Medicines { get; set; }

        public virtual DbSet<Inventory> Inventories { get; set; }

        public virtual DbSet<MedicineSupplier> MedicineSuppliers { get; set; }
    }
}
