using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day60.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfolioTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioTrackerEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PortfolioValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    CashReserve = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTrackerEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioTrackerEntries");
        }
    }
}
