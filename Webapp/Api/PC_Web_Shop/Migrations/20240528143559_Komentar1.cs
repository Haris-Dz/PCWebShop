using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class Komentar1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentari = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KupacId = table.Column<int>(type: "int", nullable: false),
                    ArtikalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentar_Artikal_ArtikalId",
                        column: x => x.ArtikalId,
                        principalTable: "Artikal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Komentar_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_ArtikalId",
                table: "Komentar",
                column: "ArtikalId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KupacId",
                table: "Komentar",
                column: "KupacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentar");
        }
    }
}
