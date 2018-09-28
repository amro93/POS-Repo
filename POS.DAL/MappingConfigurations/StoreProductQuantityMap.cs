using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.MappingConfigurations
{
    class StoreProductQuantityMap : IEntityTypeConfiguration<StoreProductQuantity>
    {
        public void Configure(EntityTypeBuilder<StoreProductQuantity> builder)
        {
            builder.HasOne(a => a.Store)
                .WithMany(b => b.StoreProductQuantities).HasForeignKey(a => a.StoreId);
            builder.HasOne(a => a.Product)
                .WithMany(b => b.StoreProductQuantities).HasForeignKey(a => a.ProductId);
            builder.HasKey("ProductId", "StoreId");
        }
    }
}
