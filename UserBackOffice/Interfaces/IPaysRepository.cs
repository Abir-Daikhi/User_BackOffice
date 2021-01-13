using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IPaysRepository
    {
        IEnumerable<Pays> GetPays(string searchString);
        Task<Pays> GetPaysById(int id);
        IEnumerable<Pays> GetPaysActive();
        IEnumerable<Pays> GetPaysByName(string name);
        IEnumerable<Pays> GetPaysByStatus(int status);
        Task AddPays(Pays p);
        Task UpdatePays(Pays p);
        Task DeletePays(Pays p);
        bool PaysExists(int id);
    }
}
