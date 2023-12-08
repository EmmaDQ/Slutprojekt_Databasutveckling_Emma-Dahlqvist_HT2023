using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb_Slutprojekt.Migrations
{
    public partial class rebootTestOfCryptation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "iSG2P/e++yYRlkujpu84zA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "password");
        }
    }
}
