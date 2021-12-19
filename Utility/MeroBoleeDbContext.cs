using MeroBolee.Model;
using MeroBolee.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Utility
{
    public class MeroBoleeDbContext : DbContext
    {
        public DbSet<TenderExtraDocumentEntity> TenderExtraDocuments { get; set; }
        public DbSet<TenderCardFeedbackEntity> TenderCardFeedbacks { get; set; }
        public DbSet<TenderStatusEntity> TenderStatus { get; set; }
        public DbSet<AuctionLog> AuctionLogs { get; set; }
        public DbSet<TenderSubmissionDocuments> Documents { get; set; }
        public DbSet<TenderSubmissionStatus> TenderSubmissionStatuses { get; set; }
        public DbSet<TenderSubmission> TenderSubmissions { get; set; }
        public DbSet<TenderSubmissionEligibilityCriteria> SubmissionEligibilityCriterias { get; set; }
        public DbSet<TenderSubmissionPriceSchedule> SubmissionPriceSchedules { get; set; }
        public DbSet<TenderSubmissionProductSpec> SubmissionProductSpecs { get; set; }
        public DbSet<TenderSubmissionPurchaseCriteria> SubmissionPurchaseCriterias { get; set; }
        public DbSet<TenderSubmissionAdditionalDocument> TenderSubmissionAdditionalDocuments { get; set; }
        public DbSet<CompanyStatusEntity> CompanyStatusEntities { get; set; }
        public DbSet<TenderWinnerEntity> TenderWinnerEntities { get; set; }
        public DbSet<EmailEntity> EmailEntities { get; set; }
        public DbSet<UserEmailEntity> UserEmailEntities { get; set; }
        public DbSet<CompanyTypeEntity> CompanyTypeEntities { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<BiddingHistoryEntity> BiddingHistoryEntities { get; set; }
        public DbSet<CompanyEntity> CompanyEntities { get; set; }
        public DbSet<DocumentStatusEntity> DocumentStatusEntities { get; set; }
        public DbSet<DocumentTypeEntity> DocumentTypeEntities { get; set; }
        public DbSet<CompanyDocumentEntity> CompanyDocumentEntities { get; set; }
        public DbSet<LiveBiddingEntity> LiveBiddingEntities { get; set; }
        public DbSet<CompanyEntity> SupplierCompanyEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<CountryEntity> CountryEntities { get; set; }
        public DbSet<ProvinceEntity> ProvinceEntities { get; set; }
        public DbSet<DistrictEntity> DistrictEntities { get; set; }
        public DbSet<CityEntity> CityEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }

        public DbSet<PublishStatus> StatusEntities { get; set; }
        public DbSet<AuctionStatusEntity> AuctionStatusEntities { get; set; }
        public DbSet<AdminStatusEntity> AdminStatusEntities { get; set; }
        public DbSet<UserStatusEntity> UserStatusEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<UserExperienceDocEntity> UserExperienceDocEntities { get; set; }
        public DbSet<MunicipalityEntity> MunicipalityEntities { get; set; }
        public DbSet<VDCEntity> VDCEntities { get; set; }
        public DbSet<MembershipTypeEntity> MembershipTypeEntities { get; set; }
        public DbSet<CompanyTypeLookupEntity> CompanyTypeLookupEntities { get; set; }
        public DbSet<FavouriteCategoryEntity> FavouriteCategoryEntities { get; set; }

        public DbSet<TenderEntity> TenderEntities { get; set; }
        public DbSet<PaymentStatusEntity> PaymentStatusEntities { get; set; }
        public DbSet<TenderMaterialEntity> TenderMaterialEntities { get; set; }
        public DbSet<TenderTermsConditionEntity> TenderTermsConditionEntities { get; set; }
        public DbSet<WatchListEntity> WatchListEntities { get; set; }
        public DbSet<MaterialFeatureEntity> MaterialFeatureEntities { get; set; }

        public DbSet<BidderRequestEntity> BidderRequestEntities { get; set; }
        public DbSet<BidderRequestDocEntity> BidderRequestDocEntities { get; set; }

        public DbSet<FAQEntity> FAQEntities { get; set; }

        public DbSet<RequestHelpStatus> RequestHelpStatuses { get; set; }
        public DbSet<RequestHelpEntity> RequestHelpEntities { get; set; }

        public DbSet<MailEntity> MailEntities { get; set; }
        public DbSet<MailAttachmentEntity> MailAttachmentEntities { get; set; }



        public MeroBoleeDbContext(DbContextOptions<MeroBoleeDbContext> dbContext) : base(dbContext)
        {
        }

        public MeroBoleeDbContext()
        {
            Database.SetCommandTimeout(524);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
            if (!dbContextOptionsBuilder.IsConfigured) // Configure Database Connection
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile($"appsettings.{Startup.HostingEnvironment}.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MeroBoleeConn");
                dbContextOptionsBuilder.UseSqlServer(connectionString);

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<UserEntity>().Property(x => x.User_Code).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TenderEntity>().Property(x => x.Tender_Code).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<BidderRequestEntity>()
                .HasOne(e => e.TenderEntity)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WatchListEntity>()
               .HasOne(e => e.UserEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<LiveBiddingEntity>()
            //   .HasOne(e => e.BidderRequestEntity)
            //   .WithOne()
            //   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LiveBiddingEntity>()
               .HasOne(e => e.UserEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<LiveBiddingEntity>()
               .HasOne(e => e.TenderMaterialEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LiveBiddingEntity>()
               .HasOne(e => e.TenderEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BiddingHistoryEntity>()
              .HasOne(e => e.UserEntity)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<BiddingHistoryEntity>()
               .HasOne(e => e.TenderMaterialEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BiddingHistoryEntity>()
               .HasOne(e => e.TenderEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyDocumentEntity>()
               .HasOne(e => e.UploadUserEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TenderEntity>()
               .HasOne(e => e.Company)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmailEntity>()
               .HasOne(e => e.User)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmailEntity>()
              .HasOne(e => e.Tender)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmailEntity>()
              .HasOne(e => e.Company)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEmailEntity>()
               .HasOne(e => e.User)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TenderWinnerEntity>()
                .HasOne(e => e.Tender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WatchListEntity>()
                .HasOne(e => e.CompanyEntity)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuctionLog>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuctionLog>()
                .HasOne(e => e.Tender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuctionLog>()
                .HasOne(e => e.Company)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TenderCardFeedbackEntity>()
                .HasOne(e => e.Tender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TenderExtraDocumentEntity>()
                .HasOne(e => e.Tender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            SetupUniqueConstraint(modelBuilder);
            SeedStatusData(modelBuilder);
            SeedLookupData(modelBuilder);
            base.OnModelCreating(modelBuilder);
            //  modelBuilder.Entity<VDCEntity>().HasMany(x=>x.User_entity).WithOptional().HasForeignKey(x => x.Vdc_id).OnDelete(DeleteBehavior.Restrict);

            //    //modelBuilder.Entity<User>().HasData(
            //    //      new User() { Id = Guid.NewGuid(), Email = "Mubeen@gmail.com", Name = "Mubeen", Password = "123123" },
            //    //      new User() { Id = Guid.NewGuid(), Email = "Tahir@gmail.com", Name = "Tahir", Password = "321321" },
            //    //      new User() { Id = Guid.NewGuid(), Email = "Cheema@gmail.com", Name = "Cheema", Password = "123321" }
            //    //      );
        }


        private void SeedStatusData(ModelBuilder builder)
        {
            builder.Entity<AdminStatusEntity>().HasData(
                new AdminStatusEntity() { Status_Id = 1, Status = "Active" },
                new AdminStatusEntity() { Status_Id = 2, Status = "Inactive" },
                new AdminStatusEntity() { Status_Id = 3, Status = "Approved" }
                );

            builder.Entity<AuctionStatusEntity>().HasData(
                new AuctionStatusEntity() { Status_Id = 1, Status = "Pending Approval" },
                new AuctionStatusEntity() { Status_Id = 2, Status = "Approved" },
                new AuctionStatusEntity() { Status_Id = 3, Status = "Closed" }
                );

            builder.Entity<TenderStatusEntity>().HasData(
                new TenderStatusEntity() { StatusId = 1, Status = "Pending Approval" },
                new TenderStatusEntity() { StatusId = 2, Status = "Change Requested" },
                new TenderStatusEntity() { StatusId = 3, Status = "Approved" },
                new TenderStatusEntity() { StatusId = 4, Status = "Cancelled" }
                );


            builder.Entity<PublishStatus>().HasData(
                new PublishStatus() { Status_id = 1, Status = "Active" },
                new PublishStatus() { Status_id = 2, Status = "Inactive" }
                );

            builder.Entity<PaymentStatusEntity>().HasData(
                new PaymentStatusEntity() { Id = 1, Payment_status = "Pending" },
                new PaymentStatusEntity() { Id = 2, Payment_status = "Paid" }
                );

            builder.Entity<RequestHelpStatus>().HasData(
                new RequestHelpStatus() { Status_id = 1, Request_status = "Requested" },
                new RequestHelpStatus() { Status_id = 2, Request_status = "Approved" },
                new RequestHelpStatus() { Status_id = 3, Request_status = "Running" },
                new RequestHelpStatus() { Status_id = 4, Request_status = "Resolved" }
                );

            builder.Entity<UserStatusEntity>().HasData(
                new UserStatusEntity() { Status_Id = 1, Status = "Active" },
                new UserStatusEntity() { Status_Id = 2, Status = "Temporary Disabled" },
                new UserStatusEntity() { Status_Id = 3, Status = "Suspended" },
                new UserStatusEntity() { Status_Id = 4, Status = "Deleted" }
                );

            builder.Entity<CompanyStatusEntity>().HasData(
                new CompanyStatusEntity() { Id = 1, Status = "Registered" },
                new CompanyStatusEntity() { Id = 2, Status = "Verifying" },
                new CompanyStatusEntity() { Id = 3, Status = "Require More Documents" },
                new CompanyStatusEntity() { Id = 4, Status = "Verified" },
                new CompanyStatusEntity() { Id = 5, Status = "Suspended" },
                new CompanyStatusEntity() { Id = 6, Status = "Deactivate" }
                );

        }
        private void SeedLookupData(ModelBuilder builder)
        {
            builder.Entity<MembershipTypeEntity>().HasData(
                new MembershipTypeEntity
                {
                    Membership_Id = 1,
                    Membership_Title = "Registration",
                    Duration = 1,
                    Duration_Type = "Year",
                    Membership_fee = 2000,
                    Discount = 0,
                    Status_Id = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now
                },
                 new MembershipTypeEntity
                 {
                     Membership_Id = 2,
                     Membership_Title = "Add New Company",
                     Duration = 1,
                     Duration_Type = "Year",
                     Membership_fee = 1500,
                     Discount = 0,
                     Status_Id = 1,
                     Date_created = DateTime.Now,
                     Date_modified = DateTime.Now
                 },
                 new MembershipTypeEntity
                 {
                     Membership_Id = 3,
                     Membership_Title = "Renew",
                     Duration = 1,
                     Duration_Type = "Year",
                     Membership_fee = 1000,
                     Discount = 0,
                     Status_Id = 1,
                     Date_created = DateTime.Now,
                     Date_modified = DateTime.Now
                 });

            builder.Entity<CountryEntity>().HasData(
               new CountryEntity() { Country_Id = 1, Country_Name = "Nepal", Country_Code = "NEP", Abbre = "NP", Date_created = DateTime.Now, Date_modified = DateTime.Now }
               );
            builder.Entity<ProvinceEntity>().HasData(
              new ProvinceEntity() { Province_Id = 1, Province = "Province No. 1", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now },
              new ProvinceEntity() { Province_Id = 2, Province = "Province No. 2", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now },
              new ProvinceEntity() { Province_Id = 3, Province = "Bagmati Province", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now },
              new ProvinceEntity() { Province_Id = 4, Province = "Gandaki Province", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now },
              new ProvinceEntity() { Province_Id = 5, Province = "Lumbini Province", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now },
              new ProvinceEntity() { Province_Id = 6, Province = "Karnali Province", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now },
              new ProvinceEntity() { Province_Id = 7, Province = "Sudurpashchim Province", Country_Id = 1, Date_created = DateTime.Now, Date_modified = DateTime.Now }
              );

            builder.Entity<DocumentStatusEntity>().HasData(
                new DocumentStatusEntity() { Id = 1, Status = "Pending" },
                new DocumentStatusEntity() { Id = 2, Status = "Approve" },
                new DocumentStatusEntity() { Id = 3, Status = "Reject" },
                new DocumentStatusEntity() { Id = 4, Status = "Requires-New" }
                );

            builder.Entity<DocumentTypeEntity>().HasData(
                new DocumentTypeEntity() { Id = 1, TypeName = "Citizenship-Front" },
                new DocumentTypeEntity() { Id = 2, TypeName = "Citizenship-Back" },
                new DocumentTypeEntity() { Id = 3, TypeName = "Tax Clearance" },
                new DocumentTypeEntity() { Id = 4, TypeName = "PAN/VAT Registration" },
                new DocumentTypeEntity() { Id = 5, TypeName = "Bank Voucher" }
                );

            builder.Entity<CategoryEntity>().HasData(
                new CategoryEntity() { Category_Id = 1, Category = "Transportation", Status_Id = 1 },
                new CategoryEntity() { Category_Id = 2, Category = "Construction", Status_Id = 1 },
                new CategoryEntity() { Category_Id = 3, Category = "Tourism", Status_Id = 1 }
                );

            builder.Entity<CompanyTypeLookupEntity>().HasData(
                new CompanyTypeLookupEntity() { Company_Type_Id = 1, Company_type = "Transportation" },
                new CompanyTypeLookupEntity() { Company_Type_Id = 2, Company_type = "Construction" },
                new CompanyTypeLookupEntity() { Company_Type_Id = 3, Company_type = "Tourism" }
                );
            builder.Entity<RoleEntity>().HasData(
                new RoleEntity() { Role_Id = 1, Role_Name = "Super Admin", Date_created = DateTime.Now, Date_modified = DateTime.Now },
                new RoleEntity() { Role_Id = 2, Role_Name = "Bid Inviter", Date_created = DateTime.Now, Date_modified = DateTime.Now },
                new RoleEntity() { Role_Id = 3, Role_Name = "Bidder", Date_created = DateTime.Now, Date_modified = DateTime.Now }
                );

            builder.Entity<CompanyEntity>().HasData(
                    new CompanyEntity
                    {
                        CompanyId = 1,
                        Name = "Merobolee",
                        PANNumber = "123",
                        CountryId = 1,
                        ProvinceId = 3,
                        Address1 = "Address1",
                        Address2 = "Address2",
                        Address3 = "Address3",
                        City = "Kathmandu",
                        Zip = "123",
                        CompanyEmail = "super.admin@test.com",
                        RegisteredAs = "SuperAdmin",
                        ReferenceCode = $"MB{DateTime.Now.ToString("MMyyddHHmmssfff")}",
                        MembershipTypeId = 1,
                        CompanyStatusId = 4
                    },
                    new CompanyEntity
                    {
                        CompanyId = 2,
                        Name = "Bid Inviter Company",
                        PANNumber = "1234",
                        CountryId = 1,
                        ProvinceId = 3,
                        Address1 = "Address1",
                        Address2 = "Address2",
                        Address3 = "Address3",
                        City = "Kathmandu",
                        Zip = "123",
                        CompanyEmail = "bid.inviter@test.com",
                        RegisteredAs = "BidInviter",
                        ReferenceCode = $"BI{DateTime.Now.ToString("MMyyddHHmmssfff")}",
                        MembershipTypeId = 1,
                        CompanyStatusId = 4
                    },
                    new CompanyEntity
                    {
                        CompanyId = 3,
                        Name = "Supplier Company",
                        PANNumber = "12345",
                        CountryId = 1,
                        ProvinceId = 3,
                        Address1 = "Address1",
                        Address2 = "Address2",
                        Address3 = "Address3",
                        City = "Kathmandu",
                        Zip = "123",
                        CompanyEmail = "bid.bidder@test.com",
                        RegisteredAs = "Bidder",
                        ReferenceCode = $"SP{DateTime.Now.ToString("MMyyddHHmmssfff")}",
                        MembershipTypeId = 1,
                        CompanyStatusId = 4
                    }
                );

            CryptoService cryptoService = new CryptoService("zPwPEx9!EARv[MM#", "QyFXAoBgAoAJAARTVXhjkg==");
            builder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    User_Id = 1,
                    First_Name = "Super",
                    Last_Name = "Admin",
                    Person_email = "super.admin@test.com",
                    Role_Id = 1,
                    Status_id = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now,
                    Password = cryptoService.Encrypt("123123"),
                },
                new UserEntity
                {
                    User_Id = 2,
                    First_Name = "Bid",
                    Last_Name = "Inviter",
                    Person_email = "bid.inviter@test.com",
                    Role_Id = 2,
                    Status_id = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now,
                    Password = cryptoService.Encrypt("123123")
                },
                new UserEntity
                {
                    User_Id = 3,
                    First_Name = "Bid",
                    Last_Name = "Bidder",
                    Person_email = "bid.bidder@test.com",
                    Role_Id = 3,
                    Status_id = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now,
                    Password = cryptoService.Encrypt("123123")
                }
                );

            builder.Entity<UserCompany>().HasData(
                new UserCompany { Id = 1, UserId = 1, CompanyId = 1 },
                new UserCompany { Id = 2, UserId = 2, CompanyId = 2 },
                new UserCompany { Id = 3, UserId = 3, CompanyId = 3 }
                );

            builder.Entity<TenderSubmissionStatus>().HasData(
                new TenderSubmissionStatus { Id = 1, Status = "Pending Payment" },
                new TenderSubmissionStatus { Id = 2, Status = "Pending" },
                new TenderSubmissionStatus { Id = 3, Status = "Processing" },
                new TenderSubmissionStatus { Id = 4, Status = "Tender Created" },
                new TenderSubmissionStatus { Id = 5, Status = "Cancelled" }
                );

        }

        private void SetupUniqueConstraint(ModelBuilder builder)
        {
            builder.Entity<CompanyEntity>(entity =>
            {
                entity.HasIndex(e => e.PANNumber).IsUnique();
            });
        }
    }
}
