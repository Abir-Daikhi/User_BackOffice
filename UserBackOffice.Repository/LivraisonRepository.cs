using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class LivraisonRepository : ILivraisonRepository
    {
        private readonly DataContext _context;
        public LivraisonRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddLivraison(Livraison l)
        {
            _context.Add(l);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivraison(Livraison l)
        {
            _context.Livraisons.Remove(l);
            await _context.SaveChangesAsync();
        }

        public async Task<Livraison> GetLivraisonById(int id)
        {
            return await _context.Livraisons.FindAsync(id);
        }

        public IEnumerable<Livraison> GetLivraisonByName(string name)
        {
            var livraison = from s in _context.Livraisons
                            select s;
            livraison = livraison.Where(s => s.Name_livraison.Contains(name));

            return livraison;
        }

        public IEnumerable<Livraison> GetLivraisons(string searchString)
        {
            var livraisons = from s in _context.Livraisons
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                livraisons = livraisons.Where(s => s.Name_livraison.Contains(searchString) ||
                s.Statut_livraison.ToString().Contains(searchString) ||
                s.Prix_livraison.ToString().Contains(searchString) ||
                s.Mode_livraison.Contains(searchString) ||
                s.Type_livraison.Contains(searchString));
            }

            return livraisons;
        }

        public bool LivraisonExists(int id)
        {
            return _context.Livraisons.Any(e => e.LivraisonID == id);
        }

        public async Task UpdateLivraison(Livraison l)
        {
            _context.Update(l);
            _context.Update(l);
            await _context.SaveChangesAsync();
        }
    }
}
