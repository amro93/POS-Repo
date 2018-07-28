using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL.Models
{
    public class Store : BaseIntity
    {
        public List<ProductCategory> ProductCategories { get; set; }

    }
}
