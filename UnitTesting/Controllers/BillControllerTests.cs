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
        public void EditGetActionWithoutIdDoesntInvokeService()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, mockBillFactory.Object, mockRecipientService.Object);
            //act
            int? nullValue = null;
            var result = controller.Edit(nullValue);
            //assert
            mockBillService.Verify(m => m.GetBill(It.IsAny<int>()), Times.Never);          
        }

        [TestMethod]
        public void EditGetActionWithIdReturnsEditViewWithProperVM()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, mockBillFactory.Object, mockRecipientService.Object);
            //act
            var result = controller.Edit(1) as ViewResult;
            //assert
            mockBillService.Verify(m => m.GetBill(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM));
        }

        [TestMethod]
        public void EditPostActionWithValidModelUpdatesBillAndRedirectsToIndexView()
        {
            //arrange
            controller = new BillsController(mockBillService.Object,
                                                mockBillFactory.Object,
                                                null);
            //act
            var result = controller.Edit(new CreateBillVM()) as RedirectToRouteResult;
            //assert
            mockBillService.Verify(m => m.UpdateBill(It.IsAny<IBill>()), Times.Once);
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [TestMethod]
        public void EditPostActionWithInvalidModelReturnsEditView()
        {
            //arrange
            controller = new BillsController(mockBillService.Object,
                                                mockBillFactory.Object,
                                                null);
            controller.ModelState.AddModelError("test", "test");
            //act
            var result = controller.Edit(new CreateBillVM()) as ViewResult;
            //assert
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM));
            mockBillService.Verify(m => m.UpdateBill(It.IsAny<IBill>()), Times.Never);
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
            controller = new BillsController(mockBillService.Object, null, null);
            int? nullvalue = null;
            //act
            var result = controller.Delete(nullvalue);
            //assert
            mockBillService.Verify(m => m.GetBill(It.IsAny<int>()), Times.Never);
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void DeleteGetActionWithIdReturnsDeleteViewWithModel()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, null);
            //act
            var result = controller.Delete(1) as ViewResult;
            //assert
            mockBillService.Verify(m => m.GetBill(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(result.Model, typeof(CreateBillVM));
        }

        [TestMethod]
        public void CreateTypesListReturnsBillTypeVmList()
        {
            //arrange
            controller = new BillsController(mockBillService.Object, null, null);
            //act
            var result = controller.CreateTypesList();
            //assert
            Assert.AreEqual(result[0].Name, "Prąd");
        }

        [TestMethod]
        public void CreateRecipientsListReturnsRecipientList()
        {
            //arrange
            controller = new BillsController(null, null, mockRecipientService.Object);
            //act
            var result = controller.CreateRecipientsList();
            //assert
            Assert.AreEqual(result[0].CompanyName,"Tauron");
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
