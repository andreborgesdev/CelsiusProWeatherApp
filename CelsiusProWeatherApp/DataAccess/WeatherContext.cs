using CelsiusProWeatherApp.Entities;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace CelsiusProWeatherApp.DataAccess
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo("./DataSources/stations.xlsx")))
            {
                var firstSheet = package.Workbook.Worksheets["stations"];
                var numberOfRow = firstSheet.Dimension.Rows;
                var numberOfColumns = firstSheet.Dimension.Columns;

                for (int i = 2; i <= numberOfRow; i++)
                {
                    modelBuilder.Entity<Station>().HasData(
                        new Station()
                        {
                            Id = Guid.NewGuid(),
                            Name = firstSheet.Cells[$"A{i}"].Text,
                            Lat = firstSheet.Cells[$"B{i}"].Text,
                            Lon = firstSheet.Cells[$"C{i}"].Text
                        });
                }
            }

            using (var package = new ExcelPackage(new FileInfo("./DataSources/time-series.xlsx")))
            {
                var firstSheet = package.Workbook.Worksheets["stations"];
                var numberOfRow = firstSheet.Dimension.Rows;
                var numberOfColumns = firstSheet.Dimension.Columns;

                for (int i = 2; i <= numberOfRow; i++)
                {
                    modelBuilder.Entity<Station>().HasData(
                        new Station()
                        {
                            Id = Guid.NewGuid(),
                            Name = firstSheet.Cells[$"A{i}"].Text,
                            Lat = firstSheet.Cells[$"B{i}"].Text,
                            Lon = firstSheet.Cells[$"C{i}"].Text
                        });
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
