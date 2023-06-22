using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristicRental.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Goods",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Goods");
        }
    }
}
