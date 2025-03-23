using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "students");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                schema: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyDepartments",
                schema: "students",
                columns: table => new
                {
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    FacultyId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyDepartments", x => new { x.FacultyId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_FacultyDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "students",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyDepartments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "students",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyDepartments_Faculties_FacultyId1",
                        column: x => x.FacultyId1,
                        principalSchema: "students",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasportSerialNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GroupId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalSchema: "students",
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDepartments_DepartmentId",
                schema: "students",
                table: "FacultyDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDepartments_FacultyId1",
                schema: "students",
                table: "FacultyDepartments",
                column: "FacultyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId1",
                schema: "students",
                table: "Students",
                column: "GroupId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyDepartments",
                schema: "students");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "students");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "students");

            migrationBuilder.DropTable(
                name: "Faculties",
                schema: "students");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "students");
        }
    }
}
