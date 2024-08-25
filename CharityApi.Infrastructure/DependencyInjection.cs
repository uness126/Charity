using Ardalis.GuardClauses;
using CharityApi.Application.Common.Interfaces;
using CharityApi.Infrastructure.Data;
using CharityApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Text;
using CharityApi.Domain.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        //services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        //services.AddScoped<ApplicationDbContextInitialiser>();

        //JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "",//_builder.Configuration["ServerConfigs:IP"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("12345"))
                    //DateTimeLibrary.Base64StringToDb(MagfaBase.Instance.Apikey, "CheetaApi").Result
                };
            });

        services.AddCors(options =>
        {
            options.AddPolicy("EnableCors", builder =>
            {
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .Build();
            });
        });

        //services.AddAuthentication()
        //    .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            //.AddApiEndpoints(); 

        //services.AddSingleton(System.TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(CharityRoles.Administrator)));

        return services;
    }
}
