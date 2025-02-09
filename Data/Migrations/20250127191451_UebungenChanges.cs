using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SP.Data.Migrations
{
    /// <inheritdoc />
    public partial class UebungenChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Übungens_Unterthemas_UnterthemaId",
                table: "Übungens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Übungens",
                table: "Übungens");

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

            migrationBuilder.RenameTable(
                name: "Übungens",
                newName: "Uebungens");

            migrationBuilder.RenameColumn(
                name: "ThemeName",
                table: "Themens",
                newName: "ThemaName");

            migrationBuilder.RenameIndex(
                name: "IX_Übungens_UnterthemaId",
                table: "Uebungens",
                newName: "IX_Uebungens_UnterthemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uebungens",
                table: "Uebungens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Lehrer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lehrer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lehrer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unterricht",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÜbungenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    LehrerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unterricht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unterricht_Lehrer_LehrerId",
                        column: x => x.LehrerId,
                        principalTable: "Lehrer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unterricht_Uebungens_ÜbungenId",
                        column: x => x.ÜbungenId,
                        principalTable: "Uebungens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentUnterricht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    UnterrichtId = table.Column<int>(type: "int", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUnterricht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUnterricht_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUnterricht_Unterricht_UnterrichtId",
                        column: x => x.UnterrichtId,
                        principalTable: "Unterricht",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnterrichtReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnterrichtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnterrichtReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnterrichtReport_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnterrichtReport_Unterricht_UnterrichtId",
                        column: x => x.UnterrichtId,
                        principalTable: "Unterricht",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29abfb43-ffc7-4202-80db-39b6346c77e7", null, "Admin", "ADMIN" },
                    { "5a6c74ce-3182-43f7-99f0-71a92d1b968f", null, "Student", "STUDENT" },
                    { "9fe1970f-688c-4c9b-9719-d0fcd9b26934", null, "Lehrer", "LEHRER" },
                    { "c61de5b4-911b-4b3b-9959-04770b78c84b", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nachname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName", "Vorname" },
                values: new object[] { "69f601c7-0a8d-4d96-b5b4-55ab8be4a0fd", 0, "c33bc098-cd29-4b38-8fa7-f79e0d163a6d", "admin@admin.ua", false, false, null, null, "ADMIN@ADMIN.UA", "ADMIN@ADMIN.UA", "AQAAAAIAAYagAAAAEHdeC1hz0WENx1w4UfKSIdppDNh+8KD7xz72sXcO0GSfp9krjUYth+UiRXu9L2h7yQ==", null, false, "1a6bef5e-19a2-4be6-8e06-35d0f0a48bdc", false, 3, "admin@admin.ua", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Lehrer_ApplicationUserId",
                table: "Lehrer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUnterricht_StudentId1",
                table: "StudentUnterricht",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUnterricht_UnterrichtId",
                table: "StudentUnterricht",
                column: "UnterrichtId");

            migrationBuilder.CreateIndex(
                name: "IX_Unterricht_LehrerId",
                table: "Unterricht",
                column: "LehrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Unterricht_ÜbungenId",
                table: "Unterricht",
                column: "ÜbungenId");

            migrationBuilder.CreateIndex(
                name: "IX_UnterrichtReport_StudentId1",
                table: "UnterrichtReport",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_UnterrichtReport_UnterrichtId",
                table: "UnterrichtReport",
                column: "UnterrichtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uebungens_Unterthemas_UnterthemaId",
                table: "Uebungens",
                column: "UnterthemaId",
                principalTable: "Unterthemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uebungens_Unterthemas_UnterthemaId",
                table: "Uebungens");

            migrationBuilder.DropTable(
                name: "StudentUnterricht");

            migrationBuilder.DropTable(
                name: "UnterrichtReport");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Unterricht");

            migrationBuilder.DropTable(
                name: "Lehrer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uebungens",
                table: "Uebungens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29abfb43-ffc7-4202-80db-39b6346c77e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a6c74ce-3182-43f7-99f0-71a92d1b968f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe1970f-688c-4c9b-9719-d0fcd9b26934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c61de5b4-911b-4b3b-9959-04770b78c84b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69f601c7-0a8d-4d96-b5b4-55ab8be4a0fd");

            migrationBuilder.RenameTable(
                name: "Uebungens",
                newName: "Übungens");

            migrationBuilder.RenameColumn(
                name: "ThemaName",
                table: "Themens",
                newName: "ThemeName");

            migrationBuilder.RenameIndex(
                name: "IX_Uebungens_UnterthemaId",
                table: "Übungens",
                newName: "IX_Übungens_UnterthemaId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Übungens",
                table: "Übungens",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Übungens_Unterthemas_UnterthemaId",
                table: "Übungens",
                column: "UnterthemaId",
                principalTable: "Unterthemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
