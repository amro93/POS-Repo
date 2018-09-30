using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace POS.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Logo { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public float StoreQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime EnterDate { get; set; }

        private User enteredBy;
        private User modifiedBy;
        private ProductCategory productCategory;
        private ICollection<OrderProductQuantity> orderProductQuantities;
        private ICollection<StoreProductQuantity> storeProductQuantities;
        private ICollection<ProductRetailer> productRetailers;
        private Pricing pricing;

        public Product()
        {
        }

        public Product(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        public Pricing Pricing
        {
            get { return LazyLoader.Load(this, ref pricing); }
            set { pricing = value; }
        }

        public User EnteredBy
        {
            get { return LazyLoader.Load(this, ref enteredBy); }
            set { enteredBy = value; }
        }
        public User ModifiedBy
        {
            get { return LazyLoader.Load(this, ref modifiedBy); }
            set { modifiedBy = value; }
        }
        public ProductCategory ProductCategory
        {
            get { return LazyLoader.Load(this, ref productCategory); }
            set { productCategory = value; }
        }
        public ICollection<OrderProductQuantity> OrderProductQuantities
        {
            get { return LazyLoader.Load(this, ref orderProductQuantities); }
            set { orderProductQuantities = value; }
        }
        public ICollection<StoreProductQuantity> StoreProductQuantities
        {
            get { return LazyLoader.Load(this, ref storeProductQuantities); }
            set { storeProductQuantities = value; }
        }
        public ICollection<ProductRetailer> ProductRetailers
        {
            get { return LazyLoader.Load(this, ref productRetailers); }
            set { productRetailers = value; }
        }
    }
}
