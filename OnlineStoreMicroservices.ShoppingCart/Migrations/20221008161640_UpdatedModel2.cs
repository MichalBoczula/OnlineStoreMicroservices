using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStoreMicroservices.ShoppingCart.Migrations
{
    public partial class UpdatedModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BasketProducts_ProductId",
                table: "BasketProducts");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductId",
                table: "BasketProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BasketProducts_ProductId",
                table: "BasketProducts");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductId",
                table: "BasketProducts",
                column: "ProductId",
                unique: true);
        }
    }
}
