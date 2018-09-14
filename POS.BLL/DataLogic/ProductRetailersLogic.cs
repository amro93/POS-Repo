using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class ProductRetailersLogic : GenericService<ProductRetailer>
    {
        public ProductRetailersLogic(IRepository<ProductRetailer> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
