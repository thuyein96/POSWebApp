using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class productbalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBalanceEntities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBalanceEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBalanceEntities_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBalanceEntities_ProductId",
                table: "ProductBalanceEntities",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBalanceEntities");
        }
    }
}
