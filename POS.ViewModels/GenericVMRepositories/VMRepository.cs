using POS.DAL.DBContexts;
using POS.DAL.GenericClasses;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace POS.ViewModels.GenericVMRepositories
{
    class VMRepository<TModel, VM> : Repository<TModel>, IVMRepository<TModel, VM>
        where TModel : class
        where VM : class, new()
    {
        IModelConverter<TModel,VM> modelConverter { get; set; }
        
        public VMRepository(IModelConverter<TModel, VM> modelConverter,
            DbCtx context) : base(context)
        {
            this.modelConverter = modelConverter;
        }

        public bool DeleteById(object id)
        {
            return base.Delete(base.GetById(id));
        }

        public bool DeleteVM(VM vm)
        {
            return base.Delete(modelConverter.GetModel(vm));
        }

        public IEnumerable<VM> GetAllVM()
        {
            var vmList = new List<VM>();
            foreach(var entity in Table)
            {
                vmList.Add(modelConverter.GetMappedViewModel(entity));
            }
            return vmList;
        }

        public VM GetVMById(object id)
        {
            return modelConverter.GetMappedViewModel(GetById(id));
        }

        public VM InsertVM(VM vm)
        {
            var model = modelConverter.GetMappedModel(vm);
            model = Add(model);
            return modelConverter.GetMappedViewModel(model);
        }

        public VM SingleVM(Expression<Func<TModel, bool>> where)
        {
            return modelConverter.GetMappedViewModel(base.Single(where));
        }

        public bool UpdateVM(VM vm)
        {
            var model = modelConverter.GetMappedModel(vm);

            return Save(model);
        }

        public IEnumerable<VM> FindVM(Expression<Func<TModel, bool>> where)
        {
            var vmList = new List<VM>();
            var dbModelList = base.Find(where);
            foreach (var entity in dbModelList)
            {
                vmList.Add(modelConverter.GetMappedViewModel(entity));
            }
            return vmList;
        }
    }
}
