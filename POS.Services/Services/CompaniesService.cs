using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class CompaniesService : GenericService<Company>
    {
        public CompaniesService(IRepository<Company> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
