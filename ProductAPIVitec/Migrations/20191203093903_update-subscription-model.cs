using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPIVitec.Migrations
{
    public partial class updatesubscriptionmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Subscription");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Subscription",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Subscription",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PriceId",
                table: "Subscription",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_ProductId",
                table: "Subscription",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Price_PriceId",
                table: "Subscription",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Product_ProductId",
                table: "Subscription",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Price_PriceId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Product_ProductId",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_PriceId",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_ProductId",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Subscription");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Subscription",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Product",
                table: "Subscription",
                nullable: false,
                defaultValue: 0);
        }
    }
}
