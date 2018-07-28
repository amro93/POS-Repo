using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL.Models
{
    public class Store : BaseEntity
    { 
        public string Name { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<StoreProductQuantity> StoreProductQuantities { get; set; }

    }
}
