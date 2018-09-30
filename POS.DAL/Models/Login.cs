using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class Login : BaseEntity
    {
        public long Id { get; set; }
        private User user;

        public Login()
        {
        }

        public Login(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public User User
        {
            get => LazyLoader.Load(this, ref user);
            set => user = value;
        }

        public DateTime Date { get; set; }
    }
}
