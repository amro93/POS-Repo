using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.MappingConfigurations
{
    public class OrderProductQuantityMap : IEntityTypeConfiguration<OrderProductQuantity>
    {
        public void Configure(EntityTypeBuilder<OrderProductQuantity> builder)
        {
            builder.HasOne(a => a.Order)
                .WithMany(b => b.OrderProductQuantities)
                .HasForeignKey(a => a.OrderId);

            builder.HasOne<Product>(a => a.Product)
                .WithMany(b => b.OrderProductQuantities)
                .HasForeignKey(a => a.ProductId);

            builder.HasKey("ProductId", "OrderId");
        }
    }
}
