using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeakyBarbers.Data.Migrations
{
    public partial class SeedServicesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ApproximateServiceDurationInMinutes", "CreationDate", "ModifiedDate", "ServiceDescription", "ServiceFee", "ServiceName" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), "Straight Razor Head Shave", 10m, "Peaky Blood Cut" },
                    { 2, 60, new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), "Haircut, neck shave, extended therapeutic scalp massage, shampoo and conditioner.", 50m, "Executive" },
                    { 3, 20, new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), "Complete grooming with neck trim.", 25m, "Classic" },
                    { 4, 15, new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), "A basic haircut for the younger gentlemen.", 15m, "Young Men's Choice" },
                    { 5, 60, new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149), "Hair dyeing and natural colouring.", 40m, "Color Camouflage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Services");
        }
    }
}
