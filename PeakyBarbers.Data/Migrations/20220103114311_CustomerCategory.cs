using Microsoft.EntityFrameworkCore.Migrations;

namespace PeakyBarbers.Data.Migrations
{
    public partial class CustomerCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerCategory",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerCategory",
                table: "AspNetUsers");
        }
    }
}
