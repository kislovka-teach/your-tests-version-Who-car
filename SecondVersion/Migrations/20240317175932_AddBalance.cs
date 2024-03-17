using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondVersion.Migrations
{
    /// <inheritdoc />
    public partial class AddBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "teachers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEMlFYKgY5LDKExZPVC5eKFFUDYmdLhJi/br3in85sd9TBR9hF6DGDUxyIzmbxnIPfw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEI98/H/qTqROBPJobxuPBb+PGlYsdoZX8rV/8ZcM8PwYlvQdPdgVRjp5l0U6tGd2tw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEEH0W1f3gwJ1CcqkEzQ22E1QH1wZhBUZnKDPwzFEzs64HYNCtTBHG7UUCYTAX7vYrA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEA72CMbE/Tdxh9AQiUdcHKx8a4Hqnd5V9OOV942jssmiz9iQlkU6/EuuzmC6wOX62A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEOXo2bQPAyoGZ5VmI1MLO0h59bn+jMxsigw/Sca3O5HQS5nLVa5506jOdITLreJ0Hg==");

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "teachers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Balance",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "teachers");

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
                column: "Password",
                value: "AQAAAAIAAYagAAAAENimrN/lHnkOaGkeq2RP1Nf0+jLxWGy27K3BeHTF8BuTaCWl1FHxfVPcYYTiS8QTiA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "AQAAAAIAAYagAAAAENykWJAxOkv/ljZiX/qe8mQJbRMrRRa1hnC85dPOTs/kP/Ven3bfU0CwnprLHOSZNQ==");
        }
    }
}
