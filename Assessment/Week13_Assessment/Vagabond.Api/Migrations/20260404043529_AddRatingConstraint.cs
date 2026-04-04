using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vagabond.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Destinations_Rating",
                table: "Destinations",
                sql: "Rating >= 1 AND Rating <= 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Destinations_Rating",
                table: "Destinations");
        }
    }
}
