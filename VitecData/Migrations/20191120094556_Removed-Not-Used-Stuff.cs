using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VitecData.Migrations
{
    public partial class RemovedNotUsedStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_Cards_cardID",
                table: "UserCards");

            migrationBuilder.DropTable(
                name: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "ZipCities");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "cardID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_Card_cardID",
                table: "UserCards",
                column: "cardID",
                principalTable: "Card",
                principalColumn: "cardID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_Card_cardID",
                table: "UserCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "cardID");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZipCities",
                columns: table => new
                {
                    ZIP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCities", x => x.ZIP);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingFrequency = table.Column<TimeSpan>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutomaticBilling = table.Column<bool>(nullable: false),
                    ExpDate = table.Column<DateTime>(nullable: false),
                    SignUpDate = table.Column<DateTime>(nullable: false),
                    SubscriptionID = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserSubscriptions_Subscriptions_SubscriptionID",
                        column: x => x.SubscriptionID,
                        principalTable: "Subscriptions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ProductID",
                table: "Subscriptions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_SubscriptionID",
                table: "UserSubscriptions",
                column: "SubscriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_UserId",
                table: "UserSubscriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_Cards_cardID",
                table: "UserCards",
                column: "cardID",
                principalTable: "Cards",
                principalColumn: "cardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
