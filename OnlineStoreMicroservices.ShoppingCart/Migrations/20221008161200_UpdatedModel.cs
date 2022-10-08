using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStoreMicroservices.ShoppingCart.Migrations
{
    public partial class UpdatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "BasketProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "BasketProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "BasketProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Total",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "BasketProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Total",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "BasketProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Total",
                value: 200m);
        }
    }
}
