using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POSWebApp.Migrations
{
    /// <inheritdoc />
    public partial class allremainingentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBalanceEntities_Product_ProductId",
                table: "ProductBalanceEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRestockEntities_Product_ProductId",
                table: "ProductRestockEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRestockEntities",
                table: "ProductRestockEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBalanceEntities",
                table: "ProductBalanceEntities");

            migrationBuilder.RenameTable(
                name: "ProductRestockEntities",
                newName: "ProductRestock");

            migrationBuilder.RenameTable(
                name: "ProductBalanceEntities",
                newName: "ProductBalance");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRestockEntities_ProductId",
                table: "ProductRestock",
                newName: "IX_ProductRestock_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBalanceEntities_ProductId",
                table: "ProductBalance",
                newName: "IX_ProductBalance_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRestock",
                table: "ProductRestock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBalance",
                table: "ProductBalance",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cashier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CashierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DOE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatusId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CashierId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Cashier_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionStatus_TransactionStatusId",
                        column: x => x.TransactionStatusId,
                        principalTable: "TransactionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionDetail_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_TransactionId",
                table: "Invoice",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CashierId",
                table: "Transaction",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionStatusId",
                table: "Transaction",
                column: "TransactionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_ProductId",
                table: "TransactionDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_TransactionId",
                table: "TransactionDetail",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBalance_Product_ProductId",
                table: "ProductBalance",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRestock_Product_ProductId",
                table: "ProductRestock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBalance_Product_ProductId",
                table: "ProductBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRestock_Product_ProductId",
                table: "ProductRestock");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "TransactionDetail");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Cashier");

            migrationBuilder.DropTable(
                name: "TransactionStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRestock",
                table: "ProductRestock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBalance",
                table: "ProductBalance");

            migrationBuilder.RenameTable(
                name: "ProductRestock",
                newName: "ProductRestockEntities");

            migrationBuilder.RenameTable(
                name: "ProductBalance",
                newName: "ProductBalanceEntities");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRestock_ProductId",
                table: "ProductRestockEntities",
                newName: "IX_ProductRestockEntities_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductBalance_ProductId",
                table: "ProductBalanceEntities",
                newName: "IX_ProductBalanceEntities_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRestockEntities",
                table: "ProductRestockEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBalanceEntities",
                table: "ProductBalanceEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBalanceEntities_Product_ProductId",
                table: "ProductBalanceEntities",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRestockEntities_Product_ProductId",
                table: "ProductRestockEntities",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
