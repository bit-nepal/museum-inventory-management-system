using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mims.Migrations
{
    /// <inheritdoc />
    public partial class Identityaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "920158da-9e7b-4375-a16c-36e774ae6edc");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6e9cb67-a247-4810-9ce4-b315b9dcefd2", 0, "a53d300f-a14f-4959-bc3e-be11e04ef354", "admin@jyapusamaj.com", true, false, null, "ADMIN@JYAPUSAMAJ.COM", "ADMIN", "AQAAAAIAAYagAAAAEPZyPVSpQwXUVeFluwTAW7hoCTbYNcwbJKpf+8t9v34zOVn24xrW/w+QvEZa0B+MPA==", null, false, "386b1127-c43a-438e-80fc-1631756b98ec", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6e9cb67-a247-4810-9ce4-b315b9dcefd2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "920158da-9e7b-4375-a16c-36e774ae6edc", 0, "414cb5b9-a153-4cd1-bef4-f589b5132af3", "admin@jyapusamaj.com", true, false, null, "ADMIN@JYAPUSAMAJ.COM", "ADMIN", "AQAAAAIAAYagAAAAEGbPkcaUctJ+PdWoCznb9UogPtC/viegzkggDwmzEKsU1F6zT0gpiP1/+8Z3lodPqw==", null, false, "d88f870f-94f0-4400-8cde-0465ea8d82cf", false, "admin" });
        }
    }
}
