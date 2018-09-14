using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class PeopleLogic : GenericService<Person>
    {
        public PeopleLogic(IRepository<Person> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
