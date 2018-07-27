using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using POS.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;

namespace CourseManagement.BLL.AppLogic
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        #region Properties
        public DbSet<T> Table { get; set; }
        public DataContext Context { get; set; }
        #endregion

        #region Constructors
        public Repository()
        {
            Context = new DataContext();
            Table = Context.Set<T>();
        }
        public Repository(DataContext context)
        {
            this.Context = context;
            Table = Context.Set<T>();
        }
        #endregion

        #region Functions

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return Table;
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
                var items = await Table.ToListAsync();
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
                return Table.Find(Id);
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
                       select Table.Find(id)).ToList<T>();
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
                return await Table.FindAsync(Id);
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
                Table.Add(t);
                return Context.SaveChanges() > 0 ? t : null;
            }
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
            catch (Exception ex) 
            {
               throw ex;
            }
        }

        public virtual async Task<T> AddAsync(T t)
        {
            try
            {
                Table.Add(t);
                return await Context.SaveChangesAsync() > 0 ? t : null;
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
                
                Context.Entry<T>(t).State = EntityState.Modified;
                var bb = Context.SaveChanges();
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
                Context.Entry<T>(t).State = EntityState.Modified;
                return await Context.SaveChangesAsync() > 0;
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
                Table.Remove(t);
                return Context.SaveChanges() > 0;
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
                Table.Remove(t);
                return await Context.SaveChangesAsync() > 0 ? true : false;
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
                return Table.Count();
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
                return Table.Where(@where);
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
                var items = await Table.Where(@where).ToListAsync();
                return items.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T Single(Expression<Func<T, bool>> where)
        {
            return Table.Single(@where) ?? Table?.SingleOrDefault(@where); //??          
        }

        public virtual T First(Expression<Func<T, bool>> where)
        {
            return Table.Single(where) ?? Table?.SingleOrDefault(@where); 
        }

        //public virtual bool SaveIncluded(T t, params string[] includedProperties)
        //{
        //    try
        //    {
        //        if (includedProperties.Any())
        //        {
        //            Table.Attach(t);
        //            Context.Configuration.ValidateOnSaveEnabled = false;
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
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
