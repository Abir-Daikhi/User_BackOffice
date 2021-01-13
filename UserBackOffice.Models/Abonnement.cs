using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Abonnement
    {
        [Key]

        public int Id_Abonnement { get; set; }

        public string Prix_Abonnement { get; set; }

        public short Is_Deleted_Abonnement { get; set; }

        public short Statut_Abonnement { get; set; }

        //public virtual List<User> LinkedUser { get; set; }
    }
}
