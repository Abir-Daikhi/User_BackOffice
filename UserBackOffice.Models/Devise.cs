using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Devise
    {
        [Key]

        public int Id_Devise { get; set; }

        public string Name_Devise { get; set; }

        public string Symbole_Devise{ get; set; }

        public short Statut_Devise { get; set; }
    }
}
