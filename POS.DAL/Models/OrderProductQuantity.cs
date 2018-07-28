using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Models
{
    public class OrderProductQuantity
    {
        [Required]
        public float Quantity { get; set; }

        public long OrderId { get; set; }

        public virtual Order Order { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}