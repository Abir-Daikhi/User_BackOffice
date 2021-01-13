using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBackOffice.Models;
using Microsoft.AspNetCore.Http;

namespace UserBackOffice.Interfaces
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> GetProduits(string searchString);
        Task<Produit> GetProduitById(int id);
        IEnumerable<Produit> GetProduitByName(string name);
        IEnumerable<Produit> GetProduitByStatus(int status);
        Task AddProduit(Produit p);
        Task UpdateProduit(Produit p);
        Task DeleteProduit(Produit p);
        bool ProduitExists(int id);
    }
}
