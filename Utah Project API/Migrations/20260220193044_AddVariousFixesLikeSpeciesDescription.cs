using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class AddVariousFixesLikeSpeciesDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent1Id",
                table: "Nestings");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent2Id",
                table: "Nestings");

            migrationBuilder.RenameColumn(
                name: "Parent2Id",
                table: "Nestings",
                newName: "Parent2Code");

            migrationBuilder.RenameColumn(
                name: "Parent1Id",
                table: "Nestings",
                newName: "Parent1Code");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_Parent2Id",
                table: "Nestings",
                newName: "IX_Nestings_Parent2Code");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_Parent1Id",
                table: "Nestings",
                newName: "IX_Nestings_Parent1Code");

            migrationBuilder.AddColumn<string>(
                name: "SpeciesDescription",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent1Code",
                table: "Nestings",
                column: "Parent1Code",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent2Code",
                table: "Nestings",
                column: "Parent2Code",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent1Code",
                table: "Nestings");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent2Code",
                table: "Nestings");

            migrationBuilder.DropColumn(
                name: "SpeciesDescription",
                table: "Species");

            migrationBuilder.RenameColumn(
                name: "Parent2Code",
                table: "Nestings",
                newName: "Parent2Id");

            migrationBuilder.RenameColumn(
                name: "Parent1Code",
                table: "Nestings",
                newName: "Parent1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_Parent2Code",
                table: "Nestings",
                newName: "IX_Nestings_Parent2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_Parent1Code",
                table: "Nestings",
                newName: "IX_Nestings_Parent1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent1Id",
                table: "Nestings",
                column: "Parent1Id",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent2Id",
                table: "Nestings",
                column: "Parent2Id",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
