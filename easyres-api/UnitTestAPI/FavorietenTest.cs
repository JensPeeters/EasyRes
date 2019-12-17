using Data_layer.Interfaces;
using Data_layer.Model;
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
    public class FavorietenTest
    {
        [DataTestMethod()]
        public void OphalenFavorietenTest()
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
            IQueryable<Gebruiker> gebruikers = new List<Gebruiker>()
            {
                new Gebruiker()
                {
                    Favorieten = new List<Restaurant>()
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
                    }
                }

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Gebruiker>>();
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.Provider).Returns(gebruikers.Provider);
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.Expression).Returns(gebruikers.Expression);
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.ElementType).Returns(gebruikers.ElementType);
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.GetEnumerator()).Returns(gebruikers.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Gebruikers).Returns(mockSet.Object);

            var mockRepo = new Mock<IFavorietenRepository>();
            mockRepo.Setup(a => a.GetFavorieteRestaurants("TestUser", "")).Returns(mockContext.Object.Gebruikers.First());

            var actual = mockRepo.Object.GetFavorieteRestaurants("TestUser", "");

            // Assert
            mockRepo.Verify(a => a.GetFavorieteRestaurants(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.IsNotNull(actual.Favorieten);
            Assert.AreEqual(actual.Favorieten.Count(), 1);
            Assert.AreEqual(actual.Favorieten.First().Naam, "Villa Belvedere");
            Assert.AreEqual(actual.Favorieten.First().Type, "Italiaans");
            Assert.AreEqual(actual.Favorieten.First().RestaurantId, 1);
            Assert.AreEqual(actual.Favorieten.First().Soort, "Restaurant");
        }

        [DataTestMethod()]
        public void OphalenFavorietenFilterTest()
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
            IQueryable<Gebruiker> gebruikers = new List<Gebruiker>()
            {
                new Gebruiker()
                {
                    GebruikersID = "TestUser",
                    Favorieten = new List<Restaurant>()
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
                        },
                        new Restaurant()
                        {
                            KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                            Openingsuren = openingsuren,
                            Locatie = adres,
                            LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                            Menu = menu,
                            Naam = "Bubto",
                            Type = "Italiaans",
                            Soort = "Restaurant",
                            Tafels = new List<Tafel>()
                            {
                                new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                            },
                            IsAdvertentie = true,
                            Gerechten = "Pizza Pasta",
                            RestaurantId = 2
                        }
                    }
                }

            }.AsQueryable();

            var gebruiker = new Gebruiker()
            {
                GebruikersID = "TestUser",
                Favorieten = new List<Restaurant>() {
                        new Restaurant()
                        {
                            KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                            Openingsuren = openingsuren,
                            Locatie = adres,
                            LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                            Menu = menu,
                            Naam = "Bubto",
                            Type = "Italiaans",
                            Soort = "Restaurant",
                            Tafels = new List<Tafel>()
                            {
                                new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                            },
                            IsAdvertentie = true,
                            Gerechten = "Pizza Pasta",
                            RestaurantId = 2
                        }
                    }
            };

            var mockSet = new Mock<DbSet<Gebruiker>>();
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.Provider).Returns(gebruikers.Provider);
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.Expression).Returns(gebruikers.Expression);
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.ElementType).Returns(gebruikers.ElementType);
            mockSet.As<IQueryable<Gebruiker>>().Setup(m => m.GetEnumerator()).Returns(gebruikers.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Gebruikers).Returns(mockSet.Object);

            var mockRepo = new Mock<IFavorietenRepository>();
            mockRepo.Setup(a => a.GetFavorieteRestaurants("TestUser", "Bubto")).Returns(gebruiker);

            var actual = mockRepo.Object.GetFavorieteRestaurants("TestUser", "Bubto");

            // Assert
            mockRepo.Verify(a => a.GetFavorieteRestaurants(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.IsNotNull(actual.Favorieten);
            Assert.AreEqual(actual.Favorieten.First().RestaurantId, 2);
            Assert.AreEqual(actual.Favorieten.Count(), 1);
            Assert.AreEqual(actual.Favorieten.First().Naam, "Bubto");
            Assert.AreEqual(actual.Favorieten.First().Type, "Italiaans");
            Assert.AreEqual(actual.Favorieten.First().Soort, "Restaurant");
        }


        [DataTestMethod()]
        public void AddFavorietTest()
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
            IQueryable<Gebruiker> gebruikers = new List<Gebruiker>()
            {
                new Gebruiker()
                {
                    GebruikersID = "TestUser",
                    Favorieten = new List<Restaurant>()
                }
            }.AsQueryable();

            var gebruiker = new Gebruiker()
            {
                GebruikersID = "TestUser",
                Favorieten = new List<Restaurant>() {
                        new Restaurant()
                        {
                            KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                            Openingsuren = openingsuren,
                            Locatie = adres,
                            LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                            Menu = menu,
                            Naam = "Bubto",
                            Type = "Italiaans",
                            Soort = "Restaurant",
                            Tafels = new List<Tafel>()
                            {
                                new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                            },
                            IsAdvertentie = true,
                            Gerechten = "Pizza Pasta",
                            RestaurantId = 2
                        }
                }

            };
            IQueryable<Restaurant> restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                    Openingsuren = openingsuren,
                    Locatie = adres,
                    LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                    Menu = menu,
                    Naam = "Bubto",
                    Type = "Italiaans",
                    Soort = "Restaurant",
                    Tafels = new List<Tafel>()
                    {
                        new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                    },
                    IsAdvertentie = true,
                    Gerechten = "Pizza Pasta",
                    RestaurantId = 2
                }
            }.AsQueryable();



            var mockSetGebruiker = new Mock<DbSet<Gebruiker>>();
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.Provider).Returns(gebruikers.Provider);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.Expression).Returns(gebruikers.Expression);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.ElementType).Returns(gebruikers.ElementType);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.GetEnumerator()).Returns(gebruikers.GetEnumerator());

            var mockSetRestaurant = new Mock<DbSet<Restaurant>>();
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(restaurants.Provider);
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(restaurants.Expression);
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(restaurants.ElementType);
            mockSetRestaurant.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(restaurants.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Gebruikers).Returns(mockSetGebruiker.Object);
            mockContext.Setup(a => a.Restaurants).Returns(mockSetRestaurant.Object);

            var mockRepo = new Mock<IFavorietenRepository>();
            mockRepo.Setup(a => a.AddFavorieteRestaurant("TestUser", 1)).Returns(gebruiker);

            var actual = mockRepo.Object.AddFavorieteRestaurant("TestUser", 1);

            // Assert
            mockRepo.Verify(a => a.AddFavorieteRestaurant(It.IsAny<string>(), It.IsAny<long>()), Times.Once);
            Assert.IsNotNull(actual.Favorieten);
            Assert.AreEqual(actual.Favorieten.First().RestaurantId, 2);
            Assert.AreEqual(actual.Favorieten.Count(), 1);
            Assert.AreEqual(actual.Favorieten.First().Naam, "Bubto");
            Assert.AreEqual(actual.Favorieten.First().Type, "Italiaans");
            Assert.AreEqual(actual.Favorieten.First().Soort, "Restaurant");
        }

        [DataTestMethod()]
        public void DeleteFavorietTest()
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
            IQueryable<Gebruiker> gebruikers = new List<Gebruiker>()
            {
                new Gebruiker()
                {
                    GebruikersID = "TestUser",
                    Favorieten = new List<Restaurant>()
                    {
                        new Restaurant()
                        {
                            KorteBeschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                            Openingsuren = openingsuren,
                            Locatie = adres,
                            LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                            Menu = menu,
                            Naam = "Bubto",
                            Type = "Italiaans",
                            Soort = "Restaurant",
                            Tafels = new List<Tafel>()
                            {
                                new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 }
                            },
                            IsAdvertentie = true,
                            Gerechten = "Pizza Pasta",
                            RestaurantId = 2
                        }
                    }
                }
            }.AsQueryable();

            var gebruiker = new Gebruiker()
            {
                GebruikersID = "TestUser",
                Favorieten = new List<Restaurant>()
            };


            var mockSetGebruiker = new Mock<DbSet<Gebruiker>>();
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.Provider).Returns(gebruikers.Provider);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.Expression).Returns(gebruikers.Expression);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.ElementType).Returns(gebruikers.ElementType);
            mockSetGebruiker.As<IQueryable<Gebruiker>>().Setup(m => m.GetEnumerator()).Returns(gebruikers.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(a => a.Gebruikers).Returns(mockSetGebruiker.Object);

            var mockRepo = new Mock<IFavorietenRepository>();
            mockRepo.Setup(a => a.DeleteFavoriet("TestUser", 2)).Returns(gebruiker);

            var actual = mockRepo.Object.DeleteFavoriet("TestUser", 2);

            // Assert
            mockRepo.Verify(a => a.DeleteFavoriet(It.IsAny<string>(), It.IsAny<long>()), Times.Once);
            Assert.IsNotNull(actual.Favorieten);
            Assert.AreEqual(actual.Favorieten.Count(), 0);
        }
    }
}
