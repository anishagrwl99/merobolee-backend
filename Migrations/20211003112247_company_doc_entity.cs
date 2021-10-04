using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class company_doc_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "mb_company_document",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    StatusChangedBy = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 16, DateTimeKind.Local).AddTicks(6799), new DateTime(2021, 10, 3, 17, 7, 47, 16, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 16, DateTimeKind.Local).AddTicks(6859), new DateTime(2021, 10, 3, 17, 7, 47, 16, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 16, DateTimeKind.Local).AddTicks(6876), new DateTime(2021, 10, 3, 17, 7, 47, 16, DateTimeKind.Local).AddTicks(6879) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 35, DateTimeKind.Local).AddTicks(5899), new DateTime(2021, 10, 3, 17, 7, 47, 35, DateTimeKind.Local).AddTicks(5927) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 35, DateTimeKind.Local).AddTicks(5939), new DateTime(2021, 10, 3, 17, 7, 47, 35, DateTimeKind.Local).AddTicks(5942) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 47, 35, DateTimeKind.Local).AddTicks(5952), new DateTime(2021, 10, 3, 17, 7, 47, 35, DateTimeKind.Local).AddTicks(5955) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 523, DateTimeKind.Local).AddTicks(4497), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(2659) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "mb_document_status",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 4, "Requires-New" },
                    { 3, "Reject" },
                    { 2, "Approve" }
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4593), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4600) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4604), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4605) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4606), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4608) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4609), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4610) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4612), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4613) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4614), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4615) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4616), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(4617) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9232), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9238) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9240), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9241) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9243), new DateTime(2021, 10, 3, 17, 7, 46, 524, DateTimeKind.Local).AddTicks(9244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 525, DateTimeKind.Local).AddTicks(5093), new DateTime(2021, 10, 3, 17, 7, 46, 525, DateTimeKind.Local).AddTicks(5101) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7142), new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7494), new DateTime(2021, 10, 3, 17, 7, 46, 528, DateTimeKind.Local).AddTicks(7497) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mb_company_document",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_document_status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mb_document_type",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(5401), new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(5427) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(5461), new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(5465) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(5480), new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(8770), new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(8778) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(8797), new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(8801) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(8810), new DateTime(2021, 10, 3, 10, 7, 59, 573, DateTimeKind.Local).AddTicks(8814) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "country_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 551, DateTimeKind.Local).AddTicks(207), new DateTime(2021, 10, 3, 10, 7, 58, 551, DateTimeKind.Local).AddTicks(8476) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(417), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(423) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(427), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(428) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(429), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(431) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 4,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(432), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(433) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 5,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(435), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 6,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(437), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(438) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "province_id",
                keyValue: 7,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(440), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(441) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3545), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3550) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3553), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3554) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "role_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3556), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(3557) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(9750), new DateTime(2021, 10, 3, 10, 7, 58, 552, DateTimeKind.Local).AddTicks(9757) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(4635), new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(4661) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "user_id",
                keyValue: 3,
                columns: new[] { "date_created", "date_modified" },
                values: new object[] { new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(5245), new DateTime(2021, 10, 3, 10, 7, 58, 556, DateTimeKind.Local).AddTicks(5249) });
        }
    }
}
