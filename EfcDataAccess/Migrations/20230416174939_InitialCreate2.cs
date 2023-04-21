using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaddleBoardReservations",
                table: "PaddleBoardReservations");

            migrationBuilder.DropIndex(
                name: "IX_PaddleBoardReservations_PadleBoardID",
                table: "PaddleBoardReservations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaddleBoardReservations",
                table: "PaddleBoardReservations",
                columns: new[] { "PadleBoardID", "ReservationID" });

            migrationBuilder.CreateIndex(
                name: "IX_PaddleBoardReservations_ReservationID",
                table: "PaddleBoardReservations",
                column: "ReservationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaddleBoardReservations",
                table: "PaddleBoardReservations");

            migrationBuilder.DropIndex(
                name: "IX_PaddleBoardReservations_ReservationID",
                table: "PaddleBoardReservations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaddleBoardReservations",
                table: "PaddleBoardReservations",
                columns: new[] { "ReservationID", "PadleBoardID" });

            migrationBuilder.CreateIndex(
                name: "IX_PaddleBoardReservations_PadleBoardID",
                table: "PaddleBoardReservations",
                column: "PadleBoardID");
        }
    }
}
