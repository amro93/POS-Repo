using CourseManagement.BLL.AppLogic;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.DataLogic
{
    public abstract class BaseLogic<T> : Repository<T> where T : class
    {
        public List<T> GetList()
        {
            return new List<T>(base.GetAll());
        }

        public async Task<List<T>> GetListAsync()
        {
            return ( new List<T>(await base.GetAllAsync()));
        }

        public List<T> FindList(Expression<Func<T, bool>> where)
        {
            return new List<T>(base.Find(where));
        }

        public async Task<List<T>> FindListAsync(Expression<Func<T, bool>> where)
        {
            return new List<T>(await base.FindAsync(where));
        }
    }
}
