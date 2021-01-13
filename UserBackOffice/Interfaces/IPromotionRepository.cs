using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IPromotionRepository
    {
        IEnumerable<Promotion> GetPromotion(string searchString);
        Task<Promotion> GetPromotionById(int id);
        IEnumerable<Promotion> GetPromotionByName(string name);
        IEnumerable<Promotion> GetPromotionByStatus(int status);
        IEnumerable<Promotion> GetPromotionByValeur(float valeur);
        Task AddPromorion(Promotion p);
        Task UpdatePromotion(Promotion p);
        Task DeletePromotion(Promotion p);
        bool PromotionExists(int id);
    }
}
