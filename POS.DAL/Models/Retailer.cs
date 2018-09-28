using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public class Retailer : BaseEntity
    {
        public virtual Person Person { get; set; }
        public virtual List<ProductRetailer> ProductRetailers { get; set; }
    }
}