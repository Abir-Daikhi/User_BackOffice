using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the reference")]
        [StringLength(50)]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Please enter the Description")]
        public string Description { get; set; }
        
        public float Prix { get; set; }

        public int Qte { get; set; }
        public int Statut_Produit { get; set; }

        [Display(Name = "Product Pictures")]
        public ICollection<ImgProduit> CataloguePhotos { get; set; }

        //l'integration
        public int? MarqueId { get; set; }
        public Marque Marque { get; set; }
        public int? CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
