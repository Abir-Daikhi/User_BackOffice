using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IDeviseRepository
    {
        IEnumerable<Devise> GetDevises(string searchString);
        Task<Devise> GetDeviseById(int id);
        IEnumerable<Devise> GetDeviseByName(string name_Devise);
        IEnumerable<Devise> GetDeviseByStatut(int statut_Devise);
        Task AddDevise(Devise d);
        Task UpdateDevise(Devise d);
        Task DeleteDevise(Devise d);
        bool DeviseExists(int id);
    }
}
