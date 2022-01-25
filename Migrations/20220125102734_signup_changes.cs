using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class signup_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_user_company_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "Phone1",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropColumn(
                name: "Phone2",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(5000)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 526, DateTimeKind.Local).AddTicks(5675), new DateTime(2022, 1, 25, 16, 12, 33, 526, DateTimeKind.Local).AddTicks(5729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 526, DateTimeKind.Local).AddTicks(5742), new DateTime(2022, 1, 25, 16, 12, 33, 526, DateTimeKind.Local).AddTicks(5745) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 526, DateTimeKind.Local).AddTicks(5754), new DateTime(2022, 1, 25, 16, 12, 33, 526, DateTimeKind.Local).AddTicks(5757) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 583, DateTimeKind.Local).AddTicks(2937), new DateTime(2022, 1, 25, 16, 12, 33, 583, DateTimeKind.Local).AddTicks(2964) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 583, DateTimeKind.Local).AddTicks(2977), new DateTime(2022, 1, 25, 16, 12, 33, 583, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 583, DateTimeKind.Local).AddTicks(2988), new DateTime(2022, 1, 25, 16, 12, 33, 583, DateTimeKind.Local).AddTicks(2991) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 543, DateTimeKind.Local).AddTicks(318), new DateTime(2022, 1, 25, 16, 12, 33, 543, DateTimeKind.Local).AddTicks(342), "MB220125001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 543, DateTimeKind.Local).AddTicks(434), new DateTime(2022, 1, 25, 16, 12, 33, 543, DateTimeKind.Local).AddTicks(437), "BI220125002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 33, 543, DateTimeKind.Local).AddTicks(495), new DateTime(2022, 1, 25, 16, 12, 33, 543, DateTimeKind.Local).AddTicks(499), "SP220125003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(9094), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(9099) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 865, DateTimeKind.Local).AddTicks(1823), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(6854) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7315), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7320) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7322), new DateTime(2022, 1, 25, 16, 12, 32, 866, DateTimeKind.Local).AddTicks(7323) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(375), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(383), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(384) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(402), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(403) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(404), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(405) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(408), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(409) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(410), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(413) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(414), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4702), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4708) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4710), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4713), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4714) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4715), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4716) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4717), new DateTime(2022, 1, 25, 16, 12, 32, 867, DateTimeKind.Local).AddTicks(4718) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 873, DateTimeKind.Local).AddTicks(7477), new DateTime(2022, 1, 25, 16, 12, 32, 873, DateTimeKind.Local).AddTicks(7511) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(34), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(56) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(487), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(490) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(525), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(526) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(545), new DateTime(2022, 1, 25, 16, 12, 32, 879, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_company_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "mb_company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_company_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5000)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 939, DateTimeKind.Local).AddTicks(7298), new DateTime(2022, 1, 20, 14, 52, 16, 939, DateTimeKind.Local).AddTicks(7338) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 939, DateTimeKind.Local).AddTicks(7353), new DateTime(2022, 1, 20, 14, 52, 16, 939, DateTimeKind.Local).AddTicks(7356) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 939, DateTimeKind.Local).AddTicks(7366), new DateTime(2022, 1, 20, 14, 52, 16, 939, DateTimeKind.Local).AddTicks(7369) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(3477), new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(3486) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(3500), new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(3503) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(3512), new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(3516) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(1628), new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(1636), "MB220120001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(1744), new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(1748), "BI220120002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(1813), new DateTime(2022, 1, 20, 14, 52, 16, 940, DateTimeKind.Local).AddTicks(1816), "SP220120003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(9306), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 611, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(6933) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7440), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7447), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7448) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(896), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(901) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(904), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(905) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(907), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(909), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(913), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(915), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(916) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(917), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(918) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6711), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6720), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6721) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6722), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6723) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6724), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6725) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6727), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6728) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 618, DateTimeKind.Local).AddTicks(8764), new DateTime(2022, 1, 20, 14, 52, 15, 618, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(424), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(450) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(987), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(990) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1027), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1028) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1048), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1049) });

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_user_company_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "mb_user_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
