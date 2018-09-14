using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class StoreProductQuantitiesLogic : GenericService<StoreProductQuantity>
    {
        public StoreProductQuantitiesLogic(IRepository<StoreProductQuantity> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
