using PMS.Infrastructure.Response;
using PMS.Infrastructure.ViewModel;
using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Services.Interfaces
{
    public interface IUserService: IRepository<SysUser>
    {
        Response<LoginResult> UserLogin(LoginModel model);
    }
}
