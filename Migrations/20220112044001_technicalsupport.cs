using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class technicalsupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_request_help",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_request_help_status",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "lk_TechnicalSupportStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_TechnicalSupportStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mb_TechnicalSupport",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TechnicalSupport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_TechnicalSupport_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_TechnicalSupportStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Requested" },
                    { 2, "Approved" },
                    { 3, "Running" },
                    { 4, "Resolved" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 519, DateTimeKind.Local).AddTicks(5571), new DateTime(2022, 1, 12, 10, 25, 0, 519, DateTimeKind.Local).AddTicks(5595) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 519, DateTimeKind.Local).AddTicks(5685), new DateTime(2022, 1, 12, 10, 25, 0, 519, DateTimeKind.Local).AddTicks(5688) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 519, DateTimeKind.Local).AddTicks(5702), new DateTime(2022, 1, 12, 10, 25, 0, 519, DateTimeKind.Local).AddTicks(5705) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 568, DateTimeKind.Local).AddTicks(9000), new DateTime(2022, 1, 12, 10, 25, 0, 568, DateTimeKind.Local).AddTicks(9023) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 568, DateTimeKind.Local).AddTicks(9035), new DateTime(2022, 1, 12, 10, 25, 0, 568, DateTimeKind.Local).AddTicks(9038) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 568, DateTimeKind.Local).AddTicks(9047), new DateTime(2022, 1, 12, 10, 25, 0, 568, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 537, DateTimeKind.Local).AddTicks(2249), new DateTime(2022, 1, 12, 10, 25, 0, 537, DateTimeKind.Local).AddTicks(2273), "MB220112001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 537, DateTimeKind.Local).AddTicks(2352), new DateTime(2022, 1, 12, 10, 25, 0, 537, DateTimeKind.Local).AddTicks(2356), "BI220112002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 0, 537, DateTimeKind.Local).AddTicks(2411), new DateTime(2022, 1, 12, 10, 25, 0, 537, DateTimeKind.Local).AddTicks(2414), "SP220112003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(2701), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(2706) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 963, DateTimeKind.Local).AddTicks(2043), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(653) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(1129), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(1134) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(1136), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(1137) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3897), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3902) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3906), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3907) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3909), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3911), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3912) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3913), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3914) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3915), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3916) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3917), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(3919) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8549), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8556), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8558) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8560), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8561) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8562), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8563) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8564), new DateTime(2022, 1, 12, 10, 24, 59, 964, DateTimeKind.Local).AddTicks(8565) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 969, DateTimeKind.Local).AddTicks(33), new DateTime(2022, 1, 12, 10, 24, 59, 969, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1237), new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1248) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1574), new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1576) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1615), new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1638), new DateTime(2022, 1, 12, 10, 24, 59, 972, DateTimeKind.Local).AddTicks(1640) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_TechnicalSupport_UserId",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lk_TechnicalSupportStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_TechnicalSupport",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "lk_request_help_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_request_help_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_request_help",
                schema: "dbo",
                columns: table => new
                {
                    request_help_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resolve_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    help_status_id = table.Column<int>(type: "int", nullable: false),
                    problem_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_request_help", x => x.request_help_id);
                    table.ForeignKey(
                        name: "FK_mb_request_help_lk_request_help_status_help_status_id",
                        column: x => x.help_status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_request_help_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_request_help_mb_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(234), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(266) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(293), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(296) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(311), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(315) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(6842), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(6851) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(6862), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(6866) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(6876), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(6879) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_request_help_status",
                columns: new[] { "status_id", "request_status" },
                values: new object[,]
                {
                    { 1, "Requested" },
                    { 2, "Approved" },
                    { 3, "Running" },
                    { 4, "Resolved" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(4106), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(4115), "MB211230001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(4209), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(4213), "BI211230002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(4509), new DateTime(2021, 12, 30, 9, 11, 59, 950, DateTimeKind.Local).AddTicks(4513), "SP211230003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(9314), new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(9320) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 939, DateTimeKind.Local).AddTicks(9165), new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(7774), new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(7779) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(7781), new DateTime(2021, 12, 30, 9, 11, 58, 940, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(451), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(455) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(459), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(462), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(463) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(464), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(465) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(466), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(467) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(468), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(469) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(471), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4788), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4793) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4796), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4796) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4798), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4799) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4801) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4802), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4803) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 945, DateTimeKind.Local).AddTicks(2005), new DateTime(2021, 12, 30, 9, 11, 58, 945, DateTimeKind.Local).AddTicks(2012) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2121), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2443), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2446) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2562), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2564) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2588), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2589) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_help_status_id",
                schema: "dbo",
                table: "mb_request_help",
                column: "help_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_user_id",
                schema: "dbo",
                table: "mb_request_help",
                column: "user_id");
        }
    }
}
