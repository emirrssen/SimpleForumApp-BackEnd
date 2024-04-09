using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleForumApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 9, 22, 51, 51, 758, DateTimeKind.Local).AddTicks(7974), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aktif", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2024, 4, 9, 22, 51, 51, 758, DateTimeKind.Local).AddTicks(7995), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasif", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2024, 4, 9, 22, 51, 51, 758, DateTimeKind.Local).AddTicks(7998), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silindi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
