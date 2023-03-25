using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<int>(type: "INTEGER", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    MaxAmount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PaddleBoardTypes",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    NameOfType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaddleBoardTypes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryType = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false),
                    TotalKilometers = table.Column<double>(type: "REAL", nullable: false),
                    AtID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Deliveries_Addresses_AtID",
                        column: x => x.AtID,
                        principalTable: "Addresses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TimeSpan = table.Column<long>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    HeldAtID = table.Column<string>(type: "TEXT", nullable: false),
                    Activity = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    CVR = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Events_Addresses_HeldAtID",
                        column: x => x.HeldAtID,
                        principalTable: "Addresses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaddleBoards",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    MinCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    PaddleBoardTypeID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaddleBoards", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PaddleBoards_PaddleBoardTypes_PaddleBoardTypeID",
                        column: x => x.PaddleBoardTypeID,
                        principalTable: "PaddleBoardTypes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false),
                    OrderedByID = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryID = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentStage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_OrderedByID",
                        column: x => x.OrderedByID,
                        principalTable: "Customers",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Orders_Deliveries_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Deliveries",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ExtrasOrders",
                columns: table => new
                {
                    ExtrasID = table.Column<string>(type: "TEXT", nullable: false),
                    OrderID = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtrasOrders", x => new { x.ExtrasID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_ExtrasOrders_Extras_ExtrasID",
                        column: x => x.ExtrasID,
                        principalTable: "Extras",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtrasOrders_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderedInGuid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Reservations_Orders_OrderedInGuid",
                        column: x => x.OrderedInGuid,
                        principalTable: "Orders",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PaddleBoardReservations",
                columns: table => new
                {
                    PadleBoardID = table.Column<string>(type: "TEXT", nullable: false),
                    ReservationID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaddleBoardReservations", x => new { x.ReservationID, x.PadleBoardID });
                    table.ForeignKey(
                        name: "FK_PaddleBoardReservations_PaddleBoards_PadleBoardID",
                        column: x => x.PadleBoardID,
                        principalTable: "PaddleBoards",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaddleBoardReservations_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_AtID",
                table: "Deliveries",
                column: "AtID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_HeldAtID",
                table: "Events",
                column: "HeldAtID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtrasOrders_OrderID",
                table: "ExtrasOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryID",
                table: "Orders",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedByID",
                table: "Orders",
                column: "OrderedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PaddleBoardReservations_PadleBoardID",
                table: "PaddleBoardReservations",
                column: "PadleBoardID");

            migrationBuilder.CreateIndex(
                name: "IX_PaddleBoards_PaddleBoardTypeID",
                table: "PaddleBoards",
                column: "PaddleBoardTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OrderedInGuid",
                table: "Reservations",
                column: "OrderedInGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ExtrasOrders");

            migrationBuilder.DropTable(
                name: "PaddleBoardReservations");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "PaddleBoards");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "PaddleBoardTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
