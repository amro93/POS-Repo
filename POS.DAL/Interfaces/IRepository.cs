using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<IQueryable<T>> GetAllAsync();
        T GetById(params object[] Id);
        Task<T> GetByIdAsync(params object[] Id);
        T Add(T t);
        Task<T> AddAsync(T t);
        bool Save(T t);
        Task<bool> SaveAsync(T t);
        bool Delete(T t);
        Task<bool> DeleteAsync(T t);
        int GetTableCount();
        IQueryable<T> Find(Expression<Func<T, bool>> where);
        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);
        T First(Expression<Func<T, bool>> where);
        IQueryable<T> Table { get;  }
        //bool SaveIncluded(T t, params string[] includedProperties);
        //bool SaveExcluded(T t, params string[] excludedProperties);
        }
}
