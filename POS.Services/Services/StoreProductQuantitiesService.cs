using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class StoreProductQuantitiesService : GenericService<StoreProductQuantity>
    {
        public StoreProductQuantitiesService(IRepository<StoreProductQuantity> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
