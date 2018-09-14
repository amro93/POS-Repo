using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class UsersLogic : GenericService<User>
    {
        public UsersLogic(IRepository<User> repository, DataContext dataContext) : base(repository, dataContext)
        {

        }
    }
}
