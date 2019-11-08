using Microsoft.EntityFrameworkCore.Migrations;

namespace VitecData.Migrations
{
    public partial class ZIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ZipCities_ZIP1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ZIP1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZIP1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ZIP",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ZIP1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZIP1",
                table: "AspNetUsers",
                column: "ZIP1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ZipCities_ZIP1",
                table: "AspNetUsers",
                column: "ZIP1",
                principalTable: "ZipCities",
                principalColumn: "ZIP",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
