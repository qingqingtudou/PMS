using PMS.Repository.Core;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services
{
    public class BaseService<T> where T : Entity
    {
        ///// <summary>
        ///// 用于事务操作
        ///// </summary>
        ///// <value>The unit work.</value>
        //protected IUnitWork UnitWork;

        //public BaseService(IUnitWork unitWork, IRepository<T> repository)
        //{
        //    UnitWork = unitWork;
        //    Repository = repository;
        //}

        ///// <summary>
        ///// 用于普通的数据库操作
        ///// </summary>
        ///// <value>The repository.</value>
        //protected IRepository<T> Repository;

        ///// <summary>
        ///// 按id批量删除
        ///// </summary>
        ///// <param name="ids"></param>
        ////public void Delete(string[] ids)
        ////{
        ////    Repository.Delete(u => ids.Contains(u.Id));
        ////}

        //public T Get(int id)
        //{
        //    return Repository.FindSingle(u => u.Id == id);
        //}
    }
}
