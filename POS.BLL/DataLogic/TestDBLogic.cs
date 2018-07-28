using CourseManagement.BLL.AppLogic;
using POS.DAL.DBContexts;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.DataLogic
{
    public class PricingLogic : BaseLogic<Pricing>
    {

        public PricingLogic(DataContext ctx) : base(ctx)
        {

        }
        public Pricing TestDb()
        {
           var x = repository.Add(new Pricing() { SellingPrice = 10.0f , SpeacialSellingPrice= 9.5f ,
               Unit = PricingUnit.Piece , BuyingPrice=9});
            //x.Products.Add(new Product() { Pricing = x, EnterDate = DateTime.Now });
            //repository._context.SaveChanges();
            return x;
        }
        

        public List<Pricing> GetPricings()
        {
            var x = base.GetList();
            return x;
        }
    }

    public class ProductLogic : BaseLogic<Product>
    {
        public ProductLogic(DataContext ctx) : base(ctx)
        {

        }
        public void TestDb() 
        {
            var pricingRepo = new Repository<Pricing>(_dataContext, true);
            var pricingDb = pricingRepo.GetById(1);
            var x = repository.Add(new Product()
            {
                EnterDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                ModifyDate = DateTime.Now,
            });
            x.Pricing = pricingDb;
            base.repository.Save(x);
        }

        public List<Product> GetProducts()
        {
            var x = base.GetList();
            return x;
        }
    }
}
