using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class StoresService : GenericService<Store>
    {
        public StoresService(IRepository<Store> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
