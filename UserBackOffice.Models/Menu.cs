using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserBackOffice.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Enter ControllerName")]
        public string ControllerName { get; set; }

        [Required(ErrorMessage = "Enter ActionMethod")]
        public string ActionMethod { get; set; }

        [Required(ErrorMessage = "Enter MenuName")]
        public string MenuName { get; set; }
        public bool Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsCache { get; set; }
        public int UserId { get; set; }

    }
}
