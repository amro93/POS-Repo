using POS.DAL.DBContexts;
using POS.DAL.Interfaces;
using POS.DAL.Models;
using POS.Services.Containers;
using POS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Services.Services
{
    public class InitAppService : IInitAppService
    {
        IDbInitializer dbInitializer;
        IRepository<User> userRepo;
        IRepository<Person> personRepo;
        IRepository<Location> locationRepo;
        IRepository<Client> clientRepo;

        public InitAppService(IDbInitializer dbInitializer,
            IRepository<User> userRepo,
            IRepository<Person> personRepo,
            IRepository<Location> locationRepo,
            IRepository<Client> clientRepo)
        {
            this.dbInitializer = dbInitializer;
            this.userRepo = userRepo;
            this.clientRepo = clientRepo;
            this.personRepo = personRepo;
            this.locationRepo = locationRepo;
        }

        public void InitApp()
        {
            //Auto Migrate Database
            dbInitializer.Migrate();
            var x = userRepo.Add(new User()
            {
                Magic = "123456",
                Role = Role.SuperAdmin,
                UserName = "Amro",
                Person = new Person()
                {
                    Gender = Gender.Male,
                    FirstName = "Amro",
                    LastName = "Samy",
                    Age = 26,
                    Location = new Location()
                    {
                        Address = "addr"
                    },
                    Client = new Client()
                    {

                    }
                }
            });

            var y = userRepo.Table;

        }        
    }
}
