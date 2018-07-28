using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public enum PricingUnit {Piece, KG, gram}
    public class Pricing : BaseIntity
    {
        public float? SpeacialSellingPrice { get; set; }
        public float? SellingPrice { get; set; }
        public float? BuyingPrice { get; set; }
        public PricingUnit? Unit { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
