using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointMed.API.Data.Migrations
{
    public partial class Added_PatientName_to_Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Appointments");
        }
    }
}
