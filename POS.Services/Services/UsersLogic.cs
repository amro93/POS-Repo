using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class UsersSerivce : GenericService<User>
    {
        public UsersSerivce(bool useLazyLoading = true) : base(useLazyLoading)
        {

        }
    }
}
