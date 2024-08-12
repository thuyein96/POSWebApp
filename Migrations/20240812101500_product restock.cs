using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class productrestock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRestockEntities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestockQuantity = table.Column<int>(type: "int", nullable: false),
                    RestockDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRestockEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRestockEntities_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRestockEntities_ProductId",
                table: "ProductRestockEntities",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRestockEntities");
        }
    }
}
