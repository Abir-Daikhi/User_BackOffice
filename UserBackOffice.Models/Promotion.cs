using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Models
{
    public class Promotion
    {
        public int PromotionID { set; get; }
        public string Name_promotion { set; get; }
        public string Type_promotion { set; get; }
        public float Valeur_promotion { set; get; }
        public DateTime Date_debut { set; get; }
        public DateTime Date_fin { set; get; }
        public int Statut_promotion { set; get; }
    }
}
