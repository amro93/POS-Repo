using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace POS.Services
{
    public class ClientsService : GenericService<Client> , IClientsService
    {
        public ClientsService(IRepository<Client> Repository, DataContext dataContext) : base(Repository, dataContext)
        {

        }

        public List<Client> GetAllClients()
        {
            return Repository.GetAll().ToList() ;
        }
    }

    public interface IClientsService : IGenericService<Client>
    {
        List<Client> GetAllClients();
    }
}
