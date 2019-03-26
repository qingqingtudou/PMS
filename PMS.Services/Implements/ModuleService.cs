using Microsoft.EntityFrameworkCore;
using PMS.Infrastructure.Enums;
using PMS.Infrastructure.ViewModel;
using PMS.Repository;
using PMS.Repository.Domain;
using PMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Services.Implements
{
    /// <summary>
    /// 功能模块服务
    /// </summary>
    public class ModuleService : BaseRepository<Module>, IModuleService
    {
        public ModuleService(PMSDbContext context) : base(context)
        {
        }

        public List<ModuleElement> GetOrgMenus()
        {
            List<ModuleElement> elements = new List<ModuleElement>();
            ModuleElement element = new ModuleElement()
            {
                DomId = "btnAdd",
                Name = "添加",
                Attr = "",
                Script = "add()",
                Class = "layui-btn-normal",
                Icon = "&#xe654;",
                Remark = "添加部门",
                Sort = 2,
                ModuleId = 2,
                Id = 21
            };
            elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnDel",
                Name = "删除",
                Attr = "",
                Script = "del()",
                Class = "layui-btn-danger",
                Icon = "&#xe640;",
                Remark = "刪除部门",
                Sort = 2,
                ModuleId = 2,
                Id = 210
            };
            elements.Add(element);
            //element = new ModuleElement()
            //{
            //    DomId = "btnDel",
            //    Name = "删除",
            //    Attr = "",
            //    Script = "del()",
            //    Class = "layui-btn-danger",
            //    Icon = "&#xe640;",
            //    Remark = "刪除部门",
            //    Sort = 2,
            //    ModuleId = 2,
            //    Id = 212
            //};
            //elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnEdit",
                Name = "编辑",
                Attr = "",
                Script = "edit()",
                Class = "layui-btn-normal",
                Icon = "&#xe642;",
                Remark = "编辑部门",
                Sort = 2,
                ModuleId = 2,
                Id = 213
            };
            elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnRefresh",
                Name = "刷新",
                Attr = "",
                Script = "refresh()",
                Class = "layui-btn-normal",
                Icon = "&#xe615;",
                Remark = "刷新",
                Sort = 2,
                ModuleId = 2,
                Id = 2131
            };
            elements.Add(element);
            return elements;
        }

        /// <summary>
        /// 获取角色功能模块
        /// </summary>
        /// <returns></returns>
        public List<ModuleView> GetRoleModules(int roleId)
        {
            var roleModuleIds = _context.RoleModules.AsNoTracking().Where(w => w.RoleId == roleId).Select(s => s.ModuleId).ToList();
            var modules = _context.Modules.AsNoTracking().Where(w => roleModuleIds.Contains(w.Id) && w.Status == (int)EDataStatus.valid && w.IsDelete == false).Select(s => new ModuleView()
            {
                Id = s.Id,
                Name = s.Name,
                CascadeId = s.CascadeId,
                Code = s.Code,
                IconName = s.IconName,
                Url = s.Url,
                ParentId = s.ParentId,
                ParentName = s.ParentName,
            }).ToList();
            return modules;
        }

        public List<ModuleElement> GetUserMenus()
        {
            List<ModuleElement> elements = new List<ModuleElement>();
            ModuleElement element = new ModuleElement()
            {
                DomId = "btnDel",
                Name = "删除",
                Attr = "",
                Script = "del()",
                Class = "layui-btn-danger",
                Icon = "&#xe640;",
                Remark = "刪除用户",
                Sort = 2,
                ModuleId = 2,
                Id = 2
            };
            elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnEdit",
                Name = "编辑",
                Attr = "",
                Script = "edit()",
                Class = "layui-btn-normal",
                Icon = "&#xe642;",
                Remark = "编辑用户",
                Sort = 2,
                ModuleId = 2,
                Id = 21
            };
            elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnAdd",
                Name = "添加",
                Attr = "",
                Script = "add()",
                Class = "layui-btn-normal",
                Icon = "&#xe640;",
                Remark = "添加用户",
                Sort = 2,
                ModuleId = 2,
                Id = 212
            };
            elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnAccessRole",
                Name = "为用户分配角色",
                Attr = "",
                Script = "openUserRoleAccess(this)",
                Class = "layui-btn-normal",
                Icon = "&#xe640;",
                Remark = "为用户分配角色",
                Sort = 2,
                ModuleId = 2,
                Id = 211
            };
            elements.Add(element);
            element = new ModuleElement()
            {
                DomId = "btnRefresh",
                Name = "刷新",
                Attr = "",
                Script = "refresh()",
                Class = "layui-btn-normal",
                Icon = "&#xe615;",
                Remark = "刷新",
                Sort = 2,
                ModuleId = 2,
                Id = 2131
            };
            elements.Add(element);
            return elements;
        }
    }
}
