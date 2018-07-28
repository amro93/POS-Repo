using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public class ProductRetailer
    {
        public Product Product { get; set; }
        public Retailer Retailer { get; set; }
    }
}
