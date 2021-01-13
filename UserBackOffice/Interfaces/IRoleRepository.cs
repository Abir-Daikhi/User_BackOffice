
using System.Collections.Generic;
using UserBackOffice.Models;
using System.Threading.Tasks;


namespace UserBackOffice.Interfaces
{
    interface IRoleRepository
    {
        IEnumerable<Role> GetAllRole();
        Role GetRoleById(int? roleId);
        int? AddRole(Role role);
        int? UpdateRole(Role role);
        void DeleteRole(int? id_role);
        bool CheckRoleNameExists(string titre_role);
        IEnumerable<Role> ShowAllRole(string sortColumn, string sortColumnDir, string search);
        List<Role> GetAllActiveRoles();
    }
}
