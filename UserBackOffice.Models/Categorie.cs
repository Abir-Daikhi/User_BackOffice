using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        [StringLength(45)]
        public string Nom_Categorie { get; set; }
        
        public int Status_Categorie { get; set; }
        
        public int Position_Categorie { get; set; }

        public int Pere { get; set; }
        //public ICollection <Categorie> Sous_Categories { get; set; }

        public ICollection<Produit> Produits { get; set; }
    }
}
