using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public enum Role { SuperAdmin, Admin, User }
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Magic { get; set; }
        [DefaultValue(Role.User)]
        public Role Role { get; set; }
        public string PhotoUrl { get; set; }

        private Person person;
        private ICollection<Order> orders;
        private ICollection<Login> logins;

        public User()
        {
        }

        public User(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Person Person { get => LazyLoader.Load(this, ref person); set => person = value; }
        //public ICollection<Order> Orders { get => LazyLoader.Load(this, ref orders); set => orders = value; }
        //public ICollection<Login> Logins { get => LazyLoader.Load(this, ref logins); set => logins = value; }
    }
}
