using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.API.Autor.Migrations
{
    public partial class InitialMigrationPostgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookAuthors",
                columns: table => new
                {
                    IdBookAuthor = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookAuthorName = table.Column<string>(nullable: true),
                    BookAuthorLastName = table.Column<string>(nullable: true),
                    BookAuthorBirthName = table.Column<DateTime>(nullable: true),
                    AuthorLibroGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookAuthors", x => x.IdBookAuthor);
                });

            migrationBuilder.CreateTable(
                name: "academicGrades",
                columns: table => new
                {
                    AcademicGradeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicGradeName = table.Column<string>(nullable: true),
                    AcademicPlace = table.Column<string>(nullable: true),
                    AcademicDate = table.Column<DateTime>(nullable: true),
                    BookAuthorId = table.Column<int>(nullable: false),
                    AcademicGradeGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicGrades", x => x.AcademicGradeId);
                    table.ForeignKey(
                        name: "FK_academicGrades_bookAuthors_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "bookAuthors",
                        principalColumn: "IdBookAuthor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_academicGrades_BookAuthorId",
                table: "academicGrades",
                column: "BookAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academicGrades");

            migrationBuilder.DropTable(
                name: "bookAuthors");
        }
    }
}
