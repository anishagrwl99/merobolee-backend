using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class addingNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PublishStatusStatus_id = table.Column<int>(type: "int", nullable: true),
                    admin_status_id = table.Column<int>(type: "int", nullable: false),
                    payment_status_id = table.Column<int>(type: "int", nullable: false),
                    date_created = table.Column<DateTime>(type: "date", nullable: false),
                    created_timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    date_modified = table.Column<DateTime>(type: "date", nullable: false),
                    modified_timestamp = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender", x => x.tender_id);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_admin_status_admin_status_id",
                        column: x => x.admin_status_id,
                        principalTable: "mb_admin_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_category_category_id",
                        column: x => x.category_id,
                        principalTable: "mb_category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_common_status_PublishStatusStatus_id",
                        column: x => x.PublishStatusStatus_id,
                        principalTable: "mb_common_status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_payment_status_payment_status_id",
                        column: x => x.payment_status_id,
                        principalTable: "mb_payment_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mb_tender_mb_user_posted_by",
                        column: x => x.posted_by,
                        principalTable: "mb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender_material",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tender_id = table.Column<int>(type: "int", nullable: false),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_material", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_tender_material_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_tender_term_condition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tender_id = table.Column<int>(type: "int", nullable: false),
                    term_condition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_tender_term_condition", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_tender_term_condition_mb_tender_tender_id",
                        column: x => x.tender_id,
                        principalTable: "mb_tender",
                        principalColumn: "tender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mb_material_feature",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    material_id = table.Column<int>(type: "int", nullable: false),
                    feature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mb_material_feature", x => x.id);
                    table.ForeignKey(
                        name: "FK_mb_material_feature_mb_tender_material_material_id",
                        column: x => x.material_id,
                        principalTable: "mb_tender_material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mb_user_company_type_Id",
                table: "mb_user",
                column: "company_type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_material_feature_material_id",
                table: "mb_material_feature",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_admin_status_id",
                table: "mb_tender",
                column: "admin_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_category_id",
                table: "mb_tender",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_payment_status_id",
                table: "mb_tender",
                column: "payment_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_posted_by",
                table: "mb_tender",
                column: "posted_by");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_PublishStatusStatus_id",
                table: "mb_tender",
                column: "PublishStatusStatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_material_tender_id",
                table: "mb_tender_material",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                table: "mb_tender_term_condition",
                column: "tender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user",
                column: "company_type_Id",
                principalTable: "mb_company_type",
                principalColumn: "company_type_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_user_mb_company_type_company_type_Id",
                table: "mb_user");

            migrationBuilder.DropTable(
                name: "mb_material_feature");

            migrationBuilder.DropTable(
                name: "mb_tender_term_condition");

            migrationBuilder.DropTable(
                name: "mb_tender_material");

            migrationBuilder.DropTable(
                name: "mb_tender");

            migrationBuilder.DropTable(
                name: "mb_payment_status");

            migrationBuilder.DropIndex(
                name: "IX_mb_user_company_type_Id",
                table: "mb_user");
        }
    }
}
