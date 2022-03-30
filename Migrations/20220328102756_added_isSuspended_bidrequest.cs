using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class added_isSuspended_bidrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuspended",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 650, DateTimeKind.Unspecified).AddTicks(5218), new DateTime(2022, 3, 28, 16, 12, 55, 650, DateTimeKind.Unspecified).AddTicks(5410) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 650, DateTimeKind.Unspecified).AddTicks(5425), new DateTime(2022, 3, 28, 16, 12, 55, 650, DateTimeKind.Unspecified).AddTicks(5430) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 650, DateTimeKind.Unspecified).AddTicks(5440), new DateTime(2022, 3, 28, 16, 12, 55, 650, DateTimeKind.Unspecified).AddTicks(5445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 698, DateTimeKind.Unspecified).AddTicks(4450), new DateTime(2022, 3, 28, 16, 12, 55, 698, DateTimeKind.Unspecified).AddTicks(4506) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 698, DateTimeKind.Unspecified).AddTicks(4523), new DateTime(2022, 3, 28, 16, 12, 55, 698, DateTimeKind.Unspecified).AddTicks(4529) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 698, DateTimeKind.Unspecified).AddTicks(4541), new DateTime(2022, 3, 28, 16, 12, 55, 698, DateTimeKind.Unspecified).AddTicks(4546) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 661, DateTimeKind.Unspecified).AddTicks(9590), new DateTime(2022, 3, 28, 16, 12, 55, 661, DateTimeKind.Unspecified).AddTicks(9800), "MB220328001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 661, DateTimeKind.Unspecified).AddTicks(9902), new DateTime(2022, 3, 28, 16, 12, 55, 661, DateTimeKind.Unspecified).AddTicks(9908), "BI220328002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 661, DateTimeKind.Unspecified).AddTicks(9968), new DateTime(2022, 3, 28, 16, 12, 55, 661, DateTimeKind.Unspecified).AddTicks(9973), "SP220328003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(4076), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(4080) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 71, DateTimeKind.Local).AddTicks(9061), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(2030) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(2500), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(2505) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(2507), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5217), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5226), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5227) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5228), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5229) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5230), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5232), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5233) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5235), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5237), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(5238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9490), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9495) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9498), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9499) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9500), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9501) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9502), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9503) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9505), new DateTime(2022, 3, 28, 16, 12, 55, 73, DateTimeKind.Local).AddTicks(9505) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 80, DateTimeKind.Local).AddTicks(2773), new DateTime(2022, 3, 28, 16, 12, 55, 80, DateTimeKind.Local).AddTicks(2783) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(817), new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(840) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(1191), new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(1193) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(1231), new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(1251), new DateTime(2022, 3, 28, 16, 12, 55, 85, DateTimeKind.Local).AddTicks(1252) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuspended",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(3152), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(3214) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(3231), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(3237) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(3248), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(3253) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(9349), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(9367) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(9384), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(9390) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(9401), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(9406) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(7329), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(7349), "MB220323001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(7464), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(7470), "BI220323002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(7542), new DateTime(2022, 3, 23, 21, 19, 28, 247, DateTimeKind.Unspecified).AddTicks(7548), "SP220323003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(8811), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(8815) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 101, DateTimeKind.Local).AddTicks(5369), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(6915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(7347), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(7352) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(7354), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(7355) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9927), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9931) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9934), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9936) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9937), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9938) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9939), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9940) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9941), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9942) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9943), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9946), new DateTime(2022, 3, 23, 21, 19, 27, 102, DateTimeKind.Local).AddTicks(9947) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4033), new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4037) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4040), new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4041) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4042), new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4043) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4044), new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4045) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4047), new DateTime(2022, 3, 23, 21, 19, 27, 103, DateTimeKind.Local).AddTicks(4048) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 107, DateTimeKind.Local).AddTicks(5705), new DateTime(2022, 3, 23, 21, 19, 27, 107, DateTimeKind.Local).AddTicks(5710) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6449), new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6458) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6754), new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6757) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6794), new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6795) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6852), new DateTime(2022, 3, 23, 21, 19, 27, 111, DateTimeKind.Local).AddTicks(6853) });
        }
    }
}
