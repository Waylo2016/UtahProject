using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class ShootMeCusICantCaseProperly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Dinosaurs",
                newName: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Dinosaurs",
                newName: "gender");
        }
    }
}
