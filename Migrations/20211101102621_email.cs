using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_callaction_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_clarification_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_correspondence_email",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition");

            migrationBuilder.CreateTable(
                name: "mb_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "VARCHAR", nullable: false),
                    Body = table.Column<string>(type: "VARCHAR", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_email_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_email_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_email_mb_user_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_user_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EmailId = table.Column<long>(type: "bigint", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_user_email_mb_email_EmailId",
                        column: x => x.EmailId,
                        principalSchema: "dbo",
                        principalTable: "mb_email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_user_email_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 112, DateTimeKind.Local).AddTicks(573), new DateTime(2021, 11, 1, 16, 11, 21, 112, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 112, DateTimeKind.Local).AddTicks(626), new DateTime(2021, 11, 1, 16, 11, 21, 112, DateTimeKind.Local).AddTicks(629) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 112, DateTimeKind.Local).AddTicks(642), new DateTime(2021, 11, 1, 16, 11, 21, 112, DateTimeKind.Local).AddTicks(645) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 155, DateTimeKind.Local).AddTicks(5322), new DateTime(2021, 11, 1, 16, 11, 21, 155, DateTimeKind.Local).AddTicks(5352) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 155, DateTimeKind.Local).AddTicks(5539), new DateTime(2021, 11, 1, 16, 11, 21, 155, DateTimeKind.Local).AddTicks(5545) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 155, DateTimeKind.Local).AddTicks(5562), new DateTime(2021, 11, 1, 16, 11, 21, 155, DateTimeKind.Local).AddTicks(5568) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 21, 125, DateTimeKind.Local).AddTicks(8158), new DateTime(2021, 11, 1, 16, 11, 21, 125, DateTimeKind.Local).AddTicks(8182), "SP112101161120377" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(8334), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(8339) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 373, DateTimeKind.Local).AddTicks(7307), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5448), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5454) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5456), new DateTime(2021, 11, 1, 16, 11, 20, 375, DateTimeKind.Local).AddTicks(5457) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(375), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(383), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(385) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(386), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(387) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(389), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(390) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(391), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(392) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(394), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(395) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(397), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(398) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8209), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8215) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8218), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8219) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8220), new DateTime(2021, 11, 1, 16, 11, 20, 376, DateTimeKind.Local).AddTicks(8221) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "password" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 381, DateTimeKind.Local).AddTicks(9677), new DateTime(2021, 11, 1, 16, 11, 20, 381, DateTimeKind.Local).AddTicks(9696), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "password" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(8509), new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(8533), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "password" },
                values: new object[] { new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(9124), new DateTime(2021, 11, 1, 16, 11, 20, 387, DateTimeKind.Local).AddTicks(9127), "ZDztlPNVNo1CxEclyEDngQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                column: "tender_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_email_AuthorId",
                schema: "dbo",
                table: "mb_email",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_email_CompanyId",
                schema: "dbo",
                table: "mb_email",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_email_TenderId",
                schema: "dbo",
                table: "mb_email",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_email_EmailId",
                schema: "dbo",
                table: "mb_user_email",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_email_UserId",
                schema: "dbo",
                table: "mb_user_email",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_user_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_email",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition");

            migrationBuilder.CreateTable(
                name: "mb_callaction_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailSentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_callaction_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_callaction_email_mb_callaction_email_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "mb_callaction_email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_callaction_email_mb_user_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_callaction_email_mb_user_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_correspondence_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailSentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUserId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_correspondence_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_correspondence_email_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_correspondence_email_mb_user_SenderUserId",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_clarification_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrespondenceId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailSentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderUserId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_clarification_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_clarification_email_mb_correspondence_email_CorrespondenceId",
                        column: x => x.CorrespondenceId,
                        principalSchema: "dbo",
                        principalTable: "mb_correspondence_email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_clarification_email_mb_user_SenderUserId",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 214, DateTimeKind.Local).AddTicks(5446), new DateTime(2021, 10, 22, 11, 18, 37, 214, DateTimeKind.Local).AddTicks(5478) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 214, DateTimeKind.Local).AddTicks(5503), new DateTime(2021, 10, 22, 11, 18, 37, 214, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 214, DateTimeKind.Local).AddTicks(5520), new DateTime(2021, 10, 22, 11, 18, 37, 214, DateTimeKind.Local).AddTicks(5523) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(1498), new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(1507) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(1518), new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(1522) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(1531), new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(1534) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(140), new DateTime(2021, 10, 22, 11, 18, 37, 215, DateTimeKind.Local).AddTicks(155), "SP102122111835979" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(4736), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(4741) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 974, DateTimeKind.Local).AddTicks(107), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1245) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1923), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1928) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1930), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(1931) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6621), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6626) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6630), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6631) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6633), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6633) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6635), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6636) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6637), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6638) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6640), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6642), new DateTime(2021, 10, 22, 11, 18, 35, 977, DateTimeKind.Local).AddTicks(6643) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4513), new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4519) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4522), new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4523) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4524), new DateTime(2021, 10, 22, 11, 18, 35, 978, DateTimeKind.Local).AddTicks(4525) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "password" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 0, DateTimeKind.Local).AddTicks(5761), new DateTime(2021, 10, 22, 11, 18, 36, 0, DateTimeKind.Local).AddTicks(5782), "YHCTM7byxNlmg1x9CGp5nA==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "password" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3052), new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3075), "YHCTM7byxNlmg1x9CGp5nA==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "password" },
                values: new object[] { new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3460), new DateTime(2021, 10, 22, 11, 18, 36, 21, DateTimeKind.Local).AddTicks(3463), "YHCTM7byxNlmg1x9CGp5nA==" });

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_FromUserId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_ParentId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_ToUserId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_clarification_email_CorrespondenceId",
                schema: "dbo",
                table: "mb_clarification_email",
                column: "CorrespondenceId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_clarification_email_SenderUserId",
                schema: "dbo",
                table: "mb_clarification_email",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_correspondence_email_SenderUserId",
                schema: "dbo",
                table: "mb_correspondence_email",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_correspondence_email_TenderId",
                schema: "dbo",
                table: "mb_correspondence_email",
                column: "TenderId");
        }
    }
}
