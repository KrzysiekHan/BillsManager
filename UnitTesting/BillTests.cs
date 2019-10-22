using System;
using DbAccess.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcUI.Controllers;
using ViewModelLayer.Models;

namespace UnitTesting
{
    [TestClass]
    public class BillTests
    {
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
            Mock<IBillRepository> mock = new Mock<IBillRepository>();
        }
    }
}
