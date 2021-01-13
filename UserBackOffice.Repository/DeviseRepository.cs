using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class DeviseRepository : IDeviseRepository
    {
        private readonly DataContext _context;

        public DeviseRepository(DataContext context)
        {
            _context = context;
        }

        async Task IDeviseRepository.AddDevise(Devise d)
        {
            _context.Add(d);
            await _context.SaveChangesAsync();
        }

        async Task IDeviseRepository.DeleteDevise(Devise d)
        {
            _context.Devises.Remove(d);
            await _context.SaveChangesAsync();
        }

        async Task<Devise> IDeviseRepository.GetDeviseById(int id)
        {

            return await _context.Devises
                .FindAsync(id);
        }

        IEnumerable<Devise> IDeviseRepository.GetDeviseByName(string name)
        {
            var devises = from s in _context.Devises
                        select s;
            devises = devises.Where(s => s.Name_Devise.Contains(name));

            return devises;
        }

        IEnumerable<Devise> IDeviseRepository.GetDeviseByStatut(int status)
        {
            
            var devises = from s in _context.Devises
                        select s;
            devises = devises.Where(s => s.Statut_Devise == status);

            return devises;
        }

        IEnumerable<Devise> IDeviseRepository.GetDevises(string searchString)
        {
            var devises = from s in _context.Devises
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                devises = devises.Where(s => s.Name_Devise.Contains(searchString)
                                       || s.Symbole_Devise.Contains(searchString)
                                       || s.Statut_Devise.ToString().Contains(searchString));
            }

            return devises;

        }

        async Task IDeviseRepository.UpdateDevise(Devise d)
        {
            _context.Update(d);
            await _context.SaveChangesAsync();
        }

        public bool DeviseExists(int id)
        {
            return _context.Devises.Any(e => e.Id_Devise == id);
        }

        public Task UpdateDevise(Devise d)
        {
            throw new NotImplementedException();
        }
    }
}
