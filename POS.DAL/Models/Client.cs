using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class Client : BaseEntity
    {
        public long Id { get; set; }
        //public string Name { get; set; }
        public Client() { }
        public Client(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public long PersonId { get; set; }
        private Person person;

        public Person Person
        {
            get => LazyLoader.Load(this, ref person);
            set => person = value;
        }

        //private ICollection<Order> orders;

        //public ICollection<Order> Orders
        //{
        //    get => LazyLoader.Load(this, ref orders);
        //    set => orders = value;
        //}
    }
}
