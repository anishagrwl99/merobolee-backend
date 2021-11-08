using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tender_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_admin_status_admin_status_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_posted_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_admin_status_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "lk_auction_status",
                keyColumn: "status_id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "admin_status_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "bid_no",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "last_request_date",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "project_start_date",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "source_fund",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.RenameColumn(
                name: "posted_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "created_by");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_posted_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_created_by");

            migrationBuilder.AddColumn<long>(
                name: "approved_by",
                schema: "dbo",
                table: "mb_tender",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_auction_status",
                keyColumn: "status_id",
                keyValue: 1,
                column: "auction_status",
                value: "Pending Approval");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_auction_status",
                keyColumn: "status_id",
                keyValue: 2,
                column: "auction_status",
                value: "Approved");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 713, DateTimeKind.Local).AddTicks(7628), new DateTime(2021, 11, 8, 16, 0, 1, 713, DateTimeKind.Local).AddTicks(7654) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 713, DateTimeKind.Local).AddTicks(7687), new DateTime(2021, 11, 8, 16, 0, 1, 713, DateTimeKind.Local).AddTicks(7690) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 713, DateTimeKind.Local).AddTicks(7704), new DateTime(2021, 11, 8, 16, 0, 1, 713, DateTimeKind.Local).AddTicks(7707) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 763, DateTimeKind.Local).AddTicks(8757), new DateTime(2021, 11, 8, 16, 0, 1, 763, DateTimeKind.Local).AddTicks(8787) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 763, DateTimeKind.Local).AddTicks(8800), new DateTime(2021, 11, 8, 16, 0, 1, 763, DateTimeKind.Local).AddTicks(8803) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 763, DateTimeKind.Local).AddTicks(8813), new DateTime(2021, 11, 8, 16, 0, 1, 763, DateTimeKind.Local).AddTicks(8816) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 724, DateTimeKind.Local).AddTicks(2945), new DateTime(2021, 11, 8, 16, 0, 1, 724, DateTimeKind.Local).AddTicks(2970), "MB112108160000854" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 724, DateTimeKind.Local).AddTicks(3048), new DateTime(2021, 11, 8, 16, 0, 1, 724, DateTimeKind.Local).AddTicks(3051), "BI112108160000858" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 1, 724, DateTimeKind.Local).AddTicks(3101), new DateTime(2021, 11, 8, 16, 0, 1, 724, DateTimeKind.Local).AddTicks(3105), "SP112108160000858" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(8361), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 852, DateTimeKind.Local).AddTicks(7940), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6299) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6768), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6773) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6776), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(6777) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9533), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9537) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9540), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9541) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9543), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9544) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9546), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9548), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9549) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9553), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9556), new DateTime(2021, 11, 8, 16, 0, 0, 853, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4351), new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4356) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4359), new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4360) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4361), new DateTime(2021, 11, 8, 16, 0, 0, 854, DateTimeKind.Local).AddTicks(4362) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 858, DateTimeKind.Local).AddTicks(3603), new DateTime(2021, 11, 8, 16, 0, 0, 858, DateTimeKind.Local).AddTicks(3609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5116), new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5132) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5497), new DateTime(2021, 11, 8, 16, 0, 0, 861, DateTimeKind.Local).AddTicks(5499) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_approved_by",
                schema: "dbo",
                table: "mb_tender",
                column: "approved_by");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_approved_by",
                schema: "dbo",
                table: "mb_tender",
                column: "approved_by",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_created_by",
                schema: "dbo",
                table: "mb_tender",
                column: "created_by",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_approved_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_created_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_approved_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "approved_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.RenameColumn(
                name: "created_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "posted_by");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_created_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_posted_by");

            migrationBuilder.AddColumn<int>(
                name: "admin_status_id",
                schema: "dbo",
                table: "mb_tender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bid_no",
                schema: "dbo",
                table: "mb_tender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_request_date",
                schema: "dbo",
                table: "mb_tender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "project_start_date",
                schema: "dbo",
                table: "mb_tender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "source_fund",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_auction_status",
                keyColumn: "status_id",
                keyValue: 1,
                column: "auction_status",
                value: "Created");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_auction_status",
                keyColumn: "status_id",
                keyValue: 2,
                column: "auction_status",
                value: "Running");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_auction_status",
                columns: new[] { "status_id", "auction_status" },
                values: new object[] { 4, "Upcoming" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 248, DateTimeKind.Local).AddTicks(8358), new DateTime(2021, 11, 4, 14, 37, 23, 248, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 248, DateTimeKind.Local).AddTicks(8411), new DateTime(2021, 11, 4, 14, 37, 23, 248, DateTimeKind.Local).AddTicks(8415) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 248, DateTimeKind.Local).AddTicks(8431), new DateTime(2021, 11, 4, 14, 37, 23, 248, DateTimeKind.Local).AddTicks(8434) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(4540), new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(4550) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(4562), new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(4566) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(4576), new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(4579) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(2005), new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(2014), "MB112104143722199" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(2104), new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(2108), "BI112104143722203" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(2170), new DateTime(2021, 11, 4, 14, 37, 23, 249, DateTimeKind.Local).AddTicks(2174), "SP112104143722203" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(8370), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 197, DateTimeKind.Local).AddTicks(7857), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6246) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6739), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6745) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6747), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(6748) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9661), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9667) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9671), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9672) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9674), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9676), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9677) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9678), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9681), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9682) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9683), new DateTime(2021, 11, 4, 14, 37, 22, 198, DateTimeKind.Local).AddTicks(9684) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4568), new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4574) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4577), new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4578) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4579), new DateTime(2021, 11, 4, 14, 37, 22, 199, DateTimeKind.Local).AddTicks(4580) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 203, DateTimeKind.Local).AddTicks(7895), new DateTime(2021, 11, 4, 14, 37, 22, 203, DateTimeKind.Local).AddTicks(7903) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(596), new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(982), new DateTime(2021, 11, 4, 14, 37, 22, 207, DateTimeKind.Local).AddTicks(985) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_admin_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "admin_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_admin_status_admin_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "admin_status_id",
                principalSchema: "dbo",
                principalTable: "lk_admin_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_posted_by",
                schema: "dbo",
                table: "mb_tender",
                column: "posted_by",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
