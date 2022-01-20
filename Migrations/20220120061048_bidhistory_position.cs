using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class bidhistory_position : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinalPosition",
                schema: "dbo",
                table: "mb_bid_history",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 786, DateTimeKind.Local).AddTicks(9769), new DateTime(2022, 1, 20, 11, 55, 47, 786, DateTimeKind.Local).AddTicks(9798) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 786, DateTimeKind.Local).AddTicks(9809), new DateTime(2022, 1, 20, 11, 55, 47, 786, DateTimeKind.Local).AddTicks(9812) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 786, DateTimeKind.Local).AddTicks(9821), new DateTime(2022, 1, 20, 11, 55, 47, 786, DateTimeKind.Local).AddTicks(9824) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 834, DateTimeKind.Local).AddTicks(3135), new DateTime(2022, 1, 20, 11, 55, 47, 834, DateTimeKind.Local).AddTicks(3159) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 834, DateTimeKind.Local).AddTicks(3171), new DateTime(2022, 1, 20, 11, 55, 47, 834, DateTimeKind.Local).AddTicks(3173) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 834, DateTimeKind.Local).AddTicks(3182), new DateTime(2022, 1, 20, 11, 55, 47, 834, DateTimeKind.Local).AddTicks(3186) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 798, DateTimeKind.Local).AddTicks(6500), new DateTime(2022, 1, 20, 11, 55, 47, 798, DateTimeKind.Local).AddTicks(6515), "MB220120001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 798, DateTimeKind.Local).AddTicks(6607), new DateTime(2022, 1, 20, 11, 55, 47, 798, DateTimeKind.Local).AddTicks(6610), "BI220120002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 798, DateTimeKind.Local).AddTicks(6666), new DateTime(2022, 1, 20, 11, 55, 47, 798, DateTimeKind.Local).AddTicks(6669), "SP220120003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(2975), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 230, DateTimeKind.Local).AddTicks(5081), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(832) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1334), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1339) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1342), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1343) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4184), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4188) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4192), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4193) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4194), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4197), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4198) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4199), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4201) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4202), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4204), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8847), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8854) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8856), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8857) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8858), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8860) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8861), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8862) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8863), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 239, DateTimeKind.Local).AddTicks(3170), new DateTime(2022, 1, 20, 11, 55, 47, 239, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(6805), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7139), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7242), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7265), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7266) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPosition",
                schema: "dbo",
                table: "mb_bid_history");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "VARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(4164), new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(4190) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(4202), new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(4206) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(4215), new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(4218) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 73, DateTimeKind.Local).AddTicks(1592), new DateTime(2022, 1, 18, 10, 2, 40, 73, DateTimeKind.Local).AddTicks(1601) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 73, DateTimeKind.Local).AddTicks(1613), new DateTime(2022, 1, 18, 10, 2, 40, 73, DateTimeKind.Local).AddTicks(1616) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 73, DateTimeKind.Local).AddTicks(1666), new DateTime(2022, 1, 18, 10, 2, 40, 73, DateTimeKind.Local).AddTicks(1670) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(8682), new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(8690), "MB220118001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(8793), new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(8797), "BI220118002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(8896), new DateTime(2022, 1, 18, 10, 2, 40, 72, DateTimeKind.Local).AddTicks(8900), "SP220118003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(4650), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(4655) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 21, DateTimeKind.Local).AddTicks(4241), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(2571) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3055), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3060) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3063), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3064) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5862), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5867) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5871), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5872) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5932), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5934) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5935), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5936) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5938), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5939) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5940), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5942), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(406), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(412) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(415), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(418), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(419) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(420), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(422), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 27, DateTimeKind.Local).AddTicks(156), new DateTime(2022, 1, 18, 10, 2, 39, 27, DateTimeKind.Local).AddTicks(164) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3089), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3109) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3487), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3489) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3525), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3527) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3546), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3547) });
        }
    }
}
