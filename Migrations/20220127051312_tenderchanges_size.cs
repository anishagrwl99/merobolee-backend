using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tenderchanges_size : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QualityRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(7000)",
                maxLength: 7000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PerformanceRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(7000)",
                maxLength: 7000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(7000)",
                maxLength: 7000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EligibilityCriteria",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(7000)",
                maxLength: 7000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(7000)",
                maxLength: 7000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 646, DateTimeKind.Local).AddTicks(3768), new DateTime(2022, 1, 27, 10, 58, 11, 646, DateTimeKind.Local).AddTicks(3799) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 646, DateTimeKind.Local).AddTicks(3811), new DateTime(2022, 1, 27, 10, 58, 11, 646, DateTimeKind.Local).AddTicks(3814) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 646, DateTimeKind.Local).AddTicks(3823), new DateTime(2022, 1, 27, 10, 58, 11, 646, DateTimeKind.Local).AddTicks(3826) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 696, DateTimeKind.Local).AddTicks(1552), new DateTime(2022, 1, 27, 10, 58, 11, 696, DateTimeKind.Local).AddTicks(1585) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 696, DateTimeKind.Local).AddTicks(1600), new DateTime(2022, 1, 27, 10, 58, 11, 696, DateTimeKind.Local).AddTicks(1604) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 696, DateTimeKind.Local).AddTicks(1614), new DateTime(2022, 1, 27, 10, 58, 11, 696, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 658, DateTimeKind.Local).AddTicks(6717), new DateTime(2022, 1, 27, 10, 58, 11, 658, DateTimeKind.Local).AddTicks(6747), "MB220127001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 658, DateTimeKind.Local).AddTicks(6927), new DateTime(2022, 1, 27, 10, 58, 11, 658, DateTimeKind.Local).AddTicks(6932), "BI220127002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 658, DateTimeKind.Local).AddTicks(6993), new DateTime(2022, 1, 27, 10, 58, 11, 658, DateTimeKind.Local).AddTicks(6996), "SP220127003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(6987), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(6992) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 56, DateTimeKind.Local).AddTicks(9367), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(5174), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(5178) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(5181), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(5182) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8247), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8255), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8257), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8259) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8260), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8261) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8263), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8264) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8265), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8266) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8268), new DateTime(2022, 1, 27, 10, 58, 11, 58, DateTimeKind.Local).AddTicks(8269) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2906), new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2912) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2914), new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2916), new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2917) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2919), new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2920) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2921), new DateTime(2022, 1, 27, 10, 58, 11, 59, DateTimeKind.Local).AddTicks(2922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 74, DateTimeKind.Local).AddTicks(4996), new DateTime(2022, 1, 27, 10, 58, 11, 74, DateTimeKind.Local).AddTicks(5003) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(1712), new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(1732) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(2060), new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(2063) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(2112), new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(2114) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(2137), new DateTime(2022, 1, 27, 10, 58, 11, 84, DateTimeKind.Local).AddTicks(2138) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QualityRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7000)",
                oldMaxLength: 7000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PerformanceRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7000)",
                oldMaxLength: 7000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7000)",
                oldMaxLength: 7000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EligibilityCriteria",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7000)",
                oldMaxLength: 7000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(7000)",
                oldMaxLength: 7000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(308), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(359), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(363) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(374), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(377) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(6247), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(6256) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(6271), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(6274) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(6284), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(6287) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(4117), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(4127), "MB220125001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(4234), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(4238), "BI220125002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(4301), new DateTime(2022, 1, 25, 16, 31, 39, 204, DateTimeKind.Local).AddTicks(4305), "SP220125003" });

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
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 39, DateTimeKind.Local).AddTicks(139), new DateTime(2022, 1, 25, 16, 31, 38, 39, DateTimeKind.Local).AddTicks(146) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(751), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(772) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1109), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1112) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1237), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1262), new DateTime(2022, 1, 25, 16, 31, 38, 44, DateTimeKind.Local).AddTicks(1263) });
        }
    }
}
