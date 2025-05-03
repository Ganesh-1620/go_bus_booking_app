using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoBusBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumnsinBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "seats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "seats");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "seats");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "seats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
