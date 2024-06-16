using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mims.Migrations
{
    /// <inheritdoc />
    public partial class Identityaaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6e9cb67-a247-4810-9ce4-b315b9dcefd2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb54431d-c748-4ee2-9460-4347cf0b8937", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aed513ef-3530-4ee9-8ea6-5fa7d9c6c6f0", 0, "3f2efd5c-8c98-45f6-b690-fd5cbec5977e", "admin@jyapusamaj.com", true, false, null, "ADMIN@JYAPUSAMAJ.COM", "ADMIN", "AQAAAAIAAYagAAAAEDEpiCXpVde7MoeQzTCaSHnZDdm014xxPt38fFdbA3GzF0Z+XUrZTho1UG4rF7oiGQ==", null, false, "cd0b26fc-3488-4ec8-87e0-1dbe35bca343", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Role", "Admin", "aed513ef-3530-4ee9-8ea6-5fa7d9c6c6f0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb54431d-c748-4ee2-9460-4347cf0b8937", "aed513ef-3530-4ee9-8ea6-5fa7d9c6c6f0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb54431d-c748-4ee2-9460-4347cf0b8937", "aed513ef-3530-4ee9-8ea6-5fa7d9c6c6f0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb54431d-c748-4ee2-9460-4347cf0b8937");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aed513ef-3530-4ee9-8ea6-5fa7d9c6c6f0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6e9cb67-a247-4810-9ce4-b315b9dcefd2", 0, "a53d300f-a14f-4959-bc3e-be11e04ef354", "admin@jyapusamaj.com", true, false, null, "ADMIN@JYAPUSAMAJ.COM", "ADMIN", "AQAAAAIAAYagAAAAEPZyPVSpQwXUVeFluwTAW7hoCTbYNcwbJKpf+8t9v34zOVn24xrW/w+QvEZa0B+MPA==", null, false, "386b1127-c43a-438e-80fc-1631756b98ec", false, "admin" });
        }
    }
}
