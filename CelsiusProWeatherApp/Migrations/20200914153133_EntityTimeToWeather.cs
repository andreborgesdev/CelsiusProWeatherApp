using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsiusProWeatherApp.Migrations
{
    public partial class EntityTimeToWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSeries");

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

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    StationId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    TypeOfIndicator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon", "Name" },
                values: new object[] { new Guid("657f70a7-3fd5-4bb5-b61d-05132c56088e"), "7.47", "46.98", "Berne - Zollikofen" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon", "Name" },
                values: new object[] { new Guid("022aaaa1-35e2-4484-9b9f-7d16f97705bf"), "6.67", "46.51", "Pully" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Lat", "Lon", "Name" },
                values: new object[] { new Guid("0a666e89-9d93-4636-afee-61bbb0811973"), "8.5667", "47.3831", "ZUERICH/FLUNTERN" });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_StationId",
                table: "Weather",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("022aaaa1-35e2-4484-9b9f-7d16f97705bf"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("0a666e89-9d93-4636-afee-61bbb0811973"));

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("657f70a7-3fd5-4bb5-b61d-05132c56088e"));

            migrationBuilder.CreateTable(
                name: "TimeSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    StationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfIndicator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSeries_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeries_StationId",
                table: "TimeSeries",
                column: "StationId");
        }
    }
}
