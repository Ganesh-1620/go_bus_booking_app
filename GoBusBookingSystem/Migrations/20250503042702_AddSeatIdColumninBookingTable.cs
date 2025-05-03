using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoBusBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatIdColumninBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Bookings");
        }
    }
}
