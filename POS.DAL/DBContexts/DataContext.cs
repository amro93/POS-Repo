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
        private bool _useLazyLoading = true;

        #endregion

        #region DBSet
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion


        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(_useLazyLoading)
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
