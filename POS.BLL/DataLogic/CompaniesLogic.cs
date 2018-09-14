using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class CompaniesLogic : GenericService<Company>
    {
        public CompaniesLogic(IRepository<Company> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
