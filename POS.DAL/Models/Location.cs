using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{

    public class Location : BaseEntity
    {
        public Location()
        {
        }

        public Location(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public long PersonId{ get; set; }
        private Person person;

        public Person Person
        {
            get { return LazyLoader.Load(this, ref person); }
            set { person = value; }
        }

    }
}
