using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Models
{
    public class StoreProductQuantity
    {
        [Required]
        public float Quantity { get; set; }

        public long StoreId { get; set; }

        public virtual Store Store { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
        
    }
}
