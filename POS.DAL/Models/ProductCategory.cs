using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL.Models
{
    public class ProductCategory : BaseIntity
    {
        //public Image Logo { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
