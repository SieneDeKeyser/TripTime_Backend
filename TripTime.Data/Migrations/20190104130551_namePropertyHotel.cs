using Microsoft.EntityFrameworkCore.Migrations;

namespace TripTime.Data.Migrations
{
    public partial class namePropertyHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hotels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hotels");
        }
    }
}
