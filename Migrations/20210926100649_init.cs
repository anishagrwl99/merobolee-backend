using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class init : Migration
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
                name: "mb_common_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_common_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_company_type",
                columns: table => new
                {
                    company_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_mail_data",
                columns: table => new
                {
                    mail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_mail_data", x => x.mail_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_payment_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_payment_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mb_request_help_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_request_help_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "mb_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                name: "mb_category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_category", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_mb_category_mb_common_status_status_id",
                        column: x => x.status_id,
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_FAQ",
                columns: table => new
                {
                    faq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_FAQ", x => x.faq_id);
                    table.ForeignKey(
                        name: "FK_mb_FAQ_mb_common_status_status_id",
                        column: x => x.status_id,
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
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
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_membership", x => x.membership_id);
                    table.ForeignKey(
                        name: "FK_mb_membership_mb_common_status_status",
                        column: x => x.status,
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
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
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                name: "mb_mail_attachment",
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
                        principalTable: "mb_mail_data",
                        principalColumn: "mail_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProvienceId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_mb_company_mb_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "mb_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_mb_province_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "mb_province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Cascade);
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
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                    district_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                    district_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                    vdc_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_mb_city_mb_vdc_vdc_id",
                        column: x => x.vdc_id,
                        principalTable: "mb_vdc",
                        principalColumn: "vdc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    province_id = table.Column<int>(type: "int", nullable: true),
                    district_id = table.Column<int>(type: "int", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    register_country_id = table.Column<int>(type: "int", nullable: false),
                    registration_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_type_Id = table.Column<int>(type: "int", nullable: true),
                    acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    no_of_employee = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    vat_pan_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    municipality_id = table.Column<int>(type: "int", nullable: true),
                    vdc_id = table.Column<int>(type: "int", nullable: true),
                    fax_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comapny_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_contact1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_contact1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    person_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activate_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    front_citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    back_citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tax_clearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pan_vat_registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_credit_letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    membership_Id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_category_category_id",
                        column: x => x.category_id,
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_city_city_id",
                        column: x => x.city_id,
                        principalTable: "mb_city",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_mb_user_mb_user_status_status_id",
                        column: x => x.status_id,
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

            migrationBuilder.CreateTable(
                name: "mb_experience_doc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    experience_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_experience_doc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_experience_doc_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_favourite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_favourite", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_category_category_id",
                        column: x => x.category_id,
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_request_help",
                columns: table => new
                {
                    request_help_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problem_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    help_status_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    resolve_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_request_help", x => x.request_help_id);
                    table.ForeignKey(
                        name: "FK_mb_request_help_mb_request_help_status_help_status_id",
                        column: x => x.help_status_id,
                        principalTable: "mb_request_help_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_request_help_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender",
                columns: table => new
                {
                    tender_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tender_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    tender_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    live_interval = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    duration_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid_no = table.Column<int>(type: "int", nullable: false),
                    posted_by = table.Column<int>(type: "int", nullable: false),
                    tender_status_id = table.Column<int>(type: "int", nullable: false),
                    admin_status_id = table.Column<int>(type: "int", nullable: false),
                    cancel_remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_request_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    source_fund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    project_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender", x => x.tender_id);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_admin_status_admin_status_id",
                        column: x => x.admin_status_id,
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_auction_status_tender_status_id",
                        column: x => x.tender_status_id,
                        principalTable: "mb_auction_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_category_category_id",
                        column: x => x.category_id,
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_user_posted_by",
                        column: x => x.posted_by,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_bidder_request",
                columns: table => new
                {
                    request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    tender_id = table.Column<int>(type: "int", nullable: false),
                    admin_status_id = table.Column<int>(type: "int", nullable: false),
                    request_send_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bidder_request", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_admin_status_admin_status_id",
                        column: x => x.admin_status_id,
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender_material",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    TenderEntityTender_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_material", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_tender_material_mb_tender_TenderEntityTender_Id",
                        column: x => x.TenderEntityTender_Id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender_term_condition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    term_condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderEntityTender_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_term_condition", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_tender_term_condition_mb_tender_TenderEntityTender_Id",
                        column: x => x.TenderEntityTender_Id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_watchlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    tender_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_watchlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_watchlist_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_watchlist_mb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_bidder_requesst_doc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidder_request_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bidder_requesst_doc", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_bidder_requesst_doc_mb_bidder_request_request_id",
                        column: x => x.request_id,
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_material_feature",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenderMaterialEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_material_feature", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_material_feature_mb_tender_material_TenderMaterialEntityId",
                        column: x => x.TenderMaterialEntityId,
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_requesst_doc_request_id",
                table: "mb_bidder_requesst_doc",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_admin_status_id",
                table: "mb_bidder_request",
                column: "admin_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_tender_id",
                table: "mb_bidder_request",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_user_id",
                table: "mb_bidder_request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_category_status_id",
                table: "mb_category",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_city_municipality_id",
                table: "mb_city",
                column: "municipality_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_city_vdc_id",
                table: "mb_city",
                column: "vdc_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_CountryId",
                table: "mb_company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_ProvienceId",
                table: "mb_company",
                column: "ProvienceId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_district_province_id",
                table: "mb_district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_experience_doc_user_id",
                table: "mb_experience_doc",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_FAQ_status_id",
                table: "mb_FAQ",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_category_id",
                table: "mb_favourite",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_user_id",
                table: "mb_favourite",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_mail_attachment_MailEntityMail_id",
                table: "mb_mail_attachment",
                column: "MailEntityMail_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_TenderMaterialEntityId",
                table: "mb_material_feature",
                column: "TenderMaterialEntityId");

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
                name: "IX_mb_request_help_help_status_id",
                table: "mb_request_help",
                column: "help_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_user_id",
                table: "mb_request_help",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_admin_status_id",
                table: "mb_tender",
                column: "admin_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_category_id",
                table: "mb_tender",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_posted_by",
                table: "mb_tender",
                column: "posted_by");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_tender_status_id",
                table: "mb_tender",
                column: "tender_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_TenderEntityTender_Id",
                table: "mb_tender_material",
                column: "TenderEntityTender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_TenderEntityTender_Id",
                table: "mb_tender_term_condition",
                column: "TenderEntityTender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_category_id",
                table: "mb_user",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_city_id",
                table: "mb_user",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_type_Id",
                table: "mb_user",
                column: "company_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_CompanyId",
                table: "mb_user",
                column: "CompanyId");

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
                name: "IX_mb_user_status_id",
                table: "mb_user",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_username",
                table: "mb_user",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_vdc_id",
                table: "mb_user",
                column: "vdc_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_vdc_district_id",
                table: "mb_vdc",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_tender_id",
                table: "mb_watchlist",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_user_id",
                table: "mb_watchlist",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_bidder_requesst_doc");

            migrationBuilder.DropTable(
                name: "mb_experience_doc");

            migrationBuilder.DropTable(
                name: "mb_FAQ");

            migrationBuilder.DropTable(
                name: "mb_favourite");

            migrationBuilder.DropTable(
                name: "mb_mail_attachment");

            migrationBuilder.DropTable(
                name: "mb_material_feature");

            migrationBuilder.DropTable(
                name: "mb_payment_status");

            migrationBuilder.DropTable(
                name: "mb_request_help");

            migrationBuilder.DropTable(
                name: "mb_tender_term_condition");

            migrationBuilder.DropTable(
                name: "mb_watchlist");

            migrationBuilder.DropTable(
                name: "mb_bidder_request");

            migrationBuilder.DropTable(
                name: "mb_mail_data");

            migrationBuilder.DropTable(
                name: "mb_tender_material");

            migrationBuilder.DropTable(
                name: "mb_request_help_status");

            migrationBuilder.DropTable(
                name: "mb_tender");

            migrationBuilder.DropTable(
                name: "mb_admin_status");

            migrationBuilder.DropTable(
                name: "mb_auction_status");

            migrationBuilder.DropTable(
                name: "mb_user");

            migrationBuilder.DropTable(
                name: "mb_category");

            migrationBuilder.DropTable(
                name: "mb_city");

            migrationBuilder.DropTable(
                name: "mb_company");

            migrationBuilder.DropTable(
                name: "mb_company_type");

            migrationBuilder.DropTable(
                name: "mb_membership");

            migrationBuilder.DropTable(
                name: "mb_role");

            migrationBuilder.DropTable(
                name: "mb_user_status");

            migrationBuilder.DropTable(
                name: "mb_municipality");

            migrationBuilder.DropTable(
                name: "mb_vdc");

            migrationBuilder.DropTable(
                name: "mb_common_status");

            migrationBuilder.DropTable(
                name: "mb_district");

            migrationBuilder.DropTable(
                name: "mb_province");

            migrationBuilder.DropTable(
                name: "mb_country");
        }
    }
}
