using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockAndBuyTestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BundleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BundleToBundleRelationshipIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildBundleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BundleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleToBundleRelationshipIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleToBundleRelationshipIds_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BundleToProductRelationshipIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BundleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleToProductRelationshipIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleToProductRelationshipIds_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleToBundleRelationshipIds_BundleId",
                table: "BundleToBundleRelationshipIds",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleToProductRelationshipIds_BundleId",
                table: "BundleToProductRelationshipIds",
                column: "BundleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundleToBundleRelationshipIds");

            migrationBuilder.DropTable(
                name: "BundleToProductRelationshipIds");

            migrationBuilder.DropTable(
                name: "Bundles");
        }
    }
}
