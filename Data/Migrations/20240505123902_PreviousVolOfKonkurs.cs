using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class PreviousVolOfKonkurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DomesticRegulations",
                table: "Konkursy",
                newName: "KrajoweRegulacje");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Konkursy",
                newName: "Kraj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KrajoweRegulacje",
                table: "Konkursy",
                newName: "DomesticRegulations");

            migrationBuilder.RenameColumn(
                name: "Kraj",
                table: "Konkursy",
                newName: "Country");
        }
    }
}
