using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Implements
{
    public class OrgService : BaseRepository<Org>, IOrgService
    {
        public OrgService(PMSDbContext context) : base(context)
        {
        }

        public List<Org> GetOrgs(int orgId)
        {
            throw new NotImplementedException();
        }
    }
}
