using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class MarqueRepository : IMarqueRepository
    {
        private readonly DataContext _context;

        public MarqueRepository(DataContext context)
        {
            _context = context;
        }

        async Task IMarqueRepository.AddMarque(Marque m)
        {
            _context.Add(m);
            await _context.SaveChangesAsync();
        }

        async Task IMarqueRepository.DeleteMarque(Marque m)
        {
            _context.Marques.Remove(m);
            await _context.SaveChangesAsync();
        }

        async Task<Marque> IMarqueRepository.GetMarqueById(int id)
        {

            return await _context.Marques
                .FindAsync(id);
        }

        IEnumerable<Marque> IMarqueRepository.GetMarqueByName(string name)
        {
            var marques = from s in _context.Marques
                          select s;
            marques = marques.Where(s => s.Name_Marque.Contains(name));

            return marques;
        }

        IEnumerable<Marque> IMarqueRepository.GetMarqueByStatut(int status)
        {
            
            var marques = from s in _context.Marques
                          select s;
            marques = marques.Where(s => s.Statut_Marque == status);

            return marques;
        }

        IEnumerable<Marque> IMarqueRepository.GetMarques(string searchString)
        {
            var marques = from s in _context.Marques
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                marques = marques.Where(s => s.Name_Marque.Contains(searchString)
                                       || s.Statut_Marque.ToString().Contains(searchString));
            }

            return marques;

        }

        async Task IMarqueRepository.UpdateMarque(Marque m)
        {
            _context.Update(m);
            await _context.SaveChangesAsync();
        }

        public bool MarqueExists(int id)
        {
            return _context.Marques.Any(e => e.Id == id);
        }

    }
}
