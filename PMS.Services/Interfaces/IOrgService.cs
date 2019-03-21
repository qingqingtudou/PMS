using PMS.Infrastructure;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Interfaces
{
    public interface IOrgService: IRepository<Org>
    {
        List<Org> GetOrgs(string fullpath);

        List<TreeModel> GetTreeModels(string fullpath,int orgId);
    }
}
