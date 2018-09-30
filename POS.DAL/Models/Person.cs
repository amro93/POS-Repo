using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{ 
    public enum Gender { Male, Female}

    /// <summary>
    /// This class represents people in the system
    /// </summary>
    public class Person : BaseEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public string Notes { get; set; }
        public string Mobile { get; set; }
        public string AlternativePhone { get; set; }
        public long UserId { get; set; }

        private Client client;
        private User user;
        private Location location;

        public Person()
        {
        }

        public Person(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public User User
        {
            get { return LazyLoader.Load(this, ref user); }
            set { user = value; }
        }

        public Client Client
        {
            get { return LazyLoader.Load(this, ref client); }
            set { client = value; }
        }
        public Location Location { get => LazyLoader.Load(this, ref location); set => location = value; }


    }
}
