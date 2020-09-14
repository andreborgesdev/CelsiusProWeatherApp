using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsiusProWeatherApp.Migrations
{
    public partial class AddedNameAttributeToStations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stations",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon", "Name" },
                values: new object[] { new Guid("b7eba244-620f-492b-b0de-59683aaa5633"), "7.47", "46.98", "Berne - Zollikofen" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon", "Name" },
                values: new object[] { new Guid("cd59526f-d608-4769-a54a-e1bf394ccef2"), "6.67", "46.51", "Pully" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon", "Name" },
                values: new object[] { new Guid("51ae7adb-db3d-4d6a-8d34-d8645f116aec"), "8.5667", "47.3831", "ZUERICH/FLUNTERN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("51ae7adb-db3d-4d6a-8d34-d8645f116aec"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("b7eba244-620f-492b-b0de-59683aaa5633"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("cd59526f-d608-4769-a54a-e1bf394ccef2"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stations");

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon" },
                values: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "12.12", "21.32" });
        }
    }
}
