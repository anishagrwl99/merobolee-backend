using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class technicalsupport_receiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_mail_attachment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_mail_data",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_vdc",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_vdc",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_user_email",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_user_email",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_user",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_user",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_TenderSubmission",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_TenderSubmission",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_tender_winner",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_tender_winner",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_tender",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_tender",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_role",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_role",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_province",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_province",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_municipality",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_municipality",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_membership",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_membership",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_email",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_email",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_district",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_district",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_country",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_country",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company_type",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_company_type",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_company",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_company",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_city",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_city",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "lk_company_type",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "lk_company_type",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "date_modified",
                schema: "dbo",
                table: "lk_category",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "date_created",
                schema: "dbo",
                table: "lk_category",
                newName: "Date_Created");

            migrationBuilder.CreateTable(
                name: "mb_TechnicalSupport_Receiver",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TechnicalSupportId = table.Column<long>(type: "bigint", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_TechnicalSupport_Receiver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_TechnicalSupport_Receiver_mb_TechnicalSupport_TechnicalSupportId",
                        column: x => x.TechnicalSupportId,
                        principalSchema: "dbo",
                        principalTable: "mb_TechnicalSupport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_TechnicalSupport_Receiver_mb_user_UserId",
                        column: x => x.UserId,
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
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 541, DateTimeKind.Local).AddTicks(7115), new DateTime(2022, 1, 13, 11, 3, 6, 541, DateTimeKind.Local).AddTicks(7273) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 541, DateTimeKind.Local).AddTicks(7382), new DateTime(2022, 1, 13, 11, 3, 6, 541, DateTimeKind.Local).AddTicks(7386) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 541, DateTimeKind.Local).AddTicks(7400), new DateTime(2022, 1, 13, 11, 3, 6, 541, DateTimeKind.Local).AddTicks(7403) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 603, DateTimeKind.Local).AddTicks(5298), new DateTime(2022, 1, 13, 11, 3, 6, 603, DateTimeKind.Local).AddTicks(5320) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 603, DateTimeKind.Local).AddTicks(5332), new DateTime(2022, 1, 13, 11, 3, 6, 603, DateTimeKind.Local).AddTicks(5335) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 603, DateTimeKind.Local).AddTicks(5344), new DateTime(2022, 1, 13, 11, 3, 6, 603, DateTimeKind.Local).AddTicks(5347) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 560, DateTimeKind.Local).AddTicks(7517), new DateTime(2022, 1, 13, 11, 3, 6, 560, DateTimeKind.Local).AddTicks(7542), "MB220113001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 560, DateTimeKind.Local).AddTicks(7625), new DateTime(2022, 1, 13, 11, 3, 6, 560, DateTimeKind.Local).AddTicks(7629), "BI220113002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 6, 560, DateTimeKind.Local).AddTicks(7754), new DateTime(2022, 1, 13, 11, 3, 6, 560, DateTimeKind.Local).AddTicks(7757), "SP220113003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(8251), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(8257) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 896, DateTimeKind.Local).AddTicks(7647), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6162) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6641), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6646) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6648), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(6649) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9435), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9444), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9445) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9447), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9448) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9450), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9453), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9454) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9455), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9456) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9457), new DateTime(2022, 1, 13, 11, 3, 5, 897, DateTimeKind.Local).AddTicks(9458) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4142), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4148) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4151), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4153), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4154) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4156), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4157) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4158), new DateTime(2022, 1, 13, 11, 3, 5, 898, DateTimeKind.Local).AddTicks(4159) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 902, DateTimeKind.Local).AddTicks(4242), new DateTime(2022, 1, 13, 11, 3, 5, 902, DateTimeKind.Local).AddTicks(4249) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(5959), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(5972) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6296), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6342), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6343) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6367), new DateTime(2022, 1, 13, 11, 3, 5, 905, DateTimeKind.Local).AddTicks(6368) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_TechnicalSupport_Receiver_TechnicalSupportId",
                schema: "dbo",
                table: "mb_TechnicalSupport_Receiver",
                column: "TechnicalSupportId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_TechnicalSupport_Receiver_UserId",
                schema: "dbo",
                table: "mb_TechnicalSupport_Receiver",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_TechnicalSupport_Receiver",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_vdc",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_vdc",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_user_email",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_user_email",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_user",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_user",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_TenderSubmission",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_TenderSubmission",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_tender_winner",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_tender_winner",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_tender",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_tender",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_role",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_role",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_province",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_province",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_municipality",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_municipality",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_membership",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_membership",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_email",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_email",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_district",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_district",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_country",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_country",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_company_type",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_company_type",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_company",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_company",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_city",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_city",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "mb_bidder_request",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "lk_company_type",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "lk_company_type",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "dbo",
                table: "lk_category",
                newName: "date_modified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "dbo",
                table: "lk_category",
                newName: "date_created");

            migrationBuilder.CreateTable(
                name: "mb_mail_data",
                schema: "dbo",
                columns: table => new
                {
                    mail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    date_modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    from_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_mail_data", x => x.mail_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_mail_attachment",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailEntityMail_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_mail_attachment", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_mail_attachment_mb_mail_data_MailEntityMail_id",
                        column: x => x.MailEntityMail_id,
                        principalSchema: "dbo",
                        principalTable: "mb_mail_data",
                        principalColumn: "mail_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(1412), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(1450) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(1479), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(1483) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(1498), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(1501) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(7575), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(7595), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(7599) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(7609), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(7613) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(5228), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(5237), "MB220112001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(5327), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(5331), "BI220112002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(5390), new DateTime(2022, 1, 12, 10, 25, 1, 102, DateTimeKind.Local).AddTicks(5393), "SP220112003" });

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
                name: "IX_mb_mail_attachment_MailEntityMail_id",
                schema: "dbo",
                table: "mb_mail_attachment",
                column: "MailEntityMail_id");
        }
    }
}
