using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcom.Server.Migrations
{
    /// <inheritdoc />
    public partial class newone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d153c726-e709-4946-824b-0ed63bbf136a",
                column: "ConcurrencyStamp",
                value: "bf90a070-0ab6-42b5-ba62-9728ad05f8f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
                column: "ConcurrencyStamp",
                value: "33443590-fcbf-4b5c-9831-665bae7ae1ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f873aaff-65e5-47c8-b3b9-620d310fabc3", "AQAAAAEAACcQAAAAEEPdWLtMnVYiz+jsyL4B/PFDQC3M/D6VgNPgAHcM6bGAd9ZrVqlS74WejGFAp+rXbw==", "e57dbd99-9a8d-46ea-804a-1e9e61017a2c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d153c726-e709-4946-824b-0ed63bbf136a",
                column: "ConcurrencyStamp",
                value: "204a60bb-b10b-4499-be0d-e7d53ef27a17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
                column: "ConcurrencyStamp",
                value: "7f5d7778-a7e4-4ea8-825e-9e0857e3e272");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5707eebe-712e-4a8d-a111-5e03c178a5c7", "AQAAAAEAACcQAAAAEOlZhdUU2PVoT42ctIucxV9MhkfXZx8YPhbSD+0JjzSgyVs4D+XHq/AZeCfpoqyjsQ==", "51df0cb1-241e-4323-ba92-799dae93595f" });
        }
    }
}
