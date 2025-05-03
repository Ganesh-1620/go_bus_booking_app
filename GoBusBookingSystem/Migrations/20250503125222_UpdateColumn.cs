using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoBusBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_Bookings_BookingId",
                table: "seats");

            migrationBuilder.DropIndex(
                name: "IX_seats_BookingId",
                table: "seats");

            migrationBuilder.AddColumn<string>(
                name: "SeatNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_seats_BookingId",
                table: "seats",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_Bookings_BookingId",
                table: "seats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
