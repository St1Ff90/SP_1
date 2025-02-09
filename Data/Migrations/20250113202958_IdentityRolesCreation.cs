using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SP.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRolesCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "497c7ac5-4356-4632-9dcb-2259cc03495f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "172288ed-c69c-4498-b11d-61feef70b2d8", null, "Lehrer", "LEHRER" },
                    { "46169538-d9cd-42ae-a45a-1251be457411", null, "Admin", "ADMIN" },
                    { "81272e9c-3713-4a2f-94e2-df761d2a16c1", null, "Manager", "MANAGER" },
                    { "8f7a833c-d318-4c6f-add3-0d4a65436170", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nachname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName", "Vorname" },
                values: new object[] { "3dfe9b8b-2a51-411c-8170-b0bfcd14dcda", 0, "b4eee09d-082e-463f-9a45-06dac1702e9a", "admin@admin.ua", false, false, null, null, "ADMIN@ADMIN.UA", "ADMIN@ADMIN.UA", "AQAAAAIAAYagAAAAEPSP9hF2ixxTP6cHXgUF7iHBT3C0bPFxgJ+4f2dK4/ySRiLmdpU4/L0Wx1PhRTg41g==", null, false, "53e383cf-b00b-4582-89aa-959402f3d9b6", false, 3, "admin@admin.ua", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "172288ed-c69c-4498-b11d-61feef70b2d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46169538-d9cd-42ae-a45a-1251be457411");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81272e9c-3713-4a2f-94e2-df761d2a16c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f7a833c-d318-4c6f-add3-0d4a65436170");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dfe9b8b-2a51-411c-8170-b0bfcd14dcda");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nachname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName", "Vorname" },
                values: new object[] { "497c7ac5-4356-4632-9dcb-2259cc03495f", 0, "91b55802-8254-4c5a-9b06-a5099ed82649", "admin@admin.ua", false, false, null, null, "ADMIN@ADMIN.UA", "ADMIN@ADMIN.UA", "AQAAAAIAAYagAAAAEBkb8M+cDvaMXlSjhHSGwJK12OeEzRaeNie2G+yT9qXx+M0FtvFViM5SJ3f2zNcSrg==", null, false, "bfacd954-a7b1-41fe-886e-6144fa7c382b", false, 3, "admin@admin.ua", "Admin" });
        }
    }
}
