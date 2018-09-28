using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.MappingConfigurations
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
