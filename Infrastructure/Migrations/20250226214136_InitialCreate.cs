using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCredits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AvailableCredits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "Id", "Name", "TotalCredits" },
                values: new object[,]
                {
                    { new Guid("03911b56-3375-489a-a60f-e7aa7ffbd045"), "Ingeniería de Sistemas", 60 },
                    { new Guid("5e9ee734-61a9-4bd8-9298-d0d0f5f67d3f"), "Derecho", 50 },
                    { new Guid("ac4a1f8d-7b99-4708-9e00-0807dfff45cd"), "Medicina", 70 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("5639e743-26bf-4e1e-bc99-a075ee33b30f"), "Profesor D", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8a9a9af4-2afe-42f4-97dc-60122239279b"), "Profesor B", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a9976d54-fedb-43f9-9015-25a960704818"), "Profesor C", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ae9a6102-0905-4bf1-8d2f-72e74e820b0c"), "Profesor A", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fb038367-2884-45cd-b1ff-a9f1d1308f7a"), "Profesor E", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "Name", "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("015028d8-8e9a-4175-a56c-9df28e44fce4"), 3, "Psicología", null, new Guid("fb038367-2884-45cd-b1ff-a9f1d1308f7a") },
                    { new Guid("13e02595-f92e-48d5-b3f2-690ccdf32bc1"), 3, "Matemáticas", null, new Guid("ae9a6102-0905-4bf1-8d2f-72e74e820b0c") },
                    { new Guid("1c930008-353a-4ae4-a6f0-987603cb68c5"), 3, "Biología", null, new Guid("8a9a9af4-2afe-42f4-97dc-60122239279b") },
                    { new Guid("40bdb71d-ee7c-470e-aec1-e05f17df9ba6"), 3, "Física", null, new Guid("ae9a6102-0905-4bf1-8d2f-72e74e820b0c") },
                    { new Guid("7f7b440f-baef-4d9f-b18a-609c38677571"), 3, "Química", null, new Guid("8a9a9af4-2afe-42f4-97dc-60122239279b") },
                    { new Guid("ac1a1770-e185-4a1c-85ed-74ba3f3c85db"), 3, "Contabilidad", null, new Guid("5639e743-26bf-4e1e-bc99-a075ee33b30f") },
                    { new Guid("c081a086-5b8f-469a-bdbf-ddbecc5fba59"), 3, "Derecho", null, new Guid("fb038367-2884-45cd-b1ff-a9f1d1308f7a") },
                    { new Guid("ce9e4d5c-f4ca-4f3b-92f0-94e9573f1007"), 3, "Programación", null, new Guid("a9976d54-fedb-43f9-9015-25a960704818") },
                    { new Guid("db5076b2-31fc-4562-afc5-8c6ab833033f"), 3, "Bases de Datos", null, new Guid("a9976d54-fedb-43f9-9015-25a960704818") },
                    { new Guid("fe336441-9557-4170-aa43-ebc0ee483783"), 3, "Economía", null, new Guid("5639e743-26bf-4e1e-bc99-a075ee33b30f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramId",
                table: "Students",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Program");
        }
    }
}
