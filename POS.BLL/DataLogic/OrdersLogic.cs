using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class OrdersLogic : GenericService<Order>
    {
        public OrdersLogic(IRepository<Order> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
