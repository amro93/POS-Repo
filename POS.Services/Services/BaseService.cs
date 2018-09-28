using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;
using POS.DAL.GenericClasses;
using POS.DAL.Interfaces;
using POS.DAL.Models;
using POS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : class 
    {

        
        public GenericService( )
        {
        }
    }
}
