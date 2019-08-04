using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackDaNutzz.Data.Migrations
{
    public partial class addedIsActiveColumnInPlayerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Players",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Players");
        }
    }
}
