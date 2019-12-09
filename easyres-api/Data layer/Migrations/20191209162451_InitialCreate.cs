using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_layer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Straat = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    Land = table.Column<string>(nullable: true),
                    Straatnummer = table.Column<int>(nullable: false),
                    Bus = table.Column<string>(nullable: true),
                    Postcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    GebruikersID = table.Column<string>(nullable: false),
                    GetFactuurByEmail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.GebruikersID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Openingsuren",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Maandag = table.Column<string>(nullable: true),
                    Dinsdag = table.Column<string>(nullable: true),
                    Woensdag = table.Column<string>(nullable: true),
                    Donderdag = table.Column<string>(nullable: true),
                    Vrijdag = table.Column<string>(nullable: true),
                    Zaterdag = table.Column<string>(nullable: true),
                    Zondag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openingsuren", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uitbaters",
                columns: table => new
                {
                    GebruikersID = table.Column<string>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitbaters", x => x.GebruikersID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    LocatieID = table.Column<int>(nullable: false),
                    MenuID = table.Column<int>(nullable: false),
                    OpeningsurenID = table.Column<int>(nullable: true),
                    KorteBeschrijving = table.Column<string>(nullable: true),
                    LangeBeschrijving = table.Column<string>(nullable: true),
                    LogoImage = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Soort = table.Column<string>(nullable: true),
                    Gerechten = table.Column<string>(nullable: true),
                    IsAdvertentie = table.Column<bool>(nullable: false),
                    GebruikersID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurants_Gebruikers_GebruikersID",
                        column: x => x.GebruikersID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikersID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_Adres_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Adres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_Openingsuren_OpeningsurenID",
                        column: x => x.OpeningsurenID,
                        principalTable: "Openingsuren",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    BestellingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestaurantId = table.Column<int>(nullable: true),
                    GebruikersID = table.Column<string>(nullable: true),
                    EtenGereed = table.Column<bool>(nullable: false),
                    DrinkenGereed = table.Column<bool>(nullable: false),
                    HuidigeTijd = table.Column<DateTime>(nullable: false),
                    EetTijdKlaar = table.Column<string>(nullable: true),
                    DrinkTijdKlaar = table.Column<string>(nullable: true),
                    EtenStatus = table.Column<bool>(nullable: false),
                    DrinkenStatus = table.Column<bool>(nullable: false),
                    TafelNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.BestellingId);
                    table.ForeignKey(
                        name: "FK_Bestellingen_Gebruikers_GebruikersID",
                        column: x => x.GebruikersID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikersID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bestellingen_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GebruikersID = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Betaald = table.Column<bool>(nullable: false),
                    TafelNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_Gebruikers_GebruikersID",
                        column: x => x.GebruikersID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikersID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturen_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservaties",
                columns: table => new
                {
                    ReservatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TelefoonNummer = table.Column<string>(nullable: true),
                    Datum = table.Column<string>(nullable: true),
                    Tijdstip = table.Column<string>(nullable: true),
                    AantalPersonen = table.Column<int>(nullable: false),
                    TafelNr = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaties", x => x.ReservatieId);
                    table.ForeignKey(
                        name: "FK_Reservaties_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GebruikersID = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: true),
                    TafelNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessies_Gebruikers_GebruikersID",
                        column: x => x.GebruikersID,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikersID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessies_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tafel",
                columns: table => new
                {
                    TafelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TafelNr = table.Column<int>(nullable: false),
                    UrenBezet = table.Column<int>(nullable: false),
                    Zitplaatsen = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tafel", x => x.TafelID);
                    table.ForeignKey(
                        name: "FK_Tafel_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aantal = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<double>(nullable: false),
                    BestellingId = table.Column<int>(nullable: true),
                    BestellingId1 = table.Column<int>(nullable: true),
                    FactuurId = table.Column<int>(nullable: true),
                    MenuID = table.Column<int>(nullable: true),
                    MenuID1 = table.Column<int>(nullable: true),
                    MenuID2 = table.Column<int>(nullable: true),
                    MenuID3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Bestellingen_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "BestellingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Bestellingen_BestellingId1",
                        column: x => x.BestellingId1,
                        principalTable: "Bestellingen",
                        principalColumn: "BestellingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Facturen_FactuurId",
                        column: x => x.FactuurId,
                        principalTable: "Facturen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Menu_MenuID1",
                        column: x => x.MenuID1,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Menu_MenuID2",
                        column: x => x.MenuID2,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Menu_MenuID3",
                        column: x => x.MenuID3,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tijdsmoment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<string>(nullable: true),
                    Van = table.Column<string>(nullable: true),
                    Tot = table.Column<string>(nullable: true),
                    TafelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tijdsmoment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tijdsmoment_Tafel_TafelID",
                        column: x => x.TafelID,
                        principalTable: "Tafel",
                        principalColumn: "TafelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_GebruikersID",
                table: "Bestellingen",
                column: "GebruikersID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_RestaurantId",
                table: "Bestellingen",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_GebruikersID",
                table: "Facturen",
                column: "GebruikersID");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_RestaurantId",
                table: "Facturen",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BestellingId",
                table: "Product",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BestellingId1",
                table: "Product",
                column: "BestellingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FactuurId",
                table: "Product",
                column: "FactuurId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MenuID",
                table: "Product",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MenuID1",
                table: "Product",
                column: "MenuID1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MenuID2",
                table: "Product",
                column: "MenuID2");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MenuID3",
                table: "Product",
                column: "MenuID3");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaties_RestaurantId",
                table: "Reservaties",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_GebruikersID",
                table: "Restaurants",
                column: "GebruikersID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocatieID",
                table: "Restaurants",
                column: "LocatieID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenuID",
                table: "Restaurants",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OpeningsurenID",
                table: "Restaurants",
                column: "OpeningsurenID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessies_GebruikersID",
                table: "Sessies",
                column: "GebruikersID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessies_RestaurantId",
                table: "Sessies",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tafel_RestaurantId",
                table: "Tafel",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tijdsmoment_TafelID",
                table: "Tijdsmoment",
                column: "TafelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Reservaties");

            migrationBuilder.DropTable(
                name: "Sessies");

            migrationBuilder.DropTable(
                name: "Tijdsmoment");

            migrationBuilder.DropTable(
                name: "Uitbaters");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "Tafel");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Openingsuren");
        }
    }
}
