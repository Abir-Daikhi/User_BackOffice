using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface ITaxesRepository
    {
        IEnumerable<Taxe> GetTaxes(string searchString);
        Task<Taxe> GetTaxeById(int id);
        IEnumerable<Taxe> GetTaxeByName(string name);
        IEnumerable<Taxe> GetTaxeByValeur(int valeur);
        IEnumerable<Taxe> GetTaxeByStatus(int status);
        Task AddTaxe(Taxe t);
        Task UpdateTaxe(Taxe t);
        Task DeleteTaxe(Taxe t);
        bool TaxeExists(int id);
    }
}
