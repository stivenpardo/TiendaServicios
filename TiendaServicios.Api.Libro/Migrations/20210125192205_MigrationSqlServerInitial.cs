using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TiendaServicios.Api.Libro.Migrations
{
    public partial class MigrationSqlServerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryMaterials",
                columns: table => new
                {
                    LibraryMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    DatePublication = table.Column<DateTime>(nullable: true),
                    BookAuthor = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMaterials", x => x.LibraryMaterialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryMaterials");
        }
    }
}
