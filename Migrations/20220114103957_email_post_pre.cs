using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class email_post_pre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPostAuctionEmail",
                schema: "dbo",
                table: "mb_email",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 621, DateTimeKind.Local).AddTicks(5038), new DateTime(2022, 1, 14, 16, 24, 56, 621, DateTimeKind.Local).AddTicks(5066) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 621, DateTimeKind.Local).AddTicks(5111), new DateTime(2022, 1, 14, 16, 24, 56, 621, DateTimeKind.Local).AddTicks(5115) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 621, DateTimeKind.Local).AddTicks(5130), new DateTime(2022, 1, 14, 16, 24, 56, 621, DateTimeKind.Local).AddTicks(5133) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 698, DateTimeKind.Local).AddTicks(3472), new DateTime(2022, 1, 14, 16, 24, 56, 698, DateTimeKind.Local).AddTicks(3499) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 698, DateTimeKind.Local).AddTicks(3511), new DateTime(2022, 1, 14, 16, 24, 56, 698, DateTimeKind.Local).AddTicks(3514) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 698, DateTimeKind.Local).AddTicks(3523), new DateTime(2022, 1, 14, 16, 24, 56, 698, DateTimeKind.Local).AddTicks(3526) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 648, DateTimeKind.Local).AddTicks(4589), new DateTime(2022, 1, 14, 16, 24, 56, 648, DateTimeKind.Local).AddTicks(4620), "MB220114001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 648, DateTimeKind.Local).AddTicks(4710), new DateTime(2022, 1, 14, 16, 24, 56, 648, DateTimeKind.Local).AddTicks(4714), "BI220114002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 14, 16, 24, 56, 648, DateTimeKind.Local).AddTicks(4776), new DateTime(2022, 1, 14, 16, 24, 56, 648, DateTimeKind.Local).AddTicks(4779), "SP220114003" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPostAuctionEmail",
                schema: "dbo",
                table: "mb_email");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(157), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(185) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(214), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(218) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(233), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(9022), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(9032) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(9044), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(9048) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(9058), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(9061) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(4851), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(4861), "MB220113001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(5014), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(5018), "BI220113002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(5079), new DateTime(2022, 1, 13, 11, 3, 7, 90, DateTimeKind.Local).AddTicks(5083), "SP220113003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(8251), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(8257) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 896, DateTimeKind.Local).AddTicks(7647), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6162) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6641), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6646) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6648), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6649) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9435), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9444), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9447), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9448) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9450), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9453), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9454) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9455), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9456) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9457), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9458) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4142), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4151), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4153), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4154) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4156), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4157) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4158), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4159) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 902, DateTimeKind.Local).AddTicks(4242), new DateTime(2022, 1, 13, 11, 3, 5, 902, DateTimeKind.Local).AddTicks(4249) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(5959), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(5972) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6296), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6342), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6343) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6367), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6368) });
        }
    }
}
