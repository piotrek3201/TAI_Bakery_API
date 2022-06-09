using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class Heroku2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1L,
                columns: new[] { "Date", "DeliveryDate" },
                values: new object[] { new DateTime(2022, 6, 9, 18, 48, 34, 327, DateTimeKind.Local).AddTicks(5587), new DateTime(2022, 6, 11, 18, 48, 34, 327, DateTimeKind.Local).AddTicks(5589) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2L,
                columns: new[] { "Date", "DeliveryDate" },
                values: new object[] { new DateTime(2022, 6, 9, 18, 48, 34, 327, DateTimeKind.Local).AddTicks(5594), new DateTime(2022, 6, 13, 18, 48, 34, 327, DateTimeKind.Local).AddTicks(5595) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
