using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Client
    {
        [Key]
        public int id_client { get; set; }
        [Required(ErrorMessage = "Entrez votre nom !!")]
        public string nom_client { get; set; }
        [Required(ErrorMessage = "Entrez votre prenom !!")]
        public string prenom_client { get; set; }
        [Required(ErrorMessage = "Entrez votre mail !!")]
        public string mail_client { get; set; }
        [Required(ErrorMessage = "Entrez votre login !!")]
        public string login_client { get; set; }
        [Required(ErrorMessage = "Entrez votre mot de passe !!")]
        public string mdp_client { get; set; }
        
        public string num_tel_client { get; set; }
        [Required(ErrorMessage = "Entrez votre numero de telephone mobile !!")]
        public string num_mob_client { get; set; }
        public bool statut_client { get; set; }
}
}
