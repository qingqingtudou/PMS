using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Services.Implements
{
    public class OrgService : BaseRepository<Org>, IOrgService
    {
        public OrgService(PMSDbContext context) : base(context)
        {
        }

        public List<Org> GetOrgs(string fullpath)
        {
            var list = _context.Orgs.AsNoTracking().Where(w => w.FullPath.StartsWith(fullpath)).ToList();
            return list;
        }

        public List<TreeModel> GetTreeModels(string fullpath, int orgId)
        {
            var list = _context.Orgs.AsNoTracking().Where(w => w.FullPath.StartsWith(fullpath)).Select(s => new TreeModel() {
                Id = s.Id,
                Name = s.Name,
                Pid = s.Pid??0
            }).ToList();

            var treeList = new List<TreeModel>();
            var rootOrg = list.Where(w => w.Id == orgId).FirstOrDefault();
            if(rootOrg == null)
            {
                return treeList;
            }
            list.Remove(rootOrg); //删掉当前根节点

            rootOrg.Children = ForTrees(orgId, list);

            treeList.Add(rootOrg);
            return treeList;
        }

        private List<TreeModel> ForTrees(int pid, List<TreeModel> forTrees)
        {
            List<TreeModel> list = new List<TreeModel>();
            var pList = forTrees.Where(w => w.Pid == pid);
            foreach (var item in pList)
            {
                item.Children = ForTrees(item.Id, forTrees);
                list.Add(item);
            }
            return list;
        }
    }
}
