using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DataContext : DbContext
    {
        #region pivate
        private bool _useLazyLoading = false;

        #endregion

        #region DBSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        #endregion

        #region Constructors
        public DataContext() : base()
        {

        }
        public DataContext(bool useLazyLoading = false) : base()
        {
            _useLazyLoading = useLazyLoading;
        }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(_useLazyLoading).UseSqlite("Data Source=POS_data.db");
            #region Connection old

            //var connection = new SqliteConnection("Data Source=POS_ProtectedData.db");
            //connection.Open();
            //var command = connection.CreateCommand();
            //command.CommandText = "SELECT quote($password);";
            //command.Parameters.AddWithValue("$password", "password");
            //var quotedPassword = (string)command.ExecuteScalar();
            //command.CommandText = "PRAGMA key = " + quotedPassword;
            //command.Parameters.Clear();
            //command.ExecuteNonQuery();
            //optionsBuilder.UseSqlite(connection); 
            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pricing>().HasMany(p => p.Products).WithOne(pp => pp.Pricing);
        } 
        #endregion
    }
}
