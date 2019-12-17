using Data_layer.Filter;
using Data_layer.Interfaces;
using Data_layer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestAPI
{
    [TestClass]
    public class RestaurantTest
    {
        IQueryFilter queryFilter;

        [SetUp]
        public void SetUp()
        {
            queryFilter = new QueryFilter();
        }

        [DataTestMethod()]
        public void OphalenRestaurantsTest()
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
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Villa Belvedere",
                      Type = "Italiaans",
                      Soort = "Restaurant",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Pizza Pasta",
                      RestaurantId = 1
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Restaurants).Returns(mockSet.Object);

            var mockRepo = new Mock<IRestaurantRepository>();
            mockRepo.Setup(a => a.GetRestaurants(queryFilter)).Returns(mockContext.Object.Restaurants.ToList());

            var actual = mockRepo.Object.GetRestaurants(queryFilter);

            // Assert
            mockRepo.Verify(a => a.GetRestaurants(It.IsAny<QueryFilter>()), Times.Once);
            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().Naam, "Villa Belvedere");
            Assert.AreEqual(actual.First().Type, "Italiaans");
            Assert.AreEqual(actual.First().RestaurantId, 1);
            Assert.AreEqual(actual.First().Soort, "Restaurant");
        }

        [DataTestMethod()]
        public void OphalenGeadverteerdeRestaurants()
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
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Villa Belvedere",
                      Type = "Italiaans",
                      Soort = "Restaurant",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Pizza Pasta",
                      RestaurantId = 1
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Restaurants).Returns(mockSet.Object);

            var mockRepo = new Mock<IRestaurantRepository>();
            mockRepo.Setup(a => a.GetRestaurants(queryFilter)).Returns(mockContext.Object.Restaurants.ToList());

            var actual = mockRepo.Object.GetRestaurants(queryFilter);

            // Assert
            mockRepo.Verify(a => a.GetRestaurants(It.IsAny<QueryFilter>()), Times.Once);
            Assert.IsTrue(actual.First().IsAdvertentie);
            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().Naam, "Villa Belvedere");
            Assert.AreEqual(actual.First().Type, "Italiaans");
            Assert.AreEqual(actual.First().RestaurantId, 1);
            Assert.AreEqual(actual.First().Soort, "Restaurant");
        }

        [DataTestMethod()]
        public void OphalenRestaurantTest()
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
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Villa Belvedere",
                      Type = "Italiaans",
                      Soort = "Restaurant",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Pizza Pasta",
                      RestaurantId = 1
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Restaurants).Returns(mockSet.Object);

            var mockRepo = new Mock<IRestaurantRepository>();
            mockRepo.Setup(a => a.GetRestaurant(1)).Returns(mockContext.Object.Restaurants.First());

            var actual = mockRepo.Object.GetRestaurant(1);

            // Assert
            mockRepo.Verify(a => a.GetRestaurant(It.IsAny<long>()), Times.Once);
            Assert.AreEqual(actual.Naam, "Villa Belvedere");
            Assert.AreEqual(actual.Type, "Italiaans");
            Assert.AreEqual(actual.RestaurantId, 1);
            Assert.AreEqual(actual.Soort, "Restaurant");
        }

        [DataTestMethod()]
        public void UpdateRestaurantTest()
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
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Villa Belvedere",
                      Type = "Italiaans",
                      Soort = "Restaurant",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Pizza Pasta",
                      RestaurantId = 1
                }
            }.AsQueryable();

            var restaurant = new Restaurant()
            {
                KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                Openingsuren = openingsuren,
                Locatie = adres,
                LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                Menu = menu,
                Naam = "Villa Belvedere",
                Type = "Chinees",
                Soort = "Restaurant",
                Tafels = new List<Tafel>()
                {
                     new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                      new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 5 }
                },
                IsAdvertentie = true,
                Gerechten = "Chinees",
                RestaurantId = 1
            };

            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Restaurants).Returns(mockSet.Object);

            var mockRepo = new Mock<IRestaurantRepository>();
            mockRepo.Setup(m => m.UpdateRestaurant(It.IsAny<Restaurant>(), It.IsAny<long>())).Returns(restaurant);
            var updatedRestaurant = mockRepo.Object.UpdateRestaurant(restaurant, 1);
            // Assert
            mockRepo.Verify(m => m.UpdateRestaurant(It.IsAny<Restaurant>(), It.IsAny<long>()), Times.Once);
            Assert.AreEqual(updatedRestaurant.Gerechten, "Chinees");
            Assert.AreEqual(updatedRestaurant.Type, "Chinees");
            Assert.AreEqual(updatedRestaurant.Tafels.Count(), 2);

        }
    }
}
