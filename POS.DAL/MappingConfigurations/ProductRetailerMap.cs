using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.MappingConfigurations
{
    public class ProductRetailerMap : IEntityTypeConfiguration<ProductRetailer>
    {
        public void Configure(EntityTypeBuilder<ProductRetailer> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
