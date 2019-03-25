using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure;
using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Model;
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

        public OperatePageResult GetSubOrgs(QueryOrgReq req)
        {
            var query = from p in _context.Orgs.AsNoTracking().Where(w => w.FullPath.StartsWith(req.fullpath) && w.Status == (int)EDataStatus.valid && w.IsDelete == false)
                        join o in _context.Orgs.AsNoTracking().Where(w => w.Status == (int)EDataStatus.valid && w.IsDelete == false)
                        on p.Pid equals o.Id into temp
                        from tp in temp.DefaultIfEmpty()
                        select new OrgView()
                        {
                            Id = p.Id,
                            Sort = p.Sort,
                            FullPath = p.FullPath,
                            FullPathText = p.FullPathText,
                            Name = p.Name,
                            ParentName = tp.Name,
                            Pid = p.Pid
                        };
            if (req.orgId > 0)
            {
                query = query.Where(w => w.Id == req.orgId || w.Pid == req.orgId);
            }
            OperatePageResult result = new OperatePageResult
            {
                count = query.Count(),
                data = query.Skip((req.page - 1) * req.limit).Take(req.limit).ToList()
            };
            return result;
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
