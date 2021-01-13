using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Adresse
    {
        public int AdresseID { set; get; }
        public string description_adresse { set; get; }
        public int Postal_adresse { set; get; }
        public int Statut_adresse { set; get; }
        public Pays Pays { set; get; }
        public int? PaysID { set; get; }
        public Ville Ville { set; get; }
        public int? VilleID { set; get; }
    }
}
