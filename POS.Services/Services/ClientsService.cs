using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class ClientsService : GenericService<Client>
    {
        public ClientsService(IRepository<Client> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
