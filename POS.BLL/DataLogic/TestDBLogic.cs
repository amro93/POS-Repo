using CourseManagement.BLL.AppLogic;
using POS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.DataLogic
{
    public class TestDBLogic : BaseLogic<TestDB>
    {
        public TestDB TestDb()
        {
           return base.Add(new TestDB() { Name = "FirstTest" });
        }
    }
}
