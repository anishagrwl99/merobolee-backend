using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class category_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lk_category_lk_common_status_status_id",
                schema: "dbo",
                table: "lk_category");

            migrationBuilder.DropIndex(
                name: "IX_lk_category_status_id",
                schema: "dbo",
                table: "lk_category");

            migrationBuilder.DropColumn(
                name: "status_id",
                schema: "dbo",
                table: "lk_category");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 728, DateTimeKind.Local).AddTicks(143), new DateTime(2022, 1, 17, 14, 46, 26, 728, DateTimeKind.Local).AddTicks(170) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 728, DateTimeKind.Local).AddTicks(181), new DateTime(2022, 1, 17, 14, 46, 26, 728, DateTimeKind.Local).AddTicks(185) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 728, DateTimeKind.Local).AddTicks(193), new DateTime(2022, 1, 17, 14, 46, 26, 728, DateTimeKind.Local).AddTicks(196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 788, DateTimeKind.Local).AddTicks(4422), new DateTime(2022, 1, 17, 14, 46, 26, 788, DateTimeKind.Local).AddTicks(4452) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 788, DateTimeKind.Local).AddTicks(4465), new DateTime(2022, 1, 17, 14, 46, 26, 788, DateTimeKind.Local).AddTicks(4468) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 788, DateTimeKind.Local).AddTicks(4476), new DateTime(2022, 1, 17, 14, 46, 26, 788, DateTimeKind.Local).AddTicks(4479) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 742, DateTimeKind.Local).AddTicks(7672), new DateTime(2022, 1, 17, 14, 46, 26, 742, DateTimeKind.Local).AddTicks(7694), "MB220117001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 742, DateTimeKind.Local).AddTicks(7780), new DateTime(2022, 1, 17, 14, 46, 26, 742, DateTimeKind.Local).AddTicks(7784), "BI220117002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 742, DateTimeKind.Local).AddTicks(7833), new DateTime(2022, 1, 17, 14, 46, 26, 742, DateTimeKind.Local).AddTicks(7836), "SP220117003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(329), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(334) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 53, DateTimeKind.Local).AddTicks(7695), new DateTime(2022, 1, 17, 14, 46, 26, 55, DateTimeKind.Local).AddTicks(7787) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 55, DateTimeKind.Local).AddTicks(8307), new DateTime(2022, 1, 17, 14, 46, 26, 55, DateTimeKind.Local).AddTicks(8311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 55, DateTimeKind.Local).AddTicks(8313), new DateTime(2022, 1, 17, 14, 46, 26, 55, DateTimeKind.Local).AddTicks(8314) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1671), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1679), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1680) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1681), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1684), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1685) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1686), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1687) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1689), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1690) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1691), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(1692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6243), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6248) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6251), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6252) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6254), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6255) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6256), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6257) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6258), new DateTime(2022, 1, 17, 14, 46, 26, 56, DateTimeKind.Local).AddTicks(6260) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 61, DateTimeKind.Local).AddTicks(4192), new DateTime(2022, 1, 17, 14, 46, 26, 61, DateTimeKind.Local).AddTicks(4200) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(2818), new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(2838) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(3463) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(3561), new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(3564) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(3639), new DateTime(2022, 1, 17, 14, 46, 26, 68, DateTimeKind.Local).AddTicks(3642) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status_id",
                schema: "dbo",
                table: "lk_category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified", "status_id" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 220, DateTimeKind.Local).AddTicks(7561), new DateTime(2022, 1, 14, 16, 24, 57, 220, DateTimeKind.Local).AddTicks(7631), 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified", "status_id" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 220, DateTimeKind.Local).AddTicks(7664), new DateTime(2022, 1, 14, 16, 24, 57, 220, DateTimeKind.Local).AddTicks(7668), 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified", "status_id" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 220, DateTimeKind.Local).AddTicks(7683), new DateTime(2022, 1, 14, 16, 24, 57, 220, DateTimeKind.Local).AddTicks(7686), 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(5182), new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(5203), new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(5217), new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(5221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(2440), new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(2450), "MB220114001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(2546), new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(2550), "BI220114002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(2651), new DateTime(2022, 1, 14, 16, 24, 57, 221, DateTimeKind.Local).AddTicks(2656), "SP220114003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(5415), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(5424) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 870, DateTimeKind.Local).AddTicks(5608), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(1748) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(2509), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(2517) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(2520), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(2521) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7560), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7567) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7571), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7572) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7575), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7576) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7578), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7580) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7581), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7583) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7585), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7586) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7588), new DateTime(2022, 1, 14, 16, 24, 55, 873, DateTimeKind.Local).AddTicks(7589) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5625), new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5722), new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5723) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5725), new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5727) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5729), new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5734), new DateTime(2022, 1, 14, 16, 24, 55, 874, DateTimeKind.Local).AddTicks(5735) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 883, DateTimeKind.Local).AddTicks(8444), new DateTime(2022, 1, 14, 16, 24, 55, 883, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(8571), new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(8603) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(9695), new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(9702) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(9824), new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(9828) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(9910), new DateTime(2022, 1, 14, 16, 24, 55, 891, DateTimeKind.Local).AddTicks(9913) });

            migrationBuilder.CreateIndex(
                name: "IX_lk_category_status_id",
                schema: "dbo",
                table: "lk_category",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_lk_category_lk_common_status_status_id",
                schema: "dbo",
                table: "lk_category",
                column: "status_id",
                principalSchema: "dbo",
                principalTable: "lk_common_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
