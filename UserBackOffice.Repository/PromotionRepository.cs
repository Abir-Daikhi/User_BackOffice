using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DataContext _context;

        public PromotionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddPromorion(Promotion p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePromotion(Promotion p)
        {
            _context.Promotions.Remove(p);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Promotion> GetPromotionByName(string name)
        {
            var promotions = from s in _context.Promotions
                             select s;
            promotions = promotions.Where(s => s.Name_promotion.Contains(name));

            return promotions;
        }

        public IEnumerable<Promotion> GetPromotionByStatus(int status)
        {
            var promotions = from s in _context.Promotions
                             select s;
            promotions = promotions.Where(s => s.Statut_promotion == status);

            return promotions;
        }

        public IEnumerable<Promotion> GetPromotionByValeur(float valeur)
        {
            var promotions = from s in _context.Promotions
                             select s;
            promotions = promotions.Where(s => s.Valeur_promotion == valeur);

            return promotions;
        }

        public IEnumerable<Promotion> GetPromotion(string searchString)
        {
            var promotions = from s in _context.Promotions
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                promotions = promotions.Where(s => s.Name_promotion.Contains(searchString)
                                       || s.Statut_promotion.ToString().Contains(searchString)
                                       || s.Valeur_promotion.ToString().Contains(searchString));
            }

            return promotions;
        }

        public async Task<Promotion> GetPromotionById(int id)
        {
            return await _context.Promotions.FindAsync(id);
        }

        public bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.PromotionID == id);
        }

        public async Task UpdatePromotion(Promotion p)
        {
            _context.Update(p);
            _context.Update(p);
            await _context.SaveChangesAsync();
        }
    }
}
