using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class VilleRepository : IVilleRepository
    {
        private readonly DataContext _context;
        public VilleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddVille(Ville v)
        {
            _context.Add(v);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVille(Ville v)
        {
            _context.Villes.Remove(v);
            await _context.SaveChangesAsync();
        }

        public async Task<Ville> GetVilleById(int id)
        {
            return await _context.Villes.FindAsync(id);
        }

        public IEnumerable<Ville> GetVilleByName(string name)
        {
            var ville = from s in _context.Villes
                        select s;
            ville = ville.Where(s => s.Name_ville.Contains(name));

            return ville;
        }

        public IEnumerable<Ville> GetVilles(string searchString)
        {
            var villes = from s in _context.Villes
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                villes = villes.Where(s => s.Name_ville.Contains(searchString));
            }

            return villes;
        }

        public async Task UpdateVille(Ville v)
        {
            _context.Update(v);
            _context.Update(v);
            await _context.SaveChangesAsync();
        }

        public bool VilleExists(int id)
        {
            return _context.Villes.Any(e => e.VilleID == id);
        }
    }
}
