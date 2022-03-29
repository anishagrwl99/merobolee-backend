using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class added_Tender_Status_seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_Tender_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "Status",
                value: "Live");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_Tender_Status",
                columns: new[] { "StatusId", "Status" },
                values: new object[] { 5, "Completed" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 694, DateTimeKind.Unspecified).AddTicks(7558), new DateTime(2022, 3, 23, 21, 19, 27, 694, DateTimeKind.Unspecified).AddTicks(7619) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 694, DateTimeKind.Unspecified).AddTicks(7633), new DateTime(2022, 3, 23, 21, 19, 27, 694, DateTimeKind.Unspecified).AddTicks(7638) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 694, DateTimeKind.Unspecified).AddTicks(7647), new DateTime(2022, 3, 23, 21, 19, 27, 694, DateTimeKind.Unspecified).AddTicks(7652) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 746, DateTimeKind.Unspecified).AddTicks(6504), new DateTime(2022, 3, 23, 21, 19, 27, 746, DateTimeKind.Unspecified).AddTicks(6561) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 746, DateTimeKind.Unspecified).AddTicks(6578), new DateTime(2022, 3, 23, 21, 19, 27, 746, DateTimeKind.Unspecified).AddTicks(6583) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 746, DateTimeKind.Unspecified).AddTicks(6593), new DateTime(2022, 3, 23, 21, 19, 27, 746, DateTimeKind.Unspecified).AddTicks(6597) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 708, DateTimeKind.Unspecified).AddTicks(4507), new DateTime(2022, 3, 23, 21, 19, 27, 708, DateTimeKind.Unspecified).AddTicks(4580) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 708, DateTimeKind.Unspecified).AddTicks(4739), new DateTime(2022, 3, 23, 21, 19, 27, 708, DateTimeKind.Unspecified).AddTicks(4755) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 21, 19, 27, 708, DateTimeKind.Unspecified).AddTicks(4910), new DateTime(2022, 3, 23, 21, 19, 27, 708, DateTimeKind.Unspecified).AddTicks(4926) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "lk_Tender_Status",
                keyColumn: "StatusId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_Tender_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "Status",
                value: "Cancelled");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(3013), new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(3082) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(3098), new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(3104) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(3121), new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(3126) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 566, DateTimeKind.Unspecified).AddTicks(693), new DateTime(2022, 3, 23, 13, 47, 55, 566, DateTimeKind.Unspecified).AddTicks(711) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 566, DateTimeKind.Unspecified).AddTicks(727), new DateTime(2022, 3, 23, 13, 47, 55, 566, DateTimeKind.Unspecified).AddTicks(733) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 566, DateTimeKind.Unspecified).AddTicks(745), new DateTime(2022, 3, 23, 13, 47, 55, 566, DateTimeKind.Unspecified).AddTicks(750) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(8448), new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(8472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(8582), new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(8588) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(8660), new DateTime(2022, 3, 23, 13, 47, 55, 565, DateTimeKind.Unspecified).AddTicks(8666) });

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
    }
}
