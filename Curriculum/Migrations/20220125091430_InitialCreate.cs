using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace curriculum.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailConfig",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    host = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    port = table.Column<int>(type: "int", nullable: false),
                    ssl = table.Column<bool>(type: "bit", nullable: false),
                    defaultCredentials = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfig", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    surname1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.id);
                    table.ForeignKey(
                        name: "FK_Credentials_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.id);
                    table.ForeignKey(
                        name: "FK_Email_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecoverLog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoverLog", x => x.id);
                    table.ForeignKey(
                        name: "FK_RecoverLog_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNumber",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    phoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNumber", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserNumber_PhoneNumber_phoneId",
                        column: x => x.phoneId,
                        principalTable: "PhoneNumber",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNumber_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    phoneId = table.Column<int>(type: "int", nullable: false),
                    emailId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.id);
                    table.ForeignKey(
                        name: "FK_Curriculum_Email_emailId",
                        column: x => x.emailId,
                        principalTable: "Email",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculum_PhoneNumber_phoneId",
                        column: x => x.phoneId,
                        principalTable: "PhoneNumber",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculum_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    curriculumId = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    initDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.id);
                    table.ForeignKey(
                        name: "FK_Experience_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    curriculumId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherData", x => x.id);
                    table.ForeignKey(
                        name: "FK_OtherData_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    curriculumId = table.Column<int>(type: "int", nullable: false),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMedia_SocialMediaType_typeId",
                        column: x => x.typeId,
                        principalTable: "SocialMediaType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    curriculumId = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    initDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    finishDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    graduationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.id);
                    table.ForeignKey(
                        name: "FK_Training_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    languageId = table.Column<int>(type: "int", nullable: false),
                    curriculumId = table.Column<int>(type: "int", nullable: false),
                    levelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Curriculum_curriculumId",
                        column: x => x.curriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Language_languageId",
                        column: x => x.languageId,
                        principalTable: "Language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguage_LanguageLevel_levelId",
                        column: x => x.levelId,
                        principalTable: "LanguageLevel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    experienceId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contract_Experience_experienceId",
                        column: x => x.experienceId,
                        principalTable: "Experience",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Value",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    OtherDataId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.id);
                    table.ForeignKey(
                        name: "FK_Value_OtherData_OtherDataId",
                        column: x => x.OtherDataId,
                        principalTable: "OtherData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    trainingId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.id);
                    table.ForeignKey(
                        name: "FK_Content_Training_trainingId",
                        column: x => x.trainingId,
                        principalTable: "Training",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contractId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                    table.ForeignKey(
                        name: "FK_Project_Contract_contractId",
                        column: x => x.contractId,
                        principalTable: "Contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubContent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contentId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContent", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubContent_Content_contentId",
                        column: x => x.contentId,
                        principalTable: "Content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    proyectId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.id);
                    table.ForeignKey(
                        name: "FK_Description_Project_proyectId",
                        column: x => x.proyectId,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_trainingId",
                table: "Content",
                column: "trainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_experienceId",
                table: "Contract",
                column: "experienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_userId",
                table: "Credentials",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_emailId",
                table: "Curriculum",
                column: "emailId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_phoneId",
                table: "Curriculum",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_userId",
                table: "Curriculum",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_proyectId",
                table: "Description",
                column: "proyectId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_userId",
                table: "Email",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_curriculumId",
                table: "Experience",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherData_curriculumId",
                table: "OtherData",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_contractId",
                table: "Project",
                column: "contractId");

            migrationBuilder.CreateIndex(
                name: "IX_RecoverLog_userId",
                table: "RecoverLog",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_curriculumId",
                table: "SocialMedia",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_typeId",
                table: "SocialMedia",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubContent_contentId",
                table: "SubContent",
                column: "contentId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_curriculumId",
                table: "Training",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_curriculumId",
                table: "UserLanguage",
                column: "curriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_languageId",
                table: "UserLanguage",
                column: "languageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_levelId",
                table: "UserLanguage",
                column: "levelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNumber_phoneId",
                table: "UserNumber",
                column: "phoneId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNumber_userId",
                table: "UserNumber",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Value_OtherDataId",
                table: "Value",
                column: "OtherDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropTable(
                name: "EmailConfig");

            migrationBuilder.DropTable(
                name: "RecoverLog");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "SubContent");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "UserNumber");

            migrationBuilder.DropTable(
                name: "Value");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "SocialMediaType");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "LanguageLevel");

            migrationBuilder.DropTable(
                name: "OtherData");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
