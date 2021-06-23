using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amznStore.Services.Discount.Infrastructure.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidTill = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CouponCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CategoryName", "CouponCode", "CouponCreated", "DiscountPercentage", "ValidTill" },
                values: new object[] { 1, "ALL", "ABC-XYZ", new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), 10m, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
