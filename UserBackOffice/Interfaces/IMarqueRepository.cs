using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IMarqueRepository
    {
        IEnumerable<Marque> GetMarques(string searchString);
        Task<Marque> GetMarqueById(int id);
        IEnumerable<Marque> GetMarqueByName(string name_Marque);
        IEnumerable<Marque> GetMarqueByStatut(int statut_Marque);
        Task AddMarque(Marque d);
        Task UpdateMarque(Marque d);
        Task DeleteMarque(Marque d);
        bool MarqueExists(int id);
    }
}
