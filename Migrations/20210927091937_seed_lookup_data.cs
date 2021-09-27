using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class seed_lookup_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 337, DateTimeKind.Local).AddTicks(324), new DateTime(2021, 9, 27, 15, 4, 37, 337, DateTimeKind.Local).AddTicks(349) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 337, DateTimeKind.Local).AddTicks(379), new DateTime(2021, 9, 27, 15, 4, 37, 337, DateTimeKind.Local).AddTicks(383) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 337, DateTimeKind.Local).AddTicks(396), new DateTime(2021, 9, 27, 15, 4, 37, 337, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_company",
                columns: new[] { "CompanyId", "Address1", "Address2", "Address3", "City", "CountryId", "Name", "ProvienceId", "Zip" },
                values: new object[] { 1, "Address1", "Address2", "Address3", "Kathmandu", 1, "Test Company", 3, "123" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 356, DateTimeKind.Local).AddTicks(3314), new DateTime(2021, 9, 27, 15, 4, 37, 356, DateTimeKind.Local).AddTicks(3342) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 356, DateTimeKind.Local).AddTicks(3355), new DateTime(2021, 9, 27, 15, 4, 37, 356, DateTimeKind.Local).AddTicks(3358) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 15, 4, 37, 356, DateTimeKind.Local).AddTicks(3367), new DateTime(2021, 9, 27, 15, 4, 37, 356, DateTimeKind.Local).AddTicks(3370) });

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_role",
                columns: new[] { "role_id", "date_created", "date_modified", "role" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4815), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4816), "Bid Inviter" },
                    { 1, new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4808), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4813), "Super Admin" },
                    { 3, new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4818), new DateTime(2021, 9, 27, 15, 4, 36, 632, DateTimeKind.Local).AddTicks(4819), "Bidder" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "address1", "address2", "address3", "back_citizenship", "bank_credit_letter", "category_id", "city_id", "CompanyId", "company_contact1", "company_contact2", "company_name", "company_registration", "company_type_Id", "acronym", "comapny_email", "country_id", "date_created", "date_modified", "description", "designation", "district_id", "no_of_employee", "expired_date", "fax_no", "first_name", "front_citizenship", "last_name", "membership_Id", "middle_name", "municipality_id", "pan_vat_registration", "password", "person_contact1", "person_contact2", "person_email", "province_id", "register_country_id", "registration_no", "role_id", "salutation", "status_id", "tax_clearance", "username", "vat_pan_no", "vdc_id", "website" },
                values: new object[] { 1, null, null, null, null, null, null, null, null, 1, null, null, null, null, null, null, null, null, new DateTime(2021, 9, 27, 15, 4, 36, 633, DateTimeKind.Local).AddTicks(445), new DateTime(2021, 9, 27, 15, 4, 36, 633, DateTimeKind.Local).AddTicks(452), null, null, null, 0, null, null, "Super", null, "Admin", null, null, null, null, "YHCTM7byxNlmg1x9CGp5nA==", null, null, "super.admin@test.com", null, 0, null, 1, null, 2, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "address1", "address2", "address3", "back_citizenship", "bank_credit_letter", "category_id", "city_id", "CompanyId", "company_contact1", "company_contact2", "company_name", "company_registration", "company_type_Id", "acronym", "comapny_email", "country_id", "date_created", "date_modified", "description", "designation", "district_id", "no_of_employee", "expired_date", "fax_no", "first_name", "front_citizenship", "last_name", "membership_Id", "middle_name", "municipality_id", "pan_vat_registration", "password", "person_contact1", "person_contact2", "person_email", "province_id", "register_country_id", "registration_no", "role_id", "salutation", "status_id", "tax_clearance", "username", "vat_pan_no", "vdc_id", "website" },
                values: new object[] { 2, null, null, null, null, null, null, null, null, 1, null, null, null, null, null, null, null, null, new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7581), new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7598), null, null, null, 0, null, null, "Bid", null, "Inviter", null, null, null, null, "YHCTM7byxNlmg1x9CGp5nA==", null, null, "bid.inviter@test.com", null, 0, null, 2, null, 2, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "address1", "address2", "address3", "back_citizenship", "bank_credit_letter", "category_id", "city_id", "CompanyId", "company_contact1", "company_contact2", "company_name", "company_registration", "company_type_Id", "acronym", "comapny_email", "country_id", "date_created", "date_modified", "description", "designation", "district_id", "no_of_employee", "expired_date", "fax_no", "first_name", "front_citizenship", "last_name", "membership_Id", "middle_name", "municipality_id", "pan_vat_registration", "password", "person_contact1", "person_contact2", "person_email", "province_id", "register_country_id", "registration_no", "role_id", "salutation", "status_id", "tax_clearance", "username", "vat_pan_no", "vdc_id", "website" },
                values: new object[] { 3, null, null, null, null, null, null, null, null, 1, null, null, null, null, null, null, null, null, new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7924), new DateTime(2021, 9, 27, 15, 4, 36, 637, DateTimeKind.Local).AddTicks(7927), null, null, null, 0, null, null, "Bid", null, "Bidder", null, null, null, null, "YHCTM7byxNlmg1x9CGp5nA==", null, null, "bid.bidder@test.com", null, 0, null, 3, null, 2, null, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(818), new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(854) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(887), new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(891) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(907), new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(3151), new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(3160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(3173), new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(3177) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(3186), new DateTime(2021, 9, 27, 12, 49, 51, 284, DateTimeKind.Local).AddTicks(3190) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 565, DateTimeKind.Local).AddTicks(7913), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(5889) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7806), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7813) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7816), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7817) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7819), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7820) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7821), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7823), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7824) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7825), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7826) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7828), new DateTime(2021, 9, 27, 12, 49, 50, 566, DateTimeKind.Local).AddTicks(7829) });
        }
    }
}
