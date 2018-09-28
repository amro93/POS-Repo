using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Models
{
    public class ProductRetailer : BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual Retailer Retailer { get; set; }
    }
}
