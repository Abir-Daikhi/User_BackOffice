using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Ville
    {
        public int VilleID { set; get; }
        public string Name_ville { set; get; }
        public ICollection<Adresse> Adresses { get; set; }
    }
}
