using System;
using System.Collections.Generic;
using System.Linq;
using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public interface IUser
    {
        List<User> GetAllUsers();
        User GetUserById(int? userId);
        long? AddUser(User user);
        long? UpdateUser(User user);
        void DeleteUser(int? userId);
        bool CheckUsernameExists(string username);
        User GetUserByUsername(string username);
        IQueryable<User> ShowAllUsers(string sortColumn, string sortColumnDir, string search);
        List<DropdownUser> GetAllUsersActiveList();
    }
}
