using System.Collections.Generic;
using System.Linq;
using UserBackOffice.Models;
using UserBackOffice.ViewModels;

namespace UserBackOffice.Repository
{
        public interface IRole
        {
            IEnumerable<Role> GetAllRole();
            Role GetRoleById(int? roleId);
            int? AddRole(Role role);
            int? UpdateRole(Role role);
            void DeleteRole(int? roleId);
            bool CheckRoleNameExists(string roleName);
            IQueryable<Role> ShowAllRole(string sortColumn, string sortColumnDir, string search);
            List<Role> GetAllActiveRoles();
            int? UpdateRoleStatus(ViewMenuRoleStatusUpdateModel vmrolemodel);
            int? UpdateSubMenuRoleStatus(ViewSubMenuRoleStatusUpdateModel vmrolemodel);
        }
    }