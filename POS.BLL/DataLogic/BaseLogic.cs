using CourseManagement.BLL.AppLogic;
using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.DataLogic
{
    public abstract class BaseLogic<T> where T : class
    {
        protected Repository<T> repository {get;set;}
        protected DataContext _dataContext { get; set; }
        public BaseLogic()
        {
            _dataContext = new DataContext(true);
            repository = new Repository<T>(_dataContext,true);
        }
        public BaseLogic(DataContext dataContext)
        {
            _dataContext = dataContext;
            repository = new Repository<T>(dataContext, true);
        }
        public List<T> GetList()
        {
            return new List<T>(repository.GetAll());
        }

        public async Task<List<T>> GetListAsync()
        {
            return ( new List<T>(await repository.GetAllAsync()));
        }

        public List<T> FindList(Expression<Func<T, bool>> where)
        {
            return new List<T>(repository.Find(where));
        }

        public async Task<List<T>> FindListAsync(Expression<Func<T, bool>> where)
        {
            return new List<T>(await repository.FindAsync(where));
        }
    }
}
