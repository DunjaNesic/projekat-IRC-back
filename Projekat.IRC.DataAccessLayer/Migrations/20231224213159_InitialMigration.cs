using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekat.IRC.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prostorija",
                columns: table => new
                {
                    OznakaSale = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sprat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prostorija", x => x.OznakaSale);
                });

            migrationBuilder.CreateTable(
                name: "TipOpreme",
                columns: table => new
                {
                    TipOpremeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipOpreme", x => x.TipOpremeID);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    ZaposleniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Katedra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.ZaposleniID);
                });

            migrationBuilder.CreateTable(
                name: "Oprema",
                columns: table => new
                {
                    SerijskiBrojOpreme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InventarskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specs = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: true),
                    TipOpremeID = table.Column<int>(type: "int", nullable: false),
                    ProstorijaOznakaSale = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprema", x => x.SerijskiBrojOpreme);
                    table.ForeignKey(
                        name: "FK_Oprema_Prostorija_ProstorijaOznakaSale",
                        column: x => x.ProstorijaOznakaSale,
                        principalTable: "Prostorija",
                        principalColumn: "OznakaSale",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oprema_TipOpreme_TipOpremeID",
                        column: x => x.TipOpremeID,
                        principalTable: "TipOpreme",
                        principalColumn: "TipOpremeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaduzenje",
                columns: table => new
                {
                    DatumZaduzivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZaposleniID = table.Column<int>(type: "int", nullable: false),
                    SerijskiBrojOpreme = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaduzenje", x => new { x.DatumZaduzivanja, x.ZaposleniID, x.SerijskiBrojOpreme });
                    table.ForeignKey(
                        name: "FK_Zaduzenje_Oprema_SerijskiBrojOpreme",
                        column: x => x.SerijskiBrojOpreme,
                        principalTable: "Oprema",
                        principalColumn: "SerijskiBrojOpreme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaduzenje_Zaposleni_ZaposleniID",
                        column: x => x.ZaposleniID,
                        principalTable: "Zaposleni",
                        principalColumn: "ZaposleniID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oprema_ProstorijaOznakaSale",
                table: "Oprema",
                column: "ProstorijaOznakaSale");

            migrationBuilder.CreateIndex(
                name: "IX_Oprema_TipOpremeID",
                table: "Oprema",
                column: "TipOpremeID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzenje_SerijskiBrojOpreme",
                table: "Zaduzenje",
                column: "SerijskiBrojOpreme");

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzenje_ZaposleniID",
                table: "Zaduzenje",
                column: "ZaposleniID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleni_Email",
                table: "Zaposleni",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zaduzenje");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.DropTable(
                name: "Prostorija");

            migrationBuilder.DropTable(
                name: "TipOpreme");
        }
    }
}
