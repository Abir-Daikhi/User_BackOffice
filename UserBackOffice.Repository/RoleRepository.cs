using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CMS_HERA_MVC.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        private bool _disposed = false;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        protected virtual void dispose(bool disposing)
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

        public void dispose()
        {
            dispose(true);

        }
        public int? AddRole(Role role)
        {
            try
            {
                int? result = -1;
                if (role != null)
                {
                    role.date_creation = DateTime.Now;
                    _context.Roles.Add(role);
                    _context.SaveChanges();
                    result = role.id_role;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckRoleNameExists(string titre_role)
        {
            try
            {
                var result = (from role in _context.Roles
                              where role.titre_role == titre_role
                              select role).Any();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRole(int? id_role)
        {
            try
            {
                Role role = _context.Roles.Find(id_role);
                if (role != null) _context.Roles.Remove(role);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Role> GetAllRole()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Role GetRoleById(int? id_role)
        {
            try
            {
                return _context.Roles.Find(id_role);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Role> ShowAllRole(string sortcolumn, string sortcolumndir, string search)
        {
            try
            {
                var queryablesroles = (from role in _context.Roles
                                       select role);

                if (!(string.IsNullOrEmpty(sortcolumn) && string.IsNullOrEmpty(sortcolumndir)))
                {
                    queryablesroles = queryablesroles;
                }
                if (!string.IsNullOrEmpty(search))
                {
                    queryablesroles = queryablesroles.Where(m => m.titre_role.Contains(search) || m.titre_role.Contains(search));
                }

                return queryablesroles;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? UpdateRole(Role role)
        {
            try
            {
                int? result = -1;

                if (role != null)
                {
                    role.date_creation = DateTime.Now;
                    role.statut_role = true;
                    _context.SaveChanges();
                    result = role.id_role;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Role> GetAllActiveRoles()
        {
            try
            {
                var listofactivemenu = (from role in _context.Roles
                                        where role.statut_role == true
                                        select role).ToList();

                listofactivemenu.Insert(0, new Role()
                {
                    id_role = -1,
                    titre_role = "---select---"
                });

                return listofactivemenu;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int? UpdateRoleStatus(ViewMenuRoleStatusUpdateModel vmrolemodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseconnection"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction();
                    var param = new DynamicParameters();
                    param.Add("@status", vmrolemodel.Status);
                    param.Add("@savedmenuroleid", vmrolemodel.SaveId);
                    var result = con.Execute("usp_updaterolestatus", param, trans, 0, CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        trans.Commit();
                    }
                    else
                    {
                        trans.Rollback();
                    }

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

}
}
