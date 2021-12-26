using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class bid_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_AuctionLog_mb_bidder_request_BiddingId",
                schema: "dbo",
                table: "mb_AuctionLog");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_lk_admin_status_admin_status_id",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_user_user_id",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_doc_mb_bidder_request_request_id",
                schema: "dbo",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropTable(
                name: "lk_auction_status",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "bidder_request_doc",
                schema: "dbo",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropColumn(
                name: "request_code",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "request_send_date",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "request_id",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                newName: "BidRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_doc_request_id",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                newName: "IX_mb_bidder_request_doc_BidRequestId");

            migrationBuilder.RenameColumn(
                name: "remark",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "Remark");

            migrationBuilder.RenameColumn(
                name: "company_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "tender_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "TenderId");

            migrationBuilder.RenameColumn(
                name: "admin_status_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "BidRequestStatusId");

            migrationBuilder.RenameColumn(
                name: "request_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_user_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "IX_mb_bidder_request_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_tender_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "IX_mb_bidder_request_TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_admin_status_id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "IX_mb_bidder_request_BidRequestStatusId");

            migrationBuilder.AddColumn<string>(
                name: "DocPath",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocTitle",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remark",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "VARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentProvider",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentReferenceCode",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lk_bidrequest_status",
                schema: "dbo",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_bidrequest_status", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_bidrequest_status",
                columns: new[] { "StatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Pending Approval" },
                    { 2, "Approve" },
                    { 3, "Require More Document" },
                    { 4, "Reject" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 671, DateTimeKind.Local).AddTicks(7011), new DateTime(2021, 12, 26, 9, 37, 28, 671, DateTimeKind.Local).AddTicks(7046) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 671, DateTimeKind.Local).AddTicks(7079), new DateTime(2021, 12, 26, 9, 37, 28, 671, DateTimeKind.Local).AddTicks(7083) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 671, DateTimeKind.Local).AddTicks(7096), new DateTime(2021, 12, 26, 9, 37, 28, 671, DateTimeKind.Local).AddTicks(7099) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 727, DateTimeKind.Local).AddTicks(393), new DateTime(2021, 12, 26, 9, 37, 28, 727, DateTimeKind.Local).AddTicks(420) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 727, DateTimeKind.Local).AddTicks(433), new DateTime(2021, 12, 26, 9, 37, 28, 727, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 727, DateTimeKind.Local).AddTicks(445), new DateTime(2021, 12, 26, 9, 37, 28, 727, DateTimeKind.Local).AddTicks(448) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 682, DateTimeKind.Local).AddTicks(5109), new DateTime(2021, 12, 26, 9, 37, 28, 682, DateTimeKind.Local).AddTicks(5135), "MB122126093728054" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 682, DateTimeKind.Local).AddTicks(5230), new DateTime(2021, 12, 26, 9, 37, 28, 682, DateTimeKind.Local).AddTicks(5234), "BI122126093728057" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 26, 9, 37, 28, 682, DateTimeKind.Local).AddTicks(5294), new DateTime(2021, 12, 26, 9, 37, 28, 682, DateTimeKind.Local).AddTicks(5297), "SP122126093728057" });

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
                name: "IX_mb_bidder_request_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_AuctionLog_mb_bidder_request_BiddingId",
                schema: "dbo",
                table: "mb_AuctionLog",
                column: "BiddingId",
                principalSchema: "dbo",
                principalTable: "mb_bidder_request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_lk_bidrequest_status_BidRequestStatusId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "BidRequestStatusId",
                principalSchema: "dbo",
                principalTable: "lk_bidrequest_status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "TenderId",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_user_company_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "mb_user_company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_user_UserId",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_doc_mb_bidder_request_BidRequestId",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                column: "BidRequestId",
                principalSchema: "dbo",
                principalTable: "mb_bidder_request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_AuctionLog_mb_bidder_request_BiddingId",
                schema: "dbo",
                table: "mb_AuctionLog");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_lk_bidrequest_status_BidRequestStatusId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_user_company_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_mb_user_UserId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_bidder_request_doc_mb_bidder_request_BidRequestId",
                schema: "dbo",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropTable(
                name: "lk_bidrequest_status",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_mb_bidder_request_CompanyId",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "DocPath",
                schema: "dbo",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropColumn(
                name: "DocTitle",
                schema: "dbo",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "PaymentProvider",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "PaymentReferenceCode",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BidRequestId",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                newName: "request_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_doc_BidRequestId",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                newName: "IX_mb_bidder_request_doc_request_id");

            migrationBuilder.RenameColumn(
                name: "Remark",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "remark");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "tender_id");

            migrationBuilder.RenameColumn(
                name: "BidRequestStatusId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "admin_status_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "request_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_UserId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "IX_mb_bidder_request_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_TenderId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "IX_mb_bidder_request_tender_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_bidder_request_BidRequestStatusId",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "IX_mb_bidder_request_admin_status_id");

            migrationBuilder.AddColumn<string>(
                name: "bidder_request_doc",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "remark",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "request_code",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "request_send_date",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "lk_auction_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auction_status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_auction_status", x => x.status_id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_auction_status",
                columns: new[] { "status_id", "auction_status" },
                values: new object[,]
                {
                    { 1, "Pending Approval" },
                    { 2, "Approved" },
                    { 3, "Closed" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 606, DateTimeKind.Local).AddTicks(9057), new DateTime(2021, 12, 22, 8, 33, 52, 606, DateTimeKind.Local).AddTicks(9084) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 606, DateTimeKind.Local).AddTicks(9109), new DateTime(2021, 12, 22, 8, 33, 52, 606, DateTimeKind.Local).AddTicks(9113) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 606, DateTimeKind.Local).AddTicks(9128), new DateTime(2021, 12, 22, 8, 33, 52, 606, DateTimeKind.Local).AddTicks(9132) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(6000), new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(6009) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(6022), new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(6036), new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(6039) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(3191), new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(3202), "MB122122083351331" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(3291), new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(3294), "BI122122083351335" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(3355), new DateTime(2021, 12, 22, 8, 33, 52, 607, DateTimeKind.Local).AddTicks(3358), "SP122122083351335" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(7077), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(7081) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 329, DateTimeKind.Local).AddTicks(6274), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(4841) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5343), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5348) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5350), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(5351) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8364), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8368) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8371), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8372) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8375), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8378), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8379) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8380), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8381) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8383), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8385), new DateTime(2021, 12, 22, 8, 33, 51, 330, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3326), new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3334) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3337), new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3338) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3339), new DateTime(2021, 12, 22, 8, 33, 51, 331, DateTimeKind.Local).AddTicks(3340) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 335, DateTimeKind.Local).AddTicks(3910), new DateTime(2021, 12, 22, 8, 33, 51, 335, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(8410), new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(8442) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(9095), new DateTime(2021, 12, 22, 8, 33, 51, 338, DateTimeKind.Local).AddTicks(9102) });

            migrationBuilder.AddForeignKey(
                name: "FK_mb_AuctionLog_mb_bidder_request_BiddingId",
                schema: "dbo",
                table: "mb_AuctionLog",
                column: "BiddingId",
                principalSchema: "dbo",
                principalTable: "mb_bidder_request",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_lk_admin_status_admin_status_id",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "admin_status_id",
                principalSchema: "dbo",
                principalTable: "lk_admin_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "tender_id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_mb_user_user_id",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_bidder_request_doc_mb_bidder_request_request_id",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                column: "request_id",
                principalSchema: "dbo",
                principalTable: "mb_bidder_request",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
