using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tenderdefaultcode_newid_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 310, DateTimeKind.Local).AddTicks(8439), new DateTime(2022, 1, 27, 12, 13, 17, 310, DateTimeKind.Local).AddTicks(8469) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 310, DateTimeKind.Local).AddTicks(8481), new DateTime(2022, 1, 27, 12, 13, 17, 310, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 310, DateTimeKind.Local).AddTicks(8493), new DateTime(2022, 1, 27, 12, 13, 17, 310, DateTimeKind.Local).AddTicks(8496) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 358, DateTimeKind.Local).AddTicks(5115), new DateTime(2022, 1, 27, 12, 13, 17, 358, DateTimeKind.Local).AddTicks(5143) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 358, DateTimeKind.Local).AddTicks(5156), new DateTime(2022, 1, 27, 12, 13, 17, 358, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 358, DateTimeKind.Local).AddTicks(5169), new DateTime(2022, 1, 27, 12, 13, 17, 358, DateTimeKind.Local).AddTicks(5172) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 322, DateTimeKind.Local).AddTicks(8224), new DateTime(2022, 1, 27, 12, 13, 17, 322, DateTimeKind.Local).AddTicks(8249) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 322, DateTimeKind.Local).AddTicks(8387), new DateTime(2022, 1, 27, 12, 13, 17, 322, DateTimeKind.Local).AddTicks(8391) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 12, 13, 17, 322, DateTimeKind.Local).AddTicks(8447), new DateTime(2022, 1, 27, 12, 13, 17, 322, DateTimeKind.Local).AddTicks(8451) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 188, DateTimeKind.Local).AddTicks(9413), new DateTime(2022, 1, 27, 10, 58, 12, 188, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 188, DateTimeKind.Local).AddTicks(9499), new DateTime(2022, 1, 27, 10, 58, 12, 188, DateTimeKind.Local).AddTicks(9503) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 188, DateTimeKind.Local).AddTicks(9514), new DateTime(2022, 1, 27, 10, 58, 12, 188, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(6635), new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(6644) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(6659), new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(6663) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(6674), new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(6678) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(4257), new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(4267) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(4389), new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(4502), new DateTime(2022, 1, 27, 10, 58, 12, 189, DateTimeKind.Local).AddTicks(4506) });

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
    }
}
