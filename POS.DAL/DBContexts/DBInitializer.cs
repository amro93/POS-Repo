using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DBInitializer : IDbInitializer
    {

        public void Migrate()
        {
            using (var db = new DataContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
