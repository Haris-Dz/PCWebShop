using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class ppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Popust",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Popust");
        }
    }
}
