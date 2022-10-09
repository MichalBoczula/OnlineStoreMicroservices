using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStoreMicroservices.DiscountCoupon.Migrations
{
    public partial class InitialWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountCoupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntegrationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCoupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiscountCoupons",
                columns: new[] { "Id", "Amount", "Code", "IntegrationId", "IsActual" },
                values: new object[] { 1, 10, "ten", "e0cfebf1-5fa6-49d0-a726-c5c4b2ce3de9", true });

            migrationBuilder.InsertData(
                table: "DiscountCoupons",
                columns: new[] { "Id", "Amount", "Code", "IntegrationId", "IsActual" },
                values: new object[] { 2, 20, "twenty", "3ed3adc6-7416-4d63-9048-9d1b92554c21", true });

            migrationBuilder.InsertData(
                table: "DiscountCoupons",
                columns: new[] { "Id", "Amount", "Code", "IntegrationId", "IsActual" },
                values: new object[] { 3, 30, "thirty", "fd918135-bcf1-4310-8b20-81365ad80862", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCoupons");
        }
    }
}
