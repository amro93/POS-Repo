using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public class ProductQuantity
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        public float Quantity { get; set; }
    }
}