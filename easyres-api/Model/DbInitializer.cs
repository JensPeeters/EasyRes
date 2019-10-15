
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //Are there already books present ?
            if (context.Restaurants.Count() == 0)
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
                List<Product> desserts = new List<Product>()
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
                            };
                List<Product> voorgerechten = new List<Product>()
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
                            };
                List<Product> hoofdgerechten = new List<Product>()
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
                            };
                List<Product> dranken = new List<Product>()
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
                            };
                Menu menu = new Menu()
                {
                    Desserts = desserts,
                    Voorgerechten = voorgerechten,
                    Hoofdgerechten =hoofdgerechten,
                    Dranken = dranken    
                };
                Restaurant[] restaurants =
                {
                    new Restaurant()
                    {
                      Beschrijving = "Villa Belvedere is trotse bezitter van het 'OSPITALITA ITALIANA' kwaliteitslabel. Uitgereikt door de Italiaanse Kamer van Koophandel voor de échte Italiaanse",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Villa Belvedere",
                      Type = "Italiaans"
                    }
                };

                List<Product> besteldeEtenswaren = new List<Product>()
                {
                    new Product()
                    {
                        Naam = "Snitzel",
                        Prijs = 25.20,
                        Aantal = 1
                    },
                    new Product()
                    {
                        Naam = "Lasagna",
                        Prijs = 15.15,
                        Aantal = 2
                    }
                };

                List<Product> besteldeDranken = new List<Product>()
                {
                    new Product()
                    {
                        Naam = "Bier 33cl",
                        Prijs = 5,
                        Aantal = 2
                    },
                    new Product()
                    {
                        Naam = "Cola 0.5l",
                        Prijs = 1.80,
                        Aantal = 3
                    }
                };

                Bestelling[] bestellingen =
                {
                    new Bestelling()
                    {
                         BesteldeDranken = besteldeDranken,
                         BesteldeEtenswaren = besteldeEtenswaren,
                         TafelNr = 4
                    }
                };

                foreach (Restaurant restaurant in restaurants)
                {
                    context.Restaurants.Add(restaurant);
                }

                foreach (Bestelling bestelling in bestellingen)
                {
                    context.Bestellingen.Add(bestelling);
                }
                context.SaveChanges();
            }
        }
    }
}
