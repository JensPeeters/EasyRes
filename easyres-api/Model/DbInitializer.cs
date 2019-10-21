
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
                      Type = "Italiaans",
                      Soort = "Restaurant"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Het beste Chineese restaurant met veel verschillende smaken.",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het hoekske",
                      Type = "Chinees",
                      Soort = "Restaurant"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Het beste Chineese restaurant met veel verschillende smaken. En zelfs nog meer als de anderen.",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het restaurant china",
                      Type = "Chinees",
                      Soort = "Restaurant"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Japan brengt de gerechten zoals ze in Japan worden gebracht, super lekker dus.",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het japaneeske",
                      Type = "Japans",
                      Soort = "Bistro"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Je denkt Afrika dus je denkt direct aan lekker eten ;)",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het afrikaanse hoofdkwartier",
                      Type = "Afrikaans",
                      Soort = "Bistro"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Het beste Chineese restaurant met veel verschillende smaken. Jaja je lees het goed het beste restaurant ter wereld.",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "De chinees",
                      Type = "Chinees",
                      Soort = "Taverne"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Veel verschillend smaken, maar echt super veel. Geloof je het niet, kom zelf proeven!",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Den bistro",
                      Type = "Japans",
                      Soort = "Taverne"
                    },
                    new Restaurant()
                    {
                      Beschrijving = "Het beste italiaanse restaurant met veel verschillende smaken enzovoort...",
                      Openingsuren = openingsuren,
                      Locatie = adres,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Alles van eten",
                      Type = "Italiaans",
                      Soort = "Trattoria"
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

                List<Reservatie> reservaties = new List<Reservatie>()
                {
                    new Reservatie()
                    {
                        AantalPersonen = 4,
                        Datum = "12/12/12",
                        Email = "floppy@doppy.com",
                        Naam = "Yvad",
                        TelefoonNummer = "+32455661289",
                        Restaurant = restaurants[0]
                    },

                    new Reservatie()
                    {
                        AantalPersonen = 6,
                        Datum = "15/14/13",
                        Email = "johndoe@example.com",
                        Naam = "John Doe",
                        TelefoonNummer = "+32412345678",
                        Restaurant = restaurants[3]
                    }
                };
                restaurants[0].Reservaties = reservaties;
                foreach (Reservatie reservatie in reservaties)
                {
                    context.Reservaties.Add(reservatie);
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
