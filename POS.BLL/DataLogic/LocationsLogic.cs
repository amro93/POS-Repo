using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLL.DataLogic
{
    public class LocationsLogic : GenericService<Location>
    {
        public LocationsLogic(IRepository<Location> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }
    }
}
