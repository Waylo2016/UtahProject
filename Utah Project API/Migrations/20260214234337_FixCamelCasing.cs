using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class FixCamelCasing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoBehaviours_Behaviours_behaviourCode",
                table: "DinoBehaviours");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoBehaviours_Dinosaurs_dinoCode",
                table: "DinoBehaviours");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoNestings_Dinosaurs_dinoCode",
                table: "DinoNestings");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoNestings_Nestings_nestingId",
                table: "DinoNestings");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_dinocode",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_targetDinocode",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_RelationTypes_relationTypeId",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_AspNetUsers_userId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_Nestings_nestId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_Species_speciesId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Dinosaurs_dinoCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Mutations_mutationCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_NestingMutations_Mutations_mutationCode",
                table: "NestingMutations");

            migrationBuilder.DropForeignKey(
                name: "FK_NestingMutations_Nestings_nestingId",
                table: "NestingMutations");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_parent1Id",
                table: "Nestings");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_parent2Id",
                table: "Nestings");

            migrationBuilder.RenameColumn(
                name: "speciesName",
                table: "Species",
                newName: "SpeciesName");

            migrationBuilder.RenameColumn(
                name: "speciesId",
                table: "Species",
                newName: "SpeciesId");

            migrationBuilder.RenameColumn(
                name: "relationTypeId",
                table: "RelationTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parent2Id",
                table: "Nestings",
                newName: "Parent2Id");

            migrationBuilder.RenameColumn(
                name: "parent1Id",
                table: "Nestings",
                newName: "Parent1Id");

            migrationBuilder.RenameColumn(
                name: "nestingDescription",
                table: "Nestings",
                newName: "NestingDescription");

            migrationBuilder.RenameColumn(
                name: "extendedDesciption",
                table: "Nestings",
                newName: "ExtendedDesciption");

            migrationBuilder.RenameColumn(
                name: "nestingId",
                table: "Nestings",
                newName: "NestingId");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_parent2Id",
                table: "Nestings",
                newName: "IX_Nestings_Parent2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_parent1Id",
                table: "Nestings",
                newName: "IX_Nestings_Parent1Id");

            migrationBuilder.RenameColumn(
                name: "mutationName",
                table: "NestingMutations",
                newName: "MutationName");

            migrationBuilder.RenameColumn(
                name: "mutationChance",
                table: "NestingMutations",
                newName: "MutationChance");

            migrationBuilder.RenameColumn(
                name: "mutationCode",
                table: "NestingMutations",
                newName: "MutationCode");

            migrationBuilder.RenameColumn(
                name: "nestingId",
                table: "NestingMutations",
                newName: "NestingId");

            migrationBuilder.RenameIndex(
                name: "IX_NestingMutations_mutationCode",
                table: "NestingMutations",
                newName: "IX_NestingMutations_MutationCode");

            migrationBuilder.RenameColumn(
                name: "mutationName",
                table: "Mutations",
                newName: "MutationName");

            migrationBuilder.RenameColumn(
                name: "mutationDescription",
                table: "Mutations",
                newName: "MutationDescription");

            migrationBuilder.RenameColumn(
                name: "mutationCode",
                table: "Mutations",
                newName: "MutationCode");

            migrationBuilder.RenameColumn(
                name: "mutationName",
                table: "DinoTraits",
                newName: "MutationName");

            migrationBuilder.RenameColumn(
                name: "mutationCode",
                table: "DinoTraits",
                newName: "MutationCode");

            migrationBuilder.RenameColumn(
                name: "dinoCode",
                table: "DinoTraits",
                newName: "DinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoTraits_mutationCode",
                table: "DinoTraits",
                newName: "IX_DinoTraits_MutationCode");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Dinosaurs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "speciesId",
                table: "Dinosaurs",
                newName: "SpeciesId");

            migrationBuilder.RenameColumn(
                name: "nestId",
                table: "Dinosaurs",
                newName: "NestId");

            migrationBuilder.RenameColumn(
                name: "dinoName",
                table: "Dinosaurs",
                newName: "DinoName");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Dinosaurs",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "dinoCode",
                table: "Dinosaurs",
                newName: "DinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_Dinosaurs_userId",
                table: "Dinosaurs",
                newName: "IX_Dinosaurs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Dinosaurs_speciesId",
                table: "Dinosaurs",
                newName: "IX_Dinosaurs_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Dinosaurs_nestId",
                table: "Dinosaurs",
                newName: "IX_Dinosaurs_NestId");

            migrationBuilder.RenameColumn(
                name: "customBondLabel",
                table: "DinoRelationships",
                newName: "CustomBondLabel");

            migrationBuilder.RenameColumn(
                name: "relationTypeId",
                table: "DinoRelationships",
                newName: "RelationTypeId");

            migrationBuilder.RenameColumn(
                name: "targetDinocode",
                table: "DinoRelationships",
                newName: "TargetDinocode");

            migrationBuilder.RenameColumn(
                name: "dinocode",
                table: "DinoRelationships",
                newName: "Dinocode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoRelationships_targetDinocode",
                table: "DinoRelationships",
                newName: "IX_DinoRelationships_TargetDinocode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoRelationships_relationTypeId",
                table: "DinoRelationships",
                newName: "IX_DinoRelationships_RelationTypeId");

            migrationBuilder.RenameColumn(
                name: "nestingId",
                table: "DinoNestings",
                newName: "NestingId");

            migrationBuilder.RenameColumn(
                name: "dinoCode",
                table: "DinoNestings",
                newName: "DinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoNestings_nestingId",
                table: "DinoNestings",
                newName: "IX_DinoNestings_NestingId");

            migrationBuilder.RenameColumn(
                name: "behaviourCode",
                table: "DinoBehaviours",
                newName: "BehaviourCode");

            migrationBuilder.RenameColumn(
                name: "dinoCode",
                table: "DinoBehaviours",
                newName: "DinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoBehaviours_behaviourCode",
                table: "DinoBehaviours",
                newName: "IX_DinoBehaviours_BehaviourCode");

            migrationBuilder.RenameColumn(
                name: "behaviourName",
                table: "Behaviours",
                newName: "BehaviourName");

            migrationBuilder.RenameColumn(
                name: "behaviourDescription",
                table: "Behaviours",
                newName: "BehaviourDescription");

            migrationBuilder.RenameColumn(
                name: "behaviourCode",
                table: "Behaviours",
                newName: "BehaviourCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoBehaviours_Behaviours_BehaviourCode",
                table: "DinoBehaviours",
                column: "BehaviourCode",
                principalTable: "Behaviours",
                principalColumn: "BehaviourCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoBehaviours_Dinosaurs_DinoCode",
                table: "DinoBehaviours",
                column: "DinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoNestings_Dinosaurs_DinoCode",
                table: "DinoNestings",
                column: "DinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoNestings_Nestings_NestingId",
                table: "DinoNestings",
                column: "NestingId",
                principalTable: "Nestings",
                principalColumn: "NestingId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_RelationTypes_RelationTypeId",
                table: "DinoRelationships",
                column: "RelationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_AspNetUsers_UserId",
                table: "Dinosaurs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_Nestings_NestId",
                table: "Dinosaurs",
                column: "NestId",
                principalTable: "Nestings",
                principalColumn: "NestingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_Species_SpeciesId",
                table: "Dinosaurs",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_NestingMutations_Mutations_MutationCode",
                table: "NestingMutations",
                column: "MutationCode",
                principalTable: "Mutations",
                principalColumn: "MutationCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NestingMutations_Nestings_NestingId",
                table: "NestingMutations",
                column: "NestingId",
                principalTable: "Nestings",
                principalColumn: "NestingId",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DinoBehaviours_Behaviours_BehaviourCode",
                table: "DinoBehaviours");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoBehaviours_Dinosaurs_DinoCode",
                table: "DinoBehaviours");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoNestings_Dinosaurs_DinoCode",
                table: "DinoNestings");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoNestings_Nestings_NestingId",
                table: "DinoNestings");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_Dinocode",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_TargetDinocode",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoRelationships_RelationTypes_RelationTypeId",
                table: "DinoRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_AspNetUsers_UserId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_Nestings_NestId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_Species_SpeciesId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Dinosaurs_DinoCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_DinoTraits_Mutations_MutationCode",
                table: "DinoTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_NestingMutations_Mutations_MutationCode",
                table: "NestingMutations");

            migrationBuilder.DropForeignKey(
                name: "FK_NestingMutations_Nestings_NestingId",
                table: "NestingMutations");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent1Id",
                table: "Nestings");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent2Id",
                table: "Nestings");

            migrationBuilder.RenameColumn(
                name: "SpeciesName",
                table: "Species",
                newName: "speciesName");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Species",
                newName: "speciesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RelationTypes",
                newName: "relationTypeId");

            migrationBuilder.RenameColumn(
                name: "Parent2Id",
                table: "Nestings",
                newName: "parent2Id");

            migrationBuilder.RenameColumn(
                name: "Parent1Id",
                table: "Nestings",
                newName: "parent1Id");

            migrationBuilder.RenameColumn(
                name: "NestingDescription",
                table: "Nestings",
                newName: "nestingDescription");

            migrationBuilder.RenameColumn(
                name: "ExtendedDesciption",
                table: "Nestings",
                newName: "extendedDesciption");

            migrationBuilder.RenameColumn(
                name: "NestingId",
                table: "Nestings",
                newName: "nestingId");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_Parent2Id",
                table: "Nestings",
                newName: "IX_Nestings_parent2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Nestings_Parent1Id",
                table: "Nestings",
                newName: "IX_Nestings_parent1Id");

            migrationBuilder.RenameColumn(
                name: "MutationName",
                table: "NestingMutations",
                newName: "mutationName");

            migrationBuilder.RenameColumn(
                name: "MutationChance",
                table: "NestingMutations",
                newName: "mutationChance");

            migrationBuilder.RenameColumn(
                name: "MutationCode",
                table: "NestingMutations",
                newName: "mutationCode");

            migrationBuilder.RenameColumn(
                name: "NestingId",
                table: "NestingMutations",
                newName: "nestingId");

            migrationBuilder.RenameIndex(
                name: "IX_NestingMutations_MutationCode",
                table: "NestingMutations",
                newName: "IX_NestingMutations_mutationCode");

            migrationBuilder.RenameColumn(
                name: "MutationName",
                table: "Mutations",
                newName: "mutationName");

            migrationBuilder.RenameColumn(
                name: "MutationDescription",
                table: "Mutations",
                newName: "mutationDescription");

            migrationBuilder.RenameColumn(
                name: "MutationCode",
                table: "Mutations",
                newName: "mutationCode");

            migrationBuilder.RenameColumn(
                name: "MutationName",
                table: "DinoTraits",
                newName: "mutationName");

            migrationBuilder.RenameColumn(
                name: "MutationCode",
                table: "DinoTraits",
                newName: "mutationCode");

            migrationBuilder.RenameColumn(
                name: "DinoCode",
                table: "DinoTraits",
                newName: "dinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoTraits_MutationCode",
                table: "DinoTraits",
                newName: "IX_DinoTraits_mutationCode");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Dinosaurs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "Dinosaurs",
                newName: "speciesId");

            migrationBuilder.RenameColumn(
                name: "NestId",
                table: "Dinosaurs",
                newName: "nestId");

            migrationBuilder.RenameColumn(
                name: "DinoName",
                table: "Dinosaurs",
                newName: "dinoName");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Dinosaurs",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "DinoCode",
                table: "Dinosaurs",
                newName: "dinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_Dinosaurs_UserId",
                table: "Dinosaurs",
                newName: "IX_Dinosaurs_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Dinosaurs_SpeciesId",
                table: "Dinosaurs",
                newName: "IX_Dinosaurs_speciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Dinosaurs_NestId",
                table: "Dinosaurs",
                newName: "IX_Dinosaurs_nestId");

            migrationBuilder.RenameColumn(
                name: "CustomBondLabel",
                table: "DinoRelationships",
                newName: "customBondLabel");

            migrationBuilder.RenameColumn(
                name: "RelationTypeId",
                table: "DinoRelationships",
                newName: "relationTypeId");

            migrationBuilder.RenameColumn(
                name: "TargetDinocode",
                table: "DinoRelationships",
                newName: "targetDinocode");

            migrationBuilder.RenameColumn(
                name: "Dinocode",
                table: "DinoRelationships",
                newName: "dinocode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoRelationships_TargetDinocode",
                table: "DinoRelationships",
                newName: "IX_DinoRelationships_targetDinocode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoRelationships_RelationTypeId",
                table: "DinoRelationships",
                newName: "IX_DinoRelationships_relationTypeId");

            migrationBuilder.RenameColumn(
                name: "NestingId",
                table: "DinoNestings",
                newName: "nestingId");

            migrationBuilder.RenameColumn(
                name: "DinoCode",
                table: "DinoNestings",
                newName: "dinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoNestings_NestingId",
                table: "DinoNestings",
                newName: "IX_DinoNestings_nestingId");

            migrationBuilder.RenameColumn(
                name: "BehaviourCode",
                table: "DinoBehaviours",
                newName: "behaviourCode");

            migrationBuilder.RenameColumn(
                name: "DinoCode",
                table: "DinoBehaviours",
                newName: "dinoCode");

            migrationBuilder.RenameIndex(
                name: "IX_DinoBehaviours_BehaviourCode",
                table: "DinoBehaviours",
                newName: "IX_DinoBehaviours_behaviourCode");

            migrationBuilder.RenameColumn(
                name: "BehaviourName",
                table: "Behaviours",
                newName: "behaviourName");

            migrationBuilder.RenameColumn(
                name: "BehaviourDescription",
                table: "Behaviours",
                newName: "behaviourDescription");

            migrationBuilder.RenameColumn(
                name: "BehaviourCode",
                table: "Behaviours",
                newName: "behaviourCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoBehaviours_Behaviours_behaviourCode",
                table: "DinoBehaviours",
                column: "behaviourCode",
                principalTable: "Behaviours",
                principalColumn: "behaviourCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoBehaviours_Dinosaurs_dinoCode",
                table: "DinoBehaviours",
                column: "dinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoNestings_Dinosaurs_dinoCode",
                table: "DinoNestings",
                column: "dinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoNestings_Nestings_nestingId",
                table: "DinoNestings",
                column: "nestingId",
                principalTable: "Nestings",
                principalColumn: "nestingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_dinocode",
                table: "DinoRelationships",
                column: "dinocode",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_Dinosaurs_targetDinocode",
                table: "DinoRelationships",
                column: "targetDinocode",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoRelationships_RelationTypes_relationTypeId",
                table: "DinoRelationships",
                column: "relationTypeId",
                principalTable: "RelationTypes",
                principalColumn: "relationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_AspNetUsers_userId",
                table: "Dinosaurs",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_Nestings_nestId",
                table: "Dinosaurs",
                column: "nestId",
                principalTable: "Nestings",
                principalColumn: "nestingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_Species_speciesId",
                table: "Dinosaurs",
                column: "speciesId",
                principalTable: "Species",
                principalColumn: "speciesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoTraits_Dinosaurs_dinoCode",
                table: "DinoTraits",
                column: "dinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_NestingMutations_Nestings_nestingId",
                table: "NestingMutations",
                column: "nestingId",
                principalTable: "Nestings",
                principalColumn: "nestingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nestings_Dinosaurs_parent1Id",
                table: "Nestings",
                column: "parent1Id",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nestings_Dinosaurs_parent2Id",
                table: "Nestings",
                column: "parent2Id",
                principalTable: "Dinosaurs",
                principalColumn: "dinoCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
