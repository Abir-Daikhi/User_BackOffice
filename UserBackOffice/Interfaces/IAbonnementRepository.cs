using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IAbonnementRepository
    {
        IEnumerable<Abonnement> GetAbonnements(string searchString);
        Task<Abonnement> GetAbonnementById(int id);
        IEnumerable<Abonnement> GetAbonnementByPrice(string Prix_Abonnement);
        IEnumerable<Abonnement> GetAbonnementByStatut(int statut_Devise);
        Task AddAbonnement(Abonnement A);
        Task UpdateAbonnement(Abonnement A);
        Task DeleteAbonnement(Abonnement A);
        bool AbonnementExists(int id);
    }
}
