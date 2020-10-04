using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sessionShoppingCarts",
                columns: table => new
                {
                    SessionShopingCartId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessionShoppingCarts", x => x.SessionShopingCartId);
                });

            migrationBuilder.CreateTable(
                name: "sessionShoppingCartDetails",
                columns: table => new
                {
                    SessionShoppingCartDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ProductSelected = table.Column<string>(nullable: true),
                    SessionShopingCartId = table.Column<int>(nullable: false),
                    SessionShoppingCartSessionShopingCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessionShoppingCartDetails", x => x.SessionShoppingCartDetailId);
                    table.ForeignKey(
                        name: "FK_sessionShoppingCartDetails_sessionShoppingCarts_SessionShopp~",
                        column: x => x.SessionShoppingCartSessionShopingCartId,
                        principalTable: "sessionShoppingCarts",
                        principalColumn: "SessionShopingCartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sessionShoppingCartDetails_SessionShoppingCartSessionShoping~",
                table: "sessionShoppingCartDetails",
                column: "SessionShoppingCartSessionShopingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sessionShoppingCartDetails");

            migrationBuilder.DropTable(
                name: "sessionShoppingCarts");
        }
    }
}
