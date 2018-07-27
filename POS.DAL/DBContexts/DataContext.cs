using Microsoft.EntityFrameworkCore;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DataContext : DbContext
    {
        public DbSet<TestDB> TestDBs { get; set; }
        public DataContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=POS_data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
