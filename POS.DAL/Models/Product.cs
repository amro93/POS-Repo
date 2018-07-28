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
        public string Name { get; set; }
        public float StoreQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime EnterDate { get; set; }
        public virtual Pricing Pricing { get; set; }
        public virtual User EnteredBy { get; set; }
        public virtual User ModifiedBy { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual List<OrderProductQuantity> OrderProductQuantities { get; set; }
        public virtual List<StoreProductQuantity> StoreProductQuantities { get; set; }
        public virtual List<ProductRetailer> ProductRetailers { get; set; }
    }
}
