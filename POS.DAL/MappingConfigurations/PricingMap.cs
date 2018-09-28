using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.MappingConfigurations
{
    public class PricingMap : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
