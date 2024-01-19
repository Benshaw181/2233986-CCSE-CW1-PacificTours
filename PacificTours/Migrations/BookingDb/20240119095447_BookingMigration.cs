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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingPrice = table.Column<double>(type: "float", nullable: false),
                    BookingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingAmountPaid = table.Column<double>(type: "float", nullable: false),
                    BookingPackageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
