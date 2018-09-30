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
            builder.HasOne(t => t.Client).WithOne(t => t.Person).HasForeignKey<Client>(t => t.PersonId);
            builder.HasOne(t => t.User).WithOne(t => t.Person).HasForeignKey<Person>(t => t.UserId);
            builder.HasOne(t => t.Location).WithOne(t => t.Person).HasForeignKey<Location>(t => t.PersonId);

            builder.ToTable("People");

        }
    }
}
