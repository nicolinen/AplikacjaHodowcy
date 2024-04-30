using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class LiniaAndKonkurs_EN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "Linie",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "KrajoweRegulacje",
                table: "Konkursy",
                newName: "DomesticRegulations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Linie",
                newName: "Opis");

            migrationBuilder.RenameColumn(
                name: "DomesticRegulations",
                table: "Konkursy",
                newName: "KrajoweRegulacje");
        }
    }
}
