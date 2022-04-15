using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Services.Auth;
using AppointMed.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AppointMed.API.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews(options =>
        {
            options.EnableEndpointRouting = false;
        }).AddJsonOptions(options => {
            options.JsonSerializerOptions.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());
        });

        this.InstallSecurity(services, configuration);
        this.InstallSwagger(services);
    }

    private void InstallSecurity(IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        var tokenValidationParameters = this.GetTokenValidationParameters(jwtSettings);

        services.AddSingleton(jwtSettings);
        services.AddSingleton(tokenValidationParameters);
        services.AddScoped<IIdentityService, IdentityService>();

        services.AddAuthentication(authOptions =>
        {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.SaveToken = true;
            jwtBearerOptions.TokenValidationParameters = tokenValidationParameters;
        });

        services.AddAuthorization();
    }

    private TokenValidationParameters GetTokenValidationParameters(JwtSettings jwtSettings)
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    }

    private void InstallSwagger(IServiceCollection services)
    {
        // Register the Swagger Generator as a service. We can define 1 or more Swagger documents here
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AppointMed API",
                Version = "v1",
                Description = "Test documentation for the AppointMed API",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "KM",
                    Email = string.Empty,
                    Url = new Uri("https://github.com/kmannopov"),
                },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT"),
                }
            });

            var reference = new OpenApiReference
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
            };

            var security = new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme { Reference = reference }, new List<string>() }
                };

            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            x.AddSecurityRequirement(security);
        });
    }
}
