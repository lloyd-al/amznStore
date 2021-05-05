using amznStore.Common.Infrastructure.Extensions;
using amznStore.Services.UserAuthentication.Core.Entities;
using amznStore.Services.UserAuthentication.Core.Interfaces;
using amznStore.Services.UserAuthentication.Infrastructure.DataContexts;
using amznStore.Services.UserAuthentication.Infrastructure.Repositories;
using amznStore.Services.UserAuthentication.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace amznStore.Services.UserAuthentication.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApiVersioning();
            services.ConfigureSwagger("User Authentication Api");

            // Mail Configuration
            services.ConfigureMailSetting(configuration);

            // Mail Service
            services.ConfigureMailService();

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            // Configure token lifespan for registration and password reset
            services.Configure<DataProtectionTokenProviderOptions>(opt => 
                opt.TokenLifespan = TimeSpan.FromHours(2));

            //services.Configure<IdentityOptions>(options =>
            //{
            //    //options.SignIn.RequireConfirmedEmail = true;
            //    options.User.RequireUniqueEmail = true;
            //});

            // configure DI for application services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = configuration["Jwt:ValidAudience"],
                    ValidIssuer = configuration["Jwt:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]))
                };

            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("UserAuthenticationDb"));
        }
    }
}
