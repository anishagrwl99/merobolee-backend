using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class favcategory_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_favourite",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 48, DateTimeKind.Local).AddTicks(2249), new DateTime(2022, 1, 27, 14, 55, 18, 48, DateTimeKind.Local).AddTicks(2278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 48, DateTimeKind.Local).AddTicks(2331), new DateTime(2022, 1, 27, 14, 55, 18, 48, DateTimeKind.Local).AddTicks(2334) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 48, DateTimeKind.Local).AddTicks(2343), new DateTime(2022, 1, 27, 14, 55, 18, 48, DateTimeKind.Local).AddTicks(2346) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 124, DateTimeKind.Local).AddTicks(7816), new DateTime(2022, 1, 27, 14, 55, 18, 124, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 124, DateTimeKind.Local).AddTicks(7859), new DateTime(2022, 1, 27, 14, 55, 18, 124, DateTimeKind.Local).AddTicks(7862) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 124, DateTimeKind.Local).AddTicks(7871), new DateTime(2022, 1, 27, 14, 55, 18, 124, DateTimeKind.Local).AddTicks(7874) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 62, DateTimeKind.Local).AddTicks(5219), new DateTime(2022, 1, 27, 14, 55, 18, 62, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 62, DateTimeKind.Local).AddTicks(5337), new DateTime(2022, 1, 27, 14, 55, 18, 62, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 62, DateTimeKind.Local).AddTicks(5427), new DateTime(2022, 1, 27, 14, 55, 18, 62, DateTimeKind.Local).AddTicks(5430) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(2615), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(2619) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 457, DateTimeKind.Local).AddTicks(3885), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(225) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(726), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(731) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(733), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(734) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3894), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3899) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3903), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3904) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3905), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3906) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3908), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3910), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3911) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3912), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3914), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8508), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8515), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8519), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8520) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8521), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8522) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8523), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8524) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 465, DateTimeKind.Local).AddTicks(4951), new DateTime(2022, 1, 27, 14, 55, 17, 465, DateTimeKind.Local).AddTicks(4958) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(3961), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(3986) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4380), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4383) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4420), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4442), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4443) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_favourite",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_favourite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_favourite_lk_category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "lk_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 837, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 1, 27, 12, 13, 17, 837, DateTimeKind.Local).AddTicks(9979) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 837, DateTimeKind.Local).AddTicks(9991), new DateTime(2022, 1, 27, 12, 13, 17, 837, DateTimeKind.Local).AddTicks(9995) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(5), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(8) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(6822), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(6846), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(6860), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(4508), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(4517) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(4654), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(4657) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(4722), new DateTime(2022, 1, 27, 12, 13, 17, 838, DateTimeKind.Local).AddTicks(4726) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(1069), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(1074) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 743, DateTimeKind.Local).AddTicks(9938), new DateTime(2022, 1, 27, 12, 13, 16, 744, DateTimeKind.Local).AddTicks(8865) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 744, DateTimeKind.Local).AddTicks(9352), new DateTime(2022, 1, 27, 12, 13, 16, 744, DateTimeKind.Local).AddTicks(9357) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 744, DateTimeKind.Local).AddTicks(9360), new DateTime(2022, 1, 27, 12, 13, 16, 744, DateTimeKind.Local).AddTicks(9361) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2304), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2308) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2312), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2314), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2315) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2316), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2318) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2319), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2323) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2325), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2326) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2327), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(2328) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7047), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7053) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7056), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7057) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7058), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7061), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7062) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7063), new DateTime(2022, 1, 27, 12, 13, 16, 745, DateTimeKind.Local).AddTicks(7064) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 749, DateTimeKind.Local).AddTicks(8711), new DateTime(2022, 1, 27, 12, 13, 16, 749, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3081), new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3101) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3549), new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3552) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3599), new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3601) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3623), new DateTime(2022, 1, 27, 12, 13, 16, 753, DateTimeKind.Local).AddTicks(3625) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_CategoryId",
                schema: "dbo",
                table: "mb_favourite",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_UserId",
                schema: "dbo",
                table: "mb_favourite",
                column: "UserId");
        }
    }
}
