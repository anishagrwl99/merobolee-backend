using MeroBolee.Infrastructure;
using MeroBolee.Middleware;
using MeroBolee.Repository;
using MeroBolee.Repository.BidderRequest;
using MeroBolee.Repository.Category;
using MeroBolee.Repository.City;
using MeroBolee.Repository.CompanyType;
using MeroBolee.Repository.Country;
using MeroBolee.Repository.District;
using MeroBolee.Repository.FAQ;
using MeroBolee.Repository.FavouriteCategory;
using MeroBolee.Repository.Mail;
using MeroBolee.Repository.Membership;
using MeroBolee.Repository.Municipality;
using MeroBolee.Repository.Province;
using MeroBolee.Repository.RequestHelp;
using MeroBolee.Repository.Role;
using MeroBolee.Repository.Status;
using MeroBolee.Repository.Tender;
using MeroBolee.Repository.User;
using MeroBolee.Repository.VDC;
using MeroBolee.Repository.WatchLIst;
using MeroBolee.Service;
using MeroBolee.Service.BidderReuest;
using MeroBolee.Service.Category;
using MeroBolee.Service.City;
using MeroBolee.Service.CompanyType;
using MeroBolee.Service.Country;
using MeroBolee.Service.District;
using MeroBolee.Service.FAQ;
using MeroBolee.Service.FavouriteCategory;
using MeroBolee.Service.Mail;
using MeroBolee.Service.Membership;
using MeroBolee.Service.Municipality;
using MeroBolee.Service.Province;
using MeroBolee.Service.RequestHelp;
using MeroBolee.Service.Status;
using MeroBolee.Service.Tender;
using MeroBolee.Service.User;
using MeroBolee.Service.VDC;
using MeroBolee.Service.WatchList;
using MeroBolee.Settings;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MeroBolee
{
    public class Startup
    {
        public static string HostingEnvironment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //  .SetBasePath(env.ContentRootPath)
            //  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
            //  .AddEnvironmentVariables();
            //configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<UserMailSetting>(Configuration.GetSection("UserMailSetting"));
            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            services.AddDbContext<MeroBoleeDbContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("MeroBoleeConn"));

            }); // Connection string is available in appsettings.Json file
                // UseSqlServer help to database connection which use package Ms.EntityFrameworkCore.SqlServer

     

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeroBolee", Version = "v1" }); // Configuration for documentation of API
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // To enable XML comment in API
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Dependency Injection
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IAdminStatusRepository, AdminStatusRepository>();
            services.AddScoped<IAuctionStatusRepository, AuctionStatusRepository>();
            services.AddScoped<IUserStatusRepository, UserStatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
            services.AddScoped<ICompanyTypeService, CompanyTypeService>();
            services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
            services.AddScoped<IMunicipalityService, MunicipalityService>();
            services.AddScoped<IVDCRepository, VDCRepository>();
            services.AddScoped<IVDCService, VDCService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
            services.AddScoped<IMembershipTypeService, MembershipTypeService>();
            services.AddScoped<IFavouriteCategoryRepository, FavouriteCategoryRepository>();
            services.AddScoped<IFavouriteCategoryService, FavouriteCategoryService>();
            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();
            services.AddScoped<IWatchListRepository, WatchListRepository>();
            services.AddScoped<IWatchListService, WatchListService>();
            services.AddScoped<IBiddingRequestService, BiddingRequestService>();
            services.AddScoped<IBidderRequestRepository, BidderRequestRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<IFAQService, FAQService>();
            services.AddScoped<IRequestHelpRepository, RequestHelpRepository>();
            services.AddScoped<IRequestHelpService, RequestHelpService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IDisplayMailService, DisplayMailService>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IMailByUserService, MailByUserService>();


            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

           

        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            HostingEnvironment = env.EnvironmentName;
            app.UseStaticFiles();

            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeroBolee v1");
               });
            }
            else
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("https://office.merobolee.com/swagger/v1/swagger.json", "MeroBolee v1");
                });
            }

            //    app.Run(context => { throw new Exception("error"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
