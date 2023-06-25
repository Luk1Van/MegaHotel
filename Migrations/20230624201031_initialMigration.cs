using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MegaHotel.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapacityRooms",
                columns: table => new
                {
                    IdCapacity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityRooms", x => x.IdCapacity);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRooms",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRooms", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    IDRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityRoomId = table.Column<int>(type: "int", nullable: false),
                    TypeRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.IDRoom);
                    table.ForeignKey(
                        name: "FK_Rooms_CapacityRooms_CapacityRoomId",
                        column: x => x.CapacityRoomId,
                        principalTable: "CapacityRooms",
                        principalColumn: "IdCapacity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_TypeRooms_TypeRoomId",
                        column: x => x.TypeRoomId,
                        principalTable: "TypeRooms",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CapacityRooms",
                columns: new[] { "IdCapacity", "GuestNumber" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "TypeRooms",
                columns: new[] { "IdType", "RoomType" },
                values: new object[,]
                {
                    { 1, "Basic" },
                    { 2, "Premium" },
                    { 3, "Lux" },
                    { 4, "PremiumLux" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "IDRoom", "CapacityRoomId", "Description", "ImageURL", "Price", "RoomNumber", "TypeRoomId" },
                values: new object[,]
                {
                    { 1, 2, "Basic room for two person.", "https://images.unsplash.com/photo-1618773928121-c32242e63f39?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80", 49.990000000000002, 20, 1 },
                    { 2, 1, "Basic room for one person.", "https://images.unsplash.com/photo-1611892440504-42a792e24d32?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80", 35.990000000000002, 21, 1 },
                    { 3, 3, "Premium room for three person.", "https://images.unsplash.com/photo-1591088398332-8a7791972843?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1074&q=80", 65.989999999999995, 30, 2 },
                    { 4, 3, "premium room for three person.", "https://images.unsplash.com/photo-1590490360182-c33d57733427?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1074&q=80", 65.989999999999995, 31, 2 },
                    { 5, 2, "Lux room for two person.", "https://images.unsplash.com/photo-1562438668-bcf0ca6578f0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1460&q=80", 99.989999999999995, 40, 3 },
                    { 6, 3, "Lux room for three person.", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80", 129.99000000000001, 41, 3 },
                    { 7, 4, "Premium-Lux for 6 person.", "https://plus.unsplash.com/premium_photo-1661876306620-f2f2989f8f8b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1084&q=80", 249.99000000000001, 50, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapacityRooms_IdCapacity",
                table: "CapacityRooms",
                column: "IdCapacity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Id",
                table: "Messages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CapacityRoomId",
                table: "Rooms",
                column: "CapacityRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IDRoom",
                table: "Rooms",
                column: "IDRoom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TypeRoomId",
                table: "Rooms",
                column: "TypeRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeRooms_IdType",
                table: "TypeRooms",
                column: "IdType",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "CapacityRooms");

            migrationBuilder.DropTable(
                name: "TypeRooms");
        }
    }
}
