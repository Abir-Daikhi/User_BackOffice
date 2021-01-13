
using CMS_HERA_MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_HERA_MVC.Models;
using CMS_HERA_MVC.Data;

namespace CMS_HERA_MVC.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext client_context;
        public ClientRepository(DataContext context)
        {
            client_context = context;
        }

        async Task IClientRepository.DeleteClient(Client client)
        {
            client_context.Clients.Remove(client);
            await client_context.SaveChangesAsync();
        }

        IEnumerable<Client> IClientRepository.GetClientByFamilyName(string prenom_client)
        {
            var clients = from s in client_context.Clients
                          select s;
            clients = clients.Where(s => s.prenom_client.Contains(prenom_client));

            return clients;
        }

        IEnumerable<Client> IClientRepository.GetClientByMail(string mail_client)
        {
            var clients = from s in client_context.Clients
                          select s;
            clients = clients.Where(s => s.mail_client.Contains(mail_client));

            return clients;
        }

        IEnumerable<Client> IClientRepository.GetClientByName(string nom_client)
        {
            var clients = from s in client_context.Clients
                          select s;
            clients = clients.Where(s => s.nom_client.Contains(nom_client));

            return clients;
        }

        IEnumerable<Client> IClientRepository.GetClientByNumMobile(string num_mob_client)
        {
            var clients = from s in client_context.Clients
                          select s;
            clients = clients.Where(s => s.num_mob_client.Contains(num_mob_client));

            return clients;
        }

        IEnumerable<Client> IClientRepository.GetClientByNumTel(string num_tel_client)
        {
            var clients = from s in client_context.Clients
                          select s;
            clients = clients.Where(s => s.num_tel_client.Contains(num_tel_client));

            return clients;
        }

        Client IClientRepository.GetClientById(int id_client)
        {
            return client_context.Clients.FirstOrDefault(m => m.id_client == id_client);
        }

        IEnumerable<Client> IClientRepository.GetClientByStatus(bool statut_client)
        {
            return (IEnumerable<Client>)client_context.Clients
                .FirstOrDefault(m => m.statut_client == statut_client);
        }

        IEnumerable<Client> IClientRepository.GetClients(string searchString)
        {
            var clients = from s in client_context.Clients
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.nom_client.Contains(searchString)
                                       || s.prenom_client.Contains(searchString)
                                       || s.mail_client.Contains(searchString)
                                       || s.num_mob_client.Contains(searchString)
                                       || s.num_tel_client.Contains(searchString)
                                       || s.statut_client.ToString().Contains(searchString));
            }

            return clients;
        }

        async Task IClientRepository.UpdateClient(Client client)
        {
            client_context.Update(client);
            await client_context.SaveChangesAsync();
        }

        bool IClientRepository.ClientExists(int id_client)
        {
            return client_context.Clients.Any(e => e.id_client == id_client);
        }

        async Task IClientRepository.AddClient(Client client)
        {
            client_context.Add(client);
            await client_context.SaveChangesAsync();
        }

        public Task UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}


