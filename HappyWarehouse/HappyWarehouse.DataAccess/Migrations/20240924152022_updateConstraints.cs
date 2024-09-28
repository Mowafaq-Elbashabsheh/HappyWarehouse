using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyWarehouse.DataAccess.Migrations
{
    public partial class updateConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { (short)1, "Admin", "مسؤول النظام" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { (short)2, "Management", "ادارة" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { (short)3, "Auditor", "مدقق" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { 1, "Admin", "مسؤول النظام" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { 2, "Management", "ادارة" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[] { 3, "Auditor", "مدقق" });
        }
    }
}
