using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class FixPascalCasingPt2ElectricBoogaloo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_Dinocode",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_TargetDinocode",
                table: "DinoRelationships");

            migrationBuilder.RenameColumn(
                name: "TargetDinocode",
                table: "DinoRelationships",
                newName: "TargetDinoCode");

            migrationBuilder.RenameColumn(
                name: "Dinocode",
                table: "DinoRelationships",
                newName: "DinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoRelationships_TargetDinocode",
                table: "DinoRelationships",
                newName: "IX_DinoRelationships_TargetDinoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_DinoCode",
                table: "DinoRelationships",
                column: "DinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_TargetDinoCode",
                table: "DinoRelationships",
                column: "TargetDinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_DinoCode",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_TargetDinoCode",
                table: "DinoRelationships");

            migrationBuilder.RenameColumn(
                name: "TargetDinoCode",
                table: "DinoRelationships",
                newName: "TargetDinocode");

            migrationBuilder.RenameColumn(
                name: "DinoCode",
                table: "DinoRelationships",
                newName: "Dinocode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoRelationships_TargetDinoCode",
                table: "DinoRelationships",
                newName: "IX_DinoRelationships_TargetDinocode");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_Dinocode",
                table: "DinoRelationships",
                column: "Dinocode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_TargetDinocode",
                table: "DinoRelationships",
                column: "TargetDinocode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
