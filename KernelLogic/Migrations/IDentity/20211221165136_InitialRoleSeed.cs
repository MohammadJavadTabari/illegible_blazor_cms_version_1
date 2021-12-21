using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KernelLogic.Migrations.IDentity
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "013cd01c-a92d-48a9-8f81-0c319fc96bd5", "ac1689da-9b33-4c75-86f2-0a5098303d21", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3aba5873-a7ab-44a3-9924-0aa40fdc8ee3", "8b6be016-4598-4a12-9fb4-6b7b1e748f31", "Viewer", "VIEWER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "013cd01c-a92d-48a9-8f81-0c319fc96bd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aba5873-a7ab-44a3-9924-0aa40fdc8ee3");
        }
    }
}
