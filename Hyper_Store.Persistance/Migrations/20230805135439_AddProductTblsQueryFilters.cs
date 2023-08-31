using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Store.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTblsQueryFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 17, 24, 39, 401, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 17, 24, 39, 401, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 17, 24, 39, 401, DateTimeKind.Local).AddTicks(3513));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 17, 22, 9, 76, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 17, 22, 9, 76, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 5, 17, 22, 9, 76, DateTimeKind.Local).AddTicks(4501));
        }
    }
}
