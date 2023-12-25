using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC_Web_Shop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KratkiOpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StanjeNaSkladistu = table.Column<int>(type: "int", nullable: false),
                    Sifra = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikal");
        }
    }
}
