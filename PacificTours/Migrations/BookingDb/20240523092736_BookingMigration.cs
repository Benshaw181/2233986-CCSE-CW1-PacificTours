using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PacificTours.Migrations.BookingDb
{
    /// <inheritdoc />
    public partial class BookingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingType = table.Column<string>(type: "TEXT", nullable: false),
                    BookingDetails = table.Column<string>(type: "TEXT", nullable: false),
                    BookingCustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    BookingPrice = table.Column<double>(type: "REAL", nullable: false),
                    BookingStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingAmountPaid = table.Column<double>(type: "REAL", nullable: false),
                    BookingPackageDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
