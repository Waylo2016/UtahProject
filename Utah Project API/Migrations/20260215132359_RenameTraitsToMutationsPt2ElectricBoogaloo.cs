using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class RenameTraitsToMutationsPt2ElectricBoogaloo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Dinosaurs_DinoCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Mutations_MutationCode",
                table: "DinoTraits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DinoTraits",
                table: "DinoTraits");

            migrationBuilder.RenameTable(
                name: "DinoTraits",
                newName: "DinoMutations");

            migrationBuilder.RenameIndex(
                name: "IX_DinoTraits_MutationCode",
                table: "DinoMutations",
                newName: "IX_DinoMutations_MutationCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DinoMutations",
                table: "DinoMutations",
                columns: new[] { "DinoCode", "MutationCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_DinoMutations_Dinosaurs_DinoCode",
                table: "DinoMutations",
                column: "DinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoMutations_Mutations_MutationCode",
                table: "DinoMutations",
                column: "MutationCode",
                principalTable: "Mutations",
                principalColumn: "MutationCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoMutations_Dinosaurs_DinoCode",
                table: "DinoMutations");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoMutations_Mutations_MutationCode",
                table: "DinoMutations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DinoMutations",
                table: "DinoMutations");

            migrationBuilder.RenameTable(
                name: "DinoMutations",
                newName: "DinoTraits");

            migrationBuilder.RenameIndex(
                name: "IX_DinoMutations_MutationCode",
                table: "DinoTraits",
                newName: "IX_DinoTraits_MutationCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DinoTraits",
                table: "DinoTraits",
                columns: new[] { "DinoCode", "MutationCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_DinoTraits_Dinosaurs_DinoCode",
                table: "DinoTraits",
                column: "DinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoTraits_Mutations_MutationCode",
                table: "DinoTraits",
                column: "MutationCode",
                principalTable: "Mutations",
                principalColumn: "MutationCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
