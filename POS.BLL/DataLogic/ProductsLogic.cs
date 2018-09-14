using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class ProductsLogic : GenericService<Product>
    {
        public ProductsLogic(IRepository<Product> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
