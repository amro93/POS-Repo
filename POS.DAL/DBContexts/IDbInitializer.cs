using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.DBContexts
{
    public interface IDbInitializer
    {
        void Migrate();
    }
}
