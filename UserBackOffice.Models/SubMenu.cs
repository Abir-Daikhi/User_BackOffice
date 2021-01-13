using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    [Table("SubMenu")]
    public class SubMenu
    {
        [Key]
        public int SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionMethod { get; set; }
        public string SubMenuName { get; set; }
        public bool Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int MenuId { get; set; }
        public int UserId { get; set; }
    }
}
