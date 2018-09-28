using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using POS.DAL.MappingConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DbCtx : DbContext
    {
        public DbCtx()
            : base()
        {

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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true)
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

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #region Reflection OnModelCreating
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    Type types = typeof(IEntityTypeConfiguration<>);
        //    // get ApplyConfiguration method with reflection
        //    var applyGenericMethod = typeof(ModelBuilder).GetMethods()
        //        .FirstOrDefault(m => m.Name == nameof(ModelBuilder.ApplyConfiguration) &&
        //        m.GetParameters().Any(p => p.ParameterType.Name.Contains("IEntityTypeConfiguration")));
        //    var x = applyGenericMethod.GetParameters().Select(p => p.ParameterType.Name);
        //    // replace GetExecutingAssembly with assembly where your configurations are if necessary
        //    foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
        //        .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters))
        //    {
        //        // use type.Namespace to filter by namespace if necessary
        //        foreach (var iface in type.GetInterfaces())
        //        {
        //            // if type implements interface IEntityTypeConfiguration<SomeEntity>
        //            if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
        //            {
        //                // make concrete ApplyConfiguration<SomeEntity> method
        //                var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
        //                // and invoke that with fresh instance of your configuration type
        //                applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
        //                break;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Not working on UWP 
        /// </summary>
        /// <param name="modelBuilder"></param>

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new ClientMap());
        //    modelBuilder.ApplyConfiguration(new CompanyMap());
        //    modelBuilder.ApplyConfiguration(new LocationMap());
        //    modelBuilder.ApplyConfiguration(new LoginMap());
        //    modelBuilder.ApplyConfiguration(new OrderMap());
        //    modelBuilder.ApplyConfiguration(new OrderProductQuantityMap());
        //    modelBuilder.ApplyConfiguration(new PersonMap());
        //    modelBuilder.ApplyConfiguration(new PricingMap());
        //    modelBuilder.ApplyConfiguration(new ProductCategoryMap());
        //    modelBuilder.ApplyConfiguration(new ProductMap());
        //    modelBuilder.ApplyConfiguration(new ProductRetailerMap());
        //    modelBuilder.ApplyConfiguration(new RetailerMap());
        //    modelBuilder.ApplyConfiguration(new StoreMap());
        //    modelBuilder.ApplyConfiguration(new StoreProductQuantityMap());
        //    modelBuilder.ApplyConfiguration(new UserMap());
        //}
        #endregion

    }
}
