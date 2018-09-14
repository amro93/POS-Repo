using Microsoft.EntityFrameworkCore;
using POS.BLL.Repositories;
using POS.DAL.DBContexts;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public abstract class GenericService<T> where T : class
    {
        protected IRepository<T> Repository {get;set;}
        internal protected DataContext _dataContext { get; set; }
        public GenericService(IRepository<T> repository , DataContext dataContext)
        {
            Repository = repository;
            _dataContext = dataContext;
        }
    }
}
