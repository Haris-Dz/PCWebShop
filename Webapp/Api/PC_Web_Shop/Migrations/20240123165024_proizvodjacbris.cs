using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class proizvodjacbris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Proizvodjac",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Proizvodjac");
        }
    }
}
