using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class call_action_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_callaction_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    SenderUserId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_callaction_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_callaction_email_mb_user_SenderUserId",
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
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 378, DateTimeKind.Local).AddTicks(7535), new DateTime(2021, 9, 30, 11, 12, 36, 378, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 378, DateTimeKind.Local).AddTicks(7622), new DateTime(2021, 9, 30, 11, 12, 36, 378, DateTimeKind.Local).AddTicks(7626) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 378, DateTimeKind.Local).AddTicks(7640), new DateTime(2021, 9, 30, 11, 12, 36, 378, DateTimeKind.Local).AddTicks(7644) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 400, DateTimeKind.Local).AddTicks(6182), new DateTime(2021, 9, 30, 11, 12, 36, 400, DateTimeKind.Local).AddTicks(6209) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 400, DateTimeKind.Local).AddTicks(6221), new DateTime(2021, 9, 30, 11, 12, 36, 400, DateTimeKind.Local).AddTicks(6224) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 36, 400, DateTimeKind.Local).AddTicks(6233), new DateTime(2021, 9, 30, 11, 12, 36, 400, DateTimeKind.Local).AddTicks(6236) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 877, DateTimeKind.Local).AddTicks(1340), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(1669) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3267), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3274) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3277), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3278) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3280), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3281) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3282), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3283) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3285), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3286) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3287), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3289), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(3290) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5459), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5464) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5469), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5471), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(5472) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(9516), new DateTime(2021, 9, 30, 11, 12, 35, 878, DateTimeKind.Local).AddTicks(9523) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2552), new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2573) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2961), new DateTime(2021, 9, 30, 11, 12, 35, 882, DateTimeKind.Local).AddTicks(2963) });

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_SenderUserId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "SenderUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_callaction_email",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(5376), new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(5404) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(5432), new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(5436) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(5451), new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(5454) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(8646), new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(8657) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(8669), new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(8672) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(8682), new DateTime(2021, 9, 29, 13, 7, 57, 610, DateTimeKind.Local).AddTicks(8686) });

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
        }
    }
}
