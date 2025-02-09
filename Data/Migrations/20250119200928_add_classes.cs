using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SP.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Themens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bereich = table.Column<int>(type: "int", nullable: false),
                    ThemeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unterthemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameUntertheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beispiele = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unterthemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unterthemas_Themens_ThemenId",
                        column: x => x.ThemenId,
                        principalTable: "Themens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Übungens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnterthemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aufgabe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antworten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Übungens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Übungens_Unterthemas_UnterthemaId",
                        column: x => x.UnterthemaId,
                        principalTable: "Unterthemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61de135a-1745-49e9-adac-9bb8dc2fa6c9", null, "Admin", "ADMIN" },
                    { "6afed12a-9c2d-4eda-b9d2-70548f695f9b", null, "Manager", "MANAGER" },
                    { "96acc6bf-0bb4-4c9e-9088-677f45e60ff2", null, "Lehrer", "LEHRER" },
                    { "a26a796a-5872-4f0f-882f-7d2976df25e9", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nachname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName", "Vorname" },
                values: new object[] { "4d74b180-f911-46e8-93d7-454e6c8d97a4", 0, "e4755979-7241-493c-8442-23eb50386203", "ApplicationUser", "admin@admin.ua", false, false, null, "", "ADMIN@ADMIN.UA", "ADMIN@ADMIN.UA", "AQAAAAIAAYagAAAAEGU2TopYK9kGjGnVUtC2ifE3nRtERVe5oCcM3No83fAyhAcAgZRja1XnkK1Q0OQMZw==", "", false, "bbea5dc9-72b9-47ea-a68f-25c0fb64f30c", false, 3, "admin@admin.ua", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Übungens_UnterthemaId",
                table: "Übungens",
                column: "UnterthemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unterthemas_ThemenId",
                table: "Unterthemas",
                column: "ThemenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Übungens");

            migrationBuilder.DropTable(
                name: "Unterthemas");

            migrationBuilder.DropTable(
                name: "Themens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61de135a-1745-49e9-adac-9bb8dc2fa6c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6afed12a-9c2d-4eda-b9d2-70548f695f9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96acc6bf-0bb4-4c9e-9088-677f45e60ff2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a26a796a-5872-4f0f-882f-7d2976df25e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d74b180-f911-46e8-93d7-454e6c8d97a4");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

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
    }
}
