using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Site
    {
        [Key]
        public int id_site { get; set; }

        [Required(ErrorMessage = "Entrez le nom du site !!")]
        public string nom_site { get; set; }
        [Required(ErrorMessage = "Entrez la permision du role !!")]
        public string url_site { get; set; }
        public bool statut_site { get; set; }
        public string token { get; set; }
        public string icone { get; set; }
        public DateTime? date_creation { get; set; }
    }
}
