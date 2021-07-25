using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mb_admin_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_admin_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_auction_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auction_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_auction_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_company_type",
                columns: table => new
                {
                    company_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_company_type", x => x.company_type_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_country",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    abbre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_user_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "md_common_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_md_common_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_province",
                columns: table => new
                {
                    province_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    province_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_province", x => x.province_id);
                    table.ForeignKey(
                        name: "FK_mb_province_mb_country_country_id",
                        column: x => x.country_id,
                        principalTable: "mb_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_category", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_mb_category_md_common_status_status_id",
                        column: x => x.status_id,
                        principalTable: "md_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_membership",
                columns: table => new
                {
                    membership_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    duration_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membership_fee = table.Column<float>(type: "real", nullable: false),
                    discount = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_membership", x => x.membership_id);
                    table.ForeignKey(
                        name: "FK_mb_membership_md_common_status_status",
                        column: x => x.status,
                        principalTable: "md_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_district",
                columns: table => new
                {
                    district_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_district", x => x.district_id);
                    table.ForeignKey(
                        name: "FK_mb_district_mb_province_province_id",
                        column: x => x.province_id,
                        principalTable: "mb_province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_municipality",
                columns: table => new
                {
                    municipality_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    municipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_municipality", x => x.municipality_id);
                    table.ForeignKey(
                        name: "FK_mb_municipality_mb_district_district_id",
                        column: x => x.district_id,
                        principalTable: "mb_district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_vdc",
                columns: table => new
                {
                    vdc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vdc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_vdc", x => x.vdc_id);
                    table.ForeignKey(
                        name: "FK_mb_vdc_mb_district_district_id",
                        column: x => x.district_id,
                        principalTable: "mb_district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_city",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipality_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_city", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_mb_city_mb_municipality_municipality_id",
                        column: x => x.municipality_id,
                        principalTable: "mb_municipality",
                        principalColumn: "municipality_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    province_id = table.Column<int>(type: "int", nullable: false),
                    district_id = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    register_country_id = table.Column<int>(type: "int", nullable: false),
                    registration_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_type_Id = table.Column<int>(type: "int", nullable: false),
                    acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    no_of_employee = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    vat_pan_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipality_id = table.Column<int>(type: "int", nullable: false),
                    vdc_id = table.Column<int>(type: "int", nullable: false),
                    fax_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comapny_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_contact1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person_contact1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person_contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activate_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserStatusStatus_Id = table.Column<int>(type: "int", nullable: true),
                    front_citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    back_citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tax_clearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pan_vat_registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experienced_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_credit_letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membership_Id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_city_city_id",
                        column: x => x.city_id,
                        principalTable: "mb_city",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_company_type_company_type_Id",
                        column: x => x.company_type_Id,
                        principalTable: "mb_company_type",
                        principalColumn: "company_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_country_country_id",
                        column: x => x.country_id,
                        principalTable: "mb_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_district_district_id",
                        column: x => x.district_id,
                        principalTable: "mb_district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_membership_membership_Id",
                        column: x => x.membership_Id,
                        principalTable: "mb_membership",
                        principalColumn: "membership_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_municipality_municipality_id",
                        column: x => x.municipality_id,
                        principalTable: "mb_municipality",
                        principalColumn: "municipality_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_province_province_id",
                        column: x => x.province_id,
                        principalTable: "mb_province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_role_role_id",
                        column: x => x.role_id,
                        principalTable: "mb_role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_user_status_UserStatusStatus_Id",
                        column: x => x.UserStatusStatus_Id,
                        principalTable: "mb_user_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_vdc_vdc_id",
                        column: x => x.vdc_id,
                        principalTable: "mb_vdc",
                        principalColumn: "vdc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_category_status_id",
                table: "mb_category",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_city_municipality_id",
                table: "mb_city",
                column: "municipality_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_district_province_id",
                table: "mb_district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_membership_status",
                table: "mb_membership",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_mb_municipality_district_id",
                table: "mb_municipality",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_province_country_id",
                table: "mb_province",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_city_id",
                table: "mb_user",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_type_Id",
                table: "mb_user",
                column: "company_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_country_id",
                table: "mb_user",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_district_id",
                table: "mb_user",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_membership_Id",
                table: "mb_user",
                column: "membership_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_municipality_id",
                table: "mb_user",
                column: "municipality_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_province_id",
                table: "mb_user",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_role_id",
                table: "mb_user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_username",
                table: "mb_user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_UserStatusStatus_Id",
                table: "mb_user",
                column: "UserStatusStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_vdc_id",
                table: "mb_user",
                column: "vdc_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_vdc_district_id",
                table: "mb_vdc",
                column: "district_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_admin_status");

            migrationBuilder.DropTable(
                name: "mb_auction_status");

            migrationBuilder.DropTable(
                name: "mb_category");

            migrationBuilder.DropTable(
                name: "mb_user");

            migrationBuilder.DropTable(
                name: "mb_city");

            migrationBuilder.DropTable(
                name: "mb_company_type");

            migrationBuilder.DropTable(
                name: "mb_membership");

            migrationBuilder.DropTable(
                name: "mb_role");

            migrationBuilder.DropTable(
                name: "mb_user_status");

            migrationBuilder.DropTable(
                name: "mb_vdc");

            migrationBuilder.DropTable(
                name: "mb_municipality");

            migrationBuilder.DropTable(
                name: "md_common_status");

            migrationBuilder.DropTable(
                name: "mb_district");

            migrationBuilder.DropTable(
                name: "mb_province");

            migrationBuilder.DropTable(
                name: "mb_country");
        }
    }
}
