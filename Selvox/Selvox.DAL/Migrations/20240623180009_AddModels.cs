using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selvox.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Industri__808DEDCCA4CD957D", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "JobRoles",
                columns: table => new
                {
                    JobRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequiredSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryRange = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobRoles__6D8BAC2FBB2A94CD", x => x.JobRoleId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__0DC06FAC021B80BC", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalityTestQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityTestQuestions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__DFA09187EDFFCABB", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CE72D638B", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: true),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employer__CA44526164042D7C", x => x.EmployerId);
                    table.ForeignKey(
                        name: "FK__Employers__Indus__6A30C649",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId");
                });

            migrationBuilder.CreateTable(
                name: "QuestionJobFieldMappings",
                columns: table => new
                {
                    MappingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    JobFieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__8B57819D8122EF1C", x => x.MappingId);
                    table.ForeignKey(
                        name: "FK__QuestionJ__JobFi__18EBB532",
                        column: x => x.JobFieldId,
                        principalTable: "JobRoles",
                        principalColumn: "JobRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__QuestionJ__Quest__17F790F9",
                        column: x => x.QuestionId,
                        principalTable: "PersonalityQuestions",
                        principalColumn: "QuestionId");
                });

            migrationBuilder.CreateTable(
                name: "PersonalityTestAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    JobField = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalityTestAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_PersonalityTestAnswers_PersonalityTestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "PersonalityTestQuestions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CareerRecommendations",
                columns: table => new
                {
                    RecommendationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    JobRoleId = table.Column<int>(type: "int", nullable: true),
                    RecommendationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MatchScore = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CareerRe__AA15BEE4FD34D332", x => x.RecommendationId);
                    table.ForeignKey(
                        name: "FK__CareerRec__JobRo__5AEE82B9",
                        column: x => x.JobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "JobRoleId");
                    table.ForeignKey(
                        name: "FK__CareerRec__UserI__59FA5E80",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PersonalityAssessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AssessmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__3D2BF81E1EA2F518", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK__Personali__UserI__4F7CD00D",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    ProficiencyLevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AcquiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserSkil__2F28BE569EC8242B", x => x.UserSkillId);
                    table.ForeignKey(
                        name: "FK__UserSkill__Skill__6383C8BA",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId");
                    table.ForeignKey(
                        name: "FK__UserSkill__UserI__628FA481",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "JobListings",
                columns: table => new
                {
                    JobListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<int>(type: "int", nullable: true),
                    JobRoleId = table.Column<int>(type: "int", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SalaryRange = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PostedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobListi__70B705E0FDA186BF", x => x.JobListingId);
                    table.ForeignKey(
                        name: "FK__JobListin__Emplo__6EF57B66",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId");
                    table.ForeignKey(
                        name: "FK__JobListin__JobRo__6FE99F9F",
                        column: x => x.JobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "JobRoleId");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobListingId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ApplicationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applicat__C93A4C99156A28E6", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK__Applicati__JobLi__74AE54BC",
                        column: x => x.JobListingId,
                        principalTable: "JobListings",
                        principalColumn: "JobListingId");
                    table.ForeignKey(
                        name: "FK__Applicati__UserI__75A278F5",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobListingId",
                table: "Applications",
                column: "JobListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerRecommendations_JobRoleId",
                table: "CareerRecommendations",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerRecommendations_UserId",
                table: "CareerRecommendations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_IndustryId",
                table: "Employers",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_EmployerId",
                table: "JobListings",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_JobRoleId",
                table: "JobListings",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityAssessments_UserId",
                table: "PersonalityAssessments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalityTestAnswers_QuestionId",
                table: "PersonalityTestAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionJobFieldMappings_JobFieldId",
                table: "QuestionJobFieldMappings",
                column: "JobFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionJobFieldMappings_QuestionId",
                table: "QuestionJobFieldMappings",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D1053445F43A0E",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserId",
                table: "UserSkills",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "CareerRecommendations");

            migrationBuilder.DropTable(
                name: "PersonalityAssessments");

            migrationBuilder.DropTable(
                name: "PersonalityTestAnswers");

            migrationBuilder.DropTable(
                name: "QuestionJobFieldMappings");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "JobListings");

            migrationBuilder.DropTable(
                name: "PersonalityTestQuestions");

            migrationBuilder.DropTable(
                name: "PersonalityQuestions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "JobRoles");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
