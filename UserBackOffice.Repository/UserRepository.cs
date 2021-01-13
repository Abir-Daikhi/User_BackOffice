using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using CMS_HERA_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext user_context;
        public UserRepository(DataContext context)
        {
            user_context = context;
        }

         User IUserRepository.GetUserByLogin(LoginUserViewModel login)
        {
            return user_context.Users.Where(e => e.Login_User == login.Username).First();
        }
        async Task IUserRepository.DeleteUser(User u)
        {
            user_context.Users.Remove(u);
            await user_context.SaveChangesAsync();
        }

        IEnumerable<User> IUserRepository.GetUserByFamilyName(string fname)
        {
            var users = from s in user_context.Users
                        select s;
            users = users.Where(s => s.Family_Name_User.Contains(fname));

            return users;
        }

        IEnumerable<User> IUserRepository.GetUserByMail(string mail)
        {
            var users = from s in user_context.Users
                        select s;
            users = users.Where(s => s.Mail_User.Contains(mail));

            return users;
        }

        IEnumerable<User> IUserRepository.GetUserByName(string name)
        {
            var users = from s in user_context.Users
                        select s;
            users = users.Where(s => s.Name_User.Contains(name));

            return users;
        }

        IEnumerable<User> IUserRepository.GetUserByNumMobile(string num_mob)
        {
            var users = from s in user_context.Users
                        select s;
            users = users.Where(s => s.Mobile_Number_User.Contains(num_mob));

            return users;
        }

        IEnumerable<User> IUserRepository.GetUserByNumTel(string num_tel)
        {
            var users = from s in user_context.Users
                        select s;
            users = users.Where(s => s.Phone_Number_User.Contains(num_tel));

            return users;
        }

        User IUserRepository.GetUserById(int id)
        {
            return user_context.Users.FirstOrDefault(m => m.Id_User == id);
        }

        IEnumerable<User> IUserRepository.GetUserByStatus(int status)
        {
            return (IEnumerable<User>)user_context.Users
                .FirstOrDefault(m => m.Statut_User == status);
        }

        IEnumerable<User> IUserRepository.GetUsers(string searchString)
        {
            var users = from s in user_context.Users
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name_User.Contains(searchString)
                                       || s.Family_Name_User.Contains(searchString)
                                       || s.Mail_User.Contains(searchString)
                                       || s.Mobile_Number_User.Contains(searchString)
                                       || s.Phone_Number_User.Contains(searchString)
                                       || s.Statut_User.ToString().Contains(searchString));
            }

            return users;
        }

        async Task IUserRepository.UpdateUser(User u)
        {
            user_context.Update(u);
            await user_context.SaveChangesAsync();
        }

        bool IUserRepository.UserExists(int id)
        {
            return user_context.Users.Any(e => e.Id_User == id);
        }

        async Task IUserRepository.AddUser(User u)
        {
            user_context.Add(u);
            await user_context.SaveChangesAsync();
        }

        public Task UpdateUser(User us)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(User us)
        {
            throw new NotImplementedException();
        }
    }
}
