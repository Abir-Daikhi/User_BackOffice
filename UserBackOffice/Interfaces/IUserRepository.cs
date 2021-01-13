using UserBackOffice.Models;
using UserBackOffice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(string searchString);
        User GetUserById(int id);
        User GetUserByLogin(LoginUserViewModel login);
        IEnumerable<User> GetUserByName(string name);
        IEnumerable<User> GetUserByFamilyName(string fname);
        IEnumerable<User> GetUserByMail(string mail);
        IEnumerable<User> GetUserByNumMobile(string num_mob);
        IEnumerable<User> GetUserByNumTel(string num_tel);
        IEnumerable<User> GetUserByStatus(int status);
        Task AddUser(User us);
        Task UpdateUser(User us);
        Task DeleteUser(User us);
        bool UserExists(int id);
    }
}
