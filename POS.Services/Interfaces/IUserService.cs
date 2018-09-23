using POS.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUserNames();
        bool Logon(LoginVM vm);

    }
}
