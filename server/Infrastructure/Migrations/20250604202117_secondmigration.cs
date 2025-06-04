using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchaseCurrency = table.Column<int>(type: "int", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleCurrency = table.Column<int>(type: "int", nullable: true),
                    PaperWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockUnits_StockTypes_StockTypeId",
                        column: x => x.StockTypeId,
                        principalTable: "StockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    StockUnitId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShelfInfo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CabinetInfo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriticalQuantity = table.Column<int>(type: "int", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_StockTypes_StockTypeId",
                        column: x => x.StockTypeId,
                        principalTable: "StockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_StockUnits_StockUnitId",
                        column: x => x.StockUnitId,
                        principalTable: "StockUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "StockTypes",
                columns: new[] { "Id", "InsertedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kağıt", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kimyasal", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Makine Parçası", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StockUnits",
                columns: new[] { "Id", "Code", "Description", "InsertedDate", "IsActive", "PaperWeight", "PurchaseCurrency", "PurchasePrice", "SaleCurrency", "SalePrice", "StockTypeId", "Unit", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "KGT", "Kilogram birimi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "80gr", 1, 10m, 1, 12m, 1, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "PCS", "Adet birimi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 1, 1m, 1, 1.2m, 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "LT", "Litre birimi", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 1, 5m, 1, 6m, 2, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CabinetInfo", "Class", "CriticalQuantity", "InsertedDate", "IsActive", "Quantity", "ShelfInfo", "StockTypeId", "StockUnitId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "K1", 1, 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100, "A1", 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "K2", 3, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 50, "B2", 2, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockTypeId",
                table: "Stocks",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_StockUnitId",
                table: "Stocks",
                column: "StockUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTypes_Name",
                table: "StockTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_Code",
                table: "StockUnits",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_StockTypeId",
                table: "StockUnits",
                column: "StockTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "StockUnits");

            migrationBuilder.DropTable(
                name: "StockTypes");
        }
    }
}
