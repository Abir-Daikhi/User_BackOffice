using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class PaysRepository: IPaysRepository
    {
        private readonly DataContext _context;

        public PaysRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Pays> GetPaysActive()
        {
            var pays = from s in _context.Pays
                       select s;

            pays = pays.Where(s => s.statut_pays == 1);


            return pays;
        }

        async Task IPaysRepository.AddPays(Pays p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
           
        }

        async Task IPaysRepository.DeletePays(Pays p)
        {
            _context.Pays.Remove(p);
            await _context.SaveChangesAsync();
        }

        IEnumerable<Pays> IPaysRepository.GetPays(string searchString)
        {
            var pays = from s in _context.Pays
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                pays = pays.Where(s => s.nom_pays.Contains(searchString)
                                       || s.statut_pays.ToString().Contains(searchString));
            }

            return pays;
        }

        async Task<Pays> IPaysRepository.GetPaysById(int id)
        {
            return await _context.Pays.FindAsync(id);
        }

        IEnumerable<Pays> IPaysRepository.GetPaysByName(string name)
        {
            var pays = from s in _context.Pays
                          select s;
            pays = pays.Where(s => s.nom_pays.Contains(name));

            return pays;
        }

        IEnumerable<Pays> IPaysRepository.GetPaysByStatus(int status)
        {
            var pays = from s in _context.Pays
                          select s;
            pays = pays.Where(s => s.statut_pays == status);

            return pays;
        }

        bool IPaysRepository.PaysExists(int id)
        {
            return _context.Pays.Any(e => e.Id == id);
        }

        async Task IPaysRepository.UpdatePays(Pays p)
        {
            _context.Update(p);
            _context.Update(p);
            await _context.SaveChangesAsync();
        }
    }
}
