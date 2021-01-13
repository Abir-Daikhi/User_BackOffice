using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserBackOffice.Models
{
    [Table("SavedSubMenuRoles")]
    public class SavedSubMenuRoles
    {
        [Key]
        public int SavedSubMenuRoleId { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public int SubMenuId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}
