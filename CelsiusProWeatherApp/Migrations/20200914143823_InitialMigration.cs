using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsiusProWeatherApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Lon = table.Column<string>(nullable: false),
                    Lat = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSeries",
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
                columns: new[] { "Id", "Lat", "Lon" },
                values: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "12.12", "21.32" });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeries_StationId",
                table: "TimeSeries",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSeries");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
