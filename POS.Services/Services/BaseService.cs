using Microsoft.EntityFrameworkCore;
using POS.BLL.Repositories;
using POS.DAL.DBContexts;
using POS.DAL.Models;
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
        private IRepository<User> repository;
        private DataContext dataContext;

        protected IRepository<T> Repository {get;set;}
        internal protected DataContext _dataContext { get; set; }
        public GenericService(bool useLazyLoading = true)
        {
            _dataContext = new DataContext();
            Repository = new Repository<T>(_dataContext, _useLazyLoading: useLazyLoading);
        }

        protected GenericService(IRepository<User> repository, DataContext dataContext)
        {
            this.repository = repository;
            this.dataContext = dataContext;
        }
    }
}
