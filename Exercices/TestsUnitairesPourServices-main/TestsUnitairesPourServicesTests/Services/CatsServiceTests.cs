using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsUnitairesPourServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestsUnitairesPourServices.Data;
using TestsUnitairesPourServices.Models;
using TestsUnitairesPourServices.Exceptions;

namespace TestsUnitairesPourServices.Services.Tests
{
    [TestClass()]
    public class CatsServiceTests
    {
        private DbContextOptions<ApplicationDBContext> _options;
        private ApplicationDBContext _db;
        private CatsService _CatsService;

        public CatsServiceTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDBContext>().UseInMemoryDatabase(databaseName: "CatsService" + Guid.NewGuid().ToString()).UseLazyLoadingProxies(true).Options;
            _db = new ApplicationDBContext(_options);
            _CatsService = new CatsService(_db);
        }

        [TestMethod()]
        public void MoveValideTest()
        {
            Cat chat = _db.Cat.First();
            House house1 = _db.House.First();
            House house2 = _db.House.Last();

            Cat? retour = _CatsService.Move(chat.Id, house1, house2);
            Assert.IsNotNull(retour);
        }

        [TestMethod()]
        public void MoveCatNullTest()
        {
            House house1 = _db.House.First();
            House house2 = _db.House.Last();

            Cat? retour = _CatsService.Move(5, house1, house2);
            Assert.IsNull(retour);
        }

        [TestMethod()]
        public void MoveMauvaisHouseTest()
        {
            Assert.ThrowsException<DontStealMyCatException>(() =>
            {
                Cat chat = _db.Cat.First();
                House house1 = _db.House.Find(2)!;
                House house2 = _db.House.Last();

                Cat? retour = _CatsService.Move(chat.Id, house1, house2);

            });
        }

        [TestMethod()]
        public void MoveChatSauvageTest()
        {
            Assert.ThrowsException<WildCatException>(() =>
            {
                Cat chat = _db.Cat.Find(2)!;
                House house1 = _db.House.Find(1)!;
                House house2 = _db.House.Last();

                Cat? retour = _CatsService.Move(chat.Id, house1, house2);

            });
        }
        [TestInitialize]
        public void init()
        {
            Cat[] cats =
            {
                new Cat()
                {
                    Id = 1,
                    Name = "miao",
                    Age = 2
                },
                new Cat()
                {
                    Id = 2,
                    Name = "ni hao",
                    Age = 50
                }

            };
            House[] houses = { 
                new House()
                {
                    Id = 1,
                    Address = "123 sesame street",
                    OwnerName = "Bob",
                    Cats = [],
                },
                new House()
                {
                    Id = 2,
                    Address = "321 sesame street",
                    OwnerName = "boB",
                    Cats = [],
                },
                new House()
                {
                    Id = 3,
                    Address = "longueuil",
                    OwnerName = "ross",
                    Cats = [],
                },
            };

            houses[0].Cats = cats.Where(c=>c.Id == 0).ToList();
            cats[0].House = houses[0];
            _db.AddRange(houses);
            _db.AddRange(cats);
            _db.SaveChanges();
        }
        [TestCleanup]
        public void Dispose()
        {
            _db.Dispose();   
        }
    }
}