using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBackOffice.Models;

namespace UserBackOffice.Interfaces
{
    public interface IClientRepository 
    {
        IEnumerable<Client> GetClients(string searchString);
        Client GetClientById(int id);
        IEnumerable<Client> GetClientByName(string nom_client);
        IEnumerable<Client> GetClientByFamilyName(string prenom_client);
        IEnumerable<Client> GetClientByMail(string mail_client);
        IEnumerable<Client> GetClientByNumMobile(string num_mob_client);
        IEnumerable<Client> GetClientByNumTel(string num_tel_client);
        IEnumerable<Client> GetClientByStatus(bool statut_client);
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(Client client);
        bool ClientExists(int id_client);
    }
}
