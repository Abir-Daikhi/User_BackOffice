using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Enter RoleName")]
        public string RoleName { get; set; }
        public bool Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UserId { get; set; }
    }
}
