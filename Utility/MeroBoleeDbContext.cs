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

            modelBuilder.Entity<CorrespondenceEmailEntity>()
               .HasOne(e => e.User)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClarificationEmailEntity>()
               .HasOne(e => e.UserEntity)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CallActionEmailEntity>()
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
                new AuctionStatusEntity() { Status_Id = 1, Status = "Created" },
                new AuctionStatusEntity() { Status_Id = 2, Status = "Running" },
                new AuctionStatusEntity() { Status_Id = 3, Status = "Closed" },
                new AuctionStatusEntity() { Status_Id = 4, Status = "Upcoming" }
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
                new UserStatusEntity() { Status_Id = 1, Status = "Registered" },
                new UserStatusEntity() { Status_Id = 2, Status = "Approved" },
                new UserStatusEntity() { Status_Id = 3, Status = "Suspended" },
                new UserStatusEntity() { Status_Id = 4, Status = "Terminated" }
                );

        }
        private void SeedLookupData(ModelBuilder builder)
        {
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

            builder.Entity<CategoryEntity>().HasData(
                new CategoryEntity() { Category_Id = 1, Category = "Transportation", Status_Id = 1 },
                new CategoryEntity() { Category_Id = 2, Category = "Construction", Status_Id = 1 },
                new CategoryEntity() { Category_Id = 3, Category = "Tourism", Status_Id = 1 }
                );

            builder.Entity<CompanyTypeEntity>().HasData(
                new CompanyTypeEntity() { Company_Type_Id = 1, Company_type = "Transportation" },
                new CompanyTypeEntity() { Company_Type_Id = 2, Company_type = "Construction" },
                new CompanyTypeEntity() { Company_Type_Id = 3, Company_type = "Tourism" }
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
                    Name = "Test Company",
                    CountryId = 1,
                    ProvinceId = 3,
                    Address1 = "Address1",
                    Address2 = "Address2",
                    Address3 = "Address3",
                    City = "Kathmandu",
                    Zip = "123"
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
                    Status_id = 2,
                    CompanyId = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now,
                    Password = cryptoService.Encrypt("123")
                },
                new UserEntity
                {
                    User_Id = 2,
                    First_Name = "Bid",
                    Last_Name = "Inviter",
                    Person_email = "bid.inviter@test.com",
                    Role_Id=2,
                    Status_id = 2,
                    CompanyId = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now,
                    Password = cryptoService.Encrypt("123")
                },
                new UserEntity
                {
                    User_Id = 3,
                    First_Name = "Bid",
                    Last_Name = "Bidder",
                    Person_email = "bid.bidder@test.com",
                    Role_Id = 3,
                    Status_id = 2,
                    CompanyId = 1,
                    Date_created = DateTime.Now,
                    Date_modified = DateTime.Now,
                    Password = cryptoService.Encrypt("123")
                }
                );
        }

        public DbSet<LiveBiddingEntity> liveBiddingEntities { get; set; }
        public DbSet<CallActionEmailEntity> CallActionEmailEntities { get; set; }
        public DbSet<ClarificationEmailEntity> ClarificationEmailEntities { get; set; }
        public DbSet<CorrespondenceEmailEntity> CorrespondenceEmailEntities { get; set; }
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
        public DbSet<CompanyTypeEntity> CompanyTypeEntities { get; set; }
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

    }
}
