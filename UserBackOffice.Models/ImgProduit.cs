using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserBackOffice.Models
{
    public class ImgProduit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the url")]
        public string Url { get; set; }

        public int NbrImgProduit { get; set; }

        public int ProduitId { get; set; }

        public Produit Produit { get; set; }
    }
}
