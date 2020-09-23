using System;
using Evaluations.Api.Data.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluations.Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:course_member_role", "student,teacher")
                .Annotation("Npgsql:Enum:evaluation_kind", "task,test")
                .Annotation("Npgsql:Enum:evaluation_part_kind", "bool,letter,numeric");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Members = table.Column<Guid[]>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization = table.Column<Guid>(type: "uuid", nullable: false),
                    Begin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<CourseMemberRole>(type: "course_member_role", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMember_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<EvaluationKind>(type: "evaluation_kind", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MaxScore = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<EvaluationPartKind>(type: "evaluation_part_kind", nullable: false),
                    EvaluationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationPart_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationPartResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Organization = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<string>(type: "text", nullable: true),
                    PartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationPartResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationPartResult_EvaluationPart_PartId",
                        column: x => x.PartId,
                        principalTable: "EvaluationPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMember_CourseId",
                table: "CourseMember",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMember_Organization",
                table: "CourseMember",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Organization",
                table: "Courses",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPart_EvaluationId",
                table: "EvaluationPart",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPart_Organization",
                table: "EvaluationPart",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPartResult_Organization",
                table: "EvaluationPartResult",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationPartResult_PartId",
                table: "EvaluationPartResult",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_CourseId",
                table: "Evaluations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_Organization",
                table: "Evaluations",
                column: "Organization");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMember");

            migrationBuilder.DropTable(
                name: "EvaluationPartResult");

            migrationBuilder.DropTable(
                name: "EvaluationPart");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
