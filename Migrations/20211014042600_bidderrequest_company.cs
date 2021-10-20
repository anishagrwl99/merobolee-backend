using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class bidderrequest_company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_created",
                schema: "dbo",
                table: "mb_company",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "company_id",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 156, DateTimeKind.Local).AddTicks(4087), new DateTime(2021, 10, 14, 10, 11, 0, 156, DateTimeKind.Local).AddTicks(4114) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 156, DateTimeKind.Local).AddTicks(4137), new DateTime(2021, 10, 14, 10, 11, 0, 156, DateTimeKind.Local).AddTicks(4141) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 156, DateTimeKind.Local).AddTicks(4161), new DateTime(2021, 10, 14, 10, 11, 0, 156, DateTimeKind.Local).AddTicks(4164) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 188, DateTimeKind.Local).AddTicks(4711), new DateTime(2021, 10, 14, 10, 11, 0, 188, DateTimeKind.Local).AddTicks(4740) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 188, DateTimeKind.Local).AddTicks(4753), new DateTime(2021, 10, 14, 10, 11, 0, 188, DateTimeKind.Local).AddTicks(4756) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 188, DateTimeKind.Local).AddTicks(4765), new DateTime(2021, 10, 14, 10, 11, 0, 188, DateTimeKind.Local).AddTicks(4769) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 11, 0, 166, DateTimeKind.Local).AddTicks(969), new DateTime(2021, 10, 14, 10, 11, 0, 166, DateTimeKind.Local).AddTicks(990), "SP102114101059651" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(3458), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(3463) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 648, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1177) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1680), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1686) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1688), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5134), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5140) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5143), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5145), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5147), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5150), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5151) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5152), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5154), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9738), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9748), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9751), new DateTime(2021, 10, 14, 10, 10, 59, 650, DateTimeKind.Local).AddTicks(9752) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 663, DateTimeKind.Local).AddTicks(1369), new DateTime(2021, 10, 14, 10, 10, 59, 663, DateTimeKind.Local).AddTicks(1386) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(157), new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(179) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(509), new DateTime(2021, 10, 14, 10, 10, 59, 672, DateTimeKind.Local).AddTicks(512) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropColumn(
                name: "company_id",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(2127), new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(2167) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(2199), new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(2203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(2218), new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(2221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(7317), new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(7326) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(7339), new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(7343) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(7353), new DateTime(2021, 10, 12, 12, 23, 6, 682, DateTimeKind.Local).AddTicks(7356) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                column: "ReferenceCode",
                value: "SP102112122305996");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(806), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 995, DateTimeKind.Local).AddTicks(991), new DateTime(2021, 10, 12, 12, 23, 5, 995, DateTimeKind.Local).AddTicks(8806) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 995, DateTimeKind.Local).AddTicks(9275), new DateTime(2021, 10, 12, 12, 23, 5, 995, DateTimeKind.Local).AddTicks(9280) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 995, DateTimeKind.Local).AddTicks(9283), new DateTime(2021, 10, 12, 12, 23, 5, 995, DateTimeKind.Local).AddTicks(9284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1959), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1963) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1967), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1968) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1969), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1970) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1972), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1973) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1975), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1976) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1977), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1978) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1980), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(1981) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(6653), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(6659) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(6661), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(6663) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(6664), new DateTime(2021, 10, 12, 12, 23, 5, 996, DateTimeKind.Local).AddTicks(6665) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 0, DateTimeKind.Local).AddTicks(6440), new DateTime(2021, 10, 12, 12, 23, 6, 0, DateTimeKind.Local).AddTicks(6462) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 3, DateTimeKind.Local).AddTicks(8386), new DateTime(2021, 10, 12, 12, 23, 6, 3, DateTimeKind.Local).AddTicks(8405) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 23, 6, 3, DateTimeKind.Local).AddTicks(8735), new DateTime(2021, 10, 12, 12, 23, 6, 3, DateTimeKind.Local).AddTicks(8738) });
        }
    }
}
