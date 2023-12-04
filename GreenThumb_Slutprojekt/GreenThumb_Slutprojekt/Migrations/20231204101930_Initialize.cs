using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb_Slutprojekt.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    garden_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Garden_garden_id",
                        column: x => x.garden_id,
                        principalTable: "Garden",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenModelPlantModel",
                columns: table => new
                {
                    GardensId = table.Column<int>(type: "int", nullable: false),
                    PlantsPlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenModelPlantModel", x => new { x.GardensId, x.PlantsPlantId });
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Garden_GardensId",
                        column: x => x.GardensId,
                        principalTable: "Garden",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Plant_PlantsPlantId",
                        column: x => x.PlantsPlantId,
                        principalTable: "Plant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instruction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    care_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instruction_Plant_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenModelPlantModel_PlantsPlantId",
                table: "GardenModelPlantModel",
                column: "PlantsPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_plant_id",
                table: "Instruction",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_garden_id",
                table: "User",
                column: "garden_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenModelPlantModel");

            migrationBuilder.DropTable(
                name: "Instruction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "Garden");
        }
    }
}
