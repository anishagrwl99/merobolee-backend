using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class entitychanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_province_mb_country_country_id",
                schema: "dbo",
                table: "mb_province");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_lk_user_status_status_id",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_role_role_id",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropIndex(
                name: "IX_mb_user_email",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropIndex(
                name: "IX_mb_user_username",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "last_name",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "middle_name",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.RenameColumn(
                name: "username",
                schema: "dbo",
                table: "mb_user",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                schema: "dbo",
                table: "mb_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "dbo",
                table: "mb_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "designation",
                schema: "dbo",
                table: "mb_user",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "user_code",
                schema: "dbo",
                table: "mb_user",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "status_id",
                schema: "dbo",
                table: "mb_user",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "dbo",
                table: "mb_user",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "expired_date",
                schema: "dbo",
                table: "mb_user",
                newName: "ExpriedDate");

            migrationBuilder.RenameColumn(
                name: "activate_date",
                schema: "dbo",
                table: "mb_user",
                newName: "ActivateDate");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "dbo",
                table: "mb_user",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_status_id",
                schema: "dbo",
                table: "mb_user",
                newName: "IX_mb_user_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_role_id",
                schema: "dbo",
                table: "mb_user",
                newName: "IX_mb_user_RoleId");

            migrationBuilder.RenameColumn(
                name: "role",
                schema: "dbo",
                table: "mb_role",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "role_id",
                schema: "dbo",
                table: "mb_role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "province_title",
                schema: "dbo",
                table: "mb_province",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "dbo",
                table: "mb_province",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "province_id",
                schema: "dbo",
                table: "mb_province",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_province_country_id",
                schema: "dbo",
                table: "mb_province",
                newName: "IX_mb_province_CountryId");

            migrationBuilder.RenameColumn(
                name: "country_name",
                schema: "dbo",
                table: "mb_country",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country_code",
                schema: "dbo",
                table: "mb_country",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "dbo",
                table: "mb_country",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_status",
                schema: "dbo",
                table: "lk_user_status",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status_id",
                schema: "dbo",
                table: "lk_user_status",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 539, DateTimeKind.Local).AddTicks(7729), new DateTime(2022, 1, 18, 10, 2, 39, 539, DateTimeKind.Local).AddTicks(7756) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 539, DateTimeKind.Local).AddTicks(7768), new DateTime(2022, 1, 18, 10, 2, 39, 539, DateTimeKind.Local).AddTicks(7771) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 539, DateTimeKind.Local).AddTicks(7780), new DateTime(2022, 1, 18, 10, 2, 39, 539, DateTimeKind.Local).AddTicks(7783) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 586, DateTimeKind.Local).AddTicks(1566), new DateTime(2022, 1, 18, 10, 2, 39, 586, DateTimeKind.Local).AddTicks(1587) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 586, DateTimeKind.Local).AddTicks(1599), new DateTime(2022, 1, 18, 10, 2, 39, 586, DateTimeKind.Local).AddTicks(1602) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 586, DateTimeKind.Local).AddTicks(1611), new DateTime(2022, 1, 18, 10, 2, 39, 586, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 550, DateTimeKind.Local).AddTicks(9421), new DateTime(2022, 1, 18, 10, 2, 39, 550, DateTimeKind.Local).AddTicks(9447), "MB220118001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 550, DateTimeKind.Local).AddTicks(9561), new DateTime(2022, 1, 18, 10, 2, 39, 550, DateTimeKind.Local).AddTicks(9565), "BI220118002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 550, DateTimeKind.Local).AddTicks(9662), new DateTime(2022, 1, 18, 10, 2, 39, 550, DateTimeKind.Local).AddTicks(9665), "SP220118003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(4650), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(4655) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 21, DateTimeKind.Local).AddTicks(4241), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(2571) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3055), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3060) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3063), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(3064) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5862), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5867) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5871), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5872) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5932), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5934) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5935), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5936) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5938), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5939) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5940), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5942), new DateTime(2022, 1, 18, 10, 2, 39, 22, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(406), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(412) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(415), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(418), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(419) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(420), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(421) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(422), new DateTime(2022, 1, 18, 10, 2, 39, 23, DateTimeKind.Local).AddTicks(423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 27, DateTimeKind.Local).AddTicks(156), new DateTime(2022, 1, 18, 10, 2, 39, 27, DateTimeKind.Local).AddTicks(164), "Super", "Admin" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3089), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3109), "Tender", "Support" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3487), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3489), "Customer", "Support" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3525), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3527), "Bid", "Inviter" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3546), new DateTime(2022, 1, 18, 10, 2, 39, 30, DateTimeKind.Local).AddTicks(3547), "Bid", "Bidder" });

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_Email",
                schema: "dbo",
                table: "mb_user",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_Username",
                schema: "dbo",
                table: "mb_user",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_province_mb_country_CountryId",
                schema: "dbo",
                table: "mb_province",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "mb_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_lk_user_status_StatusId",
                schema: "dbo",
                table: "mb_user",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "lk_user_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_role_RoleId",
                schema: "dbo",
                table: "mb_user",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "mb_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_province_mb_country_CountryId",
                schema: "dbo",
                table: "mb_province");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_lk_user_status_StatusId",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_role_RoleId",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropIndex(
                name: "IX_mb_user_Email",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropIndex(
                name: "IX_mb_user_Username",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                schema: "dbo",
                table: "mb_user");

            migrationBuilder.RenameColumn(
                name: "Username",
                schema: "dbo",
                table: "mb_user",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "dbo",
                table: "mb_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "dbo",
                table: "mb_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Designation",
                schema: "dbo",
                table: "mb_user",
                newName: "designation");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                schema: "dbo",
                table: "mb_user",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                schema: "dbo",
                table: "mb_user",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ExpriedDate",
                schema: "dbo",
                table: "mb_user",
                newName: "expired_date");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "dbo",
                table: "mb_user",
                newName: "user_code");

            migrationBuilder.RenameColumn(
                name: "ActivateDate",
                schema: "dbo",
                table: "mb_user",
                newName: "activate_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_user",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_StatusId",
                schema: "dbo",
                table: "mb_user",
                newName: "IX_mb_user_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_user_RoleId",
                schema: "dbo",
                table: "mb_user",
                newName: "IX_mb_user_role_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "mb_role",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_role",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "mb_province",
                newName: "province_title");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "dbo",
                table: "mb_province",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_province",
                newName: "province_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_province_CountryId",
                schema: "dbo",
                table: "mb_province",
                newName: "IX_mb_province_country_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "mb_country",
                newName: "country_name");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "dbo",
                table: "mb_country",
                newName: "country_code");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_country",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "dbo",
                table: "lk_user_status",
                newName: "user_status");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "lk_user_status",
                newName: "status_id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "designation",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(3978), new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(4137) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(4152), new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(4156) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(4165), new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 304, DateTimeKind.Local).AddTicks(348), new DateTime(2022, 1, 17, 15, 23, 21, 304, DateTimeKind.Local).AddTicks(357) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 304, DateTimeKind.Local).AddTicks(373), new DateTime(2022, 1, 17, 15, 23, 21, 304, DateTimeKind.Local).AddTicks(376) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 304, DateTimeKind.Local).AddTicks(385), new DateTime(2022, 1, 17, 15, 23, 21, 304, DateTimeKind.Local).AddTicks(389) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(8000), new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(8010), "MB220117001" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(8107), new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(8111), "BI220117002" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "ReferenceCode" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(8169), new DateTime(2022, 1, 17, 15, 23, 21, 303, DateTimeKind.Local).AddTicks(8173), "SP220117003" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(3738), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 15, DateTimeKind.Local).AddTicks(4079), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1321) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1842), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1847) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1850), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(1851) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4966), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4970) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4990), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4991) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4993), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4994) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4996), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4997) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4998), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(4999) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5001), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5002) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5003), new DateTime(2022, 1, 17, 15, 23, 20, 17, DateTimeKind.Local).AddTicks(5004) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(332), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(345), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(347), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(350), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(351) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(352), new DateTime(2022, 1, 17, 15, 23, 20, 18, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "first_name", "last_name" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 24, DateTimeKind.Local).AddTicks(6999), new DateTime(2022, 1, 17, 15, 23, 20, 24, DateTimeKind.Local).AddTicks(7010), "Super", "Admin" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "first_name", "last_name" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(82), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(109), "Tender", "Support" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "first_name", "last_name" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(799), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(807), "Customer", "Support" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified", "first_name", "last_name" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(897), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(900), "Bid", "Inviter" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified", "first_name", "last_name" },
                values: new object[] { new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(938), new DateTime(2022, 1, 17, 15, 23, 20, 32, DateTimeKind.Local).AddTicks(939), "Bid", "Bidder" });

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_email",
                schema: "dbo",
                table: "mb_user",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_username",
                schema: "dbo",
                table: "mb_user",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_province_mb_country_country_id",
                schema: "dbo",
                table: "mb_province",
                column: "country_id",
                principalSchema: "dbo",
                principalTable: "mb_country",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_lk_user_status_status_id",
                schema: "dbo",
                table: "mb_user",
                column: "status_id",
                principalSchema: "dbo",
                principalTable: "lk_user_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_role_role_id",
                schema: "dbo",
                table: "mb_user",
                column: "role_id",
                principalSchema: "dbo",
                principalTable: "mb_role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
