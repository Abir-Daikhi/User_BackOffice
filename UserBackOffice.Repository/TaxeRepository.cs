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
    public class TaxeRepository : ITaxesRepository
    {
        private readonly DataContext _context;

        public TaxeRepository(DataContext context)
        {
            _context = context;
        }

        async Task ITaxesRepository.AddTaxe(Taxe t)
        {
            _context.Add(t);
             await _context.SaveChangesAsync();
        }

        async Task ITaxesRepository.DeleteTaxe(Taxe t)
        {
            _context.Taxes.Remove(t);
            await _context.SaveChangesAsync();
        }

        async Task<Taxe> ITaxesRepository.GetTaxeById(int id)
        {

            return await _context.Taxes
                .FindAsync(id);
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxeByName(string name)
        {
            var taxes = from s in _context.Taxes
                        select s;
            taxes = taxes.Where(s => s.Nom_Taxe.Contains(name));

            return taxes;
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxeByStatus(int status)
        {
            /*return (IEnumerable<Taxe>) _context.Taxes
                .FirstOrDefault(m => m.Status_Taxe == status);*/
            var taxes = from s in _context.Taxes
                        select s;
            taxes = taxes.Where(s => s.Status_Taxe==status);
            
            return taxes;
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxeByValeur(int valeur)
        {
            var taxes = from s in _context.Taxes
                        select s;
            taxes = taxes.Where(s => s.Valeur_Taxe == valeur);

            return  taxes;
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxes(string searchString)
        {
            var taxes = from s in _context.Taxes
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                taxes = taxes.Where(s => s.Nom_Taxe.Contains(searchString)
                                       || s.Valeur_Taxe.ToString().Contains(searchString)
                                       || s.Status_Taxe.ToString().Contains(searchString));
            }
            
            return  taxes;

        }

        async Task ITaxesRepository.UpdateTaxe(Taxe t)
        {
            _context.Update(t);
            await _context.SaveChangesAsync();
        }

        public bool TaxeExists(int id)
        {
            return _context.Taxes.Any(e => e.Id == id);
        }
    }
}
