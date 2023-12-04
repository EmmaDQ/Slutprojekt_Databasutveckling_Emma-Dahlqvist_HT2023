using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb_Slutprojekt.Migrations
{
    public partial class newTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenModelPlantModel_Garden_GardensId",
                table: "GardenModelPlantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GardenModelPlantModel_Plant_PlantsPlantId",
                table: "GardenModelPlantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Plant_plant_id",
                table: "Instruction");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Garden_garden_id",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plant",
                table: "Plant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Garden",
                table: "Garden");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Plant",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "Instruction",
                newName: "Instructions");

            migrationBuilder.RenameTable(
                name: "Garden",
                newName: "Gardens");

            migrationBuilder.RenameIndex(
                name: "IX_User_garden_id",
                table: "Users",
                newName: "IX_Users_garden_id");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_plant_id",
                table: "Instructions",
                newName: "IX_Instructions_plant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gardens",
                table: "Gardens",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenModelPlantModel_Gardens_GardensId",
                table: "GardenModelPlantModel",
                column: "GardensId",
                principalTable: "Gardens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GardenModelPlantModel_Plants_PlantsPlantId",
                table: "GardenModelPlantModel",
                column: "PlantsPlantId",
                principalTable: "Plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Plants_plant_id",
                table: "Instructions",
                column: "plant_id",
                principalTable: "Plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gardens_garden_id",
                table: "Users",
                column: "garden_id",
                principalTable: "Gardens",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GardenModelPlantModel_Gardens_GardensId",
                table: "GardenModelPlantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GardenModelPlantModel_Plants_PlantsPlantId",
                table: "GardenModelPlantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Plants_plant_id",
                table: "Instructions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gardens_garden_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gardens",
                table: "Gardens");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "Plant");

            migrationBuilder.RenameTable(
                name: "Instructions",
                newName: "Instruction");

            migrationBuilder.RenameTable(
                name: "Gardens",
                newName: "Garden");

            migrationBuilder.RenameIndex(
                name: "IX_Users_garden_id",
                table: "User",
                newName: "IX_User_garden_id");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_plant_id",
                table: "Instruction",
                newName: "IX_Instruction_plant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plant",
                table: "Plant",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Garden",
                table: "Garden",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GardenModelPlantModel_Garden_GardensId",
                table: "GardenModelPlantModel",
                column: "GardensId",
                principalTable: "Garden",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GardenModelPlantModel_Plant_PlantsPlantId",
                table: "GardenModelPlantModel",
                column: "PlantsPlantId",
                principalTable: "Plant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Plant_plant_id",
                table: "Instruction",
                column: "plant_id",
                principalTable: "Plant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Garden_garden_id",
                table: "User",
                column: "garden_id",
                principalTable: "Garden",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
