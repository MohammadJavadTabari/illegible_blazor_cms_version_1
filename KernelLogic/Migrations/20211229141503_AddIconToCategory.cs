using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KernelLogic.Migrations
{
    public partial class AddIconToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "dbo",
                table: "ProductCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "dbo",
                table: "ProductCategory");
        }
    }
}
