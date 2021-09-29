using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class correspondence_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_correspondence_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserId = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailSentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 498, DateTimeKind.Local).AddTicks(2106), new DateTime(2021, 9, 29, 11, 21, 34, 498, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 498, DateTimeKind.Local).AddTicks(2157), new DateTime(2021, 9, 29, 11, 21, 34, 498, DateTimeKind.Local).AddTicks(2160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 498, DateTimeKind.Local).AddTicks(2173), new DateTime(2021, 9, 29, 11, 21, 34, 498, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 517, DateTimeKind.Local).AddTicks(9267), new DateTime(2021, 9, 29, 11, 21, 34, 517, DateTimeKind.Local).AddTicks(9293) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 517, DateTimeKind.Local).AddTicks(9305), new DateTime(2021, 9, 29, 11, 21, 34, 517, DateTimeKind.Local).AddTicks(9308) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 29, 11, 21, 34, 517, DateTimeKind.Local).AddTicks(9317), new DateTime(2021, 9, 29, 11, 21, 34, 517, DateTimeKind.Local).AddTicks(9320) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_correspondence_email",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(1025), new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(1052) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(1082), new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(1086) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(1101), new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(1105) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(3533), new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(3554), new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(3558) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(3568), new DateTime(2021, 9, 27, 15, 4, 37, 758, DateTimeKind.Local).AddTicks(3571) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 631, DateTimeKind.Local).AddTicks(2458), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(6) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1908), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1915) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1919), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1920) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1921), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1922) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1924), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1924) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1926), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1927) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1928), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1929) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1930), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(1931) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4808), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4813) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4815), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4816) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4818), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4819) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 633, DateTimeKind.Local).AddTicks(445), new DateTime(2021, 9, 27, 15, 4, 36, 633, DateTimeKind.Local).AddTicks(452) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7581), new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7598) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7924), new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7927) });
        }
    }
}
