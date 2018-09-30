using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class ProductRetailer : BaseEntity
    {
        public long Id { get; set; }

        private Product product;
        private Retailer retailer;

        public ProductRetailer()
        {
        }

        public ProductRetailer(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Product Product { get => LazyLoader.Load(this, ref product); set => product = value; }
        public Retailer Retailer { get => LazyLoader.Load(this, ref retailer); set => retailer = value; }
    }
}
