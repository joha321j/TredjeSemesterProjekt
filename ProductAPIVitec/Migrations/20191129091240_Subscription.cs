using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductAPIVitec.Migrations
{
    public partial class Subscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Subscription",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "Subscription",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Subscription",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "Subscription",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
