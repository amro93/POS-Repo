using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class PeopleService : GenericService<Person>
    {
        public PeopleService(IRepository<Person> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
