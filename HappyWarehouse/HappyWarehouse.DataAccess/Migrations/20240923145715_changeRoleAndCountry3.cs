using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyWarehouse.DataAccess.Migrations
{
    public partial class changeRoleAndCountry3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Country_CountryId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CountryId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CountryId",
                table: "Warehouse",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Country_CountryId",
                table: "Warehouse",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
