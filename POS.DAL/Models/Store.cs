using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class Store : BaseEntity
    { 
        public long Id { get; set; }
        public string Name { get; set; }

        private Location location;
        private ICollection<StoreProductQuantity> storeProductQuantities;

        public Store()
        {
        }

        public Store(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Location Location { get => LazyLoader.Load(this, ref location); set => location = value; }
        public ICollection<StoreProductQuantity> StoreProductQuantities { get => LazyLoader.Load(this, ref storeProductQuantities); set => storeProductQuantities = value; }

    }
}
