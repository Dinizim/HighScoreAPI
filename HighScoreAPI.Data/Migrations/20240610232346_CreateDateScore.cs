﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighScoreAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDateScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BreakingScore",
                table: "HighScores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakingScore",
                table: "HighScores");
        }
    }
}