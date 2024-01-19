using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class AddSzczeniakTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szczeniaki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiotId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szczeniaki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Szczeniaki_Mioty_MiotId",
                        column: x => x.MiotId,
                        principalTable: "Mioty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Szczeniaki_MiotId",
                table: "Szczeniaki",
                column: "MiotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Szczeniaki");
        }
    }
}
