using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class tender_submissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lk_TenderSubmissionStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_TenderSubmissionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderSubmission",
                schema: "dbo",
                columns: table => new
                {
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentProvider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentReferenceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsFormSubmission = table.Column<bool>(type: "bit", nullable: false),
                    PriceScheduleDocName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceScheduleDocPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmission", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmission_lk_TenderSubmissionStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "lk_TenderSubmissionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmission_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmission_mb_user_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmission_mb_user_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderSubmissionEligibilityCriteria",
                schema: "dbo",
                columns: table => new
                {
                    EligibilityCriteriaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SN = table.Column<int>(type: "int", nullable: false),
                    CriteriaName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Remarks = table.Column<string>(type: "VARCHAR(1500)", maxLength: 1500, nullable: true),
                    TenderSubmissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmissionEligibilityCriteria", x => x.EligibilityCriteriaId);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmissionEligibilityCriteria_mb_TenderSubmission_TenderSubmissionId",
                        column: x => x.TenderSubmissionId,
                        principalSchema: "dbo",
                        principalTable: "mb_TenderSubmission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderSubmissionPriceSchedule",
                schema: "dbo",
                columns: table => new
                {
                    PriceScheduleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ScheduleValue = table.Column<string>(type: "VARCHAR(1500)", maxLength: 1500, nullable: false),
                    TenderSubmissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmissionPriceSchedule", x => x.PriceScheduleId);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmissionPriceSchedule_mb_TenderSubmission_TenderSubmissionId",
                        column: x => x.TenderSubmissionId,
                        principalSchema: "dbo",
                        principalTable: "mb_TenderSubmission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderSubmissionProductSpec",
                schema: "dbo",
                columns: table => new
                {
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    SpecificationValue = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: false),
                    TenderSubmissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmissionProductSpec", x => x.SpecificationId);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmissionProductSpec_mb_TenderSubmission_TenderSubmissionId",
                        column: x => x.TenderSubmissionId,
                        principalSchema: "dbo",
                        principalTable: "mb_TenderSubmission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderSubmissionPurchaseCriteria",
                schema: "dbo",
                columns: table => new
                {
                    PurchaseCriteriaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SN = table.Column<int>(type: "int", nullable: false),
                    CriteriaName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Remarks = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    TenderSubmissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmissionPurchaseCriteria", x => x.PurchaseCriteriaId);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmissionPurchaseCriteria_mb_TenderSubmission_TenderSubmissionId",
                        column: x => x.TenderSubmissionId,
                        principalSchema: "dbo",
                        principalTable: "mb_TenderSubmission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_TenderSubmisssionDocument",
                schema: "dbo",
                columns: table => new
                {
                    SubmissionDocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentName = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    DocumentPath = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TenderSubmisssionDocument", x => x.SubmissionDocumentId);
                    table.ForeignKey(
                        name: "FK_mb_TenderSubmisssionDocument_mb_TenderSubmission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalSchema: "dbo",
                        principalTable: "mb_TenderSubmission",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_TenderSubmissionStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending Payment" },
                    { 2, "Pending" },
                    { 3, "Processing" },
                    { 4, "Tender Created" },
                    { 5, "Cancelled" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 58, DateTimeKind.Local).AddTicks(8235), new DateTime(2021, 11, 25, 22, 29, 37, 58, DateTimeKind.Local).AddTicks(8267) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 58, DateTimeKind.Local).AddTicks(8301), new DateTime(2021, 11, 25, 22, 29, 37, 58, DateTimeKind.Local).AddTicks(8304) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 58, DateTimeKind.Local).AddTicks(8316), new DateTime(2021, 11, 25, 22, 29, 37, 58, DateTimeKind.Local).AddTicks(8319) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 109, DateTimeKind.Local).AddTicks(1771), new DateTime(2021, 11, 25, 22, 29, 37, 109, DateTimeKind.Local).AddTicks(1794) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 109, DateTimeKind.Local).AddTicks(1806), new DateTime(2021, 11, 25, 22, 29, 37, 109, DateTimeKind.Local).AddTicks(1809) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 109, DateTimeKind.Local).AddTicks(1817), new DateTime(2021, 11, 25, 22, 29, 37, 109, DateTimeKind.Local).AddTicks(1819) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 70, DateTimeKind.Local).AddTicks(1963), new DateTime(2021, 11, 25, 22, 29, 37, 70, DateTimeKind.Local).AddTicks(1986), "MB112125222936502" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 70, DateTimeKind.Local).AddTicks(2066), new DateTime(2021, 11, 25, 22, 29, 37, 70, DateTimeKind.Local).AddTicks(2070), "BI112125222936506" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 37, 70, DateTimeKind.Local).AddTicks(2118), new DateTime(2021, 11, 25, 22, 29, 37, 70, DateTimeKind.Local).AddTicks(2121), "SP112125222936506" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(502), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(631), new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8434) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8916), new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8921) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8924), new DateTime(2021, 11, 25, 22, 29, 36, 501, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1712), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1720), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1721) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1723), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1724) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1725), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1726) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1728), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1729) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1731), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1732) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1733), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(1734) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6361), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6367) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6369), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6372), new DateTime(2021, 11, 25, 22, 29, 36, 502, DateTimeKind.Local).AddTicks(6373) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 506, DateTimeKind.Local).AddTicks(9823), new DateTime(2021, 11, 25, 22, 29, 36, 506, DateTimeKind.Local).AddTicks(9831) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(978), new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(998) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(1335), new DateTime(2021, 11, 25, 22, 29, 36, 510, DateTimeKind.Local).AddTicks(1338) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmission_CompanyId",
                schema: "dbo",
                table: "mb_TenderSubmission",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmission_CreatedBy",
                schema: "dbo",
                table: "mb_TenderSubmission",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmission_StatusId",
                schema: "dbo",
                table: "mb_TenderSubmission",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmission_UpdatedBy",
                schema: "dbo",
                table: "mb_TenderSubmission",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmissionEligibilityCriteria_TenderSubmissionId",
                schema: "dbo",
                table: "mb_TenderSubmissionEligibilityCriteria",
                column: "TenderSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmissionPriceSchedule_TenderSubmissionId",
                schema: "dbo",
                table: "mb_TenderSubmissionPriceSchedule",
                column: "TenderSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmissionProductSpec_TenderSubmissionId",
                schema: "dbo",
                table: "mb_TenderSubmissionProductSpec",
                column: "TenderSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmissionPurchaseCriteria_TenderSubmissionId",
                schema: "dbo",
                table: "mb_TenderSubmissionPurchaseCriteria",
                column: "TenderSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TenderSubmisssionDocument_SubmissionId",
                schema: "dbo",
                table: "mb_TenderSubmisssionDocument",
                column: "SubmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_TenderSubmissionEligibilityCriteria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TenderSubmissionPriceSchedule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TenderSubmissionProductSpec",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TenderSubmissionPurchaseCriteria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TenderSubmisssionDocument",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TenderSubmission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_TenderSubmissionStatus",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 505, DateTimeKind.Local).AddTicks(8240), new DateTime(2021, 11, 16, 10, 26, 32, 505, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 505, DateTimeKind.Local).AddTicks(8313), new DateTime(2021, 11, 16, 10, 26, 32, 505, DateTimeKind.Local).AddTicks(8316) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 505, DateTimeKind.Local).AddTicks(8332), new DateTime(2021, 11, 16, 10, 26, 32, 505, DateTimeKind.Local).AddTicks(8335) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(5090), new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(5111), new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(5115) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(5125), new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(5129) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(2398), new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(2409), "MB112116102631252" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(2503), new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(2506), "BI112116102631270" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(2564), new DateTime(2021, 11, 16, 10, 26, 32, 506, DateTimeKind.Local).AddTicks(2567), "SP112116102631270" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(8509), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(8514) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 250, DateTimeKind.Local).AddTicks(8249), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6284) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6766), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6771) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6773), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(6774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9753), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9757) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9761), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9762) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9764), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9765) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9767), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9769), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9770) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9771), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9772) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9773), new DateTime(2021, 11, 16, 10, 26, 31, 251, DateTimeKind.Local).AddTicks(9774) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4704), new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4710) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4714), new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4715) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4716), new DateTime(2021, 11, 16, 10, 26, 31, 252, DateTimeKind.Local).AddTicks(4717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 270, DateTimeKind.Local).AddTicks(6464), new DateTime(2021, 11, 16, 10, 26, 31, 270, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9065), new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9481), new DateTime(2021, 11, 16, 10, 26, 31, 276, DateTimeKind.Local).AddTicks(9485) });
        }
    }
}
