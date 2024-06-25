using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighScoreAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class GameModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakingScore",
                table: "HighScores");

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Games");

            migrationBuilder.AddColumn<DateTime>(
                name: "BreakingScore",
                table: "HighScores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}