using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class RenameTraitsToMutations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Traits_mutationCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_NestingMutations_Traits_mutationCode",
                table: "NestingMutations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Traits",
                table: "Traits");

            migrationBuilder.RenameTable(
                name: "Traits",
                newName: "Mutations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mutations",
                table: "Mutations",
                column: "mutationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoTraits_Mutations_mutationCode",
                table: "DinoTraits",
                column: "mutationCode",
                principalTable: "Mutations",
                principalColumn: "mutationCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NestingMutations_Mutations_mutationCode",
                table: "NestingMutations",
                column: "mutationCode",
                principalTable: "Mutations",
                principalColumn: "mutationCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Mutations_mutationCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_NestingMutations_Mutations_mutationCode",
                table: "NestingMutations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mutations",
                table: "Mutations");

            migrationBuilder.RenameTable(
                name: "Mutations",
                newName: "Traits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traits",
                table: "Traits",
                column: "mutationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoTraits_Traits_mutationCode",
                table: "DinoTraits",
                column: "mutationCode",
                principalTable: "Traits",
                principalColumn: "mutationCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NestingMutations_Traits_mutationCode",
                table: "NestingMutations",
                column: "mutationCode",
                principalTable: "Traits",
                principalColumn: "mutationCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
