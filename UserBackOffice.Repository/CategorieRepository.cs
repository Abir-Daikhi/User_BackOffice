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
    public class CategorieRepository : ICategorieRepository
    {
        private readonly DataContext _context;

        public CategorieRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Categorie> GetCategories()
        {
            var categories = from s in _context.Categories
                             select s;

            return categories;
        }

        public async Task AddCategorie(Categorie c)
        {
            _context.Add(c);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategorie(Categorie c)
        {
            _context.Categories
                .Remove(c);

            var sou_categories = this.GetSousCategories(c);
            if (sou_categories.Any())
            {
                
                foreach(var categorie in sou_categories)
                {
                    categorie.Pere = 0;
                    _context.Update(categorie);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Categorie> GetCategorieById(int id)
        {
            return await _context.Categories
               .FindAsync(id);
        }

        public IEnumerable<Categorie> GetCategorieByName(string name)
        {
            var categories = from s in _context.Categories
                             select s;
            categories = categories.Where(s => s.Nom_Categorie == name);

            return categories;
        }

        public IEnumerable<Categorie> GetCategorieByStatus(int status)
        {
            var categories = from s in _context.Categories
                             select s;
            categories = categories.Where(s => s.Status_Categorie == status);

            return categories;
        }

        public List<Categorie> GetSousCategories(Categorie c)
        {

            var sou_categories = _context.Categories
                .FromSqlRaw("SELECT * FROM Categorie WHERE Pere = {0}", c.Id)
                .ToList();

            return sou_categories;
        }
        public IEnumerable<Categorie> GetSuperCategories(string searchString)
        {
            var categories = from s in _context.Categories
                             select s;

            
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(
                   s => s.Nom_Categorie.Contains(searchString) ||
                      s.Status_Categorie.ToString().Contains(searchString)

               );
            }
            else
            {
              
                categories = categories.Where(
                   s => s.Pere == 0
               );
            }

            return categories;

        }

        public async Task UpdateCategorie(Categorie c)
        {
            _context.Update(c);
            /*var categorie_pere = await GetCategorieById(c.Pere);
            
            var sous_categorie = this.GetSousCategories(c);
            
            if (sous_categorie.Contains(categorie_pere))
            {
                categorie_pere.Pere = old_pere;
                _context.Update(categorie_pere);
            }
*/
            await _context.SaveChangesAsync();
        }

        public bool CategorieExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

    }
}
