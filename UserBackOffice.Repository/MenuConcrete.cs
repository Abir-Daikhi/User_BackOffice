using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public class MenuConcrete : IMenu
    {
        private readonly DataContext _context;
        private bool _disposed = false;

        public MenuConcrete(DataContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public List<Menu> GetAllMenu()
        {
            try
            {
                return _context.Menu.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Menu> GetAllActiveMenu()
        {
            try
            {
                var listofActiveMenu = (from menu in _context.Menu
                                        where menu.Status == true
                                        select menu).ToList();

                listofActiveMenu.Insert(0, new Menu()
                {
                    MenuId = -1,
                    MenuName = "---Select---"
                });

                return listofActiveMenu;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Menu GetMenuById(int? menuId)
        {
            try
            {
                return _context.Menu.Find(menuId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? AddMenu(Menu menu)
        {
            try
            {
                int? result = -1;

                if (menu != null)
                {
                    menu.CreateDate = DateTime.Now;
                    _context.Menu.Add(menu);
                    _context.SaveChanges();
                    result = menu.MenuId;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? UpdateMenu(Menu menu)
        {
            try
            {
                int? result = -1;

                if (menu != null)
                {
                    menu.CreateDate = DateTime.Now;
                    _context.Entry(menu).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = menu.MenuId;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMenu(int? menuId)
        {
            try
            {
                Menu menu = _context.Menu.Find(menuId);
                if (menu != null) _context.Menu.Remove(menu);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckMenuNameExists(string menuName)
        {
            try
            {
                var result = (from menu in _context.Menu
                              where menu.MenuName == menuName
                              select menu).Any();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<Menu> ShowAllMenus(string sortColumn, string sortColumnDir, string search)
        {
            try
            {
                var queryablemenu = (from register in _context.Menu
                                     select register
                    );

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    queryablemenu = queryablemenu.AsQueryable();
                   //OrderBy(sortColumn + " " + sortColumnDir);
                }
                if (!string.IsNullOrEmpty(search))
                {
                    queryablemenu = queryablemenu.Where(m => m.MenuName.Contains(search) || m.MenuName.Contains(search));
                }

                return queryablemenu;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Menu> GetAllActiveMenu(long roleId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@RoleID", roleId);
                    return con.Query<Menu>("Usp_GetMenusByRoleID", param, null, false, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Menu> GetAllActiveMenuSuperAdmin()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
                {
                    var param = new DynamicParameters();
                    return con.Query<Menu>("Usp_GetMenusByRoleID_SuperAdmin", param, null, false, 0, CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
