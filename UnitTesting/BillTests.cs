using System;
using DbAccess.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcUI.Controllers;
using ViewModelLayer.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class BillTests
    {
        //initialize repository moq for testing puroposes
        public BillTests()
        {
            IList<DbAccess.Entities.Bill> bills = new List<DbAccess.Entities.Bill>()
            {
                new DbAccess.Entities.Bill{ BillId = 1, Description = "opis 1", DueAmount = 10.0M, DueDate = DateTime.Now, Paid = false, Period = 3, Periodical = true },
                new DbAccess.Entities.Bill{ BillId = 2, Description = "opis 2", DueAmount = 3.0M, DueDate = DateTime.Now.AddMonths(-1), Paid = false, Period = 1, Periodical = true },
                new DbAccess.Entities.Bill{ BillId = 3, Description = "opis 3", DueAmount = 34.0M, DueDate = DateTime.Now.AddMonths(1), Paid = true, Period = 0, Periodical = true }
            };
            Mock<IBillRepository> mock = new Mock<IBillRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(bills);
        }


        [TestMethod]
        public void Mark_Bill_As_Paid()
        {
            //Mock<IBillRepository> mock = new Mock<IBillRepository>();
            //mock.Setup(m=>m.GetAll()).Returns(new Bill[] {
            //    new Bill()
            //})
        }

        [TestMethod]
        public void Create_Bill_Redirect_To_Index()
        {
            //arrange 
            Mock<IBillRepository> mock = new Mock<IBillRepository>();

            BillsController controller = new BillsController(null,null,null);
            var target = controller.PayBill(1);
        }
    }
}
