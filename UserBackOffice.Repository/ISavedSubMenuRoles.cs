using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public interface ISavedSubMenuRoles
    {
        int SaveRole(SavedSubMenuRoles savedRoles);
        bool CheckRoleAlreadyExists(SavedSubMenuRoles savedSubMenuRoles);
    }
}
