using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class InitialSchemaNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 902, DateTimeKind.Unspecified).AddTicks(3701), new DateTime(2022, 3, 18, 12, 37, 22, 902, DateTimeKind.Unspecified).AddTicks(3765) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 902, DateTimeKind.Unspecified).AddTicks(3782), new DateTime(2022, 3, 18, 12, 37, 22, 902, DateTimeKind.Unspecified).AddTicks(3788) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 902, DateTimeKind.Unspecified).AddTicks(3801), new DateTime(2022, 3, 18, 12, 37, 22, 902, DateTimeKind.Unspecified).AddTicks(3806) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 964, DateTimeKind.Unspecified).AddTicks(7769), new DateTime(2022, 3, 18, 12, 37, 22, 964, DateTimeKind.Unspecified).AddTicks(7830) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 964, DateTimeKind.Unspecified).AddTicks(7848), new DateTime(2022, 3, 18, 12, 37, 22, 964, DateTimeKind.Unspecified).AddTicks(7853) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 964, DateTimeKind.Unspecified).AddTicks(7865), new DateTime(2022, 3, 18, 12, 37, 22, 964, DateTimeKind.Unspecified).AddTicks(7870) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 916, DateTimeKind.Unspecified).AddTicks(8915), new DateTime(2022, 3, 18, 12, 37, 22, 916, DateTimeKind.Unspecified).AddTicks(9019), "MB220318001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 916, DateTimeKind.Unspecified).AddTicks(9134), new DateTime(2022, 3, 18, 12, 37, 22, 916, DateTimeKind.Unspecified).AddTicks(9140), "BI220318002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 916, DateTimeKind.Unspecified).AddTicks(9205), new DateTime(2022, 3, 18, 12, 37, 22, 916, DateTimeKind.Unspecified).AddTicks(9210), "SP220318003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(5643), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(5648) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 166, DateTimeKind.Local).AddTicks(8393), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(3234) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(3756), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(3761) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(3764), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(3765) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7107), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7112) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7116), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7117) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7119), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7122), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7123) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7125), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7128), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7130) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7131), new DateTime(2022, 3, 18, 12, 37, 22, 167, DateTimeKind.Local).AddTicks(7132) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2001), new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2006) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2009), new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2010) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2011), new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2012) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2014), new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2015) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2016), new DateTime(2022, 3, 18, 12, 37, 22, 168, DateTimeKind.Local).AddTicks(2017) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 173, DateTimeKind.Local).AddTicks(1620), new DateTime(2022, 3, 18, 12, 37, 22, 173, DateTimeKind.Local).AddTicks(1627) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(7638), new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(7658) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(8033), new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(8036) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(8080), new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(8082) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(8107), new DateTime(2022, 3, 18, 12, 37, 22, 185, DateTimeKind.Local).AddTicks(8108) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3374), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3411), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3425), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(3428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1016), new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1025) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1039), new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1043) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1054), new DateTime(2022, 2, 27, 21, 25, 18, 384, DateTimeKind.Local).AddTicks(1057) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8553), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8564), "MB220227001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8709), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8713), "BI220227002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 2, 27, 21, 25, 18, 383, DateTimeKind.Local).AddTicks(8784), "SP220227003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(3857), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 224, DateTimeKind.Local).AddTicks(7799), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2160), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2168), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5143), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5152), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5154), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5156), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5159), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5162), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5163) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5164), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9937), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9942) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9947), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9948) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9949), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9950) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9953) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 243, DateTimeKind.Local).AddTicks(9842), new DateTime(2022, 2, 27, 21, 25, 17, 243, DateTimeKind.Local).AddTicks(9853) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(91), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(115) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(637), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(690), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(714) });
        }
    }
}
