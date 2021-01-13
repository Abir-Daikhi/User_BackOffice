using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface ICategorieRepository
    {
        IEnumerable<Categorie> GetSuperCategories(string searchString);

        IEnumerable<Categorie> GetCategories();
        Task<Categorie> GetCategorieById(int id);
        IEnumerable<Categorie> GetCategorieByName(string name);
        IEnumerable<Categorie> GetCategorieByStatus(int status);
        List<Categorie> GetSousCategories(Categorie c);
        Task AddCategorie(Categorie c);
        Task UpdateCategorie(Categorie c);//, int old_pere);
        Task DeleteCategorie(Categorie c);
        bool CategorieExists(int id);
    }
}
