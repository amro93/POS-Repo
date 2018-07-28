using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public class Client : BaseEntity
    {
        //public virtual Person Person {get; set;}
        public virtual List<Order> Orders { get; set; }
    }
}
