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
using UnitTesting.Mocks;
using ViewModelLayer.Interfaces.Recipient;

namespace UnitTesting
{
    [TestClass]
    public class BillControllerTests
    {
        BillsController controller;
        MockingFactory factory;
        Mock<IBillService> mockBillService;
        Mock<IRecipientService> mockRecipientService;
        Mock<IBillFactory> mockBillFactory;


        [TestInitialize]
        public void Initialize()
        {
            factory = new MockingFactory();

            mockBillService = new Mock<IBillService>();
            mockBillService.Setup(m => m.GetAllBills()).Returns(factory.CreateBillList());
            mockBillService.Setup(m => m.GetBill(1)).Returns(factory.CreateBill());
            mockBillService.Setup(m => m.GetBillTypes()).Returns(factory.CreateBillTypesList());

            mockRecipientService = new Mock<IRecipientService>();
            mockRecipientService.Setup(m => m.GetActiveRecipients()).Returns(factory.CreateRecipients());

            mockBillFactory = new Mock<IBillFactory>();
            mockBillFactory.Setup(m => m.NewBill(It.IsAny<int>(), It.IsAny<int>(), 
                                                It.IsAny<int>(), It.IsAny<string>(), 
                                                It.IsAny<decimal>(), It.IsAny<DateTime>(), 
                                                It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<bool>()
                                                )).Returns(factory.CreateBill());

        }



        [TestMethod]
        public void IndexReturnsBillsListToView()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, null);
            //act
            var result = ((controller.Index("test") as ViewResult).Model) as List<CreateBillVM>;
            //assert
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void DetailsWithoutIdReturnsNotFound()
        {
            //arrange
            controller = new BillsController(null, null, null);
            //act
            var result = controller.Details(null);
            //assert
            Assert.IsInstanceOfType(result,typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void DetailsActionReturnsViewWithBillVM()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, null);
            //act
            var result = controller.Details(1) as ViewResult;
            //assert
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM));
        }

        [TestMethod]
        public void CreateGetActionReturnsViewWithBillVM()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, mockRecipientService.Object);
            //act
            var result = controller.Create() as ViewResult;
            //assert
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePostActionWithValidModelCreatesBillAndRedirectToIndex()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, mockBillFactory.Object, mockRecipientService.Object);
            //act
            var result = controller.Create(new CreateBillVM());
            //assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void CreatePostActionWithInvalidModelReturnsCreateView()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, mockBillFactory.Object, mockRecipientService.Object);
            controller.ModelState.AddModelError("test", "test");
            //act
            var result = controller.Create(new CreateBillVM()) as ViewResult;
            //assert
            mockBillService.Verify(m => m.CreateBill(It.IsAny<IBill>()), Times.Never);
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM)); //returns model to correct errors
        }

        [TestMethod]
        public void EditGetActionWithoutIdReturns404()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, mockBillFactory.Object, mockRecipientService.Object);
            //act
            var result = controller.Edit(1);
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void EditGetActionWithIdReturnsEditViewWithProperVM()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void EditPostActionWithValidModelUpdatesBillAndRedirectsToIndexView()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void EditPostActionWithInvalidModelReturnsEditView()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void PayBillActionWithIdReturnsJsonResult()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void PayBillActionWithoutIdRedirectsToIndex()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteGetActionWithoutIdReturns404()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void DeleteGetActionWithIdReturnsDeleteViewWithModel()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void DeletePostActionRedirectsToIndex()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void CreateTypesListReturnsBillTypeVmList()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void CreateRecipientsListReturnsRecipientList()
        {
            //arrange
            //act
            //assert
            Assert.Fail();
        }
        /*
                [TestMethod]
                public void ()
                {
                    //arrange
                    //act
                    //assert
                    Assert.Fail();
                }
         */
    }
}
