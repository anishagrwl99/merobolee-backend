using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class company_and_user_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmailReceiver",
                schema: "dbo",
                table: "mb_user",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompanyStatusId",
                schema: "dbo",
                table: "mb_company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lk_company_status",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_company_status", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 264, DateTimeKind.Local).AddTicks(8577), new DateTime(2021, 11, 1, 17, 34, 19, 264, DateTimeKind.Local).AddTicks(8605) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 264, DateTimeKind.Local).AddTicks(8632), new DateTime(2021, 11, 1, 17, 34, 19, 264, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 264, DateTimeKind.Local).AddTicks(8650), new DateTime(2021, 11, 1, 17, 34, 19, 264, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_company_status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Registered" },
                    { 2, "Verifying" },
                    { 3, "Require More Documents" },
                    { 4, "Verified" },
                    { 5, "Suspended" },
                    { 6, "Deactivate" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 310, DateTimeKind.Local).AddTicks(5133), new DateTime(2021, 11, 1, 17, 34, 19, 310, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 310, DateTimeKind.Local).AddTicks(5172), new DateTime(2021, 11, 1, 17, 34, 19, 310, DateTimeKind.Local).AddTicks(5175) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 310, DateTimeKind.Local).AddTicks(5183), new DateTime(2021, 11, 1, 17, 34, 19, 310, DateTimeKind.Local).AddTicks(5186) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_user_status",
                keyColumn: "status_id",
                keyValue: 1,
                column: "user_status",
                value: "Active");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_user_status",
                keyColumn: "status_id",
                keyValue: 2,
                column: "user_status",
                value: "Temporary Disabled");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_user_status",
                keyColumn: "status_id",
                keyValue: 4,
                column: "user_status",
                value: "Deleted");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 19, 276, DateTimeKind.Local).AddTicks(2577), new DateTime(2021, 11, 1, 17, 34, 19, 276, DateTimeKind.Local).AddTicks(2603), "SP112101173418593" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(9592), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 589, DateTimeKind.Local).AddTicks(9470), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6166) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6838), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6843) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6845), new DateTime(2021, 11, 1, 17, 34, 18, 591, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1550), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1558), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1559) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1560), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1561) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1563), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1564) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1565), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1566) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1568), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1569) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1570), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(1571) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8920), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8926) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8928), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8930), new DateTime(2021, 11, 1, 17, 34, 18, 592, DateTimeKind.Local).AddTicks(8931) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 598, DateTimeKind.Local).AddTicks(7956), new DateTime(2021, 11, 1, 17, 34, 18, 598, DateTimeKind.Local).AddTicks(7977), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(6821), new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(6844), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(7179), new DateTime(2021, 11, 1, 17, 34, 18, 603, DateTimeKind.Local).AddTicks(7181), true });

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_CompanyStatusId",
                schema: "dbo",
                table: "mb_company",
                column: "CompanyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_company_lk_company_status_CompanyStatusId",
                schema: "dbo",
                table: "mb_company",
                column: "CompanyStatusId",
                principalSchema: "dbo",
                principalTable: "lk_company_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_company_lk_company_status_CompanyStatusId",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropTable(
                name: "lk_company_status",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_mb_company_CompanyStatusId",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.DropColumn(
                name: "IsEmailReceiver",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "CompanyStatusId",
                schema: "dbo",
                table: "mb_company");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(4167), new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(4198) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(4227), new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(4231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(4247), new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(4250) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 544, DateTimeKind.Local).AddTicks(1225), new DateTime(2021, 11, 1, 16, 22, 19, 544, DateTimeKind.Local).AddTicks(1234) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 544, DateTimeKind.Local).AddTicks(1248), new DateTime(2021, 11, 1, 16, 22, 19, 544, DateTimeKind.Local).AddTicks(1251) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 544, DateTimeKind.Local).AddTicks(1261), new DateTime(2021, 11, 1, 16, 22, 19, 544, DateTimeKind.Local).AddTicks(1265) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_user_status",
                keyColumn: "status_id",
                keyValue: 1,
                column: "user_status",
                value: "Registered");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_user_status",
                keyColumn: "status_id",
                keyValue: 2,
                column: "user_status",
                value: "Approved");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_user_status",
                keyColumn: "status_id",
                keyValue: 4,
                column: "user_status",
                value: "Terminated");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(9313), new DateTime(2021, 11, 1, 16, 22, 19, 543, DateTimeKind.Local).AddTicks(9336), "SP112101162218090" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(6974), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(6979) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 86, DateTimeKind.Local).AddTicks(5786), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(3368) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4067), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4074), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(4075) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9099), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9107), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9108) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9113), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9115), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9116) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9117), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9118) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 11, 1, 16, 22, 18, 88, DateTimeKind.Local).AddTicks(9121) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7535), new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7540) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7543), new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7544) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7546), new DateTime(2021, 11, 1, 16, 22, 18, 89, DateTimeKind.Local).AddTicks(7547) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 99, DateTimeKind.Local).AddTicks(3224), new DateTime(2021, 11, 1, 16, 22, 18, 99, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3208), new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3573), new DateTime(2021, 11, 1, 16, 22, 18, 105, DateTimeKind.Local).AddTicks(3576) });
        }
    }
}
