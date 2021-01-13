using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IVilleRepository
    {
        IEnumerable<Ville> GetVilles(string searchString);
        Task<Ville> GetVilleById(int id);
        IEnumerable<Ville> GetVilleByName(string name);

        Task AddVille(Ville v);
        Task UpdateVille(Ville v);
        Task DeleteVille(Ville v);
        bool VilleExists(int id);
    }
}
