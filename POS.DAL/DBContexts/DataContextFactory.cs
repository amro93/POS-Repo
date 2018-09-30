using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.DBContexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .UseSqlite("Data Source=POS_data.db");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
