using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondVersion.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEE6jAXycPrmkVrJAPRwyiyyjF/LA4tcpBIb5L0/WyDCzcs/wWXVJmRDSI4qeAV5fLA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEDLNzOdxGSZDm8f26UEKK6IjrPscLAbsDMH/65P0HSiulMS+bKrmR04jlJUhjPF0Jw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEHwnKOlK/yX/5EMzxJFrpeKeA0AmMsqzdmeFsB0LVhOiHIvOXXHLKPLXfv43dGsGCw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Role" },
                values: new object[] { "AQAAAAIAAYagAAAAENimrN/lHnkOaGkeq2RP1Nf0+jLxWGy27K3BeHTF8BuTaCWl1FHxfVPcYYTiS8QTiA==", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Role" },
                values: new object[] { "AQAAAAIAAYagAAAAENykWJAxOkv/ljZiX/qe8mQJbRMrRRa1hnC85dPOTs/kP/Ven3bfU0CwnprLHOSZNQ==", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEKrrzv9jics36HK8Kr41WOB1ABpHWj7l5mkjb6vjTYsr2ed37XcXhvwOg1DZu9DQDA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEJt2WWUvKss8JGSEb3B5GB413Kn7oWN8wP5PYB6JVyEewQon8LW2mNBUNL6B+1mM2g==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEEgOUtgHZwPyhMo3Gn3DenvFLSpwxQXJnFHqlY8b13bNp5nNOd0XQbzZpVEx728/JA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Role" },
                values: new object[] { "AQAAAAIAAYagAAAAENCkXGMPAG42UQQOl9MV70PNZ9iB3Zlu00FaF/b8dw7Rp40TWcXLI/TXQdOxK4WsZw==", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Role" },
                values: new object[] { "AQAAAAIAAYagAAAAEAHhaV1+AstHj9W0NlI+97SO6qzfEh76kSwYh1NXa337xxQaUzVg6eglr9gWTmTV4Q==", 0 });
        }
    }
}
