using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{ 
    public enum OrderType { Indoor, Takeaway, Delivery }
    public class Order : BaseIntity
    {
        List<Product> Products { get; set; }

    }
}
