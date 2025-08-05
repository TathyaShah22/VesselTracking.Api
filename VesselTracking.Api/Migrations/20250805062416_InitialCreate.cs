using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VesselTracking.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    DockingPortId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacityDeadweight = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.DockingPortId);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImoNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuiltYear = table.Column<int>(type: "int", nullable: false),
                    DeadWeight = table.Column<int>(type: "int", nullable: false),
                    DockingPortId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vessels_Ports_DockingPortId",
                        column: x => x.DockingPortId,
                        principalTable: "Ports",
                        principalColumn: "DockingPortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ports",
                columns: new[] { "DockingPortId", "Country", "IsAvailable", "Name", "capacityDeadweight" },
                values: new object[,]
                {
                    { 1, "UAE", true, "Main Harbor", 100000 },
                    { 2, "UAE", false, "Secondary Port", 50000 }
                });

            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "Id", "BuiltYear", "DeadWeight", "DockingPortId", "ImoNumber", "Name", "OriginCountry", "Type" },
                values: new object[,]
                {
                    { 1, 2015, 74000, 1, "IMO7654321", "Marine Explorer", "India", "LNG" },
                    { 2, 2010, 60000, 2, "IMO1234567", "Ocean Voyager", "USA", "Cargo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_DockingPortId",
                table: "Vessels",
                column: "DockingPortId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vessels");

            migrationBuilder.DropTable(
                name: "Ports");
        }
    }
}
