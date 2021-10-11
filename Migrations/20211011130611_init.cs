using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "mb_admin_status",
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                name: "mb_document_status",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_document_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mb_document_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_document_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mb_mail_data",
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_FAQ",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_membership",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_province",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_mail_attachment",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_mail_data",
                        principalColumn: "mail_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_company",
                schema: "dbo",
                columns: table => new
                {
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAs = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    ReferenceCode = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_company", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_mb_company_mb_country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "mb_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_mb_province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "mb_province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_district",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_municipality",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_vdc",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_city",
                schema: "dbo",
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
                        principalSchema: "dbo",
                        principalTable: "mb_municipality",
                        principalColumn: "municipality_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_city_mb_vdc_vdc_id",
                        column: x => x.vdc_id,
                        principalSchema: "dbo",
                        principalTable: "mb_vdc",
                        principalColumn: "vdc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_user",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
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
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_city_city_id",
                        column: x => x.city_id,
                        principalSchema: "dbo",
                        principalTable: "mb_city",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_company_type_company_type_Id",
                        column: x => x.company_type_Id,
                        principalSchema: "dbo",
                        principalTable: "mb_company_type",
                        principalColumn: "company_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_country_country_id",
                        column: x => x.country_id,
                        principalSchema: "dbo",
                        principalTable: "mb_country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_district_district_id",
                        column: x => x.district_id,
                        principalSchema: "dbo",
                        principalTable: "mb_district",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_membership_membership_Id",
                        column: x => x.membership_Id,
                        principalSchema: "dbo",
                        principalTable: "mb_membership",
                        principalColumn: "membership_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_municipality_municipality_id",
                        column: x => x.municipality_id,
                        principalSchema: "dbo",
                        principalTable: "mb_municipality",
                        principalColumn: "municipality_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_province_province_id",
                        column: x => x.province_id,
                        principalSchema: "dbo",
                        principalTable: "mb_province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "mb_role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_user_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_vdc_vdc_id",
                        column: x => x.vdc_id,
                        principalSchema: "dbo",
                        principalTable: "mb_vdc",
                        principalColumn: "vdc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_callaction_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    SenderUserId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_mb_callaction_email_mb_callaction_email_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo",
                        principalTable: "mb_callaction_email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_callaction_email_mb_user_SenderUserId",
                        column: x => x.SenderUserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_company_document",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: false),
                    StatusChangedBy = table.Column<long>(type: "bigint", nullable: true),
                    DocumentTypeyId = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: false),
                    DocumentPath = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: true),
                    Remarks = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    AdminStatusEntityStatus_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_company_document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_admin_status_AdminStatusEntityStatus_Id",
                        column: x => x.AdminStatusEntityStatus_Id,
                        principalSchema: "dbo",
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_company_CompanyID",
                        column: x => x.CompanyID,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_document_status_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalSchema: "dbo",
                        principalTable: "mb_document_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_document_type_DocumentTypeyId",
                        column: x => x.DocumentTypeyId,
                        principalSchema: "dbo",
                        principalTable: "mb_document_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_user_StatusChangedBy",
                        column: x => x.StatusChangedBy,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_user_UploadedBy",
                        column: x => x.UploadedBy,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_experience_doc",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    experience_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_experience_doc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_experience_doc_mb_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_favourite",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_favourite", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_favourite_mb_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_request_help",
                schema: "dbo",
                columns: table => new
                {
                    request_help_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problem_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    help_status_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
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
                        principalSchema: "dbo",
                        principalTable: "mb_request_help_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_request_help_mb_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender",
                schema: "dbo",
                columns: table => new
                {
                    tender_id = table.Column<long>(type: "bigint", nullable: false)
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
                    posted_by = table.Column<long>(type: "bigint", nullable: false),
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
                        principalSchema: "dbo",
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_auction_status_tender_status_id",
                        column: x => x.tender_status_id,
                        principalSchema: "dbo",
                        principalTable: "mb_auction_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "dbo",
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_user_posted_by",
                        column: x => x.posted_by,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_user_company",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_user_company_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_user_company_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_bidder_request",
                schema: "dbo",
                columns: table => new
                {
                    request_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    tender_id = table.Column<long>(type: "bigint", nullable: false),
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
                        principalSchema: "dbo",
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_mb_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_correspondence_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserId = table.Column<long>(type: "bigint", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "mb_tender_material",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tender_id = table.Column<long>(type: "bigint", nullable: false),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_material", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_tender_material_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender_term_condition",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tender_id = table.Column<long>(type: "bigint", nullable: false),
                    term_condition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_term_condition", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_tender_term_condition_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_watchlist",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    tender_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_watchlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_watchlist_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_watchlist_mb_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_bidder_request_doc",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bidder_request_doc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    request_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bidder_request_doc", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_bidder_request_doc_mb_bidder_request_request_id",
                        column: x => x.request_id,
                        principalSchema: "dbo",
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_clarification_email",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUserId = table.Column<long>(type: "bigint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "mb_bid_history",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiddingRequestId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false),
                    Quotation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_bid_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_bidder_request_BiddingRequestId",
                        column: x => x.BiddingRequestId,
                        principalSchema: "dbo",
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_tender_material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_bid_history_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_live_bid",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiddingRequestId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TenderId = table.Column<long>(type: "bigint", nullable: false),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false),
                    Quotation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_live_bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_bidder_request_BiddingRequestId",
                        column: x => x.BiddingRequestId,
                        principalSchema: "dbo",
                        principalTable: "mb_bidder_request",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_tender_material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_tender_TenderId",
                        column: x => x.TenderId,
                        principalSchema: "dbo",
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_live_bid_mb_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_material_feature",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    material_id = table.Column<long>(type: "bigint", nullable: false),
                    feature_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    feature_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_material_feature", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_material_feature_mb_tender_material_material_id",
                        column: x => x.material_id,
                        principalSchema: "dbo",
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 2, "Construction", new DateTime(2021, 10, 11, 18, 51, 11, 401, DateTimeKind.Local).AddTicks(3061), new DateTime(2021, 10, 11, 18, 51, 11, 401, DateTimeKind.Local).AddTicks(3071) },
                    { 1, "Transportation", new DateTime(2021, 10, 11, 18, 51, 11, 401, DateTimeKind.Local).AddTicks(2980), new DateTime(2021, 10, 11, 18, 51, 11, 401, DateTimeKind.Local).AddTicks(3018) },
                    { 3, "Tourism", new DateTime(2021, 10, 11, 18, 51, 11, 401, DateTimeKind.Local).AddTicks(3105), new DateTime(2021, 10, 11, 18, 51, 11, 401, DateTimeKind.Local).AddTicks(3115) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_country",
                columns: new[] { "country_id", "abbre", "country_code", "country_name", "date_created", "date_modified" },
                values: new object[] { 1, "NP", "NEP", "Nepal", new DateTime(2021, 10, 11, 18, 51, 10, 308, DateTimeKind.Local).AddTicks(3102), new DateTime(2021, 10, 11, 18, 51, 10, 311, DateTimeKind.Local).AddTicks(5841) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_document_status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approve" },
                    { 3, "Reject" },
                    { 4, "Requires-New" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_document_type",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 5, "Bank Voucher" },
                    { 3, "Tax Clearance" },
                    { 2, "Citizenship-Back" },
                    { 1, "Citizenship-Front" },
                    { 4, "PAN/VAT Registration" }
                });

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
                table: "mb_role",
                columns: new[] { "role_id", "date_created", "date_modified", "role" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 11, 18, 51, 10, 313, DateTimeKind.Local).AddTicks(8637), new DateTime(2021, 10, 11, 18, 51, 10, 313, DateTimeKind.Local).AddTicks(8656), "Super Admin" },
                    { 2, new DateTime(2021, 10, 11, 18, 51, 10, 313, DateTimeKind.Local).AddTicks(8662), new DateTime(2021, 10, 11, 18, 51, 10, 313, DateTimeKind.Local).AddTicks(8663), "Bid Inviter" },
                    { 3, new DateTime(2021, 10, 11, 18, 51, 10, 313, DateTimeKind.Local).AddTicks(8666), new DateTime(2021, 10, 11, 18, 51, 10, 313, DateTimeKind.Local).AddTicks(8667), "Bidder" }
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
                    { 1, "Transportation", new DateTime(2021, 10, 11, 18, 51, 11, 343, DateTimeKind.Local).AddTicks(7565), new DateTime(2021, 10, 11, 18, 51, 11, 343, DateTimeKind.Local).AddTicks(7598), 1 },
                    { 2, "Construction", new DateTime(2021, 10, 11, 18, 51, 11, 343, DateTimeKind.Local).AddTicks(7640), new DateTime(2021, 10, 11, 18, 51, 11, 343, DateTimeKind.Local).AddTicks(7646), 1 },
                    { 3, "Tourism", new DateTime(2021, 10, 11, 18, 51, 11, 343, DateTimeKind.Local).AddTicks(7729), new DateTime(2021, 10, 11, 18, 51, 11, 343, DateTimeKind.Local).AddTicks(7735), 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_province",
                columns: new[] { "province_id", "country_id", "date_created", "date_modified", "province_title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1776), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1795), "Province No. 1" },
                    { 2, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1806), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1807), "Province No. 2" },
                    { 3, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1810), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1812), "Bagmati Province" },
                    { 4, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1814), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1816), "Gandaki Province" },
                    { 5, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1818), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1820), "Lumbini Province" },
                    { 6, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1823), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1824), "Karnali Province" },
                    { 7, 1, new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1827), new DateTime(2021, 10, 11, 18, 51, 10, 312, DateTimeKind.Local).AddTicks(1828), "Sudurpashchim Province" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "address1", "address2", "address3", "back_citizenship", "bank_credit_letter", "category_id", "city_id", "company_contact1", "company_contact2", "company_name", "company_registration", "company_type_Id", "acronym", "comapny_email", "country_id", "date_created", "date_modified", "description", "designation", "district_id", "no_of_employee", "expired_date", "fax_no", "first_name", "front_citizenship", "last_name", "membership_Id", "middle_name", "municipality_id", "pan_vat_registration", "password", "person_contact1", "person_contact2", "person_email", "province_id", "register_country_id", "registration_no", "role_id", "salutation", "status_id", "tax_clearance", "username", "vat_pan_no", "vdc_id", "website" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, new DateTime(2021, 10, 11, 18, 51, 10, 315, DateTimeKind.Local).AddTicks(8355), new DateTime(2021, 10, 11, 18, 51, 10, 315, DateTimeKind.Local).AddTicks(8383), null, null, null, 0, null, null, "Super", null, "Admin", null, null, null, null, "YHCTM7byxNlmg1x9CGp5nA==", null, null, "super.admin@test.com", null, 0, null, 1, null, 2, null, null, null, null, null },
                    { 2L, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, new DateTime(2021, 10, 11, 18, 51, 10, 325, DateTimeKind.Local).AddTicks(9254), new DateTime(2021, 10, 11, 18, 51, 10, 325, DateTimeKind.Local).AddTicks(9289), null, null, null, 0, null, null, "Bid", null, "Inviter", null, null, null, null, "YHCTM7byxNlmg1x9CGp5nA==", null, null, "bid.inviter@test.com", null, 0, null, 2, null, 2, null, null, null, null, null },
                    { 3L, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, new DateTime(2021, 10, 11, 18, 51, 10, 326, DateTimeKind.Local).AddTicks(308), new DateTime(2021, 10, 11, 18, 51, 10, 326, DateTimeKind.Local).AddTicks(321), null, null, null, 0, null, null, "Bid", null, "Bidder", null, null, null, null, "YHCTM7byxNlmg1x9CGp5nA==", null, null, "bid.bidder@test.com", null, 0, null, 3, null, 2, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_company",
                columns: new[] { "CompanyId", "Address1", "Address2", "Address3", "City", "CountryId", "Name", "ProvinceId", "ReferenceCode", "RegisteredAs", "Zip" },
                values: new object[] { 1L, "Address1", "Address2", "Address3", "Kathmandu", 1, "Test Company", 3, null, null, "123" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user_company",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user_company",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[] { 2L, 1L, 2L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user_company",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[] { 3L, 1L, 3L });

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_BiddingRequestId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "BiddingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_MaterialId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_TenderId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bid_history_UserId",
                schema: "dbo",
                table: "mb_bid_history",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_admin_status_id",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "admin_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_tender_id",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_user_id",
                schema: "dbo",
                table: "mb_bidder_request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_bidder_request_doc_request_id",
                schema: "dbo",
                table: "mb_bidder_request_doc",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_ParentId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_callaction_email_SenderUserId",
                schema: "dbo",
                table: "mb_callaction_email",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_category_status_id",
                schema: "dbo",
                table: "mb_category",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_city_municipality_id",
                schema: "dbo",
                table: "mb_city",
                column: "municipality_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_city_vdc_id",
                schema: "dbo",
                table: "mb_city",
                column: "vdc_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_CountryId",
                schema: "dbo",
                table: "mb_company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_ProvinceId",
                schema: "dbo",
                table: "mb_company",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_AdminStatusEntityStatus_Id",
                schema: "dbo",
                table: "mb_company_document",
                column: "AdminStatusEntityStatus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_CompanyID",
                schema: "dbo",
                table: "mb_company_document",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_DocumentStatusId",
                schema: "dbo",
                table: "mb_company_document",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_DocumentTypeyId",
                schema: "dbo",
                table: "mb_company_document",
                column: "DocumentTypeyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_StatusChangedBy",
                schema: "dbo",
                table: "mb_company_document",
                column: "StatusChangedBy");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_document_UploadedBy",
                schema: "dbo",
                table: "mb_company_document",
                column: "UploadedBy");

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

            migrationBuilder.CreateIndex(
                name: "IX_mb_district_province_id",
                schema: "dbo",
                table: "mb_district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_experience_doc_user_id",
                schema: "dbo",
                table: "mb_experience_doc",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_FAQ_status_id",
                schema: "dbo",
                table: "mb_FAQ",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_category_id",
                schema: "dbo",
                table: "mb_favourite",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_favourite_user_id",
                schema: "dbo",
                table: "mb_favourite",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_BiddingRequestId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "BiddingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_MaterialId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_TenderId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_live_bid_UserId",
                schema: "dbo",
                table: "mb_live_bid",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_mail_attachment_MailEntityMail_id",
                schema: "dbo",
                table: "mb_mail_attachment",
                column: "MailEntityMail_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_material_id",
                schema: "dbo",
                table: "mb_material_feature",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_membership_status",
                schema: "dbo",
                table: "mb_membership",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_mb_municipality_district_id",
                schema: "dbo",
                table: "mb_municipality",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_province_country_id",
                schema: "dbo",
                table: "mb_province",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_help_status_id",
                schema: "dbo",
                table: "mb_request_help",
                column: "help_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_request_help_user_id",
                schema: "dbo",
                table: "mb_request_help",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_admin_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "admin_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_category_id",
                schema: "dbo",
                table: "mb_tender",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_posted_by",
                schema: "dbo",
                table: "mb_tender",
                column: "posted_by");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_tender_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "tender_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_category_id",
                schema: "dbo",
                table: "mb_user",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_city_id",
                schema: "dbo",
                table: "mb_user",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_type_Id",
                schema: "dbo",
                table: "mb_user",
                column: "company_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_country_id",
                schema: "dbo",
                table: "mb_user",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_district_id",
                schema: "dbo",
                table: "mb_user",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_membership_Id",
                schema: "dbo",
                table: "mb_user",
                column: "membership_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_municipality_id",
                schema: "dbo",
                table: "mb_user",
                column: "municipality_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_province_id",
                schema: "dbo",
                table: "mb_user",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_role_id",
                schema: "dbo",
                table: "mb_user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_status_id",
                schema: "dbo",
                table: "mb_user",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_username",
                schema: "dbo",
                table: "mb_user",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_vdc_id",
                schema: "dbo",
                table: "mb_user",
                column: "vdc_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_CompanyId",
                schema: "dbo",
                table: "mb_user_company",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_UserId",
                schema: "dbo",
                table: "mb_user_company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_vdc_district_id",
                schema: "dbo",
                table: "mb_vdc",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_tender_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_watchlist_user_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_bid_history",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_bidder_request_doc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_callaction_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_clarification_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_company_document",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_experience_doc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_FAQ",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_favourite",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_live_bid",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_mail_attachment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_material_feature",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_payment_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_request_help",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_tender_term_condition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_user_company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_watchlist",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_correspondence_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_document_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_document_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_bidder_request",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_mail_data",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_tender_material",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_request_help_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_tender",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_admin_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_auction_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_city",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_company_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_membership",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_user_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_municipality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_vdc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_common_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_district",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_province",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_country",
                schema: "dbo");
        }
    }
}
