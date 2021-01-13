using System;
using System.Collections.Generic;
using System.Linq;
using UserBackOffice.Models;
using UserBackOffice.ViewModels;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

namespace UserBackOffice.Repository
{
    public interface ISubMenu : IDisposable
    {
        IEnumerable<SubMenu> GetAllSubMenu();
        SubMenu GetSubMenuById(int? subMenuId);
        int? AddSubMenu(SubMenu subMenu);
        int? UpdateSubMenu(SubMenu subMenu);
        void DeleteSubMenu(int? subMenuId);
        bool CheckSubMenuNameExists(string subMenuName, int menuId);
        IQueryable<SubMenuViewModel> ShowAllSubMenus(string sortColumn, string sortColumnDir, string search);
        List<SubMenu> GetAllActiveSubMenu(int menuid);
        List<SubMenu> GetAllActiveSubMenuByMenuId(int menuid);
    }
}
