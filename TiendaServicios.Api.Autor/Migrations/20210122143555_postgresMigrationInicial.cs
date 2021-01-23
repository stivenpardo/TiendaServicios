using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class postgresMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuth",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BookAuthorGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuth", x => x.BookAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "AcademyLevel",
                columns: table => new
                {
                    AcademicLevelId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    AcademyCenter = table.Column<int>(nullable: false),
                    GradeDate = table.Column<DateTime>(nullable: true),
                    BookAuthorId = table.Column<int>(nullable: false),
                    AcedemiLevelGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyLevel", x => x.AcademicLevelId);
                    table.ForeignKey(
                        name: "FK_AcademyLevel_BookAuth_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "BookAuth",
                        principalColumn: "BookAuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademyLevel_BookAuthorId",
                table: "AcademyLevel",
                column: "BookAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademyLevel");

            migrationBuilder.DropTable(
                name: "BookAuth");
        }
    }
}
