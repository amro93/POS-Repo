using Microsoft.EntityFrameworkCore;
using POS.DAL.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.DataLogic
{
    public class InitializeDataLogic
    {
        public static void MigrateDBAsync()
        {
            using (var db = new DataContext())
            {
                db.Database.Migrate();
            }
            //var t = new Task(() => {
            //    using (var db = new DataContext())
            //    {
            //            db.Database.Migrate();
            //    }
            //});
            //t.RunSynchronously();
            //t.Start();
        }
    }
}
