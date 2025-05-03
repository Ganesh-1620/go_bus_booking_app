using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoBusBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemovedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "seats");

            migrationBuilder.DropColumn(
                name: "BookedByCustomerId",
                table: "seats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookedByCustomerId",
                table: "seats",
                type: "int",
                nullable: true);
        }
    }
}
