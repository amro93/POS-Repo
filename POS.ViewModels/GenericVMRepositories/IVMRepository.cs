using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace POS.ViewModels.GenericVMRepositories
{
    public interface IVMRepository<TModel, VM> : IRepository<TModel>
        where TModel : class
        where VM : class, new()
    {
        //IModelConverter<TModel, VM> modelConverter { get; set; }
        bool UpdateVM(VM vm);
        VM GetVMById(object id);
        VM InsertVM(VM vm);
        IEnumerable<VM> GetAllVM();
        IEnumerable<VM> FindVM(Expression<Func<TModel, bool>> Where);
        bool DeleteVM(VM vm);
        Boolean DeleteById(object id);
        VM SingleVM(Expression<Func<TModel, bool>> filter);
    }
}
