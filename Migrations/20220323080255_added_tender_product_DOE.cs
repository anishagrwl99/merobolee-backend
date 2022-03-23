using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class added_tender_product_DOE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfExecution",
                schema: "dbo",
                table: "mb_tender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Product",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 39, DateTimeKind.Unspecified).AddTicks(6475), new DateTime(2022, 3, 23, 13, 47, 55, 39, DateTimeKind.Unspecified).AddTicks(6538) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 39, DateTimeKind.Unspecified).AddTicks(6552), new DateTime(2022, 3, 23, 13, 47, 55, 39, DateTimeKind.Unspecified).AddTicks(6557) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 39, DateTimeKind.Unspecified).AddTicks(6567), new DateTime(2022, 3, 23, 13, 47, 55, 39, DateTimeKind.Unspecified).AddTicks(6572) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 91, DateTimeKind.Unspecified).AddTicks(1271), new DateTime(2022, 3, 23, 13, 47, 55, 91, DateTimeKind.Unspecified).AddTicks(1330) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 91, DateTimeKind.Unspecified).AddTicks(1346), new DateTime(2022, 3, 23, 13, 47, 55, 91, DateTimeKind.Unspecified).AddTicks(1350) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 91, DateTimeKind.Unspecified).AddTicks(1361), new DateTime(2022, 3, 23, 13, 47, 55, 91, DateTimeKind.Unspecified).AddTicks(1365) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 52, DateTimeKind.Unspecified).AddTicks(4768), new DateTime(2022, 3, 23, 13, 47, 55, 52, DateTimeKind.Unspecified).AddTicks(4819), "MB220323001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 52, DateTimeKind.Unspecified).AddTicks(4911), new DateTime(2022, 3, 23, 13, 47, 55, 52, DateTimeKind.Unspecified).AddTicks(4917), "BI220323002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 52, DateTimeKind.Unspecified).AddTicks(4999), new DateTime(2022, 3, 23, 13, 47, 55, 52, DateTimeKind.Unspecified).AddTicks(5005), "SP220323003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(2515), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(2519) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 450, DateTimeKind.Local).AddTicks(8655), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(1036), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(1041) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(1043), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(1044) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3624), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3629) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3632), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3633) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3635), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3636) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3637), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3638) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3639), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3640) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3642), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3643) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3644), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(3645) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7763), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7768) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7770), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7771) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7772), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7773) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7774), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7775) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7776), new DateTime(2022, 3, 23, 13, 47, 54, 452, DateTimeKind.Local).AddTicks(7777) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 457, DateTimeKind.Local).AddTicks(2574), new DateTime(2022, 3, 23, 13, 47, 54, 457, DateTimeKind.Local).AddTicks(2579) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7258), new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7593), new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7595) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7634), new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7635) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7658), new DateTime(2022, 3, 23, 13, 47, 54, 466, DateTimeKind.Local).AddTicks(7659) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfExecution",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "Product",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(5823), new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(5883) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(5898), new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(5903) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(5915), new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(5919) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 346, DateTimeKind.Unspecified).AddTicks(1533), new DateTime(2022, 3, 21, 21, 6, 21, 346, DateTimeKind.Unspecified).AddTicks(1549) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 346, DateTimeKind.Unspecified).AddTicks(1565), new DateTime(2022, 3, 21, 21, 6, 21, 346, DateTimeKind.Unspecified).AddTicks(1570) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 346, DateTimeKind.Unspecified).AddTicks(1582), new DateTime(2022, 3, 21, 21, 6, 21, 346, DateTimeKind.Unspecified).AddTicks(1586) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(9625), new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(9643), "MB220321001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(9751), new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(9758), "BI220321002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(9821), new DateTime(2022, 3, 21, 21, 6, 21, 345, DateTimeKind.Unspecified).AddTicks(9827), "SP220321003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(6878), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 118, DateTimeKind.Local).AddTicks(5139), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4504) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4983), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4989) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4991), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4992) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8079), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8084) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8087), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8088) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8090), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8091) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8092), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8093) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8095), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8095) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8097), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8097) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8099), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2427), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2433) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2436), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2437) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2440) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2442), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2443) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2444), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 134, DateTimeKind.Local).AddTicks(4466), new DateTime(2022, 3, 21, 21, 6, 20, 134, DateTimeKind.Local).AddTicks(4474) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(3901), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(3921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4228), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4269), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4270) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4290), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4292) });
        }
    }
}
