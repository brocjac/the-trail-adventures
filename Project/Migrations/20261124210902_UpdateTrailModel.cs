using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrailModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "TotalLengthMiles",
                table: "Trails");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Activities",
                newName: "Type");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surface",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalLengthMiles",
                table: "Activities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TrailId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrailId",
                table: "Activities",
                column: "TrailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Trails_TrailId",
                table: "Activities",
                column: "TrailId",
                principalTable: "Trails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Trails_TrailId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TrailId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TotalLengthMiles",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TrailId",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Activities",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Trails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Trails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surface",
                table: "Trails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalLengthMiles",
                table: "Trails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
