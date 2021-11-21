using MeroBolee.Infrastructure;
using MeroBolee.Middleware;
using MeroBolee.Repository;
using MeroBolee.Service;
using MeroBolee.Settings;
using MeroBolee.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;

namespace MeroBolee
{
    /// <summary>
    /// Startup 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// App host environment
        /// </summary>
        public static string HostingEnvironment { get; set; }
        private readonly string _corsPolicy = "MeroBoleeClients";


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //  .SetBasePath(env.ContentRootPath)
            //  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
            //  .AddEnvironmentVariables();
            //configuration = builder.Build();
            Configuration = configuration;
            HostingEnvironment = env.EnvironmentName;
        }



        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SMTPServerInfo>(Configuration.GetSection("EmailConfig"));
            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            services.Configure<CryptoKeys>(Configuration.GetSection("CryptoConfig"));
            services.Configure<AppDefaults>(Configuration.GetSection("AppDefaults"));
            //CryptoConfig.Salt = Configuration.GetValue<string>("EncryptionSalt");

            //Enabling Cross Origin Requests from merobolee ui 
            string[] origins = Configuration.GetValue<string>("APIAllowedOrigins").Split(',');
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _corsPolicy, builder =>
               {
                   builder.AllowAnyOrigin()
                   //builder.WithOrigins(origins)
                   .AllowAnyMethod()
                   .AllowAnyHeader();
               });

            });
          


            services.AddDbContext<MeroBoleeDbContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("MeroBoleeConn"));

            }); // Connection string is available in appsettings.Json file
                // UseSqlServer help to database connection which use package Ms.EntityFrameworkCore.SqlServer



            services.AddSwaggerGen(c =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MeroBolee",
                    Description = "Pass JWT Token on header of every request. Anonymous request is allowed only on endpoints under Account and Signup."
                });
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeroBolee", Version = "v1" }); // Configuration for documentation of API
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // To enable XML comment in API
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // To Enable authorization using Swagger (JWT)  
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nTo generate token use \\Authenticate endpoint.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()

                    }
                });
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWTSettings:Issuer"],
                    ValidAudience = Configuration["JWTSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSettings:Secret"])) //Configuration["JwtToken:SecretKey"]  
                };
            })
            ;

            // Dependency Injection
            services.AddScoped<ICryptoService, CryptoService>();
            services.AddScoped<IReferenceCodeService, ReferenceCodeService>();
            services.AddScoped<IUploadFile, UploadImage>();

            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IAdminStatusRepository, AdminStatusRepository>();
            services.AddScoped<IAuctionStatusRepository, AuctionStatusRepository>();
            services.AddScoped<IUserStatusRepository, UserStatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
            services.AddScoped<ICompanyTypeService, CompanyTypeService>();
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
            services.AddScoped<ISMTPEmailService, SMTPEmailService>();


            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();


            //signup
            services.AddScoped<ISignupRepository, SignupRepository>();
            services.AddScoped<ISignupService, SignupService>();


            //Document
            services.AddScoped<ICompanyDocumentRepository, CompanyDocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IDocumentStatusRepository, DocumentStatusRepository>();
            services.AddScoped<ICompanyDocumentService, CompanyDocumentService>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();
            services.AddScoped<IDocumentStatusService, DocumentStatusService>();

            //Company
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();

            //EMail
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailService, EmailService>();

            //Support
            services.AddScoped<ISupportService, SupportService>();


            //Hangfire configuration
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("MeroBoleeConn"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddControllers();
            services.AddMvc();

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
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(env.ContentRootPath, "Resource")),
                RequestPath = "/Resource"
            });

            app.UseSwagger();
            if (!env.IsEnvironment("Production"))
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
                    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeroBolee v1");
                    c.SwaggerEndpoint("https://office.merobolee.com/swagger/v1/swagger.json", "MeroBolee v1");
                });
            }

            //    app.Run(context => { throw new Exception("error"); });

            //Use Hangfire dashboard
            app.UseHangfireDashboard();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_corsPolicy);

            app.UseAuthorization();
            app.UseAuthentication();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

     
            app.UseEndpoints(endpoints =>
            {
               // endpoints.MapControllers();
                endpoints.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=BackgroundJob}/{action=MoveRecord}/{id?}");

                endpoints.MapHangfireDashboard();
            });
        }
    }
}
