using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mock.depart.Controllers;
using mock.depart.Models;
using mock.depart.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock.depart.Services.Tests
{
    [TestClass()]
    public class BaseServiceTests
    {
        CatsService _catsService;
        CatsController _catsController;
        Mock<CatsService> _mockCatsService;
        Mock<CatsController> _mockCatsController;

        CatOwner _catOwner1;
        CatOwner _catOwner2;

        Cat _cat1;
        Cat _cat2;

        [TestInitialize]
        public void init()
        {
            
            _mockCatsService = new Mock<CatsService>() { CallBase = true };
            _mockCatsController = new Mock<CatsController>(_mockCatsService.Object) { CallBase = true };

            _catsService = new CatsService();
            _catsController = new CatsController(_catsService);

            CatOwner catowner1 = new CatOwner()
            {
                Id = "1"
            };
            CatOwner catowner2 = new CatOwner()
            {
                Id = "2"
            };


            Cat chat1 = new Cat() { 
                Id = 1,
                Name = "popo",
                CuteLevel = Cuteness.BarelyOk,
                CatOwner = catowner1
            };

            Cat chat2 = new Cat()
            {
                Id = 2,
                Name = "poopoo",
                CuteLevel = Cuteness.YouCanKeepIt,
                CatOwner = catowner2
            };

            _catOwner1 = catowner1;
            _catOwner1.Cats = new List<Cat>(){ chat1 };

            _catOwner2 = catowner2;

            _cat1 = chat1;
            _cat1.CatOwner = catowner1;

            _cat2 = chat2;
            _cat2.CatOwner = catowner2;
        }

        [TestMethod()]
        public void DeleteTestValid()
        {
            _mockCatsService.Setup(s => s.Get(1)).Returns(_cat1);
            _mockCatsService.Setup(s => s.Delete(1)).Returns(_cat1);
            _mockCatsController.Setup(s => s.UserId).Returns("1");
            var result = _mockCatsController.Object.DeleteCat(1);

            Assert.IsInstanceOfType(result.Result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }

        [TestMethod()]
        public void DeleteTestNotYours()
        {
            _mockCatsService.Setup(s => s.Get(1)).Returns(_cat1);
            _mockCatsService.Setup(s => s.Delete(1)).Returns(_cat1);
            _mockCatsController.Setup(s => s.UserId).Returns("2");

            var actionresult = _mockCatsController.Object.DeleteCat(1);
            var result = actionresult.Result as BadRequestObjectResult;
            Assert.IsNotNull(result);

            Assert.AreEqual("Cat is not yours", result.Value);
        }

        [TestMethod()]
        public void DeleteTestTropCute()
        {

            Cat newcat = _cat1;
            newcat.Id = 3;
            newcat.CuteLevel = Cuteness.Amazing;
            _mockCatsService.Setup(s => s.Get(3)).Returns(_cat1);
            _mockCatsService.Setup(s => s.Delete(3)).Returns(_cat1);
            _mockCatsController.Setup(s => s.UserId).Returns("1");

            var actionresult = _mockCatsController.Object.DeleteCat(3);
            var result = actionresult.Result as BadRequestObjectResult;
            Assert.IsNotNull(result);

            Assert.AreEqual("Cat is too cute", result.Value);
        }

        [TestMethod()]
        public void ExistePas()
        {
            _mockCatsService.Setup(s => s.Get(It.IsAny<int>())).Returns(value:null);
            _mockCatsController.Setup(s => s.UserId).Returns("1");

            var actionresult = _mockCatsController.Object.DeleteCat(4);
            var result = actionresult.Result as NotFoundResult;
            Assert.IsNotNull(result);
        }
    }
}