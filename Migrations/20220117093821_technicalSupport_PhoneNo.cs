using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class technicalSupport_PhoneNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                type: "VARCHAR",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 734, DateTimeKind.Local).AddTicks(3697), new DateTime(2022, 1, 17, 15, 23, 20, 734, DateTimeKind.Local).AddTicks(3729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 734, DateTimeKind.Local).AddTicks(3869), new DateTime(2022, 1, 17, 15, 23, 20, 734, DateTimeKind.Local).AddTicks(3872) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 734, DateTimeKind.Local).AddTicks(3881), new DateTime(2022, 1, 17, 15, 23, 20, 734, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 793, DateTimeKind.Local).AddTicks(4905), new DateTime(2022, 1, 17, 15, 23, 20, 793, DateTimeKind.Local).AddTicks(4939) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 793, DateTimeKind.Local).AddTicks(4951), new DateTime(2022, 1, 17, 15, 23, 20, 793, DateTimeKind.Local).AddTicks(4954) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 793, DateTimeKind.Local).AddTicks(4964), new DateTime(2022, 1, 17, 15, 23, 20, 793, DateTimeKind.Local).AddTicks(4967) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 749, DateTimeKind.Local).AddTicks(3734), new DateTime(2022, 1, 17, 15, 23, 20, 749, DateTimeKind.Local).AddTicks(3760) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 749, DateTimeKind.Local).AddTicks(3848), new DateTime(2022, 1, 17, 15, 23, 20, 749, DateTimeKind.Local).AddTicks(3851) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 749, DateTimeKind.Local).AddTicks(3901), new DateTime(2022, 1, 17, 15, 23, 20, 749, DateTimeKind.Local).AddTicks(3904) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(3738), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 15, DateTimeKind.Local).AddTicks(4079), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1321) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1842), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1847) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1850), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1851) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4966), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4970) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4990), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4991) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4993), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4994) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4996), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4997) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4998), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4999) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5001), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5002) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5003), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5004) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(332), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(345), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(347), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(350), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(351) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(352), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 24, DateTimeKind.Local).AddTicks(6999), new DateTime(2022, 1, 17, 15, 23, 20, 24, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(82), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(109) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(799), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(807) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(897), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(900) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(938), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(939) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                schema: "dbo",
                table: "mb_TechnicalSupport");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(3594), new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(3625) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(3637), new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(3641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(3650), new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(3653) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 333, DateTimeKind.Local).AddTicks(1173), new DateTime(2022, 1, 17, 14, 46, 27, 333, DateTimeKind.Local).AddTicks(1182) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 333, DateTimeKind.Local).AddTicks(1236), new DateTime(2022, 1, 17, 14, 46, 27, 333, DateTimeKind.Local).AddTicks(1239) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 333, DateTimeKind.Local).AddTicks(1249), new DateTime(2022, 1, 17, 14, 46, 27, 333, DateTimeKind.Local).AddTicks(1253) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(8318), new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(8326) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(8428), new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(8432) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(8534), new DateTime(2022, 1, 17, 14, 46, 27, 332, DateTimeKind.Local).AddTicks(8538) });

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
    }
}
