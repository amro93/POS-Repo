using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class ProductCategoriesService : GenericService<ProductCategory>
    {
        public ProductCategoriesService(IRepository<ProductCategory> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
