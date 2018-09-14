using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class StoresLogic : GenericService<Store>
    {
        public StoresLogic(IRepository<Store> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
