using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public interface ISavedAssignedRoles
    {
        long? AddAssignedRoles(SavedAssignedRoles savedAssignedRoles);
        bool CheckAssignedRoles(long? userId);
        SavedAssignedRoles GetAssignedRolesbyUserId(long? userId);
    }
}
