using UserBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBackOffice.Interfaces
{
    public interface IAdresseRepository
    {
        IEnumerable<Adresse> GetAdresses(string searchString);
        Task<Adresse> GetAdresseById(int id);
        IEnumerable<Adresse> GetAdresseByPostal(int postal);
        IEnumerable<Adresse> GetAdresseByStatus(int status);
        Task AddAdresse(Adresse a);
        Task UpdateAdresse(Adresse a);
        Task DeleteAdresse(Adresse a);
        bool AdresseExists(int id);
    }
}
