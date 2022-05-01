using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InquiryPlate.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infraction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infraction_Plates_PlateId",
                        column: x => x.PlateId,
                        principalTable: "Plates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Infraction_PlateId",
                table: "Infraction",
                column: "PlateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infraction");

            migrationBuilder.DropTable(
                name: "Plates");
        }
    }
}
