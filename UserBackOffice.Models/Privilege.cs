using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Privilege
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public byte state { get; set; }
        public DateTime? created_at = System.DateTime.Now;
        public DateTime? updated_at = System.DateTime.Now;


    }
}
