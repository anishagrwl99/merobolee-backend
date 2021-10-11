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
                name: "lk_admin_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_admin_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "lk_auction_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auction_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_auction_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "lk_common_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_common_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "lk_company_type",
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
                    table.PrimaryKey("PK_lk_company_type", x => x.company_type_id);
                });

            migrationBuilder.CreateTable(
                name: "lk_document_status",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_document_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lk_request_help_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_request_help_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "lk_user_status",
                schema: "dbo",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lk_user_status", x => x.status_id);
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
                        name: "FK_mb_category_lk_common_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_common_status",
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
                        name: "FK_mb_FAQ_lk_common_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_common_status",
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
                        name: "FK_mb_membership_lk_common_status_status",
                        column: x => x.status,
                        principalSchema: "dbo",
                        principalTable: "lk_common_status",
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
                name: "mb_user",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_code = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activate_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_mb_user_lk_user_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_user_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_user_mb_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "mb_role",
                        principalColumn: "role_id",
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
                    ReferenceCode = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MembershipTypeId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_mb_company_mb_membership_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalSchema: "dbo",
                        principalTable: "mb_membership",
                        principalColumn: "membership_id",
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
                        name: "FK_mb_request_help_lk_request_help_status_help_status_id",
                        column: x => x.help_status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_request_help_status",
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
                        name: "FK_mb_tender_lk_admin_status_admin_status_id",
                        column: x => x.admin_status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_tender_lk_auction_status_tender_status_id",
                        column: x => x.tender_status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_auction_status",
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
                        name: "FK_mb_company_document_lk_admin_status_AdminStatusEntityStatus_Id",
                        column: x => x.AdminStatusEntityStatus_Id,
                        principalSchema: "dbo",
                        principalTable: "lk_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_company_document_lk_document_status_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalSchema: "dbo",
                        principalTable: "lk_document_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_document_mb_company_CompanyID",
                        column: x => x.CompanyID,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
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
                name: "mb_company_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_company_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mb_company_type_lk_company_type_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalSchema: "dbo",
                        principalTable: "lk_company_type",
                        principalColumn: "company_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mb_company_type_mb_company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mb_company",
                        principalColumn: "CompanyId",
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
                        name: "FK_mb_bidder_request_lk_admin_status_admin_status_id",
                        column: x => x.admin_status_id,
                        principalSchema: "dbo",
                        principalTable: "lk_admin_status",
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
                table: "lk_admin_status",
                columns: new[] { "status_id", "admin_status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" },
                    { 3, "Approved" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_auction_status",
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
                table: "lk_common_status",
                columns: new[] { "status_id", "status" },
                values: new object[,]
                {
                    { 2, "Inactive" },
                    { 1, "Active" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_company_type",
                columns: new[] { "company_type_id", "company_type", "date_created", "date_modified" },
                values: new object[,]
                {
                    { 3, "Tourism", new DateTime(2021, 10, 11, 20, 1, 45, 157, DateTimeKind.Local).AddTicks(4822), new DateTime(2021, 10, 11, 20, 1, 45, 157, DateTimeKind.Local).AddTicks(4829) },
                    { 1, "Transportation", new DateTime(2021, 10, 11, 20, 1, 45, 157, DateTimeKind.Local).AddTicks(4741), new DateTime(2021, 10, 11, 20, 1, 45, 157, DateTimeKind.Local).AddTicks(4773) },
                    { 2, "Construction", new DateTime(2021, 10, 11, 20, 1, 45, 157, DateTimeKind.Local).AddTicks(4798), new DateTime(2021, 10, 11, 20, 1, 45, 157, DateTimeKind.Local).AddTicks(4804) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_document_status",
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
                table: "lk_request_help_status",
                columns: new[] { "status_id", "request_status" },
                values: new object[,]
                {
                    { 4, "Resolved" },
                    { 3, "Running" },
                    { 2, "Approved" },
                    { 1, "Requested" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "lk_user_status",
                columns: new[] { "status_id", "user_status" },
                values: new object[,]
                {
                    { 1, "Registered" },
                    { 2, "Approved" },
                    { 4, "Terminated" },
                    { 3, "Suspended" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_country",
                columns: new[] { "country_id", "abbre", "country_code", "country_name", "date_created", "date_modified" },
                values: new object[] { 1, "NP", "NEP", "Nepal", new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(7914), new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(7928) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_document_type",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 5, "Bank Voucher" },
                    { 4, "PAN/VAT Registration" },
                    { 2, "Citizenship-Back" },
                    { 1, "Citizenship-Front" },
                    { 3, "Tax Clearance" }
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
                table: "mb_role",
                columns: new[] { "role_id", "date_created", "date_modified", "role" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 11, 20, 1, 43, 953, DateTimeKind.Local).AddTicks(6182), new DateTime(2021, 10, 11, 20, 1, 43, 953, DateTimeKind.Local).AddTicks(6195), "Super Admin" },
                    { 2, new DateTime(2021, 10, 11, 20, 1, 43, 953, DateTimeKind.Local).AddTicks(6200), new DateTime(2021, 10, 11, 20, 1, 43, 953, DateTimeKind.Local).AddTicks(6203), "Bid Inviter" },
                    { 3, new DateTime(2021, 10, 11, 20, 1, 43, 953, DateTimeKind.Local).AddTicks(6207), new DateTime(2021, 10, 11, 20, 1, 43, 953, DateTimeKind.Local).AddTicks(6210), "Bidder" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_category",
                columns: new[] { "category_id", "category", "date_created", "date_modified", "status_id" },
                values: new object[,]
                {
                    { 1, "Transportation", new DateTime(2021, 10, 11, 20, 1, 45, 88, DateTimeKind.Local).AddTicks(4626), new DateTime(2021, 10, 11, 20, 1, 45, 88, DateTimeKind.Local).AddTicks(4662), 1 },
                    { 2, "Construction", new DateTime(2021, 10, 11, 20, 1, 45, 88, DateTimeKind.Local).AddTicks(4727), new DateTime(2021, 10, 11, 20, 1, 45, 88, DateTimeKind.Local).AddTicks(4739), 1 },
                    { 3, "Tourism", new DateTime(2021, 10, 11, 20, 1, 45, 88, DateTimeKind.Local).AddTicks(4810), new DateTime(2021, 10, 11, 20, 1, 45, 88, DateTimeKind.Local).AddTicks(4819), 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_membership",
                columns: new[] { "membership_id", "date_created", "date_modified", "discount", "duration", "duration_type", "title", "membership_fee", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 11, 20, 1, 43, 947, DateTimeKind.Local).AddTicks(6674), new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(1609), 0f, 1, "Year", "Registration", 2000f, 1 },
                    { 2, new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(2885), new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(2895), 0f, 1, "Year", "Add New Company", 1500f, 1 },
                    { 3, new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(2901), new DateTime(2021, 10, 11, 20, 1, 43, 951, DateTimeKind.Local).AddTicks(2904), 0f, 1, "Year", "Renew", 1000f, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_province",
                columns: new[] { "province_id", "country_id", "date_created", "date_modified", "province_title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1739), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1748), "Province No. 1" },
                    { 2, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1755), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1759), "Province No. 2" },
                    { 3, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1763), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1767), "Bagmati Province" },
                    { 4, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1772), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1775), "Gandaki Province" },
                    { 5, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1779), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1782), "Lumbini Province" },
                    { 6, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1786), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1790), "Karnali Province" },
                    { 7, 1, new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1794), new DateTime(2021, 10, 11, 20, 1, 43, 952, DateTimeKind.Local).AddTicks(1797), "Sudurpashchim Province" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_user",
                columns: new[] { "user_id", "activate_date", "date_created", "date_modified", "designation", "expired_date", "first_name", "last_name", "middle_name", "password", "email", "role_id", "status_id", "username" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2021, 10, 11, 20, 1, 43, 967, DateTimeKind.Local).AddTicks(3649), new DateTime(2021, 10, 11, 20, 1, 43, 967, DateTimeKind.Local).AddTicks(3683), null, null, "Super", "Admin", null, "YHCTM7byxNlmg1x9CGp5nA==", "super.admin@test.com", 1, 2, null },
                    { 2L, null, new DateTime(2021, 10, 11, 20, 1, 43, 978, DateTimeKind.Local).AddTicks(370), new DateTime(2021, 10, 11, 20, 1, 43, 978, DateTimeKind.Local).AddTicks(407), null, null, "Bid", "Inviter", null, "YHCTM7byxNlmg1x9CGp5nA==", "bid.inviter@test.com", 2, 2, null },
                    { 3L, null, new DateTime(2021, 10, 11, 20, 1, 43, 978, DateTimeKind.Local).AddTicks(1306), new DateTime(2021, 10, 11, 20, 1, 43, 978, DateTimeKind.Local).AddTicks(1312), null, null, "Bid", "Bidder", null, "YHCTM7byxNlmg1x9CGp5nA==", "bid.bidder@test.com", 3, 2, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_company",
                columns: new[] { "CompanyId", "Address1", "Address2", "Address3", "City", "CompanyEmail", "CompanyWebsite", "ContactPerson", "CountryId", "MembershipTypeId", "Name", "Phone1", "Phone2", "ProvinceId", "ReferenceCode", "RegisteredAs", "Zip" },
                values: new object[] { 1L, "Address1", "Address2", "Address3", "Kathmandu", null, null, null, 1, 1, "Test Company", null, null, 3, "SP102111200143954", "Supplier", "123" });

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
                name: "IX_mb_company_MembershipTypeId",
                schema: "dbo",
                table: "mb_company",
                column: "MembershipTypeId");

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
                name: "IX_mb_company_type_CompanyId",
                schema: "dbo",
                table: "mb_company_type",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mb_company_type_CompanyTypeId",
                schema: "dbo",
                table: "mb_company_type",
                column: "CompanyTypeId");

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
                name: "mb_city",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_clarification_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_company_document",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_company_type",
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
                name: "mb_municipality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_vdc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_correspondence_email",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_document_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_document_type",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_company_type",
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
                name: "lk_request_help_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_district",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_tender",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_membership",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_province",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_admin_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_auction_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_country",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_common_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "lk_user_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_role",
                schema: "dbo");
        }
    }
}
