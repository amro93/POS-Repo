using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public enum OrderType { Indoor, Takeaway, Delivery }

    public class Order : BaseEntity
    {
        public OrderType? Type { get; set; }
        public string Address { get; set; }
        public virtual User SystemUser { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<ProductQuantity> GetProductQuantities { get; set; }
    }
}
