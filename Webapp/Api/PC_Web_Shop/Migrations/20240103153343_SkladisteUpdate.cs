using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class SkladisteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_Artikal_ArtikalId",
                table: "Skladiste");

            migrationBuilder.DropIndex(
                name: "IX_Skladiste_ArtikalId",
                table: "Skladiste");

            migrationBuilder.DropColumn(
                name: "ArtikalId",
                table: "Skladiste");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtikalId",
                table: "Skladiste",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skladiste_ArtikalId",
                table: "Skladiste",
                column: "ArtikalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_Artikal_ArtikalId",
                table: "Skladiste",
                column: "ArtikalId",
                principalTable: "Artikal",
                principalColumn: "Id");
        }
    }
}
