using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class defaultpassword_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 653, DateTimeKind.Local).AddTicks(1343), new DateTime(2022, 1, 25, 16, 31, 38, 653, DateTimeKind.Local).AddTicks(1388) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 653, DateTimeKind.Local).AddTicks(1401), new DateTime(2022, 1, 25, 16, 31, 38, 653, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 653, DateTimeKind.Local).AddTicks(1439), new DateTime(2022, 1, 25, 16, 31, 38, 653, DateTimeKind.Local).AddTicks(1442) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 715, DateTimeKind.Local).AddTicks(1552), new DateTime(2022, 1, 25, 16, 31, 38, 715, DateTimeKind.Local).AddTicks(1582) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 715, DateTimeKind.Local).AddTicks(1594), new DateTime(2022, 1, 25, 16, 31, 38, 715, DateTimeKind.Local).AddTicks(1597) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 715, DateTimeKind.Local).AddTicks(1606), new DateTime(2022, 1, 25, 16, 31, 38, 715, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 667, DateTimeKind.Local).AddTicks(7269), new DateTime(2022, 1, 25, 16, 31, 38, 667, DateTimeKind.Local).AddTicks(7294) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 667, DateTimeKind.Local).AddTicks(7389), new DateTime(2022, 1, 25, 16, 31, 38, 667, DateTimeKind.Local).AddTicks(7392) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 667, DateTimeKind.Local).AddTicks(7452), new DateTime(2022, 1, 25, 16, 31, 38, 667, DateTimeKind.Local).AddTicks(7455) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(1011), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(1015) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 31, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 1, 25, 16, 31, 38, 32, DateTimeKind.Local).AddTicks(8778) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 32, DateTimeKind.Local).AddTicks(9248), new DateTime(2022, 1, 25, 16, 31, 38, 32, DateTimeKind.Local).AddTicks(9253) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 32, DateTimeKind.Local).AddTicks(9255), new DateTime(2022, 1, 25, 16, 31, 38, 32, DateTimeKind.Local).AddTicks(9256) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2161), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2168), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2171), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2172) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2174), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2175) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2177), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2178) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2179), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2182), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(2182) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6382), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6387) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6389), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6391) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6392), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6396) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6397), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6399), new DateTime(2022, 1, 25, 16, 31, 38, 33, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 39, DateTimeKind.Local).AddTicks(139), new DateTime(2022, 1, 25, 16, 31, 38, 39, DateTimeKind.Local).AddTicks(146), "96CErs1vPN0JRlkPOni6TQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(751), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(772), "96CErs1vPN0JRlkPOni6TQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1109), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1112), "96CErs1vPN0JRlkPOni6TQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1237), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1238), "96CErs1vPN0JRlkPOni6TQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1262), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1263), "96CErs1vPN0JRlkPOni6TQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(3387), new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(3451) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(3465), new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(3469) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(3479), new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(3482) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 104, DateTimeKind.Local).AddTicks(391), new DateTime(2022, 1, 25, 16, 12, 34, 104, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 104, DateTimeKind.Local).AddTicks(412), new DateTime(2022, 1, 25, 16, 12, 34, 104, DateTimeKind.Local).AddTicks(416) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 104, DateTimeKind.Local).AddTicks(425), new DateTime(2022, 1, 25, 16, 12, 34, 104, DateTimeKind.Local).AddTicks(428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(8242), new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(8250) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(8393), new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(8397) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(8460), new DateTime(2022, 1, 25, 16, 12, 34, 103, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(9094), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(9099) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 865, DateTimeKind.Local).AddTicks(1823), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(6854) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7315), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7320) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7322), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7323) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(375), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(383), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(384) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(402), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(403) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(404), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(405) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(408), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(409) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(410), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(413) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(414), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4702), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4708) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4710), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4713), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4714) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4715), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4716) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4717), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4718) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 873, DateTimeKind.Local).AddTicks(7477), new DateTime(2022, 1, 25, 16, 12, 32, 873, DateTimeKind.Local).AddTicks(7511), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(34), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(56), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(487), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(490), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(525), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(526), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified", "Password" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(545), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(546), "ZDztlPNVNo1CxEclyEDngQ==" });
        }
    }
}
