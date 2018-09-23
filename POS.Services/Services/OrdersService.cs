using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services
{
    public class OrdersService : GenericService<Order>
    {
        public OrdersService(IRepository<Order> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
