using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class EveryRecordGetsStars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Added",
                table: "Activities");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Trails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Trails",
                type: "int",
                nullable: false,
                defaultValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Added",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Trails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Activities",
                type: "datetime2",
                nullable: true);
        }
    }
}
