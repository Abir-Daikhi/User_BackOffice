using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Livraison
    {
        public int LivraisonID { set; get; }
        public string Mode_livraison { set; get; }
        public string Name_livraison { set; get; }
        public float Prix_livraison { set; get; }
        public string Type_livraison { set; get; }
        public int Statut_livraison { set; get; }
    }
}
