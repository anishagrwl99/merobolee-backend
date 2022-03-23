using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class added_IsDeleted_tender_dependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_IdentityUserId",
            //    schema: "dbo",
            //    table: "AspNetUserTokens");

            //migrationBuilder.DropColumn(
            //    name: "IdentityUserId",
            //    schema: "dbo",
            //    table: "AspNetUserTokens");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_tender_term_condition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_tender_material",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_tender",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_material_feature",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_live_bid",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_bidder_request",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_bid_history",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_AuctionLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 796, DateTimeKind.Unspecified).AddTicks(1138), new DateTime(2022, 3, 21, 21, 6, 20, 796, DateTimeKind.Unspecified).AddTicks(1202) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 796, DateTimeKind.Unspecified).AddTicks(1218), new DateTime(2022, 3, 21, 21, 6, 20, 796, DateTimeKind.Unspecified).AddTicks(1223) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 796, DateTimeKind.Unspecified).AddTicks(1235), new DateTime(2022, 3, 21, 21, 6, 20, 796, DateTimeKind.Unspecified).AddTicks(1240) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 850, DateTimeKind.Unspecified).AddTicks(1552), new DateTime(2022, 3, 21, 21, 6, 20, 850, DateTimeKind.Unspecified).AddTicks(1609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 850, DateTimeKind.Unspecified).AddTicks(1625), new DateTime(2022, 3, 21, 21, 6, 20, 850, DateTimeKind.Unspecified).AddTicks(1630) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 850, DateTimeKind.Unspecified).AddTicks(1641), new DateTime(2022, 3, 21, 21, 6, 20, 850, DateTimeKind.Unspecified).AddTicks(1645) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 812, DateTimeKind.Unspecified).AddTicks(4270), new DateTime(2022, 3, 21, 21, 6, 20, 812, DateTimeKind.Unspecified).AddTicks(4338), "MB220321001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 812, DateTimeKind.Unspecified).AddTicks(4534), new DateTime(2022, 3, 21, 21, 6, 20, 812, DateTimeKind.Unspecified).AddTicks(4548), "BI220321002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 812, DateTimeKind.Unspecified).AddTicks(4655), new DateTime(2022, 3, 21, 21, 6, 20, 812, DateTimeKind.Unspecified).AddTicks(4667), "SP220321003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(6878), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 118, DateTimeKind.Local).AddTicks(5139), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4504) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4983), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4989) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4991), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(4992) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8079), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8084) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8087), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8088) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8090), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8091) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8092), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8093) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8095), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8095) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8097), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8097) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8099), new DateTime(2022, 3, 21, 21, 6, 20, 121, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2427), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2433) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2436), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2437) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2440) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2442), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2443) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2444), new DateTime(2022, 3, 21, 21, 6, 20, 122, DateTimeKind.Local).AddTicks(2445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 134, DateTimeKind.Local).AddTicks(4466), new DateTime(2022, 3, 21, 21, 6, 20, 134, DateTimeKind.Local).AddTicks(4474) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(3901), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(3921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4228), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4269), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4270) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4290), new DateTime(2022, 3, 21, 21, 6, 20, 151, DateTimeKind.Local).AddTicks(4292) });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //    schema: "dbo",
            //    table: "AspNetUserTokens",
            //    column: "UserId",
            //    principalSchema: "dbo",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //    schema: "dbo",
            //    table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_tender_term_condition");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_live_bid");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_bidder_request_doc");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_bidder_request");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_bid_history");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_AuctionLog");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                schema: "dbo",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(2548), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(2611) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(2626), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(2632) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(2642), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(2647) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(8225), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(8241) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(8257), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(8262) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(8273), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(8277) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(6229), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(6248), "MB220314001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(6351), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(6357), "BI220314002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(6420), new DateTime(2022, 3, 14, 23, 45, 34, 784, DateTimeKind.Unspecified).AddTicks(6426), "SP220314003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(1044), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(1048) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 627, DateTimeKind.Local).AddTicks(7335), new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9042) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9502), new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9509), new DateTime(2022, 3, 14, 23, 45, 33, 628, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2222), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2226) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2230), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2231) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2232), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2233) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2235), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2237), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2240), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2240) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2242), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(2243) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7522), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7528) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7530), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7533), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7535), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7536) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7537), new DateTime(2022, 3, 14, 23, 45, 33, 629, DateTimeKind.Local).AddTicks(7538) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 634, DateTimeKind.Local).AddTicks(7717), new DateTime(2022, 3, 14, 23, 45, 33, 634, DateTimeKind.Local).AddTicks(7724) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(981), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1006) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1351), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1353) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1390), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1496), new DateTime(2022, 3, 14, 23, 45, 33, 644, DateTimeKind.Local).AddTicks(1497) });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUserTokens_AspNetUsers_IdentityUserId",
            //    schema: "dbo",
            //    table: "AspNetUserTokens",
            //    column: "IdentityUserId",
            //    principalSchema: "dbo",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
