using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class status_manage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_company_document_lk_admin_status_AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document");

            migrationBuilder.DropTable(
                name: "lk_admin_status",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_mb_company_document_AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document");

            migrationBuilder.DropColumn(
                name: "AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 27, DateTimeKind.Local).AddTicks(3438), new DateTime(2021, 12, 26, 21, 43, 9, 27, DateTimeKind.Local).AddTicks(3462) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 27, DateTimeKind.Local).AddTicks(3491), new DateTime(2021, 12, 26, 21, 43, 9, 27, DateTimeKind.Local).AddTicks(3494) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 27, DateTimeKind.Local).AddTicks(3508), new DateTime(2021, 12, 26, 21, 43, 9, 27, DateTimeKind.Local).AddTicks(3511) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 96, DateTimeKind.Local).AddTicks(6168), new DateTime(2021, 12, 26, 21, 43, 9, 96, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 96, DateTimeKind.Local).AddTicks(6208), new DateTime(2021, 12, 26, 21, 43, 9, 96, DateTimeKind.Local).AddTicks(6211) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 96, DateTimeKind.Local).AddTicks(6220), new DateTime(2021, 12, 26, 21, 43, 9, 96, DateTimeKind.Local).AddTicks(6223) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 48, DateTimeKind.Local).AddTicks(8999), new DateTime(2021, 12, 26, 21, 43, 9, 48, DateTimeKind.Local).AddTicks(9028), "MB122126214308428" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 48, DateTimeKind.Local).AddTicks(9119), new DateTime(2021, 12, 26, 21, 43, 9, 48, DateTimeKind.Local).AddTicks(9123), "BI122126214308431" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 9, 48, DateTimeKind.Local).AddTicks(9174), new DateTime(2021, 12, 26, 21, 43, 9, 48, DateTimeKind.Local).AddTicks(9177), "SP122126214308431" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(8105), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(8110) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 426, DateTimeKind.Local).AddTicks(8938), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6544) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6924), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6931), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(6932) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9046), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9054), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9055) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9056), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9059), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9060) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9062), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9063) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9064), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9065) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9066), new DateTime(2021, 12, 26, 21, 43, 8, 427, DateTimeKind.Local).AddTicks(9067) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2307), new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2356), new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2358) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2359), new DateTime(2021, 12, 26, 21, 43, 8, 428, DateTimeKind.Local).AddTicks(2360) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 432, DateTimeKind.Local).AddTicks(727), new DateTime(2021, 12, 26, 21, 43, 8, 432, DateTimeKind.Local).AddTicks(736) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2358), new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2381) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2778), new DateTime(2021, 12, 26, 21, 43, 8, 435, DateTimeKind.Local).AddTicks(2780) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lk_admin_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_admin_status", x => x.status_id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_admin_status",
                columns: new[] { "status_id", "admin_status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" },
                    { 3, "Approved" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(226), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(279), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(310) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(328), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(331) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(7260), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(7270) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(7282), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(7285) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(7294), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(7298) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(4362), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(4373), "MB122126093728054" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(4496), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(4499), "BI122126093728057" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(4559), new DateTime(2021, 12, 26, 9, 37, 29, 229, DateTimeKind.Local).AddTicks(4563), "SP122126093728057" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(1065), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(1071) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 51, DateTimeKind.Local).AddTicks(4454), new DateTime(2021, 12, 26, 9, 37, 28, 52, DateTimeKind.Local).AddTicks(7698) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 52, DateTimeKind.Local).AddTicks(8459), new DateTime(2021, 12, 26, 9, 37, 28, 52, DateTimeKind.Local).AddTicks(8464) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 52, DateTimeKind.Local).AddTicks(8466), new DateTime(2021, 12, 26, 9, 37, 28, 52, DateTimeKind.Local).AddTicks(8468) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2494), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2499) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2502), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2504) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2506), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2508), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2509) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2511), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2512) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2513), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2514) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2516), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(2517) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(8330), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(8342) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(8346), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(8346) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(8348), new DateTime(2021, 12, 26, 9, 37, 28, 53, DateTimeKind.Local).AddTicks(8349) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 58, DateTimeKind.Local).AddTicks(3356), new DateTime(2021, 12, 26, 9, 37, 28, 58, DateTimeKind.Local).AddTicks(3363) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 61, DateTimeKind.Local).AddTicks(7260), new DateTime(2021, 12, 26, 9, 37, 28, 61, DateTimeKind.Local).AddTicks(7281) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 61, DateTimeKind.Local).AddTicks(7614), new DateTime(2021, 12, 26, 9, 37, 28, 61, DateTimeKind.Local).AddTicks(7616) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document",
                column: "AdminStatusEntityStatus_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_company_document_lk_admin_status_AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document",
                column: "AdminStatusEntityStatus_Id",
                principalSchema: "dbo",
                principalTable: "lk_admin_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
