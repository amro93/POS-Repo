using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class Retailer : BaseEntity
    {
        public long Id { get; set; }

        private Person person;
        private ICollection<ProductRetailer> productRetailers;

        public Retailer()
        {
        }

        public Retailer(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Person Person { get => LazyLoader.Load(this, ref person); set => person = value; }
        public ICollection<ProductRetailer> ProductRetailers { get => LazyLoader.Load(this, ref productRetailers); set => productRetailers = value; }
    }
}