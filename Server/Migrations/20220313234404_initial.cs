using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace volvo.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelVehicle",
                columns: table => new
                {
                    IdModelVehicle = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameModelVehicle = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVehicle", x => x.IdModelVehicle);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    IdVehicle = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdModelVehicle = table.Column<long>(type: "INTEGER", nullable: false),
                    YearManufacturing = table.Column<int>(type: "INTEGER", maxLength: 4, nullable: false),
                    YearModel = table.Column<int>(type: "INTEGER", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.IdVehicle);
                    table.ForeignKey(
                        name: "FK_Vehicle_ModelVehicle_IdModelVehicle",
                        column: x => x.IdModelVehicle,
                        principalTable: "ModelVehicle",
                        principalColumn: "IdModelVehicle");
                });

            migrationBuilder.InsertData(
                table: "ModelVehicle",
                columns: new[] { "IdModelVehicle", "NameModelVehicle" },
                values: new object[] { 1L, "FH" });

            migrationBuilder.InsertData(
                table: "ModelVehicle",
                columns: new[] { "IdModelVehicle", "NameModelVehicle" },
                values: new object[] { 2L, "FM" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "IdVehicle", "IdModelVehicle", "YearManufacturing", "YearModel" },
                values: new object[] { 1L, 1L, 2022, 2022 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "IdVehicle", "IdModelVehicle", "YearManufacturing", "YearModel" },
                values: new object[] { 2L, 2L, 2022, 2023 });

            migrationBuilder.CreateIndex(
                name: "IX_ModelVehicle_IdModelVehicle",
                table: "ModelVehicle",
                column: "IdModelVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_IdModelVehicle",
                table: "Vehicle",
                column: "IdModelVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_IdVehicle_IdModelVehicle",
                table: "Vehicle",
                columns: new[] { "IdVehicle", "IdModelVehicle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "ModelVehicle");
        }
    }
}
