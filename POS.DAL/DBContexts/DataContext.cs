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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<OrderProductQuantity> ProductQuantities { get; set; }
        public DbSet<ProductRetailer> ProductRetailers { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProductQuantity> StoreProductQuantities { get; set; }
        public DbSet<User> Users { get; set; }

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
            optionsBuilder.UseLazyLoadingProxies(_useLazyLoading)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseSqlite("Data Source=POS_data.db");

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

            #region OrderProductQuantity
            modelBuilder.Entity<OrderProductQuantity>().HasOne<Order>(a => a.Order)
                    .WithMany(b => b.OrderProductQuantities)
                    .HasForeignKey(a => a.OrderId);

            modelBuilder.Entity<OrderProductQuantity>().HasOne<Product>(a => a.Product)
                .WithMany(b => b.OrderProductQuantities)
                .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<OrderProductQuantity>().HasKey("ProductId", "OrderId");
            #endregion

            #region StoreProductQuantity

            modelBuilder.Entity<StoreProductQuantity>().HasOne<Store>(a => a.Store)
                .WithMany(b => b.StoreProductQuantities).HasForeignKey(a => a.StoreId);

            modelBuilder.Entity<StoreProductQuantity>().HasOne<Product>(a => a.Product)
                .WithMany(b => b.StoreProductQuantities).HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<StoreProductQuantity>().HasKey("ProductId", "StoreId"); 

            #endregion

            base.OnModelCreating(modelBuilder);
        } 
        #endregion
    }
}
