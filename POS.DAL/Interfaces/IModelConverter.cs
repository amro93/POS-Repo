using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Interfaces
{
    public interface IModelConverter<T> where T : class
    {
        T GetModel();
    }
    public interface IModelConverter<TModel, VM>
     where TModel : class
     where VM : class, new()
    {
        TModel GetModel(VM vm);
        TModel GetMappedModel(VM vm);
        VM GetMappedViewModel(TModel model);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="VM"></typeparam>
    /// <typeparam name="TMapInput">Input view model used for mapping</typeparam>
    public interface IModelConverter<TModel, VM, in TMapInput> : IModelConverter<TModel, VM>
     where TModel : class, new()
     where VM : class, new()
    {
        TModel GetModel(VM vm, TMapInput obj);
        TModel GetMappedModel(VM vm, TMapInput obj);
        VM GetMappedViewModel(TModel model, TMapInput obj);
    }
}
