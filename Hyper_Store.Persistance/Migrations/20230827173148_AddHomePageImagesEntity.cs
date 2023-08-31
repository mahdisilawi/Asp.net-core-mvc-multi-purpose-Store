using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Store.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddHomePageImagesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 27, 21, 1, 47, 376, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 27, 21, 1, 47, 376, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 27, 21, 1, 47, 376, DateTimeKind.Local).AddTicks(1436));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 20, 22, 35, 17, 932, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 20, 22, 35, 17, 932, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 20, 22, 35, 17, 932, DateTimeKind.Local).AddTicks(3648));
        }
    }
}
