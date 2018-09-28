using Autofac;
using POS.DAL.DBContexts;
using POS.DAL.Interfaces;
using POS.DAL.Models;
using POS.Services.Containers;
using POS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services.Services
{
    public class InitAppService : IInitAppService
    {
        IDbInitializer dbInitializer;
        IRepository<User> userRepo;
        public InitAppService(IDbInitializer dbInitializer,
            IRepository<User> userRepo)
        {
            this.dbInitializer = dbInitializer;
            this.userRepo = userRepo;
        }

        public void InitApp()
        {
            //Auto Migrate Database
            dbInitializer.Migrate();
        }        
    }
}
