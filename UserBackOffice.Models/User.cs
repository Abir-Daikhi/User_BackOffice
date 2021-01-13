using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserBackOffice.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public bool? Status { get; set; }
        public long? CreatedBy { get; set; }

    }

    [NotMapped]

    public class DropdownUser
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
    }
}