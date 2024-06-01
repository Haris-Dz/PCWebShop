using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class editSMSLoga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DodatniSadrzaj",
                table: "Smslog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DodatniSadrzaj",
                table: "Smslog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
