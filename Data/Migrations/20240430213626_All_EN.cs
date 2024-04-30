using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class All_EN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpisRodzicow",
                table: "Mioty",
                newName: "ParentsDesc");

            migrationBuilder.RenameColumn(
                name: "NazwaMiotu",
                table: "Mioty",
                newName: "MotherName");

            migrationBuilder.RenameColumn(
                name: "ImieOjca",
                table: "Mioty",
                newName: "LitterName");

            migrationBuilder.RenameColumn(
                name: "ImieMatki",
                table: "Mioty",
                newName: "FatherName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentsDesc",
                table: "Mioty",
                newName: "OpisRodzicow");

            migrationBuilder.RenameColumn(
                name: "MotherName",
                table: "Mioty",
                newName: "NazwaMiotu");

            migrationBuilder.RenameColumn(
                name: "LitterName",
                table: "Mioty",
                newName: "ImieOjca");

            migrationBuilder.RenameColumn(
                name: "FatherName",
                table: "Mioty",
                newName: "ImieMatki");
        }
    }
}
