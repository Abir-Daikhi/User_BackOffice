using System;
using System.Collections.Generic;
using System.Data.Entity;
using UserBackOffice.Models;

namespace UserBackOffice.Repository
{
    public class DataContext : DbContext
    {
        public DataContext()
           : base("name=DatabaseConnection")
        {
        }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<SubMenu> SubMenu { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SavedMenuRoles> SavedMenuRoles { get; set; }
        public DbSet<SavedSubMenuRoles> SavedSubMenuRoles { get; set; }
        public DbSet<Password> Password { get; set; }
        public DbSet<SavedAssignedRoles> SavedAssignedRoles { get; set; }
    }
}
