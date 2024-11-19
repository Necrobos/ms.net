using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Avito.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LevelAccess = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserFIO = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickUpPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PickUpPointName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    CreatedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUpPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PassSeriesAndNumber = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserFIO = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsForSelling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    DateOfExposing = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PickUpPointId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOnTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsForSelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsForSelling_PickUpPoints_PickUpPointId",
                        column: x => x.PickUpPointId,
                        principalTable: "PickUpPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemForSellingSeller",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "integer", nullable: false),
                    SellersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemForSellingSeller", x => new { x.ItemsId, x.SellersId });
                    table.ForeignKey(
                        name: "FK_ItemForSellingSeller_ItemsForSelling_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "ItemsForSelling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemForSellingSeller_Sellers_SellersId",
                        column: x => x.SellersId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemForSellingSeller_SellersId",
                table: "ItemForSellingSeller",
                column: "SellersId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsForSelling_PickUpPointId",
                table: "ItemsForSelling",
                column: "PickUpPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "ItemForSellingSeller");

            migrationBuilder.DropTable(
                name: "ItemsForSelling");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "PickUpPoints");
        }
    }
}
