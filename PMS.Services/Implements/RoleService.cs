using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Response;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Services.Implements
{
    public class RoleService : BaseRepository<Role>, IRoleService
    {
        public RoleService(PMSDbContext context) : base(context)
        {
        }

        public List<RoleView> GetUserRoles(int userRole)
        {
            var role = _context.Roles.AsNoTracking().Where(w => w.Id == userRole).FirstOrDefault();
            var query = _context.Roles.AsNoTracking().Where(w => w.Sort > role.Sort).Select(s => new RoleView()
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            return query;
        }
    }
}
