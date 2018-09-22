using POS.BLL.Repositories;
using POS.DAL.DBContexts;
using POS.DAL.Models;
using POS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public class PricingService : GenericService<Pricing>
    {
        public PricingService(IRepository<Pricing> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }

        public Pricing TestDb()
        {
           var x = Repository.Add(new Pricing() { SellingPrice = 10.0f , SpeacialSellingPrice= 9.5f ,
               Unit = PricingUnit.Piece , BuyingPrice=9});
            //x.Products.Add(new Product() { Pricing = x, EnterDate = DateTime.Now });
            //repository._context.SaveChanges();
            return x;
        }
        

        public List<Pricing> GetPricings()
        {
            var x = base.Repository.GetAll().ToList();
            return x;
        }
    }

    public class ProductService : GenericService<Product>
    {
        public ProductService(IRepository<Product> repository, DataContext dataContext) : base(repository, dataContext)
        {
        }

        public void TestDb() 
        {
            var pricingRepo = new Repository<Pricing>(_dataContext, true);
            var pricingDb = pricingRepo.GetById(1);
            var x = Repository.Add(new Product()
            {
                EnterDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
            });
            x.Pricing = pricingDb;
            base.Repository.Save(x);
        }

        public List<Product> GetProducts()
        {
            var x = base.Repository.GetAll().ToList(); ;
            return x;
        }
    }
}
