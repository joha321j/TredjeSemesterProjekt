using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPIVitec.Migrations
{
    public partial class ZipCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZipCities",
                columns: table => new
                {
                    Zip = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCities", x => x.Zip);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZipCities");
        }
    }
}
