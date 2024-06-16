using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mims.Migrations
{
    /// <inheritdoc />
    public partial class Identityaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "920158da-9e7b-4375-a16c-36e774ae6edc", 0, "414cb5b9-a153-4cd1-bef4-f589b5132af3", "admin@jyapusamaj.com", true, false, null, "ADMIN@JYAPUSAMAJ.COM", "ADMIN", "AQAAAAIAAYagAAAAEGbPkcaUctJ+PdWoCznb9UogPtC/viegzkggDwmzEKsU1F6zT0gpiP1/+8Z3lodPqw==", null, false, "d88f870f-94f0-4400-8cde-0465ea8d82cf", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "920158da-9e7b-4375-a16c-36e774ae6edc");
        }
    }
}
