using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class Clarification_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_clarification_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserId = table.Column<int>(type: "int", nullable: false),
                    CorrespondenceId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 154, DateTimeKind.Local).AddTicks(1779), new DateTime(2021, 9, 29, 13, 7, 57, 154, DateTimeKind.Local).AddTicks(1804) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 154, DateTimeKind.Local).AddTicks(1832), new DateTime(2021, 9, 29, 13, 7, 57, 154, DateTimeKind.Local).AddTicks(1835) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 154, DateTimeKind.Local).AddTicks(1855), new DateTime(2021, 9, 29, 13, 7, 57, 154, DateTimeKind.Local).AddTicks(1858) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 173, DateTimeKind.Local).AddTicks(1274), new DateTime(2021, 9, 29, 13, 7, 57, 173, DateTimeKind.Local).AddTicks(1297) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 173, DateTimeKind.Local).AddTicks(1311), new DateTime(2021, 9, 29, 13, 7, 57, 173, DateTimeKind.Local).AddTicks(1314) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 173, DateTimeKind.Local).AddTicks(1323), new DateTime(2021, 9, 29, 13, 7, 57, 173, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 720, DateTimeKind.Local).AddTicks(1342), new DateTime(2021, 9, 29, 13, 7, 56, 720, DateTimeKind.Local).AddTicks(9169) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(679), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(685) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(688), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(690) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(691), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(693), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(694) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(695), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(697) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(698), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(699) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(700), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(701) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(2628), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(2633) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(2636), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(2637) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(2638), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(2639) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(6657), new DateTime(2021, 9, 29, 13, 7, 56, 721, DateTimeKind.Local).AddTicks(6665) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 725, DateTimeKind.Local).AddTicks(2218), new DateTime(2021, 9, 29, 13, 7, 56, 725, DateTimeKind.Local).AddTicks(2266) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 56, 725, DateTimeKind.Local).AddTicks(2838), new DateTime(2021, 9, 29, 13, 7, 56, 725, DateTimeKind.Local).AddTicks(2841) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_clarification_email",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(1438), new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(1466) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(1496), new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(1500) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(1514), new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(1518) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(4193), new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(4206) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(4217), new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(4220) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(4229), new DateTime(2021, 9, 29, 11, 21, 34, 965, DateTimeKind.Local).AddTicks(4233) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 56, DateTimeKind.Local).AddTicks(3499), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(1797) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3191), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3199) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3202), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3204), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3205) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3206), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3207) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3208), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3209) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3211), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3212) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3214), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(3214) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(5345), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(5350) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(5352), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(5354) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(5396), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(5397) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(9340), new DateTime(2021, 9, 29, 11, 21, 34, 57, DateTimeKind.Local).AddTicks(9349) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 61, DateTimeKind.Local).AddTicks(872), new DateTime(2021, 9, 29, 11, 21, 34, 61, DateTimeKind.Local).AddTicks(890) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 61, DateTimeKind.Local).AddTicks(1245), new DateTime(2021, 9, 29, 11, 21, 34, 61, DateTimeKind.Local).AddTicks(1247) });
        }
    }
}
