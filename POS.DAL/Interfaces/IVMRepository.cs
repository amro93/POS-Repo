using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace POS.DAL.Interfaces
{
    public interface IVMRepository<TModel, VM> : IRepository<TModel>
        where TModel : class
        where VM : class, new()
    {
        //IModelConverter<TModel, VM> modelConverter { get; set; }
        VM UpdateVM(VM vm);
        VM GetVMById(object id);
        VM InsertVM(VM vm);
        IEnumerable<VM> GetAllVM();
        IEnumerable<VM> Find(Expression<Func<TModel, bool>> Where);
        VM DeleteVM(VM vm);
        Boolean DeleteById(object id);
        VM SingleVMWhere(Expression<Func<TModel, bool>> filter);
    }
}
