using MeroBolee.Model;
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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
            if (!dbContextOptionsBuilder.IsConfigured) // Configure Database Connection
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MeroBoleeConn");
                dbContextOptionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().Property(x => x.User_Code).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TenderEntity>().Property(x => x.Tender_Code).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Username)
                .IsUnique();

          //  modelBuilder.Entity<VDCEntity>().HasMany(x=>x.User_entity).WithOptional().HasForeignKey(x => x.Vdc_id).OnDelete(DeleteBehavior.Restrict);

            //    //modelBuilder.Entity<User>().HasData(
            //    //      new User() { Id = Guid.NewGuid(), Email = "Mubeen@gmail.com", Name = "Mubeen", Password = "123123" },
            //    //      new User() { Id = Guid.NewGuid(), Email = "Tahir@gmail.com", Name = "Tahir", Password = "321321" },
            //    //      new User() { Id = Guid.NewGuid(), Email = "Cheema@gmail.com", Name = "Cheema", Password = "123321" }
            //    //      );
        }

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
