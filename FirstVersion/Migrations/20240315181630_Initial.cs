using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstVersion.Migrations
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
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "Company name")
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
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, defaultValue: "Name"),
                    Surname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, defaultValue: "Surname"),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Login", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    DrivingLicenseReceiptDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    City = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drivers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    Model = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    Category = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CostPerDay = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    LastLeased = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    City = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false, defaultValue: "None"),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    DriverId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "123", "AQAAAAIAAYagAAAAEPf6PLZx2wO2MPFHqiG/gmc1pS4Cnncj5qpqEGzYt3kKe91xj7oE0mZu0LDvpqdDeA==" },
                    { 2, "1234", "AQAAAAIAAYagAAAAEDQzbQYz9AZ8L95LL6rYX31SbS9futdJ0a18IPtkSgHS6hCoYD3+ECm/oo5Qs62tNA==" },
                    { 3, "12345", "AQAAAAIAAYagAAAAEFoeOHVeMxhdxrYUPgUYhF1cLnSOKQURhEcM4xVqJ5brrHiP0AhIxUo1ZGqn6V/tsw==" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[,]
                {
                    { 4, "123456", "AQAAAAIAAYagAAAAEIJLuzKRySN7cATLXDjs8nK+hrpYp1H29WzXxQejpu8rbFIg/T/1vvsPsm6Q+1gdJA==", 1 },
                    { 5, "1234567", "AQAAAAIAAYagAAAAELGe18TB7OLsFgS/6Q5H63rBzylmpBgHhwshJfFPDNAJt5y2D5PJ7HbDukVsyxMMbw==", 1 }
                });

            migrationBuilder.InsertData(
                table: "drivers",
                columns: new[] { "Id", "Category", "DrivingLicenseReceiptDate" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Balance", "CompanyId" },
                values: new object[,]
                {
                    { 4, 0m, 1 },
                    { 5, 0m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CompanyId",
                table: "Cars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverId",
                table: "Cars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EmployeeId",
                table: "Cars",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_CompanyId",
                table: "employees",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
