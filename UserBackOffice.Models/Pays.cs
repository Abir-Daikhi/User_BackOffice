using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Pays
    {
        
        public int Id { set; get; }
       
        public string nom_pays { set; get; }
        public int statut_pays { set; get; }
        public string alias { set; get; }
        public ICollection<Adresse> Adresses { get; set; }
    }
}
