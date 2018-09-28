using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DBInitializer : IDbInitializer
    {
        DataContext context;

        public DBInitializer(DataContext context)
        {
            this.context = context;
        }

        public void Migrate()
        {
          context.Database.Migrate();
        }
    }
}
