using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalPage.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DBSequenceHiLo",
                startValue: 1000L,
                incrementBy: 50);

            migrationBuilder.CreateTable(
                name: "RentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentItemId = table.Column<int>(type: "int", nullable: false),
                    StartOfRenting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfRenting = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentedItems_RentItems_RentItemId",
                        column: x => x.RentItemId,
                        principalTable: "RentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RentItems",
                columns: new[] { "Id", "Available", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "CATEGORY_SKI", "sielni lehet vele", "síléc", 500 },
                    { 2, true, "CATEGORY_SNOWBOARD", "tartja a bokád", "snowboard csizma", 1000 },
                    { 3, true, "CATEGORY_SNOWBOARD", "gyors", "snowboard", 2000 },
                    { 4, true, "CATEGORY_PROTECTIVEEQUIPMENTS", "szép kesztyű", "kesztyű", 220 },
                    { 5, true, "CATEGORY_SKI", "hegyes", "sí bot", 200 },
                    { 6, true, "CATEGORY_CLOTHING", "piros, nem engedi át a vizet", "snowboard nadrág", 1400 },
                    { 7, true, "CATEGORY_PROTECTIVEEQUIPMENTS", "védi a térded, fekete", "térdvédő", 1050 },
                    { 8, true, "CATEGORY_CLOTHING", "síkabát", "kabát", 2500 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sarah Parker" },
                    { 2, "Michael Corse" },
                    { 3, "Anna Smith" }
                });

            migrationBuilder.InsertData(
                table: "RentedItems",
                columns: new[] { "Id", "EndOfRenting", "RentItemId", "StartOfRenting", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 2, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 4, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 3, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 4, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 6, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentedItems_RentItemId",
                table: "RentedItems",
                column: "RentItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentedItems_UserId",
                table: "RentedItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentedItems");

            migrationBuilder.DropTable(
                name: "RentItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "DBSequenceHiLo");
        }
    }
}
