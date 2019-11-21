using System;
using System.Collections.Generic;
using System.Linq;

namespace easyres_api.Model
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //Are there already restaurants present ?
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
                List<Tafel> tafels = new List<Tafel>()
                {
                    new Tafel() { TafelNr = 1, Zitplaatsen = 5 },
                    new Tafel() { TafelNr = 2, Zitplaatsen = 4 },
                    new Tafel() { TafelNr = 3, Zitplaatsen = 4 },
                    new Tafel() { TafelNr = 4, Zitplaatsen = 2 },
                    new Tafel() { TafelNr = 5, Zitplaatsen = 2 }
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
                Adres adres1 = new Adres()
                {
                    Bus = "A",
                    Gemeente = "Sint-Niklaas",
                    Straat = "Papegaielaan",
                    Straatnummer = 10,
                    Land = "België",
                    Postcode = 2000
                };
                Adres adres2 = new Adres()
                {
                    Bus = "A",
                    Gemeente = "Sint-Gillis-Waas",
                    Straat = "Papegaielaan",
                    Straatnummer = 10,
                    Land = "België",
                    Postcode = 2000
                };
                Adres adres3 = new Adres()
                {
                    Bus = "A",
                    Gemeente = "Amsterdam",
                    Straat = "Papegaielaan",
                    Straatnummer = 10,
                    Land = "Nederland",
                    Postcode = 2000
                };
                Adres adres4 = new Adres()
                {
                    Bus = "A",
                    Gemeente = "Rotterdam",
                    Straat = "Papegaielaan",
                    Straatnummer = 10,
                    Land = "Nederland",
                    Postcode = 2000
                };
                Adres adres5 = new Adres()
                {
                    Bus = "A",
                    Gemeente = "Den Haag",
                    Straat = "Papegaielaan",
                    Straatnummer = 10,
                    Land = "Nederland",
                    Postcode = 2000
                };
                Adres adres6 = new Adres()
                {
                    Bus = "A",
                    Gemeente = "Groningen",
                    Straat = "Papegaielaan",
                    Straatnummer = 10,
                    Land = "Nederland",
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
                Restaurant[] restaurants =
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
                      Gerechten = "Pizza Pasta"
                    },

                    new Restaurant()
                    {
                      KorteBeschrijving = "Het beste Chineese restaurant met veel verschillende smaken.",
                      Openingsuren = openingsuren,
                      Locatie = adres1,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het hoekske",
                      Type = "Chinees",
                      Soort = "Restaurant",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = false,
                      Gerechten = "Pizza Pasta"

                    },
                    new Restaurant()
                    {
                      KorteBeschrijving = "Het beste Chineese restaurant met veel verschillende smaken. En zelfs nog meer als de anderen.",
                      Openingsuren = openingsuren,
                      Locatie = adres2,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het restaurant china",
                      Type = "Chinees",
                      Soort = "Restaurant",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = false,
                      Gerechten = "Salade Stoverij"
                    },
                    new Restaurant()
                    {
                      KorteBeschrijving = "Japan brengt de gerechten zoals ze in Japan worden gebracht, super lekker dus.",
                      Openingsuren = openingsuren,
                      Locatie = adres3,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het japaneeske",
                      Type = "Japans",
                      Soort = "Bistro",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Salade Stoverij"
                    },
                    new Restaurant()
                    {
                      KorteBeschrijving = "Je denkt Afrika dus je denkt direct aan lekker eten ;)",
                      Openingsuren = openingsuren,
                      Locatie = adres4,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Het afrikaanse hoofdkwartier",
                      Type = "Afrikaans",
                      Soort = "Bistro",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = false,
                      Gerechten = "Pizza Pasta"
                    },
                    new Restaurant()
                    {
                      KorteBeschrijving = "Het beste Chineese restaurant met veel verschillende smaken. Jaja je lees het goed het beste restaurant ter wereld.",
                      Openingsuren = openingsuren,
                      Locatie = adres5,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "De chinees",
                      Type = "Chinees",
                      Soort = "Taverne",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Pizza Pasta"
                    },
                    new Restaurant()
                    {
                      KorteBeschrijving = "Veel verschillend smaken, maar echt super veel. Geloof je het niet, kom zelf proeven!",
                      Openingsuren = openingsuren,
                      Locatie = adres6,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Den bistro",
                      Type = "Japans",
                      Soort = "Taverne",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = false,
                      Gerechten = "Stoverij"
                    },
                    new Restaurant()
                    {
                      KorteBeschrijving = "Het beste italiaanse restaurant met veel verschillende smaken enzovoort...",
                      Openingsuren = openingsuren,
                      Locatie = adres1,
                      LogoImage = "https://via.placeholder.com/350x350.png/8b0000/fff?text=Foto van een restaurant",
                      Menu = menu,
                      Naam = "Alles van eten",
                      Type = "Italiaans",
                      Soort = "Trattoria",
                      Tafels = new List<Tafel>()
                      {
                          new Tafel() { TafelNr = 1, UrenBezet = 3, Zitplaatsen = 5 },
                          new Tafel() { TafelNr = 2, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 3, UrenBezet = 3, Zitplaatsen = 4 },
                          new Tafel() { TafelNr = 4, UrenBezet = 3, Zitplaatsen = 2 },
                          new Tafel() { TafelNr = 5, UrenBezet = 3, Zitplaatsen = 2 }
                      },
                      IsAdvertentie = true,
                      Gerechten = "Salade"
                    }
                };

                Bestelling[] bestellingen =
                {
                    new Bestelling()
                    {
                         Dranken = new List<Product>()
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
                         },
                         Etenswaren = new List<Product>()
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
                         },
                         Restaurant = restaurants[0],
                         TafelNr = 4,
                         EtenGereed = false,
                         DrinkenGereed = false,
                         HuidigeTijd = DateTime.Now,
                         EtenStatus = true,
                         DrinkenStatus = true
                    }
                };
                foreach (Bestelling bestelling in bestellingen)
                {
                    context.Bestellingen.Add(bestelling);
                }

                foreach (Restaurant restaurant in restaurants)
                {
                    context.Restaurants.Add(restaurant);
                }
                context.SaveChanges();
            }
        }
    }
}
