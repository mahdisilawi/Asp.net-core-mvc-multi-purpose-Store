using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hyper_Store.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddViewCountToProductTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 20, 16, 52, 14, 42, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 20, 16, 52, 14, 42, DateTimeKind.Local).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 20, 16, 52, 14, 42, DateTimeKind.Local).AddTicks(3075));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

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
    }
}
