using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace trainStation.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Service = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    SpecialHandling = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    TrainID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Train_TrainID",
                        column: x => x.TrainID,
                        principalTable: "Train",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Train",
                columns: new[] { "Id", "Cargo", "Company", "Length", "Mass", "Name", "Service", "SpecialHandling" },
                values: new object[,]
                {
                    { 1, null, "Glacier Express", 160.0, 0.0, "Zermatt-St.Moritz", 0, false },
                    { 2, 3, "BNSF Railway", 2000.0, 15000.0, "BNSF Transcon", 1, false },
                    { 3, 0, "JR Central", 400.0, 0.0, "Shinkansen Nozomi", 0, false }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "Arrival", "Departure", "Platform", "TrainID" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 8, 15, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, new DateTime(2026, 5, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2026, 5, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), null, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainID",
                table: "Schedule",
                column: "TrainID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Train");
        }
    }
}
