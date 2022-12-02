using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcom.Server.Migrations
{
    /// <inheritdoc />
    public partial class AppUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "E_Mail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MoneySpent",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d153c726-e709-4946-824b-0ed63bbf136a",
                column: "ConcurrencyStamp",
                value: "d0f99767-b9ab-4bbd-a520-889fe0c306a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
                column: "ConcurrencyStamp",
                value: "0ec9ea72-8f2f-4c96-932d-88c0d42aad10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
                columns: new[] { "ConcurrencyStamp", "E_Mail", "MoneySpent", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96b62519-256a-459b-b98c-026ae87dff8f", null, null, "admin", "AQAAAAEAACcQAAAAEEMZyXRLePvlceS7Z+lEC0FzARz6gZvt2OmubHD7WsVYHXs7qalmLaWnCxbmMp8KSw==", "8e2b3e25-e07b-4dc1-8e7a-8ccf36910837" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "E_Mail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MoneySpent",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f873aaff-65e5-47c8-b3b9-620d310fabc3", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEEPdWLtMnVYiz+jsyL4B/PFDQC3M/D6VgNPgAHcM6bGAd9ZrVqlS74WejGFAp+rXbw==", "e57dbd99-9a8d-46ea-804a-1e9e61017a2c" });
        }
    }
}
