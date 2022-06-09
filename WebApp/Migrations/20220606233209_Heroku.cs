using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class Heroku : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1L,
                columns: new[] { "Date", "DeliveryDate" },
                values: new object[] { new DateTime(2022, 6, 7, 1, 32, 8, 990, DateTimeKind.Local).AddTicks(2744), new DateTime(2022, 6, 9, 1, 32, 8, 990, DateTimeKind.Local).AddTicks(2745) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2L,
                columns: new[] { "Date", "DeliveryDate" },
                values: new object[] { new DateTime(2022, 6, 7, 1, 32, 8, 990, DateTimeKind.Local).AddTicks(2750), new DateTime(2022, 6, 11, 1, 32, 8, 990, DateTimeKind.Local).AddTicks(2752) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1L,
                columns: new[] { "Date", "DeliveryDate" },
                values: new object[] { new DateTime(2022, 6, 7, 1, 30, 2, 555, DateTimeKind.Local).AddTicks(9060), new DateTime(2022, 6, 9, 1, 30, 2, 555, DateTimeKind.Local).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2L,
                columns: new[] { "Date", "DeliveryDate" },
                values: new object[] { new DateTime(2022, 6, 7, 1, 30, 2, 555, DateTimeKind.Local).AddTicks(9067), new DateTime(2022, 6, 11, 1, 30, 2, 555, DateTimeKind.Local).AddTicks(9068) });
        }
    }
}
