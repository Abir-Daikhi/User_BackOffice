using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Marque
    {
      
        public int Id { get; set; }
        public string Name_Marque { get; set; }
        public int Statut_Marque { get; set; }

        public ICollection<Produit> Produits { get; set; }
    }
}
