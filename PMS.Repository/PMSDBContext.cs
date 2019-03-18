using Microsoft.EntityFrameworkCore;
using PMS.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Repository
{
    public partial class PMSDbContext:DbContext
    {
        public PMSDbContext(DbContextOptions<PMSDbContext> options): base(options)
        {

        }

        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Org> Orgs { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<SysUser> SysUsers { get; set; }
    }
}
