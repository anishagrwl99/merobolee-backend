using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class email_typos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 838, DateTimeKind.Local).AddTicks(4077), new DateTime(2022, 2, 27, 21, 25, 17, 838, DateTimeKind.Local).AddTicks(4109) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 838, DateTimeKind.Local).AddTicks(4122), new DateTime(2022, 2, 27, 21, 25, 17, 838, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 838, DateTimeKind.Local).AddTicks(4134), new DateTime(2022, 2, 27, 21, 25, 17, 838, DateTimeKind.Local).AddTicks(4137) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 889, DateTimeKind.Local).AddTicks(6695), new DateTime(2022, 2, 27, 21, 25, 17, 889, DateTimeKind.Local).AddTicks(6726) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 889, DateTimeKind.Local).AddTicks(6797), new DateTime(2022, 2, 27, 21, 25, 17, 889, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 889, DateTimeKind.Local).AddTicks(6810), new DateTime(2022, 2, 27, 21, 25, 17, 889, DateTimeKind.Local).AddTicks(6813) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 850, DateTimeKind.Local).AddTicks(7255), new DateTime(2022, 2, 27, 21, 25, 17, 850, DateTimeKind.Local).AddTicks(7276), "MB220227001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 850, DateTimeKind.Local).AddTicks(7368), new DateTime(2022, 2, 27, 21, 25, 17, 850, DateTimeKind.Local).AddTicks(7372), "BI220227002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 850, DateTimeKind.Local).AddTicks(7477), new DateTime(2022, 2, 27, 21, 25, 17, 850, DateTimeKind.Local).AddTicks(7481), "SP220227003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(3857), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(3862) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 224, DateTimeKind.Local).AddTicks(7799), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2160), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2168), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5143), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5152), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5154), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5156), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5159), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5162), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5163) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5164), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(5165) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9937), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9942) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9946) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9947), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9948) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9949), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9950) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 2, 27, 21, 25, 17, 226, DateTimeKind.Local).AddTicks(9953) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 243, DateTimeKind.Local).AddTicks(9842), new DateTime(2022, 2, 27, 21, 25, 17, 243, DateTimeKind.Local).AddTicks(9853) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "Email" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(91), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(115), "tender.support@test.com" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(637), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(690), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(713), new DateTime(2022, 2, 27, 21, 25, 17, 254, DateTimeKind.Local).AddTicks(714) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 709, DateTimeKind.Local).AddTicks(5114), new DateTime(2022, 1, 27, 14, 55, 18, 709, DateTimeKind.Local).AddTicks(5167) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 709, DateTimeKind.Local).AddTicks(5210), new DateTime(2022, 1, 27, 14, 55, 18, 709, DateTimeKind.Local).AddTicks(5222) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 709, DateTimeKind.Local).AddTicks(5259), new DateTime(2022, 1, 27, 14, 55, 18, 709, DateTimeKind.Local).AddTicks(5272) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 712, DateTimeKind.Local).AddTicks(148), new DateTime(2022, 1, 27, 14, 55, 18, 712, DateTimeKind.Local).AddTicks(170) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 712, DateTimeKind.Local).AddTicks(221), new DateTime(2022, 1, 27, 14, 55, 18, 712, DateTimeKind.Local).AddTicks(236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 712, DateTimeKind.Local).AddTicks(273), new DateTime(2022, 1, 27, 14, 55, 18, 712, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 711, DateTimeKind.Local).AddTicks(3599), new DateTime(2022, 1, 27, 14, 55, 18, 711, DateTimeKind.Local).AddTicks(3623), "MB220127001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 711, DateTimeKind.Local).AddTicks(3919), new DateTime(2022, 1, 27, 14, 55, 18, 711, DateTimeKind.Local).AddTicks(3936), "BI220127002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 18, 711, DateTimeKind.Local).AddTicks(4162), new DateTime(2022, 1, 27, 14, 55, 18, 711, DateTimeKind.Local).AddTicks(4178), "SP220127003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(2615), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(2619) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 457, DateTimeKind.Local).AddTicks(3885), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(225) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(726), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(731) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(733), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(734) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3894), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3899) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3903), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3904) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3905), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3906) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3908), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3910), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3911) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3912), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3914), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(3915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8508), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8515), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8519), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8520) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8521), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8522) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8523), new DateTime(2022, 1, 27, 14, 55, 17, 459, DateTimeKind.Local).AddTicks(8524) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 465, DateTimeKind.Local).AddTicks(4951), new DateTime(2022, 1, 27, 14, 55, 17, 465, DateTimeKind.Local).AddTicks(4958) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "Email" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(3961), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(3986), "tender.suport@test.com" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4380), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4383) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4420), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4442), new DateTime(2022, 1, 27, 14, 55, 17, 470, DateTimeKind.Local).AddTicks(4443) });
        }
    }
}
