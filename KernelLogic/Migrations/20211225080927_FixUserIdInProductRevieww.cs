using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KernelLogic.Migrations
{
    public partial class FixUserIdInProductRevieww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductReviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProductReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
