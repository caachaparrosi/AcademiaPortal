using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("2d18dc6f-a7aa-467b-be0e-78feb6824c99"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("54fc4635-e80b-4166-af6f-e4bbbf32ce8f"));

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03911b56-3375-489a-a60f-e7aa7ffbd045"), "Profesor 1" },
                    { new Guid("5e9ee734-61a9-4bd8-9298-d0d0f5f67d3f"), "Profesor 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("03911b56-3375-489a-a60f-e7aa7ffbd045"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("5e9ee734-61a9-4bd8-9298-d0d0f5f67d3f"));

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2d18dc6f-a7aa-467b-be0e-78feb6824c99"), "Profesor 2" },
                    { new Guid("54fc4635-e80b-4166-af6f-e4bbbf32ce8f"), "Profesor 1" }
                });
        }
    }
}
