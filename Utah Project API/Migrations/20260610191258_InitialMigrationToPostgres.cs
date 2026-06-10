using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Utah_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationToPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Behaviours",
                columns: table => new
                {
                    BehaviourCode = table.Column<string>(type: "text", nullable: false),
                    BehaviourName = table.Column<string>(type: "text", nullable: false),
                    BehaviourDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behaviours", x => x.BehaviourCode);
                });

            migrationBuilder.CreateTable(
                name: "Mutations",
                columns: table => new
                {
                    MutationCode = table.Column<string>(type: "text", nullable: false),
                    MutationName = table.Column<string>(type: "text", nullable: false),
                    MutationDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mutations", x => x.MutationCode);
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RelationTypes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpeciesName = table.Column<string>(type: "text", nullable: false),
                    SpeciesDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                    DinoCode = table.Column<int>(type: "integer", nullable: false),
                    BehaviourCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoBehaviours", x => new { x.DinoCode, x.BehaviourCode });
                    table.ForeignKey(
                        name: "FK_DinoBehaviours_Behaviours_BehaviourCode",
                        column: x => x.BehaviourCode,
                        principalTable: "Behaviours",
                        principalColumn: "BehaviourCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinoMutations",
                columns: table => new
                {
                    DinoCode = table.Column<int>(type: "integer", nullable: false),
                    MutationCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoMutations", x => new { x.DinoCode, x.MutationCode });
                    table.ForeignKey(
                        name: "FK_DinoMutations_Mutations_MutationCode",
                        column: x => x.MutationCode,
                        principalTable: "Mutations",
                        principalColumn: "MutationCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DinoNestings",
                columns: table => new
                {
                    DinoCode = table.Column<int>(type: "integer", nullable: false),
                    NestingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoNestings", x => new { x.DinoCode, x.NestingId });
                });

            migrationBuilder.CreateTable(
                name: "DinoRelationships",
                columns: table => new
                {
                    DinoCode = table.Column<int>(type: "integer", nullable: false),
                    TargetDinoCode = table.Column<int>(type: "integer", nullable: false),
                    RelationTypeId = table.Column<int>(type: "integer", nullable: false),
                    CustomBondLabel = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoRelationships", x => new { x.DinoCode, x.TargetDinoCode, x.RelationTypeId });
                    table.ForeignKey(
                        name: "FK_DinoRelationships_RelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dinosaurs",
                columns: table => new
                {
                    DinoCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    DinoName = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    NestId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinosaurs", x => x.DinoCode);
                    table.ForeignKey(
                        name: "FK_Dinosaurs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dinosaurs_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nestings",
                columns: table => new
                {
                    NestingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NestingDescription = table.Column<string>(type: "text", nullable: false),
                    ExtendedDesciption = table.Column<string>(type: "text", nullable: false),
                    Parent1Code = table.Column<int>(type: "integer", nullable: true),
                    Parent2Code = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nestings", x => x.NestingId);
                    table.ForeignKey(
                        name: "FK_Nestings_Dinosaurs_Parent1Code",
                        column: x => x.Parent1Code,
                        principalTable: "Dinosaurs",
                        principalColumn: "DinoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nestings_Dinosaurs_Parent2Code",
                        column: x => x.Parent2Code,
                        principalTable: "Dinosaurs",
                        principalColumn: "DinoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NestingMutations",
                columns: table => new
                {
                    NestingId = table.Column<int>(type: "integer", nullable: false),
                    MutationCode = table.Column<string>(type: "text", nullable: false),
                    MutationName = table.Column<string>(type: "text", nullable: false),
                    MutationChance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NestingMutations", x => new { x.NestingId, x.MutationCode });
                    table.ForeignKey(
                        name: "FK_NestingMutations_Mutations_MutationCode",
                        column: x => x.MutationCode,
                        principalTable: "Mutations",
                        principalColumn: "MutationCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NestingMutations_Nestings_NestingId",
                        column: x => x.NestingId,
                        principalTable: "Nestings",
                        principalColumn: "NestingId",
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
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DinoBehaviours_BehaviourCode",
                table: "DinoBehaviours",
                column: "BehaviourCode");

            migrationBuilder.CreateIndex(
                name: "IX_DinoMutations_MutationCode",
                table: "DinoMutations",
                column: "MutationCode");

            migrationBuilder.CreateIndex(
                name: "IX_DinoNestings_NestingId",
                table: "DinoNestings",
                column: "NestingId");

            migrationBuilder.CreateIndex(
                name: "IX_DinoRelationships_RelationTypeId",
                table: "DinoRelationships",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DinoRelationships_TargetDinoCode",
                table: "DinoRelationships",
                column: "TargetDinoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_NestId",
                table: "Dinosaurs",
                column: "NestId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_SpeciesId",
                table: "Dinosaurs",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Dinosaurs_UserId",
                table: "Dinosaurs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NestingMutations_MutationCode",
                table: "NestingMutations",
                column: "MutationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Nestings_Parent1Code",
                table: "Nestings",
                column: "Parent1Code");

            migrationBuilder.CreateIndex(
                name: "IX_Nestings_Parent2Code",
                table: "Nestings",
                column: "Parent2Code");

            migrationBuilder.AddForeignKey(
                name: "FK_DinoBehaviours_Dinosaurs_DinoCode",
                table: "DinoBehaviours",
                column: "DinoCode",
                principalTable: "Dinosaurs",
                principalColumn: "DinoCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DinoMutations_Dinosaurs_DinoCode",
                table: "DinoMutations",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Dinosaurs_Nestings_NestId",
                table: "Dinosaurs",
                column: "NestId",
                principalTable: "Nestings",
                principalColumn: "NestingId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dinosaurs_AspNetUsers_UserId",
                table: "Dinosaurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent1Code",
                table: "Nestings");

            migrationBuilder.DropForeignKey(
                name: "FK_Nestings_Dinosaurs_Parent2Code",
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
                name: "DinoMutations");

            migrationBuilder.DropTable(
                name: "DinoNestings");

            migrationBuilder.DropTable(
                name: "DinoRelationships");

            migrationBuilder.DropTable(
                name: "NestingMutations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Behaviours");

            migrationBuilder.DropTable(
                name: "RelationTypes");

            migrationBuilder.DropTable(
                name: "Mutations");

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
