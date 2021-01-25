using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicio.Api.CarritoCompra.Migrations
{
    public partial class MigrationSqlServerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionCart",
                columns: table => new
                {
                    SesionCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionCart", x => x.SesionCartId);
                });

            migrationBuilder.CreateTable(
                name: "SessionCartDetail",
                columns: table => new
                {
                    SesionCartDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    SelectedProduct = table.Column<string>(nullable: true),
                    SesionCartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionCartDetail", x => x.SesionCartDetailId);
                    table.ForeignKey(
                        name: "FK_SessionCartDetail_SessionCart_SesionCartId",
                        column: x => x.SesionCartId,
                        principalTable: "SessionCart",
                        principalColumn: "SesionCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionCartDetail_SesionCartId",
                table: "SessionCartDetail",
                column: "SesionCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionCartDetail");

            migrationBuilder.DropTable(
                name: "SessionCart");
        }
    }
}
