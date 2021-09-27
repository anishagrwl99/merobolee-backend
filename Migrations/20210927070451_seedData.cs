using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_admin_status",
                columns: new[] { "status_id", "admin_status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" },
                    { 3, "Approved" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_auction_status",
                columns: new[] { "status_id", "auction_status" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Running" },
                    { 3, "Closed" },
                    { 4, "Upcoming" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_common_status",
                columns: new[] { "status_id", "status" },
                values: new object[,]
                {
                    { 2, "Inactive" },
                    { 1, "Active" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_company_type",
                columns: new[] { "company_type_id", "company_type", "date_created", "date_modified" },
                values: new object[,]
                {
                    { 1, "Transportation", new DateTime(2021, 9, 27, 12, 49, 51, 62, DateTimeKind.Local).AddTicks(1591), new DateTime(2021, 9, 27, 12, 49, 51, 62, DateTimeKind.Local).AddTicks(1614) },
                    { 2, "Construction", new DateTime(2021, 9, 27, 12, 49, 51, 62, DateTimeKind.Local).AddTicks(1626), new DateTime(2021, 9, 27, 12, 49, 51, 62, DateTimeKind.Local).AddTicks(1629) },
                    { 3, "Tourism", new DateTime(2021, 9, 27, 12, 49, 51, 62, DateTimeKind.Local).AddTicks(1637), new DateTime(2021, 9, 27, 12, 49, 51, 62, DateTimeKind.Local).AddTicks(1640) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_country",
                columns: new[] { "country_id", "abbre", "country_code", "country_name", "date_created", "date_modified" },
                values: new object[] { 1, "NP", "NEP", "Nepal", new DateTime(2021, 9, 27, 12, 49, 50, 565, DateTimeKind.Local).AddTicks(7913), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(5889) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_payment_status",
                columns: new[] { "id", "payment_status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Paid" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_request_help_status",
                columns: new[] { "status_id", "request_status" },
                values: new object[,]
                {
                    { 1, "Requested" },
                    { 2, "Approved" },
                    { 3, "Running" },
                    { 4, "Resolved" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user_status",
                columns: new[] { "status_id", "user_status" },
                values: new object[,]
                {
                    { 3, "Suspended" },
                    { 1, "Registered" },
                    { 2, "Approved" },
                    { 4, "Terminated" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_category",
                columns: new[] { "category_id", "category", "date_created", "date_modified", "status_id" },
                values: new object[,]
                {
                    { 1, "Transportation", new DateTime(2021, 9, 27, 12, 49, 51, 50, DateTimeKind.Local).AddTicks(9962), new DateTime(2021, 9, 27, 12, 49, 51, 50, DateTimeKind.Local).AddTicks(9991), 1 },
                    { 2, "Construction", new DateTime(2021, 9, 27, 12, 49, 51, 51, DateTimeKind.Local).AddTicks(22), new DateTime(2021, 9, 27, 12, 49, 51, 51, DateTimeKind.Local).AddTicks(25), 1 },
                    { 3, "Tourism", new DateTime(2021, 9, 27, 12, 49, 51, 51, DateTimeKind.Local).AddTicks(38), new DateTime(2021, 9, 27, 12, 49, 51, 51, DateTimeKind.Local).AddTicks(41), 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_province",
                columns: new[] { "province_id", "country_id", "date_created", "date_modified", "province_title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7806), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7813), "Province No. 1" },
                    { 2, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7816), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7817), "Province No. 2" },
                    { 3, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7819), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7820), "Bagmati Province" },
                    { 4, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7821), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7822), "Gandaki Province" },
                    { 5, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7823), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7824), "Lumbini Province" },
                    { 6, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7825), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7826), "Karnali Province" },
                    { 7, 1, new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7828), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7829), "Sudurpashchim Province" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_admin_status",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_admin_status",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_admin_status",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_auction_status",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_auction_status",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_auction_status",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_auction_status",
                keyColumn: "status_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_common_status",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_payment_status",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_payment_status",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_request_help_status",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_request_help_status",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_request_help_status",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_request_help_status",
                keyColumn: "status_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user_status",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user_status",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user_status",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user_status",
                keyColumn: "status_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_common_status",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1);
        }
    }
}
