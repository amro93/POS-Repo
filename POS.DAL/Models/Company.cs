using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class Company : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Phone_1 { get; set; }
        public long Phone_2 { get; set; }
        public long Phone_3 { get; set; }
        public long Phone_4 { get; set; }
        public string Notes { get; set; }
        public string LogoUrl { get; set; }

        private Location location;

        public Company()
        {
        }

        public Company(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Location Location
        {
            get => LazyLoader.Load(this, ref location);
            set => location = value;
        }
    }
}
