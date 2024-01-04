using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAndBuyTestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBundleRelationshipIds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductBundleRelationshipIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBundleRelationshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBundleRelationshipIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBundleRelationshipIds_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundleRelationshipIds_ProductId",
                table: "ProductBundleRelationshipIds",
                column: "ProductId");
        }
    }
}
