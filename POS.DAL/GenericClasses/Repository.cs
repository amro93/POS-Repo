using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using POS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;

namespace POS.DAL.GenericClasses
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        #region Properties
        private DbSet<T> _entities { get; set; }
        protected DataContext context { get; set; }
        public virtual IQueryable<T> Table { get => this.Entities; }
        #endregion

        #region Constructors
        public Repository(DataContext context)
        {
            this.context = context;
            //context.ChangeTracker.AutoDetectChangesEnabled = true;
            //context.ChangeTracker.LazyLoadingEnabled = _useLazyLoading;
            //_entities = _context.Set<T>();
        }
        #endregion

        #region Functions

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return Entities;
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
                var items = await Entities.ToListAsync();
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
                return Entities.Find(Id);
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
                        select Entities.Find(id)).ToList<T>();
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
                return await Entities.FindAsync(Id);
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
                Entities.Add(t);
                return context.SaveChanges() > 0 ? t : null;
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
                Entities.Add(t);
                return await context.SaveChangesAsync() > 0 ? t : null;
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
                context.Entry<T>(t).State = EntityState.Modified;
                var bb = context.SaveChanges();
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
                context.Entry<T>(t).State = EntityState.Modified;
                return await context.SaveChangesAsync() > 0;
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
                Entities.Remove(t);
                return context.SaveChanges() > 0;
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
                Entities.Remove(t);
                return await context.SaveChangesAsync() > 0 ? true : false;
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
                return Entities.Count();
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
                return Entities.Where(@where);
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
                var items = await Entities.Where(@where).ToListAsync();
                return items.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public virtual T Single(Expression<Func<T, bool>> where)
        {
            return Entities.Single(@where) ?? Entities?.SingleOrDefault(@where); //??          
        }

        public virtual T First(Expression<Func<T, bool>> where)
        {
            return Entities.Single(where) ?? Entities?.SingleOrDefault(@where);
        }
        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = context.Set<T>();
                }
                return _entities;
            }
        }


        //public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
        //                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //                                       string includeProperties = "")
        //{
        //    try
        //    {
        //        _context.ChangeTracker.LazyLoadingEnabled = false;
        //        IQueryable<T> query = _entities;
        //        if (filter != null)
        //            query = query.Where(filter).AsNoTracking();

        //        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //            query = query.Include(includeProperty);

        //        if (orderBy != null)
        //            return orderBy(query).AsNoTracking();
        //        else
        //            return query.AsNoTracking();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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



    }
}
