using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class ProductsSerivce : GenericService<Product>
    {
        public ProductsSerivce(IRepository<Product> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
