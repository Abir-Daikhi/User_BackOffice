using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public interface ISavedMenuRoles
    {
        int SaveRole(SavedMenuRoles savedRoles);
        bool CheckRoleAlreadyExists(SavedMenuRoles savedRoles);
    }
}
