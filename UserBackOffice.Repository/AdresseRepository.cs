using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class AdresseRepository : IAdresseRepository
    {
        private readonly DataContext _context;

        
        public AdresseRepository(DataContext context)
        {
            _context = context;
            
        }
        public async Task AddAdresse(Adresse a)
        {
            _context.Add(a);
            await _context.SaveChangesAsync();

        }

        public bool AdresseExists(int id)
        {
            return _context.Adresses.Any(e => e.AdresseID == id);
        }

        public async Task DeleteAdresse(Adresse a)
        {
            _context.Adresses.Remove(a);
            await _context.SaveChangesAsync();
        }

        public async Task<Adresse> GetAdresseById(int id)
        {
            return await _context.Adresses.FindAsync(id);
        }

        public IEnumerable<Adresse> GetAdresseByPostal(int postal)
        {
            var adresse = from s in _context.Adresses
                       select s;
            adresse = adresse.Where(s => s.Postal_adresse == postal);

            return adresse;
        }

       

        public IEnumerable<Adresse> GetAdresseByStatus(int status)
        {
            var adresse = from s in _context.Adresses
                          select s;
            adresse = adresse.Where(s => s.Statut_adresse == status);

            return adresse;
        }

        public IEnumerable<Adresse> GetAdresses(string searchString)
        {
            var adresse = from s in _context.Adresses
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                adresse = adresse.Where(s => s.Postal_adresse.ToString().Contains(searchString)
                                       || s.Statut_adresse.ToString().Contains(searchString));
            }

            return adresse
                .Include(pays => pays.Pays)
                .Include(ville => ville.Ville); 
        }

        public async Task UpdateAdresse(Adresse a)
        {
            _context.Update(a);
            await _context.SaveChangesAsync();
        }
    }
}
