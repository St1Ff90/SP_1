using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SP.Data.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nachname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Vorname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nachname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName", "Vorname" },
                values: new object[] { "497c7ac5-4356-4632-9dcb-2259cc03495f", 0, "91b55802-8254-4c5a-9b06-a5099ed82649", "admin@admin.ua", false, false, null, null, "ADMIN@ADMIN.UA", "ADMIN@ADMIN.UA", "AQAAAAIAAYagAAAAEBkb8M+cDvaMXlSjhHSGwJK12OeEzRaeNie2G+yT9qXx+M0FtvFViM5SJ3f2zNcSrg==", null, false, "bfacd954-a7b1-41fe-886e-6144fa7c382b", false, 3, "admin@admin.ua", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "497c7ac5-4356-4632-9dcb-2259cc03495f");

            migrationBuilder.DropColumn(
                name: "Nachname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Vorname",
                table: "AspNetUsers");
        }
    }
}
