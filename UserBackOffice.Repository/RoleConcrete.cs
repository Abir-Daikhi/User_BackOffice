//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.Entity;
//using System.Data.SqlClient;
//using System.Linq;
//using UserBackOffice.Models;
//using UserBackOffice.ViewModels;

//namespace UserBackOffice.Repository
//{
//    public class RoleConcrete : IRole
//    {
//        private readonly DataContext _context;
//        private bool _disposed = false;

//        public RoleConcrete(DataContext context)
//        {
//            _context = context;
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this._disposed)
//            {
//                if (disposing)
//                {
//                    _context.Dispose();
//                }
//            }
//            this._disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);

//            GC.SuppressFinalize(this);
//        }
//        public int? AddRole(Role role)
//        {
//            try
//            {
//                int? result = -1;
//                if (role != null)
//                {
//                    role.CreateDate = DateTime.Now;
//                    _context.Role.Add(role);
//                    _context.SaveChanges();
//                    result = role.RoleId;
//                }
//                return result;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public bool CheckRoleNameExists(string roleName)
//        {
//            try
//            {
//                var result = (from role in _context.Role
//                              where role.RoleName == roleName
//                              select role).Any();

//                return result;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public void DeleteRole(int? roleId)
//        {
//            try
//            {
//                Role role = _context.Role.Find(roleId);
//                if (role != null) _context.Role.Remove(role);
//                _context.SaveChanges();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public IEnumerable<Role> GetAllRole()
//        {
//            try
//            {
//                return _context.Role.ToList();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public Role GetRoleById(int? roleId)
//        {
//            try
//            {
//                return _context.Role.Find(roleId);
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public IQueryable<Role> ShowAllRole(string sortColumn, string sortColumnDir, string search)
//        {
//            try
//            {
//                var queryablesRole = (from role in _context.Role
//                                             select role);

//                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
//                {
//                    queryablesRole = queryablesRole.AsQueryable();
//                        //OrderBy(sortColumn + " " + sortColumnDir);
//                }
//                if (!string.IsNullOrEmpty(search))
//                {
//                    queryablesRole = queryablesRole.Where(m => m.RoleName.Contains(search) || m.RoleName.Contains(search));
//                }

//                return queryablesRole;

//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public int? UpdateRole(Role role)
//        {
//            try
//            {
//                int? result = -1;

//                if (role != null)
//                {
//                    role.CreateDate = DateTime.Now;
//                    _context.Entry(role).State = EntityState.Modified;
//                    _context.SaveChanges();
//                    result = role.RoleId;
//                }
//                return result;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public List<Role> GetAllActiveRoles()
//        {
//            try
//            {
//                var listofActiveMenu = (from role in _context.Role
//                                        where role.Status == true
//                                        select role).ToList();

//                listofActiveMenu.Insert(0, new Role()
//                {
//                    RoleId = -1,
//                    RoleName = "---Select---"
//                });

//                return listofActiveMenu;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        //public int? UpdateRoleStatus(ViewMenuRoleStatusUpdateModel vmrolemodel)
//        //{
//        //    try
//        //    {
//        //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
//        //        {
//        //            con.Open();
//        //            SqlTransaction trans = con.BeginTransaction();
//        //            var param = new DynamicParameters();
//        //            param.Add("@Status", vmrolemodel.Status);
//        //            param.Add("@SavedMenuRoleId", vmrolemodel.SaveId);
//        //            var result = con.Execute("Usp_UpdateRoleStatus", param, trans, 0, CommandType.StoredProcedure);
//        //            if (result > 0)
//        //            {
//        //                trans.Commit();
//        //            }
//        //            else
//        //            {
//        //                trans.Rollback();
//        //            }

//        //            return result;
//        //        }
//        //    }
//        //    catch (Exception)
//        //    {
//        //        throw;
//        //    }
//        //}

//    //    public int? UpdateSubMenuRoleStatus(ViewSubMenuRoleStatusUpdateModel vmrolemodel)
//    //    {
//    //        try
//    //        {
//    //            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
//    //            {
//    //                con.Open();
//    //                SqlTransaction trans = con.BeginTransaction();
//    //                var param = new DynamicParameters();
//    //                param.Add("@Status", vmrolemodel.Status);
//    //                param.Add("@SavedSubMenuRoleId", vmrolemodel.SaveId);
//    //                var result = con.Execute("UpdateSubMenuRoleStatus", param, trans, 0, CommandType.StoredProcedure);
//    //                if (result > 0)
//    //                {
//    //                    trans.Commit();
//    //                }
//    //                else
//    //                {
//    //                    trans.Rollback();
//    //                }

//    //                return result;
//    //            }
//    //        }
//    //        catch (Exception)
//    //        {
//    //            throw;
//    //        }
//    //    }
//    //}
//}
//}
