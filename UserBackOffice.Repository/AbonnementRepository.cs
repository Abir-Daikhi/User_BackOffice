using UserBackOffice.Data;
using UserBackOffice.Interfaces;
using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class AbonnementRepository : IAbonnementRepository
    {
        private readonly DataContext _context;

        public AbonnementRepository(DataContext context)
        {
            _context = context;
        }

        async Task IAbonnementRepository.AddAbonnement(Abonnement A)
        {
            _context.Add(A);
            await _context.SaveChangesAsync();
        }

        async Task IAbonnementRepository.DeleteAbonnement(Abonnement A)
        {
            _context.Abonnements.Remove(A);
            await _context.SaveChangesAsync();
        }

        async Task<Abonnement> IAbonnementRepository.GetAbonnementById(int id)
        {

            return await _context.Abonnements
                .FindAsync(id);
        }

        IEnumerable<Abonnement> IAbonnementRepository.GetAbonnementByPrice(string prix)
        {
            var abonnements = from s in _context.Abonnements
                             select s;
            abonnements = abonnements.Where(s => s.Prix_Abonnement.Contains(prix)
            && s.Is_Deleted_Abonnement.ToString().Contains("0"));
            

            return abonnements;
        }

        IEnumerable<Abonnement> IAbonnementRepository.GetAbonnementByStatut(int status)
        {
            
            var abonnements = from s in _context.Abonnements
                              select s;
            abonnements = abonnements.Where(s => s.Statut_Abonnement == status
            && s.Is_Deleted_Abonnement.ToString().Contains("0"));
            
            return abonnements;
        }

        IEnumerable<Abonnement> IAbonnementRepository.GetAbonnements(string searchString)
        {
            var abonnements = from s in _context.Abonnements
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                abonnements = abonnements.Where(s => s.Prix_Abonnement.Contains(searchString)
                                       || s.Statut_Abonnement.ToString().Contains(searchString)
                                       && s.Is_Deleted_Abonnement.ToString().Contains("0"));
                
            }

            return abonnements;

        }

        async Task IAbonnementRepository.UpdateAbonnement(Abonnement A)
        {
            _context.Update(A);
            await _context.SaveChangesAsync();
        }

        public bool AbonnementExists(int id)
        {
            return _context.Abonnements.Any(e => e.Id_Abonnement == id);
        }
    }
}
