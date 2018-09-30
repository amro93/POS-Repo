using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class StoreProductQuantity : BaseEntity
    {
        public float Quantity { get; set; }

        public long StoreId { get; set; }
        public long ProductId { get; set; }

        private Product product;
        private Store store;

        public StoreProductQuantity()
        {
        }

        public StoreProductQuantity(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Store Store { get => LazyLoader.Load(this, ref store); set=> store = value; }
        public Product Product { get => LazyLoader.Load(this, ref product); set => product = value; }
        
    }
}
