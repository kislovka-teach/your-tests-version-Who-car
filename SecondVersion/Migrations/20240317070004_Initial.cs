using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecondVersion.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    AvatarUrl = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, defaultValue: "https://buzookod.ru/media/2816616767_vubrbeJ.jpg")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Login", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teachers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teachers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    Theme = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, defaultValue: "None"),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false, defaultValue: "None"),
                    TeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesEnrolledId = table.Column<int>(type: "integer", nullable: false),
                    StudentsEnrolledId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesEnrolledId, x.StudentsEnrolledId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesEnrolledId",
                        column: x => x.CoursesEnrolledId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_StudentsEnrolledId",
                        column: x => x.StudentsEnrolledId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    Ordinal = table.Column<short>(type: "smallint", nullable: false),
                    ContentUrl = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, defaultValue: "http://localhost:3000/"),
                    Duration = table.Column<double>(type: "double precision", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "123", "AQAAAAIAAYagAAAAEKrrzv9jics36HK8Kr41WOB1ABpHWj7l5mkjb6vjTYsr2ed37XcXhvwOg1DZu9DQDA==", 0 },
                    { 2, "1234", "AQAAAAIAAYagAAAAEJt2WWUvKss8JGSEb3B5GB413Kn7oWN8wP5PYB6JVyEewQon8LW2mNBUNL6B+1mM2g==", 0 },
                    { 3, "12345", "AQAAAAIAAYagAAAAEEgOUtgHZwPyhMo3Gn3DenvFLSpwxQXJnFHqlY8b13bNp5nNOd0XQbzZpVEx728/JA==", 0 },
                    { 4, "123456", "AQAAAAIAAYagAAAAENCkXGMPAG42UQQOl9MV70PNZ9iB3Zlu00FaF/b8dw7Rp40TWcXLI/TXQdOxK4WsZw==", 0 },
                    { 5, "1234567", "AQAAAAIAAYagAAAAEAHhaV1+AstHj9W0NlI+97SO6qzfEh76kSwYh1NXa337xxQaUzVg6eglr9gWTmTV4Q==", 0 }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Student A" },
                    { 2, "Student B" },
                    { 3, "Student C" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { 4, 1, "Teacher A" },
                    { 5, 2, "Teacher B" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsEnrolledId",
                table: "CourseStudent",
                column: "StudentsEnrolledId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_CompanyId",
                table: "teachers",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
