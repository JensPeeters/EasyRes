using Data_layer.Interfaces;
using Data_layer.Model;
using Data_layer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestAPI
{
    [TestClass]
    public class ReserveerTest
    {
        [DataTestMethod()]
        public void OphalenReserveringenGebruikerTest()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Reservatie> reservaties = new List<Reservatie>()
            {
                new Reservatie()
                {
                    AantalPersonen = 5,
                    Datum = DateTime.Now.ToString(),
                    Email = "test@email.com",
                    Naam = "Bob",
                    ReservatieId = 1,
                    Restaurant = new Restaurant()
                    {
                        Naam = "Shalaka"
                    },
                    TafelNr = 5,
                    TelefoonNummer = "+32477299417",
                    Tijdstip = "18:00",
                    UserId = "TestUser"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Reservatie>>();
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.Provider).Returns(reservaties.Provider);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.Expression).Returns(reservaties.Expression);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.ElementType).Returns(reservaties.ElementType);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.GetEnumerator()).Returns(reservaties.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Reservaties).Returns(mockSet.Object);

            var mockRepo = new Mock<IReserveringenRepository>();
            mockRepo.Setup(a => a.GetReserveringen("TestUser", "asc")).Returns(mockContext.Object.Reservaties.ToList());

            var actual = mockRepo.Object.GetReserveringen("TestUser", "asc");

            // Assert
            mockRepo.Verify(a => a.GetReserveringen(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().Naam, "Bob");
        }



        [DataTestMethod()]
        public void CreateReservatieTest()
        {

            Openingsuren openingsuren = new Openingsuren()
            {
                Maandag = "16:00 - 23:00",
                Dinsdag = "16:00 - 23:00",
                Woensdag = "16:00 - 23:00",
                Donderdag = "16:00 - 23:00",
                Vrijdag = "16:00 - 23:00",
                Zaterdag = "16:00 - 23:00",
                Zondag = "16:00 - 23:00"
            };
            Adres adres = new Adres()
            {
                Bus = "A",
                Gemeente = "Antwerpen",
                Straat = "Papegaielaan",
                Straatnummer = 10,
                Land = "België",
                Postcode = 2000
            };

            Menu menu = new Menu()
            {
                Desserts = new List<Product>()
                        {
                                new Product()
                                {
                                    Naam = "Dame Blanche",
                                    Prijs = 4.55
                                },
                                new Product()
                                {
                                    Naam = "Brownie",
                                    Prijs = 2.40
                                },
                                new Product()
                                {
                                    Naam = "Crème brûlée",
                                    Prijs = 10.20
                                }
                            },
                Voorgerechten = new List<Product>()
                    {
                                new Product()
                                {
                                    Naam = "Kaaskroketten",
                                    Prijs = 4.70
                                },
                                new Product()
                                {
                                    Naam = "Lookbroodjes",
                                    Prijs = 3.80
                                }
                            },
                Hoofdgerechten = new List<Product>()
                    {
                                new Product()
                                {
                                    Naam = "Verse zalm met aardappelpuree",
                                    Prijs = 23.10
                                },
                                new Product()
                                {
                                    Naam = "Lasagna",
                                    Prijs = 19.10
                                },
                                new Product()
                                {
                                    Naam = "Spareribs 250g",
                                    Prijs = 34.20
                                }
                            },
                Dranken = new List<Product>()
                    {
                                new Product()
                                {
                                    Naam = "Sex on the beach",
                                    Prijs = 3.45
                                },
                                new Product()
                                {
                                    Naam = "Cognac 5cl",
                                    Prijs = 6.50
                                }
                            }
            };

            IQueryable<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                    {
                    RestaurantId = 1,
                      KorteBeschrijving = "Het beste italiaanse restaurant met veel verschillende smaken enzovoort...",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Alles van eten",
                      Type = "Italiaans",
                      Soort = "Trattoria",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5, BezetteMomenten = new List<Tijdsmoment>() },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4, BezetteMomenten = new List<Tijdsmoment>()  },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4, BezetteMomenten = new List<Tijdsmoment>()  },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2, BezetteMomenten = new List<Tijdsmoment>()  },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2, BezetteMomenten = new List<Tijdsmoment>()  }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Salade",
                      Reservaties = new List<Reservatie>()
                    }
            }.AsQueryable();


            var reservatie = new Reservatie()
            {
                AantalPersonen = 5,
                Datum = DateTime.Now.ToString(),
                Email = "test@email.com",
                Restaurant = restaurants.First(),
                Naam = "Bob",
                TelefoonNummer = "+32477299417",
                Tijdstip = "18:00",
                UserId = "TestUser"
            };

            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(m => m.Restaurants).Returns(mockSet.Object);

            var repo = new RestaurantRepository(mockContext.Object);

            repo.AddReservatie(reservatie);

            // Assert
            Assert.AreEqual(mockContext.Object.Restaurants.First().Reservaties.Count(), 1);
        }

        [DataTestMethod()]
        public void DeleteReservatieTest()
        {
            IQueryable<Reservatie> reservaties = new List<Reservatie>()
            {
                new Reservatie()
                {
                   AantalPersonen = 5,
                    Datum = DateTime.Now.ToString(),
                    Email = "test@email.com",
                    Naam = "Bob",
                    ReservatieId = 1,
                    Restaurant = new Restaurant()
                    {
                        RestaurantId = 1,
                        Naam = "Shalaka"
                    },
                    TafelNr = 5,
                    TelefoonNummer = "+32477299417",
                    Tijdstip = "18:00",
                    UserId = "TestUser"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Reservatie>>();
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.Provider).Returns(reservaties.Provider);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.Expression).Returns(reservaties.Expression);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.ElementType).Returns(reservaties.ElementType);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.GetEnumerator()).Returns(reservaties.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(m => m.Reservaties).Returns(mockSet.Object);

            var repo = new ReserveringenRepository(mockContext.Object);
            var deletedReservatie = repo.DeleteReservatie(1, "TestUser");

            mockContext.Verify(m => m.Reservaties.Remove(It.IsAny<Reservatie>()), Times.Once);
            Assert.AreEqual(deletedReservatie.ReservatieId, 1);
            // Assert
        }

        [DataTestMethod()]
        public void OphalenReservatieTest()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Reservatie> reservaties = new List<Reservatie>()
            {
                new Reservatie()
                {
                    AantalPersonen = 5,
                    Datum = DateTime.Now.ToString(),
                    Email = "test@email.com",
                    Naam = "Bob",
                    ReservatieId = 1,
                    Restaurant = new Restaurant()
                    {
                        Naam = "Shalaka"
                    },
                    TafelNr = 5,
                    TelefoonNummer = "+32477299417",
                    Tijdstip = "18:00",
                    UserId = "TestUser"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Reservatie>>();
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.Provider).Returns(reservaties.Provider);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.Expression).Returns(reservaties.Expression);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.ElementType).Returns(reservaties.ElementType);
            mockSet.As<IQueryable<Reservatie>>().Setup(m => m.GetEnumerator()).Returns(reservaties.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Reservaties).Returns(mockSet.Object);

            var mockRepo = new Mock<IReserveringenRepository>();
            mockRepo.Setup(a => a.GetReservatie(1)).Returns(mockContext.Object.Reservaties.Where(a => a.ReservatieId == 1).FirstOrDefault());

            var actual = mockRepo.Object.GetReservatie(1);

            mockRepo.Verify(a => a.GetReservatie(It.IsAny<long>()), Times.Once);
            Assert.AreEqual(actual.ReservatieId, 1);
            Assert.AreEqual(actual.Email, "test@email.com");
            Assert.AreEqual(actual.Naam, "Bob");
            Assert.AreEqual(actual.UserId, "TestUser");
            Assert.AreEqual(actual.Restaurant.Naam, "Shalaka");
        }
    }
}
