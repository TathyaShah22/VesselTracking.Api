using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VesselTracking.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Docking_portDockingPortId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vessels_Ports_Docking_portDockingPortId",
                        column: x => x.Docking_portDockingPortId,
                        principalTable: "Ports",
                        principalColumn: "DockingPortId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_Docking_portDockingPortId",
                table: "Vessels",
                column: "Docking_portDockingPortId");
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
