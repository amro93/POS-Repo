using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class OrderProductQuantity : BaseEntity
    {
        public float Quantity { get; set; }

        public long OrderId { get; set; }

        private Order order;

        public long ProductId { get; set; }

        private Product product;

        public OrderProductQuantity()
        {
        }

        public OrderProductQuantity(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Order Order
        {
            get { return LazyLoader.Load(this, ref order); }
            set { order = value; }
        }


        public Product Product
        {
            get { return LazyLoader.Load(this, ref product); }
            set { product = value; }
        }
    }
}