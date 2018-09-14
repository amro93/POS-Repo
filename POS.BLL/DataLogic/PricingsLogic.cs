using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class PricingsLogic : GenericService<Pricing>
    {
        public PricingsLogic(IRepository<Pricing> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
