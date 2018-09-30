using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class ProductCategory : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        private ICollection<Product> products;

        public ProductCategory()
        {
        }

        public ProductCategory(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public ICollection<Product> Products { get => LazyLoader.Load(this, ref products); set => products = value; }
    }
}
