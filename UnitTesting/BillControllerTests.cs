using System;
using DbAccess.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcUI.Controllers;
using ViewModelLayer.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces;
using MvcUI.Models.Bill;

namespace UnitTesting
{
    [TestClass]
    public class BillControllerTests
    {
        TestDbContext TestDbContext;
        BillsController controller;
        Mock<IBillService> mockBillService;

        [TestInitialize]
        public void Initialize()
        {
            TestDbContext = new TestDbContext();
            mockBillService = new Mock<IBillService>();
            mockBillService.Setup(m => m.GetAllBills()).Returns(CreateBillList());
            mockBillService.Setup(m => m.GetBill(1)).Returns(CreateBill());

        }

        private IBill CreateBill()
        {
            IBill bill = new Bill { BillId = 1, Description = "opis 1", DueAmount = 10.0M, DueDate = DateTime.Now, Paid = false, Period = 3, Periodical = true };
            return bill;
        }

        private IEnumerable<IBill> CreateBillList()
        {
            IEnumerable<IBill> list = new List<Bill>()
            {
                new Bill{ BillId = 1, Description = "opis 1", DueAmount = 10.0M, DueDate = DateTime.Now, Paid = false, Period = 3, Periodical = true },
                new Bill{ BillId = 2, Description = "opis 2", DueAmount = 3.0M, DueDate = DateTime.Now.AddMonths(-1), Paid = false, Period = 1, Periodical = true },
                new Bill{ BillId = 3, Description = "opis 3", DueAmount = 34.0M, DueDate = DateTime.Now.AddMonths(1), Paid = true, Period = 0, Periodical = true }
            };
            return list;
        }

        [TestMethod]
        public void Index_pass_bills_list()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, null);
            //act
            var result = ((controller.Index("test") as ViewResult).Model) as List<CreateBillVM>;
            //assert
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void Details_Without_Id_Returns_NotFound()
        {
            //arrange
            controller = new BillsController(null, null, null);
            //act
            var result = controller.Details(null);
            //assert
            Assert.IsInstanceOfType(result,typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void Details_Action_Returns_View_With_BillVM()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, null);
            //act
            var result = controller.Details(1) as ViewResult;
            //assert
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM));
        }

        [TestMethod]
        public void Mark_Bill_As_Paid()
        {
            //Mock<IBillRepository> mock = new Mock<IBillRepository>();
            //mock.Setup(m=>m.GetAll()).Returns(new Bill[] {
            //    new Bill()
            //})
            Assert.Fail();
        }

        [TestMethod]
        public void Create_Bill_Redirect_To_Index()
        {
            //arrange 
            //Mock<IBillRepository> mock = new Mock<IBillRepository>();
            //BillsController controller = new BillsController(null,null,null);
            //var target = controller.PayBill(1);
            Assert.Fail();
        }
    }
}
