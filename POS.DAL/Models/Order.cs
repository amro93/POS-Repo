using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public enum OrderType { Indoor, Takeaway, Delivery }

    public class Order : BaseEntity
    {
        public long Id { get; set; }
        public OrderType? Type { get; set; }
        public string Address { get; set; }
        public long ClientId { get; set; }
        private User user;

        public User User
        {
            get => LazyLoader.Load(this, ref user);
            set => user = value;
        }

        private Client client;
        private ICollection<OrderProductQuantity> orderProductQuantities;

        public Order()
        {
        }

        public Order(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Client Client
        {
            get { return LazyLoader.Load(this, ref client); }
            set { client = value; }
        }

        public ICollection<OrderProductQuantity> OrderProductQuantities
        {
            get { return LazyLoader.Load(this, ref orderProductQuantities); }
            set { orderProductQuantities = value; }
        }
    }
}
