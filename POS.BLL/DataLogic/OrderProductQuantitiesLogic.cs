using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class OrderProductQuantitiesLogic : GenericService<OrderProductQuantity>
    {
        public OrderProductQuantitiesLogic(IRepository<OrderProductQuantity> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
