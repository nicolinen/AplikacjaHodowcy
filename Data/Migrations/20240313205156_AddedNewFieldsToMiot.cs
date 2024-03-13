using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class AddedNewFieldsToMiot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpisRodzicow",
                table: "Mioty",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Mioty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpisRodzicow",
                table: "Mioty");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Mioty");
        }
    }
}
