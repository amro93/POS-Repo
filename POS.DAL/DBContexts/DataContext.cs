using Microsoft.EntityFrameworkCore;
using POS.DAL.MappingConfigurations;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DataContext : DbContext
    {
        #region pivate
        private bool _useLazyLoading = false;

        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        #endregion
        #region DBSet
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Location> Locations { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Person> People { get; set; }
        //public DbSet<Pricing> Pricings { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<OrderProductQuantity> OrderProductQuantity { get; set; }
        //public DbSet<ProductRetailer> ProductRetailers { get; set; }
        //public DbSet<Retailer> Retailers { get; set; }
        //public DbSet<Store> Stores { get; set; }
        //public DbSet<StoreProductQuantity> StoreProductQuantities { get; set; }
        //public DbSet<User> Users { get; set; }

        //public override DbSet<TEntity> Set<TEntity>() // where TEntity : class
        //{
        //    return base.Set<TEntity>();
        //}
        #endregion


        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseSqlite("Data Source=POS_data.db");
            base.OnConfiguring(optionsBuilder);
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
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsClass && type.Namespace != null && type.Namespace.EndsWith("MappingConfigurations"))
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)) && type.IsClass);

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
