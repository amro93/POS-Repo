
using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class ProductRetailersSerivce : GenericService<ProductRetailer>
    {
        public ProductRetailersSerivce(IRepository<ProductRetailer> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
