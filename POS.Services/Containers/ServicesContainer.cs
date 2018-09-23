using Autofac;
using POS.DAL.DBContexts;
using POS.DAL.GenericClasses;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace POS.Services.Containers
{
    public class Factory
    {
        public static IContainer Container;

        public static void CreateBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service")).As(t => t.GetInterfaces()
                .FirstOrDefault(l => l.Name == "I" + t.Name));

            //builder.RegisterType(typeof(ClientsService)).As(typeof(IClientsService));
            builder.RegisterType(typeof(DBInitializer)).As(typeof(IDbInitializer));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            Container = builder.Build();
        }
    }
}
