using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "PaddleBoards");

            migrationBuilder.DropColumn(
                name: "MinCapacity",
                table: "PaddleBoards");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PaddleBoards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PaddleBoards");

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "PaddleBoardTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinCapacity",
                table: "PaddleBoardTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PaddleBoardTypes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "PaddleBoardTypes");

            migrationBuilder.DropColumn(
                name: "MinCapacity",
                table: "PaddleBoardTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PaddleBoardTypes");

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "PaddleBoards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinCapacity",
                table: "PaddleBoards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PaddleBoards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PaddleBoards",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
