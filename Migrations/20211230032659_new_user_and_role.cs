using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class new_user_and_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 429, DateTimeKind.Local).AddTicks(1875), new DateTime(2021, 12, 30, 9, 11, 59, 429, DateTimeKind.Local).AddTicks(1905) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 429, DateTimeKind.Local).AddTicks(1936), new DateTime(2021, 12, 30, 9, 11, 59, 429, DateTimeKind.Local).AddTicks(1939) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 429, DateTimeKind.Local).AddTicks(1952), new DateTime(2021, 12, 30, 9, 11, 59, 429, DateTimeKind.Local).AddTicks(1955) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 475, DateTimeKind.Local).AddTicks(7409), new DateTime(2021, 12, 30, 9, 11, 59, 475, DateTimeKind.Local).AddTicks(7434) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 475, DateTimeKind.Local).AddTicks(7445), new DateTime(2021, 12, 30, 9, 11, 59, 475, DateTimeKind.Local).AddTicks(7448) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 475, DateTimeKind.Local).AddTicks(7457), new DateTime(2021, 12, 30, 9, 11, 59, 475, DateTimeKind.Local).AddTicks(7460) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 445, DateTimeKind.Local).AddTicks(5262), new DateTime(2021, 12, 30, 9, 11, 59, 445, DateTimeKind.Local).AddTicks(5287), "MB211230001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 445, DateTimeKind.Local).AddTicks(5373), new DateTime(2021, 12, 30, 9, 11, 59, 445, DateTimeKind.Local).AddTicks(5377), "BI211230002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 59, 445, DateTimeKind.Local).AddTicks(5431), new DateTime(2021, 12, 30, 9, 11, 59, 445, DateTimeKind.Local).AddTicks(5435), "SP211230003" });

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
                columns: new[] { "date_created", "date_modified", "role" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4796), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4796), "Tender Support" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified", "role" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4798), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4799), "Customer Support" });
            
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_role",
                columns: new[] { "role_id", "date_created", "date_modified", "role" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4801), "Bid Inviter" },
                    { 5, new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4802), new DateTime(2021, 12, 30, 9, 11, 58, 941, DateTimeKind.Local).AddTicks(4803), "Bidder" }
                });
            
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
                columns: new[] { "date_created", "date_modified", "first_name", "last_name", "email" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2121), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2134), "Tender", "Support", "tender.suport@test.com" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "first_name", "last_name", "email" },
                values: new object[] { new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2443), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2446), "Customer", "Support", "customer.support@test.com" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user_company",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompanyId",
                value: 1L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user_company",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CompanyId",
                value: 1L);

            
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "date_created", "date_modified", "designation", "expired_date", "first_name", "IsEmailReceiver", "last_name", "middle_name", "password", "email", "ProfilePicture", "role_id", "status_id", "username" },
                values: new object[] { 4L, null, new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2562), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2564), null, null, "Bid", true, "Inviter", null, "ZDztlPNVNo1CxEclyEDngQ==", "bid.inviter@test.com", null, 4, 1, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "date_created", "date_modified", "designation", "expired_date", "first_name", "IsEmailReceiver", "last_name", "middle_name", "password", "email", "ProfilePicture", "role_id", "status_id", "username" },
                values: new object[] { 5L, null, new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2588), new DateTime(2021, 12, 30, 9, 11, 58, 948, DateTimeKind.Local).AddTicks(2589), null, null, "Bid", true, "Bidder", null, "ZDztlPNVNo1CxEclyEDngQ==", "bid.bidder@test.com", null, 5, 1, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user_company",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[] { 4L, 2L, 4L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user_company",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[] { 5L, 3L, 5L });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user_company",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user_company",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(3360), new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(3403) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(3437), new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(3441) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(3457), new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(3461) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 157, DateTimeKind.Local).AddTicks(181), new DateTime(2021, 12, 29, 9, 55, 48, 157, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 157, DateTimeKind.Local).AddTicks(204), new DateTime(2021, 12, 29, 9, 55, 48, 157, DateTimeKind.Local).AddTicks(208) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 157, DateTimeKind.Local).AddTicks(218), new DateTime(2021, 12, 29, 9, 55, 48, 157, DateTimeKind.Local).AddTicks(222) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(7605), new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(7616), "MB211229001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(7711), new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(7715), "BI211229002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "ReferenceCode" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(7783), new DateTime(2021, 12, 29, 9, 55, 48, 156, DateTimeKind.Local).AddTicks(7787), "SP211229003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(4186), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(4191) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 964, DateTimeKind.Local).AddTicks(3503), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2053) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2529), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2533) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2535), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(2536) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5412), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5417) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5420), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5422), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5424), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5425) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5427), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5429), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5430) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5431), new DateTime(2021, 12, 29, 9, 55, 46, 965, DateTimeKind.Local).AddTicks(5432) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(65), new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(70) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified", "role" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(73), new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(74), "Bid Inviter" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified", "role" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(75), new DateTime(2021, 12, 29, 9, 55, 46, 966, DateTimeKind.Local).AddTicks(77), "Bidder" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 970, DateTimeKind.Local).AddTicks(8209), new DateTime(2021, 12, 29, 9, 55, 46, 970, DateTimeKind.Local).AddTicks(8222) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "first_name", "last_name", "email" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 974, DateTimeKind.Local).AddTicks(9455), new DateTime(2021, 12, 29, 9, 55, 46, 974, DateTimeKind.Local).AddTicks(9485), "Bid", "Inviter", "bid.inviter@test.com" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "first_name", "last_name", "email" },
                values: new object[] { new DateTime(2021, 12, 29, 9, 55, 46, 975, DateTimeKind.Local).AddTicks(108), new DateTime(2021, 12, 29, 9, 55, 46, 975, DateTimeKind.Local).AddTicks(112), "Bid", "Bidder", "bid.bidder@test.com" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user_company",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompanyId",
                value: 2L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user_company",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CompanyId",
                value: 3L);
        }
    }
}
