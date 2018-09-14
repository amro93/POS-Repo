using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class ClientsLogic : GenericService<Client>
    {
        public ClientsLogic(IRepository<Client> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
