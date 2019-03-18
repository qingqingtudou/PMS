using PMS.Repository.Domain;
using PMS.Repository.Interfaces;
using System.Collections.Generic;

namespace PMS.Services.Interfaces
{
    public interface IMenuUservice: IRepository<Menu>
    {
        List<Menu> GetMenus();
    }
}
