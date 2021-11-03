using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class seed_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 962, DateTimeKind.Local).AddTicks(3455), new DateTime(2021, 11, 3, 12, 42, 11, 962, DateTimeKind.Local).AddTicks(3480) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 962, DateTimeKind.Local).AddTicks(3506), new DateTime(2021, 11, 3, 12, 42, 11, 962, DateTimeKind.Local).AddTicks(3570) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 962, DateTimeKind.Local).AddTicks(3588), new DateTime(2021, 11, 3, 12, 42, 11, 962, DateTimeKind.Local).AddTicks(3591) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 2, DateTimeKind.Local).AddTicks(9624), new DateTime(2021, 11, 3, 12, 42, 12, 2, DateTimeKind.Local).AddTicks(9649) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 2, DateTimeKind.Local).AddTicks(9662), new DateTime(2021, 11, 3, 12, 42, 12, 2, DateTimeKind.Local).AddTicks(9666) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 12, 2, DateTimeKind.Local).AddTicks(9675), new DateTime(2021, 11, 3, 12, 42, 12, 2, DateTimeKind.Local).AddTicks(9678) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "CompanyEmail", "CompanyStatusId", "date_created", "date_modified", "Name", "ReferenceCode", "RegisteredAs" },
                values: new object[] { "super.admin@test.com", 4, new DateTime(2021, 11, 3, 12, 42, 11, 972, DateTimeKind.Local).AddTicks(3230), new DateTime(2021, 11, 3, 12, 42, 11, 972, DateTimeKind.Local).AddTicks(3253), "Merobolee", "MB112103124211492", "SuperAdmin" });


            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_company",
                columns: new[] { "CompanyId", "Address1", "Address2", "Address3", "City", "CompanyEmail", "CompanyStatusId", "CompanyWebsite", "ContactPerson", "CountryId", "date_created", "date_modified", "MembershipTypeId", "Name", "Phone1", "Phone2", "ProvinceId", "ReferenceCode", "RegisteredAs", "Zip" },
                values: new object[,]
                {
                    { 3L, "Address1", "Address2", "Address3", "Kathmandu", "bid.bidder@test.com", 4, null, null, 1, new DateTime(2021, 11, 3, 12, 42, 11, 972, DateTimeKind.Local).AddTicks(3378), new DateTime(2021, 11, 3, 12, 42, 11, 972, DateTimeKind.Local).AddTicks(3382), 1, "Supplier Company", null, null, 3, "SP112103124211495", "Bidder", "123" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(5663), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(5668) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 490, DateTimeKind.Local).AddTicks(4001), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3911), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3916) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3918), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(3920) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7138), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7143) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7146), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7147) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7149), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7151), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7152) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7154), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7157), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7158) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7159), new DateTime(2021, 11, 3, 12, 42, 11, 491, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1828), new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1834) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1837), new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1838) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1840), new DateTime(2021, 11, 3, 12, 42, 11, 492, DateTimeKind.Local).AddTicks(1841) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "status_id" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 496, DateTimeKind.Local).AddTicks(2417), new DateTime(2021, 11, 3, 12, 42, 11, 496, DateTimeKind.Local).AddTicks(2426), 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "status_id" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(6990), new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(7013), 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "status_id" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(7464), new DateTime(2021, 11, 3, 12, 42, 11, 499, DateTimeKind.Local).AddTicks(7469), 1 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 876, DateTimeKind.Local).AddTicks(7058), new DateTime(2021, 11, 3, 11, 14, 33, 876, DateTimeKind.Local).AddTicks(7096) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 876, DateTimeKind.Local).AddTicks(7130), new DateTime(2021, 11, 3, 11, 14, 33, 876, DateTimeKind.Local).AddTicks(7134) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 876, DateTimeKind.Local).AddTicks(7151), new DateTime(2021, 11, 3, 11, 14, 33, 876, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(3055), new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(3065) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(3077), new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(3081) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(3091), new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(3095) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "CompanyEmail", "CompanyStatusId", "date_created", "date_modified", "Name", "ReferenceCode", "RegisteredAs" },
                values: new object[] { null, null, new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(1092), new DateTime(2021, 11, 3, 11, 14, 33, 877, DateTimeKind.Local).AddTicks(1107), "Test Company", "SP112103111432696", "Bidder,BidInviter" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(212), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 694, DateTimeKind.Local).AddTicks(9148), new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8139) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8603), new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8608) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8611), new DateTime(2021, 11, 3, 11, 14, 32, 695, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1367), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1371) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1375), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1376) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1377), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1378) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1381), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1382) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1385), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1386) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1388), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1390), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5981), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5986) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5989), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5990) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5991), new DateTime(2021, 11, 3, 11, 14, 32, 696, DateTimeKind.Local).AddTicks(5992) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "date_created", "date_modified", "status_id" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 700, DateTimeKind.Local).AddTicks(9737), new DateTime(2021, 11, 3, 11, 14, 32, 700, DateTimeKind.Local).AddTicks(9756), 2 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "date_created", "date_modified", "status_id" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(4641), new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(4669), 2 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "date_created", "date_modified", "status_id" },
                values: new object[] { new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(5313), new DateTime(2021, 11, 3, 11, 14, 32, 704, DateTimeKind.Local).AddTicks(5314), 2 });

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
        }
    }
}
