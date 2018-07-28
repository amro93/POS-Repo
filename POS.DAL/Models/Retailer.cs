using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public class Retailer : BaseEntity
    {
        public Person Person { get; set; }
        public List<ProductRetailer> ProductRetailers { get; set; }
    }
}