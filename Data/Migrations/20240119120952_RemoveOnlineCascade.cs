using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikacjaHodowcy.Data.Migrations
{
    public partial class RemoveOnlineCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mioty_Linie_LiniaId",
                table: "Mioty");

            migrationBuilder.AddForeignKey(
                name: "FK_Mioty_Linie_LiniaId",
                table: "Mioty",
                column: "LiniaId",
                principalTable: "Linie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mioty_Linie_LiniaId",
                table: "Mioty");

            migrationBuilder.AddForeignKey(
                name: "FK_Mioty_Linie_LiniaId",
                table: "Mioty",
                column: "LiniaId",
                principalTable: "Linie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
