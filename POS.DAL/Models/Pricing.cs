using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public enum PricingUnit {Piece, KG, gram}
    public class Pricing : BaseEntity
    {
        public Pricing()
        {
        }

        public Pricing(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public long Id { get; set; }
        public float? SpeacialSellingPrice { get; set; }
        public float? SellingPrice { get; set; }
        public float? BuyingPrice { get; set; }
        public PricingUnit? Unit { get; set; }
    }
}
