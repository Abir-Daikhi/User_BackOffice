using System;
using System.Collections.Generic;
using System.Linq;
using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
     public class PasswordConcrete : IPassword
    {
        private readonly DataContext _context;
        public PasswordConcrete(DataContext context)
        {
            _context = context;
        }
        public long? SavePassword(Password passwordMaster)
        {
            try
            {
                long? result = -1;
                if (passwordMaster != null)
                {
                    _context.Password.Add(passwordMaster);
                    _context.SaveChanges();
                    result = passwordMaster.PasswordId;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetPasswordbyUserId(long userId)
        {
            try
            {
                var password = (from passwordmaster in _context.Password
                                where passwordmaster.UserId == userId
                                select passwordmaster.password).FirstOrDefault();

                return password;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
