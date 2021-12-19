using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tender_card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_auction_status_tender_status_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "duration",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.RenameColumn(
                name: "duration_type",
                schema: "dbo",
                table: "mb_tender",
                newName: "QualityRequest");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "dbo",
                table: "mb_tender",
                newName: "PerformanceRequest");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EligibilityCriteria",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "mb_tender",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationTill",
                schema: "dbo",
                table: "mb_tender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "auction_status",
                schema: "dbo",
                table: "lk_auction_status",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "lk_Tender_Status",
                schema: "dbo",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_Tender_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "mb_Tender_Card_Feeback",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Feeback = table.Column<string>(type: "VARCHAR(1500)", maxLength: 1500, nullable: false),
                    TenderEntityTender_Id = table.Column<long>(type: "bigint", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_Tender_Card_Feeback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_Tender_Card_Feeback_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_Tender_Card_Feeback_mb_tender_TenderEntityTender_Id",
                        column: x => x.TenderEntityTender_Id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_Tender_Card_Feeback_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_Tender_Card_Feeback_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderCard",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    Label = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_TenderCard_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_Tender_Status",
                columns: new[] { "StatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Pending Approval" },
                    { 2, "Change Requested" },
                    { 3, "Approved" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 487, DateTimeKind.Local).AddTicks(5583), new DateTime(2021, 12, 19, 15, 28, 28, 487, DateTimeKind.Local).AddTicks(5606) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 487, DateTimeKind.Local).AddTicks(5635), new DateTime(2021, 12, 19, 15, 28, 28, 487, DateTimeKind.Local).AddTicks(5638) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 487, DateTimeKind.Local).AddTicks(5658), new DateTime(2021, 12, 19, 15, 28, 28, 487, DateTimeKind.Local).AddTicks(5661) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 528, DateTimeKind.Local).AddTicks(6242), new DateTime(2021, 12, 19, 15, 28, 28, 528, DateTimeKind.Local).AddTicks(6264) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 528, DateTimeKind.Local).AddTicks(6277), new DateTime(2021, 12, 19, 15, 28, 28, 528, DateTimeKind.Local).AddTicks(6280) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 528, DateTimeKind.Local).AddTicks(6289), new DateTime(2021, 12, 19, 15, 28, 28, 528, DateTimeKind.Local).AddTicks(6292) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 497, DateTimeKind.Local).AddTicks(3385), new DateTime(2021, 12, 19, 15, 28, 28, 497, DateTimeKind.Local).AddTicks(3402), "MB122119152827912" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 497, DateTimeKind.Local).AddTicks(3480), new DateTime(2021, 12, 19, 15, 28, 28, 497, DateTimeKind.Local).AddTicks(3483), "BI122119152827916" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 28, 497, DateTimeKind.Local).AddTicks(3564), new DateTime(2021, 12, 19, 15, 28, 28, 497, DateTimeKind.Local).AddTicks(3567), "SP122119152827916" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(4120), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 910, DateTimeKind.Local).AddTicks(2903), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(1922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2398), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2403) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2406), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(2407) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5296), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5301) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5304), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5305) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5307), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5308) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5309), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5310) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5311), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5312) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5314), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5315) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5316), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(5317) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9954), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9960) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9963), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9964) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9965), new DateTime(2021, 12, 19, 15, 28, 27, 911, DateTimeKind.Local).AddTicks(9966) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 916, DateTimeKind.Local).AddTicks(4871), new DateTime(2021, 12, 19, 15, 28, 27, 916, DateTimeKind.Local).AddTicks(4879) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7008), new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7020) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7408), new DateTime(2021, 12, 19, 15, 28, 27, 919, DateTimeKind.Local).AddTicks(7411) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_Card_Feeback_CompanyId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_Card_Feeback_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                column: "TenderEntityTender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_Card_Feeback_TenderId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_Tender_Card_Feeback_UserId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderCard_TenderId",
                schema: "dbo",
                table: "mb_TenderCard",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_Tender_Status_tender_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "tender_status_id",
                principalSchema: "dbo",
                principalTable: "lk_Tender_Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_Tender_Status_tender_status_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropTable(
                name: "lk_Tender_Status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_Tender_Card_Feeback",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TenderCard",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "AdditionalRequest",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "EligibilityCriteria",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "RegistrationTill",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.RenameColumn(
                name: "QualityRequest",
                schema: "dbo",
                table: "mb_tender",
                newName: "duration_type");

            migrationBuilder.RenameColumn(
                name: "PerformanceRequest",
                schema: "dbo",
                table: "mb_tender",
                newName: "description");

            migrationBuilder.AddColumn<int>(
                name: "duration",
                schema: "dbo",
                table: "mb_tender",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "auction_status",
                schema: "dbo",
                table: "lk_auction_status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 405, DateTimeKind.Local).AddTicks(7845), new DateTime(2021, 12, 15, 11, 32, 27, 405, DateTimeKind.Local).AddTicks(7871) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 405, DateTimeKind.Local).AddTicks(7896), new DateTime(2021, 12, 15, 11, 32, 27, 405, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 405, DateTimeKind.Local).AddTicks(7914), new DateTime(2021, 12, 15, 11, 32, 27, 405, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(4785), new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(4794) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(4806), new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(4809) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(4819), new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(4823) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(1940), new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(1949), "MB122115113226188" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(2040), new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(2043), "BI122115113226192" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(2102), new DateTime(2021, 12, 15, 11, 32, 27, 406, DateTimeKind.Local).AddTicks(2106), "SP122115113226192" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(7912), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 186, DateTimeKind.Local).AddTicks(6928), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(5786) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6278), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6286), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(6287) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9293), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9302), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9303) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9305), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9306) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9307), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9308) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9310), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9312), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9313) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9315), new DateTime(2021, 12, 15, 11, 32, 26, 187, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3946), new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3951) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3955), new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3956) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3957), new DateTime(2021, 12, 15, 11, 32, 26, 188, DateTimeKind.Local).AddTicks(3958) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 192, DateTimeKind.Local).AddTicks(5394), new DateTime(2021, 12, 15, 11, 32, 26, 192, DateTimeKind.Local).AddTicks(5402) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(7947), new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(7960) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(8440), new DateTime(2021, 12, 15, 11, 32, 26, 195, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_auction_status_tender_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "tender_status_id",
                principalSchema: "dbo",
                principalTable: "lk_auction_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
