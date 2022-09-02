using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCGPS.Data.Migrations
{
    public partial class ModifyMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImdbRating",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Movies");

            migrationBuilder.AlterColumn<float>(
                name: "ImdbRating",
                table: "Movies",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
