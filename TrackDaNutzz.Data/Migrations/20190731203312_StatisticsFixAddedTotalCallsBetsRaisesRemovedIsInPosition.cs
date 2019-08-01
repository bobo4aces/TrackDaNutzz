using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackDaNutzz.Data.Migrations
{
    public partial class StatisticsFixAddedTotalCallsBetsRaisesRemovedIsInPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AggressionFactor",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "IsInPosition",
                table: "HandPlayers");

            migrationBuilder.AddColumn<int>(
                name: "TotalBets",
                table: "Statistics",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCalls",
                table: "Statistics",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRaises",
                table: "Statistics",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBets",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "TotalCalls",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "TotalRaises",
                table: "Statistics");

            migrationBuilder.AddColumn<decimal>(
                name: "AggressionFactor",
                table: "Statistics",
                type: "DECIMAL(15,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsInPosition",
                table: "HandPlayers",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }
    }
}
