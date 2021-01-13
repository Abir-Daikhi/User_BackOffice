using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserBackOffice.Models
{
    [Table("Password")]
    public class Password
    {
        [Key]
        public long PasswordId { get; set; }
        public string password { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? UserId { get; set; }
    }
}
