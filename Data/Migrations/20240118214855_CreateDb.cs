using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mioty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieMatki = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImieOjca = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NazwaMiotu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LiniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mioty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mioty_Linie_LiniaId",
                        column: x => x.LiniaId,
                        principalTable: "Linie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mioty_LiniaId",
                table: "Mioty",
                column: "LiniaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mioty");

            migrationBuilder.DropTable(
                name: "Linie");
        }
    }
}
