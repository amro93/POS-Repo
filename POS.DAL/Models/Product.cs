using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL.Models
{
    public class Product : BaseEntity
    {
        //public Image Logo { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime EnterDate { get; set; }
        public virtual Person EnteredBy { get; set; }
        public virtual Person ModifiedBy { get; set; }
        public virtual Pricing Pricing { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<ProductQuantity> ProductQuantities { get; set; }
        public virtual List<ProductRetailer> ProductRetailers { get; set; }
    }
}
