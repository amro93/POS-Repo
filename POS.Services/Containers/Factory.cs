using Microsoft.Extensions.DependencyInjection;
using POS.DAL.DBContexts;
using POS.DAL.GenericClasses;
using POS.DAL.Interfaces;
using POS.Services.Interfaces;
using POS.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;

namespace POS.Services.Containers
{
    public class Factory
    {
        public static IServiceProvider Container;

        public static void CreateBuilder()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DataContext>();
            services.AddTransient<IDbInitializer, DBInitializer>();
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));


            Dictionary<Type, Type> keyValuePairsServices = new Dictionary<Type, Type>();
            var servs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name.EndsWith("Service") && t.IsClass);
            foreach (var service in servs)
            {
                keyValuePairsServices.Add(service, service.GetInterfaces()
                .FirstOrDefault(l => l.Name == "I" + service.Name));
            }
            foreach(var service in keyValuePairsServices)
            {
                services.AddTransient(service.Value, service.Key);
            }

            Container = services.BuildServiceProvider();

        }
        //public static void CreateBuilder()
        //{
        //    ContainerBuilder builder = new ContainerBuilder();
        //    builder.RegisterType<DataContext>().SingleInstance();

        //    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        //        .Where(t => t.Name.EndsWith("Service")).As(t => t.GetInterfaces()
        //        .FirstOrDefault(l => l.Name == "I" + t.Name));

        //    builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        //    builder.RegisterType(typeof(DBInitializer)).As(typeof(IDbInitializer));

        //    Container = builder.Build();
        //}

    }
}
