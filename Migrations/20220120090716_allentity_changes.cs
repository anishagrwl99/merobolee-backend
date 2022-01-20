using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeroBolee.Migrations
{
    public partial class allentity_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_city_mb_municipality_municipality_id",
                schema: "dbo",
                table: "mb_city");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_city_mb_vdc_vdc_id",
                schema: "dbo",
                table: "mb_city");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_district_mb_province_province_id",
                schema: "dbo",
                table: "mb_district");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_experience_doc_mb_user_user_id",
                schema: "dbo",
                table: "mb_experience_doc");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_favourite_lk_category_category_id",
                schema: "dbo",
                table: "mb_favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_favourite_mb_user_user_id",
                schema: "dbo",
                table: "mb_favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_material_id",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_membership_lk_common_status_status",
                schema: "dbo",
                table: "mb_membership");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_municipality_mb_district_district_id",
                schema: "dbo",
                table: "mb_municipality");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_category_category_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_Tender_Status_tender_status_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_company_company_id",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_approved_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_created_by",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_Tender_Card_Feeback_mb_tender_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_Tender_ExtraDocuments_mb_tender_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_vdc_mb_district_district_id",
                schema: "dbo",
                table: "mb_vdc");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_company_company_id",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_user_user_id",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropTable(
                name: "mb_company_type",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "vdc",
                schema: "dbo",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "cancel_remark",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "tender_code",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "tender_title",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "payment_status",
                schema: "dbo",
                table: "mb_payment_status");

            migrationBuilder.DropColumn(
                name: "municipality",
                schema: "dbo",
                table: "mb_municipality");

            migrationBuilder.DropColumn(
                name: "duration_type",
                schema: "dbo",
                table: "mb_membership");

            migrationBuilder.DropColumn(
                name: "title",
                schema: "dbo",
                table: "mb_membership");

            migrationBuilder.DropColumn(
                name: "experience_doc",
                schema: "dbo",
                table: "mb_experience_doc");

            migrationBuilder.DropColumn(
                name: "district_title",
                schema: "dbo",
                table: "mb_district");

            migrationBuilder.DropColumn(
                name: "city_title",
                schema: "dbo",
                table: "mb_city");

            migrationBuilder.DropColumn(
                name: "company_type",
                schema: "dbo",
                table: "lk_company_type");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "tender_id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "TenderId");

            migrationBuilder.RenameColumn(
                name: "company_id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_watchlist_user_id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "IX_mb_watchlist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_watchlist_tender_id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "IX_mb_watchlist_TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_watchlist_company_id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "IX_mb_watchlist_CompanyId");

            migrationBuilder.RenameColumn(
                name: "district_id",
                schema: "dbo",
                table: "mb_vdc",
                newName: "DistrictId");

            migrationBuilder.RenameColumn(
                name: "vdc_id",
                schema: "dbo",
                table: "mb_vdc",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_vdc_district_id",
                schema: "dbo",
                table: "mb_vdc",
                newName: "IX_mb_vdc_DistrictId");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "term_condition",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "TermCondition");

            migrationBuilder.RenameColumn(
                name: "tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_term_condition_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "IX_mb_tender_term_condition_TenderId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "TenderId");

            migrationBuilder.RenameColumn(
                name: "material",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "Materials");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_material_tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "IX_mb_tender_material_TenderId");

            migrationBuilder.RenameColumn(
                name: "TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                newName: "TenderEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_Tender_ExtraDocuments_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                newName: "IX_mb_Tender_ExtraDocuments_TenderEntityId");

            migrationBuilder.RenameColumn(
                name: "TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "TenderEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_Tender_Card_Feeback_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "IX_mb_Tender_Card_Feeback_TenderEntityId");

            migrationBuilder.RenameColumn(
                name: "created_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "company_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "approved_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "tender_status_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "start_date",
                schema: "dbo",
                table: "mb_tender",
                newName: "LiveStartDate");

            migrationBuilder.RenameColumn(
                name: "live_interval",
                schema: "dbo",
                table: "mb_tender",
                newName: "LiveInterval");

            migrationBuilder.RenameColumn(
                name: "end_date",
                schema: "dbo",
                table: "mb_tender",
                newName: "LiveEndDate");

            migrationBuilder.RenameColumn(
                name: "category_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "tender_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_tender_status_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_created_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_company_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_category_id",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_approved_by",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_payment_status",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "district_id",
                schema: "dbo",
                table: "mb_municipality",
                newName: "DistrictId");

            migrationBuilder.RenameColumn(
                name: "municipality_id",
                schema: "dbo",
                table: "mb_municipality",
                newName: "MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_municipality_district_id",
                schema: "dbo",
                table: "mb_municipality",
                newName: "IX_mb_municipality_DistrictId");

            migrationBuilder.RenameColumn(
                name: "duration",
                schema: "dbo",
                table: "mb_membership",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "discount",
                schema: "dbo",
                table: "mb_membership",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "dbo",
                table: "mb_membership",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "membership_fee",
                schema: "dbo",
                table: "mb_membership",
                newName: "MembershipFee");

            migrationBuilder.RenameColumn(
                name: "membership_id",
                schema: "dbo",
                table: "mb_membership",
                newName: "MembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_membership_status",
                schema: "dbo",
                table: "mb_membership",
                newName: "IX_mb_membership_StatusId");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "material_id",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "feature_value",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "FeatureValue");

            migrationBuilder.RenameColumn(
                name: "feature_name",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "FeatureName");

            migrationBuilder.RenameIndex(
                name: "IX_mb_material_feature_material_id",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "IX_mb_material_feature_MaterialId");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "mb_favourite",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "dbo",
                table: "mb_favourite",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "category_id",
                schema: "dbo",
                table: "mb_favourite",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_favourite_user_id",
                schema: "dbo",
                table: "mb_favourite",
                newName: "IX_mb_favourite_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_favourite_category_id",
                schema: "dbo",
                table: "mb_favourite",
                newName: "IX_mb_favourite_CategoryId");

            migrationBuilder.RenameColumn(
                name: "question",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "answer",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "Answer");

            migrationBuilder.RenameColumn(
                name: "faq_id",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "dbo",
                table: "mb_experience_doc",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_experience_doc_user_id",
                schema: "dbo",
                table: "mb_experience_doc",
                newName: "IX_mb_experience_doc_UserId");

            migrationBuilder.RenameColumn(
                name: "province_id",
                schema: "dbo",
                table: "mb_district",
                newName: "ProvinceId");

            migrationBuilder.RenameColumn(
                name: "district_id",
                schema: "dbo",
                table: "mb_district",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_district_province_id",
                schema: "dbo",
                table: "mb_district",
                newName: "IX_mb_district_ProvinceId");

            migrationBuilder.RenameColumn(
                name: "abbre",
                schema: "dbo",
                table: "mb_country",
                newName: "Abbre");

            migrationBuilder.RenameColumn(
                name: "vdc_id",
                schema: "dbo",
                table: "mb_city",
                newName: "VdcId");

            migrationBuilder.RenameColumn(
                name: "municipality_id",
                schema: "dbo",
                table: "mb_city",
                newName: "MunicipalityId");

            migrationBuilder.RenameColumn(
                name: "city_id",
                schema: "dbo",
                table: "mb_city",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_city_vdc_id",
                schema: "dbo",
                table: "mb_city",
                newName: "IX_mb_city_VdcId");

            migrationBuilder.RenameIndex(
                name: "IX_mb_city_municipality_id",
                schema: "dbo",
                table: "mb_city",
                newName: "IX_mb_city_MunicipalityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "lk_TechnicalSupportStatus",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "company_type_id",
                schema: "dbo",
                table: "lk_company_type",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "dbo",
                table: "lk_common_status",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status_id",
                schema: "dbo",
                table: "lk_common_status",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "category",
                schema: "dbo",
                table: "lk_category",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "category_id",
                schema: "dbo",
                table: "lk_category",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_vdc",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                schema: "dbo",
                table: "mb_TenderSubmisssionDocument",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DocPath",
                schema: "dbo",
                table: "mb_TenderSubmissionAdditionalDocument",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "PriceScheduleDocPath",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PriceScheduleDocName",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReferenceCode",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentProvider",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermCondition",
                schema: "dbo",
                table: "mb_tender_term_condition",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Materials",
                schema: "dbo",
                table: "mb_tender_material",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermsAndConditionDocPath",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenderDetailDocTitle",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenderDetailDocPath",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QualityRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PerformanceRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EligibilityCriteria",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancelRemarks",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "mb_tender",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_role",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_province",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                schema: "dbo",
                table: "mb_payment_status",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipalityName",
                schema: "dbo",
                table: "mb_municipality",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurationType",
                schema: "dbo",
                table: "mb_membership",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembershipTitle",
                schema: "dbo",
                table: "mb_membership",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureValue",
                schema: "dbo",
                table: "mb_material_feature",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureName",
                schema: "dbo",
                table: "mb_material_feature",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Quotation",
                schema: "dbo",
                table: "mb_live_bid",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                schema: "dbo",
                table: "mb_FAQ",
                type: "VARCHAR(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                schema: "dbo",
                table: "mb_FAQ",
                type: "VARCHAR(5000)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperiencedDoc",
                schema: "dbo",
                table: "mb_experience_doc",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                schema: "dbo",
                table: "mb_document_type",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_district",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abbre",
                schema: "dbo",
                table: "mb_country",
                type: "VARCHAR(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_country",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "mb_country",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone2",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone1",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address3",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                schema: "dbo",
                table: "mb_company",
                type: "VARCHAR(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_city",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "dbo",
                table: "mb_AuctionLog",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "lk_user_status",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "lk_TenderSubmissionStatus",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "lk_company_type",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "lk_common_status",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "dbo",
                table: "lk_category",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 285, DateTimeKind.Local).AddTicks(8183), new DateTime(2022, 1, 20, 14, 52, 16, 285, DateTimeKind.Local).AddTicks(8214) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 285, DateTimeKind.Local).AddTicks(8227), new DateTime(2022, 1, 20, 14, 52, 16, 285, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 285, DateTimeKind.Local).AddTicks(8368), new DateTime(2022, 1, 20, 14, 52, 16, 285, DateTimeKind.Local).AddTicks(8371) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified", "Name" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 343, DateTimeKind.Local).AddTicks(7694), new DateTime(2022, 1, 20, 14, 52, 16, 343, DateTimeKind.Local).AddTicks(7723), "Transportation" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified", "Name" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 343, DateTimeKind.Local).AddTicks(7790), new DateTime(2022, 1, 20, 14, 52, 16, 343, DateTimeKind.Local).AddTicks(7793), "Construction" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified", "Name" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 343, DateTimeKind.Local).AddTicks(7803), new DateTime(2022, 1, 20, 14, 52, 16, 343, DateTimeKind.Local).AddTicks(7806), "Tourism" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 299, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 1, 20, 14, 52, 16, 299, DateTimeKind.Local).AddTicks(8532) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 299, DateTimeKind.Local).AddTicks(8638), new DateTime(2022, 1, 20, 14, 52, 16, 299, DateTimeKind.Local).AddTicks(8641) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 16, 299, DateTimeKind.Local).AddTicks(8699), new DateTime(2022, 1, 20, 14, 52, 16, 299, DateTimeKind.Local).AddTicks(8703) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(9306), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified", "DurationType", "MembershipTitle" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 611, DateTimeKind.Local).AddTicks(1149), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(6933), "Year", "Registration" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified", "DurationType", "MembershipTitle" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7440), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7445), "Year", "Add New Company" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified", "DurationType", "MembershipTitle" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7447), new DateTime(2022, 1, 20, 14, 52, 15, 612, DateTimeKind.Local).AddTicks(7448), "Year", "Renew" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_payment_status",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentStatus",
                value: "Pending");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_payment_status",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentStatus",
                value: "Paid");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(896), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(901) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(904), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(905) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(907), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(909), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(913), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(913) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(915), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(916) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(917), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(918) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6711), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6717) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6720), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6721) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6722), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6723) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6724), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6725) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6727), new DateTime(2022, 1, 20, 14, 52, 15, 613, DateTimeKind.Local).AddTicks(6728) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 618, DateTimeKind.Local).AddTicks(8764), new DateTime(2022, 1, 20, 14, 52, 15, 618, DateTimeKind.Local).AddTicks(8770), false });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(424), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(450), false });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(987), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(990), false });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1027), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1028), false });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1048), new DateTime(2022, 1, 20, 14, 52, 15, 624, DateTimeKind.Local).AddTicks(1049), false });

            migrationBuilder.AddForeignKey(
                name: "FK_mb_city_mb_municipality_MunicipalityId",
                schema: "dbo",
                table: "mb_city",
                column: "MunicipalityId",
                principalSchema: "dbo",
                principalTable: "mb_municipality",
                principalColumn: "MunicipalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_city_mb_vdc_VdcId",
                schema: "dbo",
                table: "mb_city",
                column: "VdcId",
                principalSchema: "dbo",
                principalTable: "mb_vdc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_district_mb_province_ProvinceId",
                schema: "dbo",
                table: "mb_district",
                column: "ProvinceId",
                principalSchema: "dbo",
                principalTable: "mb_province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_experience_doc_mb_user_UserId",
                schema: "dbo",
                table: "mb_experience_doc",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_favourite_lk_category_CategoryId",
                schema: "dbo",
                table: "mb_favourite",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "lk_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_favourite_mb_user_UserId",
                schema: "dbo",
                table: "mb_favourite",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_MaterialId",
                schema: "dbo",
                table: "mb_material_feature",
                column: "MaterialId",
                principalSchema: "dbo",
                principalTable: "mb_tender_material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_membership_lk_common_status_StatusId",
                schema: "dbo",
                table: "mb_membership",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "lk_common_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_municipality_mb_district_DistrictId",
                schema: "dbo",
                table: "mb_municipality",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "mb_district",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_category_CategoryId",
                schema: "dbo",
                table: "mb_tender",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "lk_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_Tender_Status_StatusId",
                schema: "dbo",
                table: "mb_tender",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "lk_Tender_Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_company_CompanyId",
                schema: "dbo",
                table: "mb_tender",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "mb_company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_ApprovedBy",
                schema: "dbo",
                table: "mb_tender",
                column: "ApprovedBy",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_CreatedBy",
                schema: "dbo",
                table: "mb_tender",
                column: "CreatedBy",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_Tender_Card_Feeback_mb_tender_TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                column: "TenderEntityId",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_Tender_ExtraDocuments_mb_tender_TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                column: "TenderEntityId",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_tender_material",
                column: "TenderId",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_tender_term_condition",
                column: "TenderId",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_vdc_mb_district_DistrictId",
                schema: "dbo",
                table: "mb_vdc",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "mb_district",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_company_CompanyId",
                schema: "dbo",
                table: "mb_watchlist",
                column: "CompanyId",
                principalSchema: "dbo",
                principalTable: "mb_company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_watchlist",
                column: "TenderId",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_user_UserId",
                schema: "dbo",
                table: "mb_watchlist",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mb_city_mb_municipality_MunicipalityId",
                schema: "dbo",
                table: "mb_city");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_city_mb_vdc_VdcId",
                schema: "dbo",
                table: "mb_city");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_district_mb_province_ProvinceId",
                schema: "dbo",
                table: "mb_district");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_experience_doc_mb_user_UserId",
                schema: "dbo",
                table: "mb_experience_doc");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_favourite_lk_category_CategoryId",
                schema: "dbo",
                table: "mb_favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_favourite_mb_user_UserId",
                schema: "dbo",
                table: "mb_favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_MaterialId",
                schema: "dbo",
                table: "mb_material_feature");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_membership_lk_common_status_StatusId",
                schema: "dbo",
                table: "mb_membership");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_municipality_mb_district_DistrictId",
                schema: "dbo",
                table: "mb_municipality");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_category_CategoryId",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_lk_Tender_Status_StatusId",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_company_CompanyId",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_ApprovedBy",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_mb_user_CreatedBy",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_Tender_Card_Feeback_mb_tender_TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_Tender_ExtraDocuments_mb_tender_TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_material_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_tender_material");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_tender_term_condition");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_vdc_mb_district_DistrictId",
                schema: "dbo",
                table: "mb_vdc");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_company_CompanyId",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_tender_TenderId",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropForeignKey(
                name: "FK_mb_watchlist_mb_user_UserId",
                schema: "dbo",
                table: "mb_watchlist");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "mb_vdc");

            migrationBuilder.DropColumn(
                name: "CancelRemarks",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "mb_tender");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                schema: "dbo",
                table: "mb_payment_status");

            migrationBuilder.DropColumn(
                name: "MunicipalityName",
                schema: "dbo",
                table: "mb_municipality");

            migrationBuilder.DropColumn(
                name: "DurationType",
                schema: "dbo",
                table: "mb_membership");

            migrationBuilder.DropColumn(
                name: "MembershipTitle",
                schema: "dbo",
                table: "mb_membership");

            migrationBuilder.DropColumn(
                name: "ExperiencedDoc",
                schema: "dbo",
                table: "mb_experience_doc");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "mb_district");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "mb_city");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "lk_company_type");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "tender_id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_watchlist_UserId",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "IX_mb_watchlist_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_watchlist_TenderId",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "IX_mb_watchlist_tender_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_watchlist_CompanyId",
                schema: "dbo",
                table: "mb_watchlist",
                newName: "IX_mb_watchlist_company_id");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "mb_vdc",
                newName: "district_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_vdc",
                newName: "vdc_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_vdc_DistrictId",
                schema: "dbo",
                table: "mb_vdc",
                newName: "IX_mb_vdc_district_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TermCondition",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "term_condition");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "tender_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_term_condition_TenderId",
                schema: "dbo",
                table: "mb_tender_term_condition",
                newName: "IX_mb_tender_term_condition_tender_id");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TenderId",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "tender_id");

            migrationBuilder.RenameColumn(
                name: "Materials",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "material");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_material_TenderId",
                schema: "dbo",
                table: "mb_tender_material",
                newName: "IX_mb_tender_material_tender_id");

            migrationBuilder.RenameColumn(
                name: "TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                newName: "TenderEntityTender_Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_Tender_ExtraDocuments_TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                newName: "IX_mb_Tender_ExtraDocuments_TenderEntityTender_Id");

            migrationBuilder.RenameColumn(
                name: "TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "TenderEntityTender_Id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_Tender_Card_Feeback_TenderEntityId",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                newName: "IX_mb_Tender_Card_Feeback_TenderEntityTender_Id");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "mb_tender",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "mb_tender",
                newName: "company_id");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                schema: "dbo",
                table: "mb_tender",
                newName: "approved_by");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                schema: "dbo",
                table: "mb_tender",
                newName: "tender_status_id");

            migrationBuilder.RenameColumn(
                name: "LiveStartDate",
                schema: "dbo",
                table: "mb_tender",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "LiveInterval",
                schema: "dbo",
                table: "mb_tender",
                newName: "live_interval");

            migrationBuilder.RenameColumn(
                name: "LiveEndDate",
                schema: "dbo",
                table: "mb_tender",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "mb_tender",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_tender",
                newName: "tender_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_StatusId",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_tender_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_CreatedBy",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_created_by");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_CompanyId",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_company_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_CategoryId",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_tender_ApprovedBy",
                schema: "dbo",
                table: "mb_tender",
                newName: "IX_mb_tender_approved_by");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_payment_status",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "mb_municipality",
                newName: "district_id");

            migrationBuilder.RenameColumn(
                name: "MunicipalityId",
                schema: "dbo",
                table: "mb_municipality",
                newName: "municipality_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_municipality_DistrictId",
                schema: "dbo",
                table: "mb_municipality",
                newName: "IX_mb_municipality_district_id");

            migrationBuilder.RenameColumn(
                name: "Duration",
                schema: "dbo",
                table: "mb_membership",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Discount",
                schema: "dbo",
                table: "mb_membership",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                schema: "dbo",
                table: "mb_membership",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "MembershipFee",
                schema: "dbo",
                table: "mb_membership",
                newName: "membership_fee");

            migrationBuilder.RenameColumn(
                name: "MembershipId",
                schema: "dbo",
                table: "mb_membership",
                newName: "membership_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_membership_StatusId",
                schema: "dbo",
                table: "mb_membership",
                newName: "IX_mb_membership_status");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "material_id");

            migrationBuilder.RenameColumn(
                name: "FeatureValue",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "feature_value");

            migrationBuilder.RenameColumn(
                name: "FeatureName",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "feature_name");

            migrationBuilder.RenameIndex(
                name: "IX_mb_material_feature_MaterialId",
                schema: "dbo",
                table: "mb_material_feature",
                newName: "IX_mb_material_feature_material_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_favourite",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "mb_favourite",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "mb_favourite",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_favourite_UserId",
                schema: "dbo",
                table: "mb_favourite",
                newName: "IX_mb_favourite_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_favourite_CategoryId",
                schema: "dbo",
                table: "mb_favourite",
                newName: "IX_mb_favourite_category_id");

            migrationBuilder.RenameColumn(
                name: "Question",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "question");

            migrationBuilder.RenameColumn(
                name: "Answer",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "answer");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_FAQ",
                newName: "faq_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "mb_experience_doc",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_experience_doc_UserId",
                schema: "dbo",
                table: "mb_experience_doc",
                newName: "IX_mb_experience_doc_user_id");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                schema: "dbo",
                table: "mb_district",
                newName: "province_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_district",
                newName: "district_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_district_ProvinceId",
                schema: "dbo",
                table: "mb_district",
                newName: "IX_mb_district_province_id");

            migrationBuilder.RenameColumn(
                name: "Abbre",
                schema: "dbo",
                table: "mb_country",
                newName: "abbre");

            migrationBuilder.RenameColumn(
                name: "VdcId",
                schema: "dbo",
                table: "mb_city",
                newName: "vdc_id");

            migrationBuilder.RenameColumn(
                name: "MunicipalityId",
                schema: "dbo",
                table: "mb_city",
                newName: "municipality_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "mb_city",
                newName: "city_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_city_VdcId",
                schema: "dbo",
                table: "mb_city",
                newName: "IX_mb_city_vdc_id");

            migrationBuilder.RenameIndex(
                name: "IX_mb_city_MunicipalityId",
                schema: "dbo",
                table: "mb_city",
                newName: "IX_mb_city_municipality_id");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                schema: "dbo",
                table: "lk_TechnicalSupportStatus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "lk_company_type",
                newName: "company_type_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "dbo",
                table: "lk_common_status",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "lk_common_status",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "Category",
                schema: "dbo",
                table: "lk_category",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "lk_category",
                newName: "category_id");

            migrationBuilder.AddColumn<string>(
                name: "vdc",
                schema: "dbo",
                table: "mb_vdc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                schema: "dbo",
                table: "mb_user",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                schema: "dbo",
                table: "mb_user",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentPath",
                schema: "dbo",
                table: "mb_TenderSubmisssionDocument",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "DocPath",
                schema: "dbo",
                table: "mb_TenderSubmissionAdditionalDocument",
                type: "VARCHAR(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "PriceScheduleDocPath",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PriceScheduleDocName",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentReferenceCode",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentProvider",
                schema: "dbo",
                table: "mb_TenderSubmission",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "term_condition",
                schema: "dbo",
                table: "mb_tender_term_condition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "material",
                schema: "dbo",
                table: "mb_tender_material",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TermsAndConditionDocPath",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenderDetailDocTitle",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenderDetailDocPath",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QualityRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PerformanceRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EligibilityCriteria",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalRequest",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cancel_remark",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tender_code",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "tender_title",
                schema: "dbo",
                table: "mb_tender",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                type: "VARCHAR",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "mb_TechnicalSupport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_province",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payment_status",
                schema: "dbo",
                table: "mb_payment_status",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "municipality",
                schema: "dbo",
                table: "mb_municipality",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duration_type",
                schema: "dbo",
                table: "mb_membership",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                schema: "dbo",
                table: "mb_membership",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "feature_value",
                schema: "dbo",
                table: "mb_material_feature",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "feature_name",
                schema: "dbo",
                table: "mb_material_feature",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Quotation",
                schema: "dbo",
                table: "mb_live_bid",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "question",
                schema: "dbo",
                table: "mb_FAQ",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "answer",
                schema: "dbo",
                table: "mb_FAQ",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5000)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "experience_doc",
                schema: "dbo",
                table: "mb_experience_doc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                schema: "dbo",
                table: "mb_document_type",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "district_title",
                schema: "dbo",
                table: "mb_district",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "mb_country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "abbre",
                schema: "dbo",
                table: "mb_country",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone2",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone1",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "ContactPerson",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyEmail",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address3",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                schema: "dbo",
                table: "mb_company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city_title",
                schema: "dbo",
                table: "mb_city",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "dbo",
                table: "mb_AuctionLog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "lk_user_status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "lk_TenderSubmissionStatus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "company_type",
                schema: "dbo",
                table: "lk_company_type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "dbo",
                table: "lk_common_status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "category",
                schema: "dbo",
                table: "lk_category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "mb_company_type",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyTypeId = table.Column<int>(type: "int", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "datetime", nullable: false)
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(332), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(358) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(372), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(375) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_category",
                keyColumn: "category_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(386), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(389) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 1,
                columns: new[] { "company_type", "Date_Created", "Date_Modified" },
                values: new object[] { "Transportation", new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(8120), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(8132) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 2,
                columns: new[] { "company_type", "Date_Created", "Date_Modified" },
                values: new object[] { "Construction", new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(8143), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(8147) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "lk_company_type",
                keyColumn: "company_type_id",
                keyValue: 3,
                columns: new[] { "company_type", "Date_Created", "Date_Modified" },
                values: new object[] { "Tourism", new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(8157), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(8160) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(5004), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(5168), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(5172) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_company",
                keyColumn: "CompanyId",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(5240), new DateTime(2022, 1, 20, 11, 55, 48, 321, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_country",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(2975), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified", "duration_type", "title" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 230, DateTimeKind.Local).AddTicks(5081), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(832), "Year", "Registration" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified", "duration_type", "title" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1334), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1339), "Year", "Add New Company" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_membership",
                keyColumn: "membership_id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified", "duration_type", "title" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1342), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(1343), "Year", "Renew" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_payment_status",
                keyColumn: "id",
                keyValue: 1,
                column: "payment_status",
                value: "Pending");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_payment_status",
                keyColumn: "id",
                keyValue: 2,
                column: "payment_status",
                value: "Paid");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4184), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4188) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4192), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4193) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4194), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4196) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4197), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4198) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4199), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4201) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4202), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_province",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4204), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8847), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8854) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8856), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8857) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8858), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8860) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8861), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8862) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_role",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date_Created", "Date_Modified" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8863), new DateTime(2022, 1, 20, 11, 55, 47, 232, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 239, DateTimeKind.Local).AddTicks(3170), new DateTime(2022, 1, 20, 11, 55, 47, 239, DateTimeKind.Local).AddTicks(3180), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(6805), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(6819), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7139), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7142), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7242), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7244), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "mb_user",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Date_Created", "Date_Modified", "IsEmailReceiver" },
                values: new object[] { new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7265), new DateTime(2022, 1, 20, 11, 55, 47, 248, DateTimeKind.Local).AddTicks(7266), true });

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

            migrationBuilder.AddForeignKey(
                name: "FK_mb_city_mb_municipality_municipality_id",
                schema: "dbo",
                table: "mb_city",
                column: "municipality_id",
                principalSchema: "dbo",
                principalTable: "mb_municipality",
                principalColumn: "municipality_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_city_mb_vdc_vdc_id",
                schema: "dbo",
                table: "mb_city",
                column: "vdc_id",
                principalSchema: "dbo",
                principalTable: "mb_vdc",
                principalColumn: "vdc_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_district_mb_province_province_id",
                schema: "dbo",
                table: "mb_district",
                column: "province_id",
                principalSchema: "dbo",
                principalTable: "mb_province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_experience_doc_mb_user_user_id",
                schema: "dbo",
                table: "mb_experience_doc",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_favourite_lk_category_category_id",
                schema: "dbo",
                table: "mb_favourite",
                column: "category_id",
                principalSchema: "dbo",
                principalTable: "lk_category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_favourite_mb_user_user_id",
                schema: "dbo",
                table: "mb_favourite",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_material_feature_mb_tender_material_material_id",
                schema: "dbo",
                table: "mb_material_feature",
                column: "material_id",
                principalSchema: "dbo",
                principalTable: "mb_tender_material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_membership_lk_common_status_status",
                schema: "dbo",
                table: "mb_membership",
                column: "status",
                principalSchema: "dbo",
                principalTable: "lk_common_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_municipality_mb_district_district_id",
                schema: "dbo",
                table: "mb_municipality",
                column: "district_id",
                principalSchema: "dbo",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_category_category_id",
                schema: "dbo",
                table: "mb_tender",
                column: "category_id",
                principalSchema: "dbo",
                principalTable: "lk_category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_lk_Tender_Status_tender_status_id",
                schema: "dbo",
                table: "mb_tender",
                column: "tender_status_id",
                principalSchema: "dbo",
                principalTable: "lk_Tender_Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_company_company_id",
                schema: "dbo",
                table: "mb_tender",
                column: "company_id",
                principalSchema: "dbo",
                principalTable: "mb_company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_approved_by",
                schema: "dbo",
                table: "mb_tender",
                column: "approved_by",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_mb_user_created_by",
                schema: "dbo",
                table: "mb_tender",
                column: "created_by",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_Tender_Card_Feeback_mb_tender_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_Card_Feeback",
                column: "TenderEntityTender_Id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_Tender_ExtraDocuments_mb_tender_TenderEntityTender_Id",
                schema: "dbo",
                table: "mb_Tender_ExtraDocuments",
                column: "TenderEntityTender_Id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_material_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_tender_material",
                column: "tender_id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_tender_term_condition_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_tender_term_condition",
                column: "tender_id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_vdc_mb_district_district_id",
                schema: "dbo",
                table: "mb_vdc",
                column: "district_id",
                principalSchema: "dbo",
                principalTable: "mb_district",
                principalColumn: "district_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_company_company_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "company_id",
                principalSchema: "dbo",
                principalTable: "mb_company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_tender_tender_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "tender_id",
                principalSchema: "dbo",
                principalTable: "mb_tender",
                principalColumn: "tender_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mb_watchlist_mb_user_user_id",
                schema: "dbo",
                table: "mb_watchlist",
                column: "user_id",
                principalSchema: "dbo",
                principalTable: "mb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
