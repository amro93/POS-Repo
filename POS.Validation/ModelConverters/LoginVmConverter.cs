using POS.DAL.GenericClasses;
using POS.DAL.Interfaces;
using POS.DAL.Models;
using POS.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Validation.ModelConverters
{
    public class LoginVmConverter : IModelConverter<User,LoginVM>
    {
        public User GetMappedModel(LoginVM vm)
        {
            throw new NotImplementedException();
        }

        public LoginVM GetMappedViewModel(User model)
        {
            throw new NotImplementedException();
        }

        public User GetModel(LoginVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
