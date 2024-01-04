using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAndBuyTestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BundleToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BundleToProductRelationship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BundleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityNeeded = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleToProductRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleToProductRelationship_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BundleToProductRelationship_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleToProductRelationship_BundleId",
                table: "BundleToProductRelationship",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleToProductRelationship_ProductId",
                table: "BundleToProductRelationship",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundleToProductRelationship");
        }
    }
}
