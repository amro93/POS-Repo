using Autofac;
using POS.DAL.DBContexts;
using POS.DAL.GenericClasses;
using POS.DAL.Interfaces;
using POS.Services.Interfaces;
using POS.Services.Services;
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
            builder.RegisterType<DbCtx>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service")).As(t => t.GetInterfaces()
                .FirstOrDefault(l => l.Name == "I" + t.Name));

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(DBInitializer)).As(typeof(IDbInitializer));

            Container = builder.Build();
        }
    }
}
