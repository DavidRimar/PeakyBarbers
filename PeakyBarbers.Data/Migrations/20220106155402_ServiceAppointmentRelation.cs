using Microsoft.EntityFrameworkCore.Migrations;

namespace PeakyBarbers.Data.Migrations
{
    public partial class ServiceAppointmentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "AppointmentSlots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSlots_ServiceId",
                table: "AppointmentSlots",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSlots_Services_ServiceId",
                table: "AppointmentSlots",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSlots_Services_ServiceId",
                table: "AppointmentSlots");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSlots_ServiceId",
                table: "AppointmentSlots");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "AppointmentSlots");
        }
    }
}
