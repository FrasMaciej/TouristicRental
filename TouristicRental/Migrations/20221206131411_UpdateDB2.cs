using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristicRental.Migrations
{
    public partial class UpdateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Orders");
        }
    }
}
