using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Behaviours",
                columns: table => new
                {
                    behaviourCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    behaviourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    behaviourDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behaviours", x => x.behaviourCode);
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                columns: table => new
                {
                    relationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.relationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    speciesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speciesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.speciesId);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    mutationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mutationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mutationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.mutationCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinoBehaviours",
                columns: table => new
                {
                    dinoCode = table.Column<int>(type: "int", nullable: false),
                    behaviourCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoBehaviours", x => new { x.dinoCode, x.behaviourCode });
                    table.ForeignKey(
                        name: "FK_DinoBehaviours_Behaviours_behaviourCode",
                        column: x => x.behaviourCode,
                        principalTable: "Behaviours",
                        principalColumn: "behaviourCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinoNestings",
                columns: table => new
                {
                    dinoCode = table.Column<int>(type: "int", nullable: false),
                    nestingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoNestings", x => new { x.dinoCode, x.nestingId });
                });

            migrationBuilder.CreateTable(
                name: "DinoRelationships",
                columns: table => new
                {
                    dinocode = table.Column<int>(type: "int", nullable: false),
                    targetDinocode = table.Column<int>(type: "int", nullable: false),
                    relationTypeId = table.Column<int>(type: "int", nullable: false),
                    customBondLabel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoRelationships", x => new { x.dinocode, x.targetDinocode, x.relationTypeId });
                    table.ForeignKey(
                        name: "FK_DinoRelationships_RelationTypes_relationTypeId",
                        column: x => x.relationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "relationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dinosaurs",
                columns: table => new
                {
                    dinoCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dinoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speciesId = table.Column<int>(type: "int", nullable: false),
                    nestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinosaurs", x => x.dinoCode);
                    table.ForeignKey(
                        name: "FK_Dinosaurs_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dinosaurs_Species_speciesId",
                        column: x => x.speciesId,
                        principalTable: "Species",
                        principalColumn: "speciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinoTraits",
                columns: table => new
                {
                    dinoCode = table.Column<int>(type: "int", nullable: false),
                    mutationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mutationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoTraits", x => new { x.dinoCode, x.mutationCode });
                    table.ForeignKey(
                        name: "FK_DinoTraits_Dinosaurs_dinoCode",
                        column: x => x.dinoCode,
                        principalTable: "Dinosaurs",
                        principalColumn: "dinoCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DinoTraits_Traits_mutationCode",
                        column: x => x.mutationCode,
                        principalTable: "Traits",
                        principalColumn: "mutationCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nestings",
                columns: table => new
                {
                    nestingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nestingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extendedDesciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent1Id = table.Column<int>(type: "int", nullable: true),
                    parent2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nestings", x => x.nestingId);
                    table.ForeignKey(
                        name: "FK_Nestings_Dinosaurs_parent1Id",
                        column: x => x.parent1Id,
                        principalTable: "Dinosaurs",
                        principalColumn: "dinoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nestings_Dinosaurs_parent2Id",
                        column: x => x.parent2Id,
                        principalTable: "Dinosaurs",
                        principalColumn: "dinoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NestingMutations",
                columns: table => new
                {
                    nestingId = table.Column<int>(type: "int", nullable: false),
                    mutationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mutationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mutationChance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NestingMutations", x => new { x.nestingId, x.mutationCode });
                    table.ForeignKey(
                        name: "FK_NestingMutations_Nestings_nestingId",
                        column: x => x.nestingId,
                        principalTable: "Nestings",
                        principalColumn: "nestingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NestingMutations_Traits_mutationCode",
                        column: x => x.mutationCode,
                        principalTable: "Traits",
                        principalColumn: "mutationCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DinoBehaviours_behaviourCode",
                table: "DinoBehaviours",
                column: "behaviourCode");

            migrationBuilder.CreateIndex(
                name: "IX_DinoNestings_nestingId",
                table: "DinoNestings",
                column: "nestingId");

            migrationBuilder.CreateIndex(
                name: "IX_DinoRelationships_relationTypeId",
                table: "DinoRelationships",
                column: "relationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DinoRelationships_targetDinocode",
                table: "DinoRelationships",
                column: "targetDinocode");

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_nestId",
                table: "Dinosaurs",
                column: "nestId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_speciesId",
                table: "Dinosaurs",
                column: "speciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_userId",
                table: "Dinosaurs",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_DinoTraits_mutationCode",
                table: "DinoTraits",
                column: "mutationCode");

            migrationBuilder.CreateIndex(
                name: "IX_NestingMutations_mutationCode",
                table: "NestingMutations",
                column: "mutationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Nestings_parent1Id",
                table: "Nestings",
                column: "parent1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nestings_parent2Id",
                table: "Nestings",
                column: "parent2Id");

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
                name: "FK_Dinosaurs_Nestings_nestId",
                table: "Dinosaurs",
                column: "nestId",
                principalTable: "Nestings",
                principalColumn: "nestingId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_AspNetUsers_userId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_parent1Id",
                table: "Nestings");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_parent2Id",
                table: "Nestings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DinoBehaviours");

            migrationBuilder.DropTable(
                name: "DinoNestings");

            migrationBuilder.DropTable(
                name: "DinoRelationships");

            migrationBuilder.DropTable(
                name: "DinoTraits");

            migrationBuilder.DropTable(
                name: "NestingMutations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Behaviours");

            migrationBuilder.DropTable(
                name: "RelationTypes");

            migrationBuilder.DropTable(
                name: "Traits");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Dinosaurs");

            migrationBuilder.DropTable(
                name: "Nestings");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
