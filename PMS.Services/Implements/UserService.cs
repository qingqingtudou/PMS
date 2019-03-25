using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Enums;
using PMS.Infrastructure.Model;
using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Linq;

namespace PMS.Services.Implements
{
    public class UserService : BaseRepository<SysUser>, IUserService
    {
        public UserService(PMSDbContext context) : base(context)
        {
        }

        public SysUser GetSysUserById(int Id)
        {
            return _context.SysUsers.AsNoTracking().Where(w => w.Id == Id).FirstOrDefault();
        }

        public OperatePageResult GetUserList(QueryUserReq pageSize)
        {
            var query = from u in _context.SysUsers.AsNoTracking().Where(w => w.OrgFullPath.StartsWith(pageSize.fullpath))
                        join o in _context.Orgs.AsNoTracking() on u.OrgId equals o.Id into temp
                        from tp in temp.DefaultIfEmpty()
                        select new UserView()
                        {
                            Id = u.Id,
                            Account = u.Account,
                            CreateTime = u.CreateTime ?? DateTime.Now,
                            CreateUser = u.Creator,
                            OrganizationIds = u.OrgId ?? 0,
                            Organizations = tp.Name,
                            Name = u.Name,
                            Sex = u.Sex ?? 0,
                            Status = u.Status ??0,
                        };
            if (pageSize.orgId > 0)
            {
                query = query.Where(w => w.OrganizationIds == pageSize.orgId);
            }
            OperatePageResult result = new OperatePageResult
            {
                count = query.Count(),
                data = query.Skip((pageSize.page - 1) * pageSize.limit).Take(pageSize.limit).ToList()
            };
            return result;
        }

        public OperateResult<SysUser> UserLogin(LoginModel model)
        {
            var query = _context.SysUsers.Where(f => f.Account == model.Account && f.Password == model.Password && f.IsDelete == false && f.Status == (int)EDataStatus.valid);
            var user = query.FirstOrDefault();
            OperateResult<SysUser> result = new OperateResult<SysUser>();

            if (user == null)
            {
                result.Code = (int)EResponse.NotFound;
                result.Message = "用户名或密码错误";
                return result;
            }
            result.Code = (int)EResponse.Ok;
            result.Message = "登录成功";
            result.Payload = user;
            return result;
        }
    }
}
