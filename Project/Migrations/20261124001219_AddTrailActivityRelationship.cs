using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class AddTrailActivityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TrailId",
                table: "Activities");
        }
    }
}
