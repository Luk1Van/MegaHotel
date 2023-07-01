using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegaHotel.Migrations
{
    /// <inheritdoc />
    public partial class addedCalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarRooms",
                columns: table => new
                {
                    IDCalendar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<int>(type: "int", nullable: false),
                    IsAvaible = table.Column<bool>(type: "bit", nullable: false),
                    RoomCalendarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarRooms", x => x.IDCalendar);
                    table.ForeignKey(
                        name: "FK_CalendarRooms_Rooms_RoomCalendarId",
                        column: x => x.RoomCalendarId,
                        principalTable: "Rooms",
                        principalColumn: "IDRoom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CalendarRooms",
                columns: new[] { "IDCalendar", "Data", "IsAvaible", "RoomCalendarId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 2, true, 1 },
                    { 3, 3, true, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRooms_IDCalendar",
                table: "CalendarRooms",
                column: "IDCalendar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRooms_RoomCalendarId",
                table: "CalendarRooms",
                column: "RoomCalendarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarRooms");
        }
    }
}
