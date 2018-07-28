using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public enum PricingUnit {Piece, KG, gram}
    public class Pricing : BaseEntity
    {
        public float? SpeacialSellingPrice { get; set; }
        public float? SellingPrice { get; set; }
        public float? BuyingPrice { get; set; }
        public PricingUnit? Unit { get; set; }
    }
}
