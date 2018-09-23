using POS.DAL.DBContexts;
using POS.DAL.Interfaces;
using POS.DAL.Models;
using POS.Services.Interfaces;
using POS.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Services.Services
{
    class UserService : GenericService<User>, IUserService
    {
        public UserService(IRepository<User> Repository, DataContext dataContext) : base(Repository, dataContext)
        {
        }
        
        public IEnumerable<string> GetUserNames()
        {
            return Repository.Table.Where(t => t.Role == Role.User).Select(u => u.UserName);
        }

        public bool Logon(LoginVM vm)
        {
            var result = Repository.Table.FirstOrDefault(t => t.UserName == vm.UserName && t.Magic == vm.Magic);
            if (result == null)
            {
                InsertNewUser();
                return false;
            }
            return result != null;
        }

        public void InsertNewUser()
        {
            var user = Repository.Add(new User() {
                UserName = "Amro",
                Magic = "123465",
                CreationDate = DateTime.Now,
                Role = Role.SuperAdmin
            });
        }
    }
}
