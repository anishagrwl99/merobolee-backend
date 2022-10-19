using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "dbo",
                table: "mb_live_bid",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                schema: "dbo",
                table: "mb_live_bid",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "dbo",
                table: "mb_live_bid",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Units",
                schema: "dbo",
                table: "mb_live_bid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FAQType",
                schema: "dbo",
                table: "mb_FAQ",
                type: "VARCHAR(5000)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_company_document",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "mb_payment_details",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TxnId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TxnAmt = table.Column<long>(type: "bigint", nullable: false),
                    TxnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TxnSts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentChanel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_payment_details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mb_supplier_quotation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Quotation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_supplier_quotation", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 429, DateTimeKind.Unspecified).AddTicks(8007), new DateTime(2022, 9, 13, 12, 31, 27, 429, DateTimeKind.Unspecified).AddTicks(8067) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 429, DateTimeKind.Unspecified).AddTicks(8081), new DateTime(2022, 9, 13, 12, 31, 27, 429, DateTimeKind.Unspecified).AddTicks(8086) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 429, DateTimeKind.Unspecified).AddTicks(8096), new DateTime(2022, 9, 13, 12, 31, 27, 429, DateTimeKind.Unspecified).AddTicks(8101) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 479, DateTimeKind.Unspecified).AddTicks(6528), new DateTime(2022, 9, 13, 12, 31, 27, 479, DateTimeKind.Unspecified).AddTicks(6578) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 479, DateTimeKind.Unspecified).AddTicks(6603), new DateTime(2022, 9, 13, 12, 31, 27, 479, DateTimeKind.Unspecified).AddTicks(6609) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 479, DateTimeKind.Unspecified).AddTicks(6620), new DateTime(2022, 9, 13, 12, 31, 27, 479, DateTimeKind.Unspecified).AddTicks(6625) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 441, DateTimeKind.Unspecified).AddTicks(6411), new DateTime(2022, 9, 13, 12, 31, 27, 441, DateTimeKind.Unspecified).AddTicks(6457), "MB220913001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 441, DateTimeKind.Unspecified).AddTicks(6551), new DateTime(2022, 9, 13, 12, 31, 27, 441, DateTimeKind.Unspecified).AddTicks(6558), "BI220913002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 27, 441, DateTimeKind.Unspecified).AddTicks(6614), new DateTime(2022, 9, 13, 12, 31, 27, 441, DateTimeKind.Unspecified).AddTicks(6619), "SP220913003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(3095), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(3101) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 579, DateTimeKind.Local).AddTicks(5485), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(109) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(621), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(627) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(629), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(630) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4422), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4427) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4430), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4431) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4434), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4436), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4437) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4439), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4440) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4441), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4444), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(4445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9283), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9289) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9292), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9293) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9295), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9297), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9299), new DateTime(2022, 9, 13, 12, 31, 26, 580, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 586, DateTimeKind.Local).AddTicks(218), new DateTime(2022, 9, 13, 12, 31, 26, 586, DateTimeKind.Local).AddTicks(226) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(3806), new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(3826) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(4266), new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(4268) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(4316), new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(4317) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(4340), new DateTime(2022, 9, 13, 12, 31, 26, 590, DateTimeKind.Local).AddTicks(4342) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_payment_details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_supplier_quotation",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "dbo",
                table: "mb_live_bid");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "dbo",
                table: "mb_live_bid");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "dbo",
                table: "mb_live_bid");

            migrationBuilder.DropColumn(
                name: "Units",
                schema: "dbo",
                table: "mb_live_bid");

            migrationBuilder.DropColumn(
                name: "FAQType",
                schema: "dbo",
                table: "mb_FAQ");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "mb_company_document");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(5492), new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(5562) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(5578), new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(5584) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(5602), new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(5607) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 193, DateTimeKind.Unspecified).AddTicks(1434), new DateTime(2022, 3, 28, 16, 12, 56, 193, DateTimeKind.Unspecified).AddTicks(1450) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 193, DateTimeKind.Unspecified).AddTicks(1468), new DateTime(2022, 3, 28, 16, 12, 56, 193, DateTimeKind.Unspecified).AddTicks(1473) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 193, DateTimeKind.Unspecified).AddTicks(1484), new DateTime(2022, 3, 28, 16, 12, 56, 193, DateTimeKind.Unspecified).AddTicks(1489) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(9467), new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(9484), "MB220328001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(9591), new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(9598), "BI220328002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(9670), new DateTime(2022, 3, 28, 16, 12, 56, 192, DateTimeKind.Unspecified).AddTicks(9675), "SP220328003" });

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
    }
}
