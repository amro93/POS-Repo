using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.MappingConfigurations
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
