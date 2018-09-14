using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using POS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;

namespace POS.BLL.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        #region Properties
        internal DbSet<T> _dbSet { get; set; }
        internal protected DataContext _context { get; set; }
        #endregion

        #region Constructors
        public Repository(DataContext context, bool _useLazyLoading)
        {
            _context = context;
            context.ChangeTracker.AutoDetectChangesEnabled = true;
            context.ChangeTracker.LazyLoadingEnabled = _useLazyLoading;
            _dbSet = _context.Set<T>();
        }
        #endregion

        #region Functions

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return _dbSet;
                //return _dbSet.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            try
            {
                var items = await _dbSet.ToListAsync();
                //var items = await _dbSet.AsNoTracking().ToListAsync();
                return items.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T GetById(params object[] Id)
        {
            try
            {
                return _dbSet.Find(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual List<T> GetSetById(List<int> idList)
        {
            try
            {
                return (from id in idList
                        select _dbSet.Find(id)).ToList<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> GetByIdAsync(params object[] Id)
        {
            try
            {
                return await _dbSet.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T Add(T t)
        {
            try
            {
                _dbSet.Add(t);
                return _context.SaveChanges() > 0 ? t : null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            #region Old
            //catch (DbEntityValidationException e)
            //{
            //    string err = "";
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        err += $"Entity of Type {eve.Entry.Entity.GetType().Name} 'in state' {eve.Entry.State} 'has the following validation errors:'";
            //        foreach (var valErr in eve.ValidationErrors)
            //        {
            //            err += $"" +
            //                $"-Property: '{valErr.PropertyName}' , Error: {valErr.ErrorMessage}";
            //        }
            //        //logger
            //    }
            //    throw e;
            //    //return null;
            //} 
            #endregion
        }

        public virtual async Task<T> AddAsync(T t)
        {
            try
            {
                //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                //_context.ChangeTracker.AutoDetectChangesEnabled = true;
                _dbSet.Add(t);
                return await _context.SaveChangesAsync() > 0 ? t : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual bool Save(T t)
        {
            try
            {
                _context.Entry<T>(t).State = EntityState.Modified;
                var bb = _context.SaveChanges();
                return bb > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> SaveAsync(T t)
        {
            try
            {
                _context.Entry<T>(t).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public virtual bool Delete(T t)
        {
            try
            {
                _dbSet.Remove(t);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T t)
        {
            try
            {
                _dbSet.Remove(t);
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public virtual int GetTableCount()
        {
            try
            {
                return _dbSet.Count();
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            try
            {
                return _dbSet.Where(@where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> where)
        {
            try
            {
                var items = await _dbSet.Where(@where).ToListAsync();
                return items.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               string includeProperties = "")
        {
            try
            {
                _context.ChangeTracker.LazyLoadingEnabled = false;
                IQueryable<T> query = _dbSet;
                if (filter != null)
                    query = query.Where(filter).AsNoTracking();

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);

                if (orderBy != null)
                    return orderBy(query).AsNoTracking();
                else
                    return query.AsNoTracking();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T Single(Expression<Func<T, bool>> where)
        {
            return _dbSet.Single(@where) ?? _dbSet?.SingleOrDefault(@where); //??          
        }

        public virtual T First(Expression<Func<T, bool>> where)
        {
            return _dbSet.Single(where) ?? _dbSet?.SingleOrDefault(@where);
        }

        //public virtual bool SaveIncluded(T t, params string[] includedProperties)
        //{
        //    try
        //    {
        //        if (includedProperties.Any())
        //        {
        //            Table.Attach(t);
        //            Context.ChangeTracker.AutoDetectChangesEnabled = true;
        //            foreach (var name in includedProperties)
        //            {
        //                Context.Entry(t).Property(name).IsModified = true;
        //            }
        //            var excludedProps = Context.Entry<T>(t).CurrentValues.PropertyNames.Except(includedProperties);
        //            foreach (var name in includedProperties)
        //            {
        //                Context.Entry(t).Property(name).IsModified = false;
        //            }
        //        }
        //        else
        //        {
        //            Context.Entry<T>(t).State = EntityState.Modified;
        //        }
        //        return Context.SaveChanges() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logger.LogError(getMethod: "Save", message: new Repository<TT>(), ex: ex);
        //        throw ex;
        //        //return false;
        //    }
        //}

        //public bool SaveExcluded(T t, params string[] excludedProperties)
        //{
        //    try
        //    {
        //        if (excludedProperties.Any())
        //        {

        //            Table.Attach(t);
        //            //Context.Configuration.ValidateOnSaveEnabled = false;
        //            foreach (var name in excludedProperties)
        //            {
        //                Context.Entry(t).Property(name).IsModified = false;
        //            }
        //            var takenProp = Context.Entry<T>(t).CurrentValues.PropertyNames.Except(excludedProperties);
        //            foreach (var name in takenProp)
        //            {

        //                Context.Entry(t).Property(name).IsModified = true;
        //            }
        //        }
        //        else
        //        {
        //            Context.Entry<T>(t).State = EntityState.Modified;
        //        }
        //        return Context.SaveChanges() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logger.LogError(getMethod: "Save", message: new Repository<TT>(), ex: ex);
        //        throw ex;
        //        //return false;
        //    }
        //}

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
