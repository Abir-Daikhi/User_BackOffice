using System;
using System.Collections.Generic;
using System.Linq;
using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public interface IMenu : IDisposable
    {
        List<Menu> GetAllMenu();
        List<Menu> GetAllActiveMenu();
        Menu GetMenuById(int? menuId);
        int? AddMenu(Menu menuMaster);
        int? UpdateMenu(Menu menuMaster);
        void DeleteMenu(int? menuId);
        bool CheckMenuNameExists(string menuName);
        IQueryable<Menu> ShowAllMenus(string sortColumn, string sortColumnDir, string search);
        List<Menu> GetAllActiveMenu(long userId);
        List<Menu> GetAllActiveMenuSuperAdmin();
    }
}
