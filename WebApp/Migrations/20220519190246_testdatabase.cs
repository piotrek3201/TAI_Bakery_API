using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApp.Migrations
{
    public partial class testdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additions",
                columns: table => new
                {
                    AdditionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdditionName = table.Column<string>(type: "text", nullable: false),
                    AdditionVisual = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additions", x => x.AdditionId);
                });

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    CakeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CakeName = table.Column<string>(type: "text", nullable: false),
                    CakeColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.CakeId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Fillings",
                columns: table => new
                {
                    FillingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FillingName = table.Column<string>(type: "text", nullable: false),
                    FillingColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fillings", x => x.FillingId);
                });

            migrationBuilder.CreateTable(
                name: "Glazes",
                columns: table => new
                {
                    GlazeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GlazeName = table.Column<string>(type: "text", nullable: false),
                    GlazeColor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glazes", x => x.GlazeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerEmail = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CustomerPhone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    CustomerAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CustomerCity = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CustomerPostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrderValue = table.Column<decimal>(type: "numeric", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diameter = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsByWeight = table.Column<bool>(type: "boolean", nullable: false),
                    IsCustomizable = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customizations",
                columns: table => new
                {
                    CustomizationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SizeId = table.Column<long>(type: "bigint", nullable: false),
                    GlazeId = table.Column<long>(type: "bigint", nullable: false),
                    FillingId = table.Column<long>(type: "bigint", nullable: false),
                    CakeId = table.Column<long>(type: "bigint", nullable: false),
                    AdditionId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.CustomizationId);
                    table.ForeignKey(
                        name: "FK_Customizations_Additions_AdditionId",
                        column: x => x.AdditionId,
                        principalTable: "Additions",
                        principalColumn: "AdditionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_Cakes_CakeId",
                        column: x => x.CakeId,
                        principalTable: "Cakes",
                        principalColumn: "CakeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_Fillings_FillingId",
                        column: x => x.FillingId,
                        principalTable: "Fillings",
                        principalColumn: "FillingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_Glazes_GlazeId",
                        column: x => x.GlazeId,
                        principalTable: "Glazes",
                        principalColumn: "GlazeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customizations_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomizationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "Customizations",
                        principalColumn: "CustomizationId");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Additions",
                columns: new[] { "AdditionId", "AdditionName", "AdditionVisual" },
                values: new object[] { 1L, "Owoce", "" });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "CakeId", "CakeColor", "CakeName" },
                values: new object[,]
                {
                    { 1L, "#FFFF99", "Śmietankowe" },
                    { 2L, "#FDE456", "Waniliowe" },
                    { 3L, "#AC7A33", "Czekoladowe" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1L, "Torty" },
                    { 2L, "Ciasta" },
                    { 3L, "Ciastka" },
                    { 4L, "Cukierki" },
                    { 5L, "Lody" }
                });

            migrationBuilder.InsertData(
                table: "Fillings",
                columns: new[] { "FillingId", "FillingColor", "FillingName" },
                values: new object[,]
                {
                    { 1L, "#FFFDD0", "Kremowe" },
                    { 2L, "#7B3F00", "Czekoladowe" },
                    { 3L, "#CF2942", "Truskawkowe" },
                    { 4L, "#DC143C", "Malinowe" }
                });

            migrationBuilder.InsertData(
                table: "Glazes",
                columns: new[] { "GlazeId", "GlazeColor", "GlazeName" },
                values: new object[,]
                {
                    { 1L, "#FFFFF0", "Śmietankowa" },
                    { 2L, "#7B3F00", "Czekoladowa" },
                    { 3L, "#F5ACCB", "Truskawkowa" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerAddress", "CustomerCity", "CustomerEmail", "CustomerName", "CustomerPhone", "CustomerPostalCode", "Date", "DeliveryDate", "IsFinished", "OrderValue" },
                values: new object[,]
                {
                    { 1L, "Aleja Jana Pawła II 21/37", "", "piotrek3201@onet.pl", "Piotr Kałuziński", "+48501171851", "00-213", new DateTime(2022, 5, 19, 21, 2, 46, 751, DateTimeKind.Local).AddTicks(5673), new DateTime(2022, 5, 21, 21, 2, 46, 751, DateTimeKind.Local).AddTicks(5675), false, 50m },
                    { 2L, "Długa 10", "", "jan.kowalski@gmail.com", "Jan Kowalski", "+48501355704", "02-137", new DateTime(2022, 5, 19, 21, 2, 46, 751, DateTimeKind.Local).AddTicks(5680), new DateTime(2022, 5, 23, 21, 2, 46, 751, DateTimeKind.Local).AddTicks(5681), false, 20m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Diameter" },
                values: new object[,]
                {
                    { 1L, 20 },
                    { 2L, 30 },
                    { 3L, 45 }
                });

            migrationBuilder.InsertData(
                table: "Customizations",
                columns: new[] { "CustomizationId", "AdditionId", "CakeId", "FillingId", "GlazeId", "SizeId", "Text" },
                values: new object[] { 1L, 1L, 1L, 2L, 1L, 3L, "100 lat!" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "IsByWeight", "IsCustomizable", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, 1L, "Sam skomponuj swój wymarzony tort!", "", false, true, "Tort własny", 50m },
                    { 2L, 2L, "Pyszne czekoladowe ciasto, lepsze niż we Władysławowie!", "", false, false, "Brownie", 20m },
                    { 3L, 4L, "Klasyczne ciasto ze świeżymi jabłkami", "", false, false, "Szarlotka", 15m },
                    { 4L, 4L, "Kultowe karmelki", "", true, false, "Kukułki", 17m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "CustomizationId", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, 8.5m, 1L, 0.5 },
                    { 2L, null, 1L, 40m, 3L, 2.0 },
                    { 3L, null, 2L, 15m, 4L, 1.0 },
                    { 4L, null, 2L, 4.75m, 2L, 0.25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_AdditionId",
                table: "Customizations",
                column: "AdditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_CakeId",
                table: "Customizations",
                column: "CakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_FillingId",
                table: "Customizations",
                column: "FillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_GlazeId",
                table: "Customizations",
                column: "GlazeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_SizeId",
                table: "Customizations",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomizationId",
                table: "OrderDetails",
                column: "CustomizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Additions");

            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropTable(
                name: "Fillings");

            migrationBuilder.DropTable(
                name: "Glazes");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
