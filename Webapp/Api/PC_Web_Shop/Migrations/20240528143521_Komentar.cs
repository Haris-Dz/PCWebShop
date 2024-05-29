using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class Komentar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Artikal",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Artikal");
        }
    }
}
