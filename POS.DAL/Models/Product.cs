using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL.Models
{
    public class Product : BaseIntity
    {
        public DateTime ExpirationDate { get; set; }
        public DateTime EnterDate { get; set; }
        //public virtual Person EnteredBy { get; set; }
        //public virtual Person ModifiedBy { get; set; }

        public virtual Pricing Pricing { get; set; }
        //public virtual List<Product> Products { get; set; }
    }
}
