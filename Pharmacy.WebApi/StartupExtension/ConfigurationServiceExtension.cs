using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pharmacy.Core.ConfiurationSettings;
using Pharmacy.Core.Domain.Entities.IdentityEntities;
using Pharmacy.Core.Domain.IRepositoriesContracts;
using Pharmacy.Core.DTO;
using Pharmacy.Core.IServiceContracts;
using Pharmacy.Core.Services;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.DbContext;
using Pharmacy.Infrastructure.Repositories;
using System.Text;
namespace Pharmacy.WebApi.StartupExtension
{
    public static class ConfigurationServiceExtension
    {

        public static IServiceCollection configureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Addd auto controller to service
            services.AddControllers();

            //Add authorization policy

            services.AddAuthorization(options =>
            {
                var policyAuthentication = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.FallbackPolicy = policyAuthentication;

            });


            //Add ApplicationDbContext to service

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });


            //Add repository ,service for Identity

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;


                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                // options.SignIn.RequireConfirmedEmail = true;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
            .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>()
             ;


            //Add Service Token
            services.AddTransient<IJwtService, JwtService>();



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                 {
                      
                     options.TokenValidationParameters = new TokenValidationParameters()
                     {

                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,


                         ValidIssuer = configuration["Jwt:Issuer"],
                         ValidAudience = configuration["jwt:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]! )),


                     };


                 }
            );


             

            //Add Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.Xml"));
            });

            //Config JwtSettings

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));


            //Add Email Settings to IOC
           services.Configure<EmailSettings>(
    configuration.GetSection("EmailSettings"));

            services.AddScoped<IEmailService, EmailService>();



            //Employee

            services.AddTransient<IEmployeesRepository, EmployeesRepositoy>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }

    }
}