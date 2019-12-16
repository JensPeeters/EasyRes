using Data_layer.Interfaces;
using Data_layer.Model;
using Data_layer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestAPI
{
    [TestClass]
    public class BestellingTest
    {
        [DataTestMethod()]
        public void OphalenBestellingenGebruiker()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Bestelling> bestellingen = new List<Bestelling>()
            {
                new Bestelling()
                {
                    BestellingId = 1,
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
                    },
                    DrinkenGereed = false,
                    DrinkenStatus = false,
                    EtenGereed = false,
                    EtenStatus = false,
                    Etenswaren = new List<Product>()
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
                    Gebruiker = new Gebruiker()
                    {
                         GebruikersID = "TestUser"
                    },
                    Restaurant = new Restaurant()
                    {
                         RestaurantId = 1,
                         Naam = "Com a Casa"
                    },
                    TafelNr = 5
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Bestelling>>();
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.Provider).Returns(bestellingen.Provider);
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.Expression).Returns(bestellingen.Expression);
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.ElementType).Returns(bestellingen.ElementType);
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.GetEnumerator()).Returns(bestellingen.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Bestellingen).Returns(mockSet.Object);

            var mockRepo = new Mock<IBestellingenRepository>();
            mockRepo.Setup(a => a.GetBestellingenGebruiker("TestUser", 1)).Returns(mockContext.Object.Bestellingen.ToList());

            var actual = mockRepo.Object.GetBestellingenGebruiker("TestUser", 1);

            // Assert
            mockRepo.Verify(a => a.GetBestellingenGebruiker("TestUser", 1), Times.Once);
            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().TafelNr, 5);
        }

        [DataTestMethod()]
        public void CreateBestellingTest()
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
                      Bestellingen = new List<Bestelling>()
                    }
            }.AsQueryable();

            IQueryable<Gebruiker> gebruikers = new List<Gebruiker>()
            {
                new Gebruiker()
                {
                    GebruikersID = "TestUser"
                }
            }.AsQueryable();

            var bestelling = new Bestelling()
            {
                BestellingId = 1,
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
                    },
                DrinkenGereed = false,
                DrinkenStatus = false,
                EtenGereed = false,
                EtenStatus = false,
                Etenswaren = new List<Product>()
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
                TafelNr = 5,
                Restaurant = restaurants.First(),
                Gebruiker = gebruikers.First()
            };

            IQueryable<Bestelling> bestellingen = new List<Bestelling>().AsQueryable();
           

            var mockSetRestaurant = new Mock<DbSet<Restaurant>>();
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockSetGebruiker = new Mock<DbSet<Gebruiker>>();
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.Provider).Returns(gebruikers.Provider);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.Expression).Returns(gebruikers.Expression);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.ElementType).Returns(gebruikers.ElementType);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.GetEnumerator()).Returns(gebruikers.GetEnumerator());

            var mockSetBestelling = new Mock<DbSet<Bestelling>>();
            mockSetBestelling.As<IQueryable<Bestelling>>().Setup(m => m.Provider).Returns(bestellingen.Provider);
            mockSetBestelling.As<IQueryable<Bestelling>>().Setup(m => m.Expression).Returns(bestellingen.Expression);
            mockSetBestelling.As<IQueryable<Bestelling>>().Setup(m => m.ElementType).Returns(bestellingen.ElementType);
            mockSetBestelling.As<IQueryable<Bestelling>>().Setup(m => m.GetEnumerator()).Returns(bestellingen.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(m => m.Restaurants).Returns(mockSetRestaurant.Object);
            mockContext.Setup(m => m.Gebruikers).Returns(mockSetGebruiker.Object);
            mockContext.Setup(m => m.Bestellingen).Returns(mockSetBestelling.Object);

            var repo = new BestellingenRepository(mockContext.Object);
            var createdBestelling = repo.AddBestelling(1, "TestUser", bestelling);

            // Assert
            mockSetBestelling.Verify(m => m.Add(It.IsAny<Bestelling>()), Times.Once);

        }

        [DataTestMethod()]
        public void DeleteReservatieTest()
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

            IQueryable<Bestelling> bestellingen = new List<Bestelling>()
            {
                new Bestelling()
                {
                   BestellingId = 1,
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
                    },
                DrinkenGereed = false,
                DrinkenStatus = false,
                EtenGereed = false,
                EtenStatus = false,
                Etenswaren = new List<Product>()
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
                TafelNr = 5,
                Gebruiker = new Gebruiker()
                {
                    GebruikersID = "TestUser"
                },
                Restaurant = new Restaurant()
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
                      Gerechten = "Salade"
                }
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Bestelling>>();
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.Provider).Returns(bestellingen.Provider);
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.Expression).Returns(bestellingen.Expression);
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.ElementType).Returns(bestellingen.ElementType);
            mockSet.As<IQueryable<Bestelling>>().Setup(m => m.GetEnumerator()).Returns(bestellingen.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(m => m.Bestellingen).Returns(mockSet.Object);

            var repo = new BestellingenRepository(mockContext.Object);
            var deletedBestelling = repo.DeleteBestellingen("TestUser",1);

            mockContext.Verify(m => m.Bestellingen.Remove(It.IsAny<Bestelling>()), Times.Once);
            Assert.AreEqual(deletedBestelling.Count(), 1);
            Assert.AreEqual(deletedBestelling.First().Gebruiker.GebruikersID, "TestUser");
            // Assert
        }

    }
}
