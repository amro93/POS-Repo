using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public class InitializeDataService
    {
        public static void MigrateDBAsync()
        {
            using (var db = new DataContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
