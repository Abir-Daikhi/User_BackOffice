using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
   public interface ILivraisonRepository
    {
        IEnumerable<Livraison> GetLivraisons(string searchString);
        Task<Livraison> GetLivraisonById(int id);
        IEnumerable<Livraison> GetLivraisonByName(string name);

        Task AddLivraison(Livraison l);
        Task UpdateLivraison(Livraison l);
        Task DeleteLivraison(Livraison l);
        bool LivraisonExists(int id);
    }
}
