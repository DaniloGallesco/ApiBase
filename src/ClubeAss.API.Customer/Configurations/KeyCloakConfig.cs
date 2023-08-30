using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace ClubeAss.API.Customer.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class KeyCloakConfig
    {

        public static IServiceCollection AddKeyCloakConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentException("services");
            }

            if (configuration == null)
            {
                throw new ArgumentException("configuration");
            }

            IConfigurationSection section = configuration.GetSection("" ?? "AppJwtSettings");
            services.Configure<AppJwtSettings>(section);
            AppJwtSettings appSettings = section.Get<AppJwtSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(delegate (AuthenticationOptions x)
            {
                x.DefaultAuthenticateScheme = "Bearer";
                x.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(delegate (JwtBearerOptions x)
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer
                };
            });
            return services;
        }
    }


    public class AppJwtSettings
    {
        public string SecretKey { get; set; }

        public int Expiration { get; set; }

        public string Issuer { get; set; }

        public IList<string> Issuers { get; set; }

        public string Audience { get; set; }

        public IList<string> Audiences { get; set; }
    }

    //        public static IApplicationBuilder AddConfigureKeyCloakConfig(this IApplicationBuilder app, IWebHostEnvironment env)
    //        {
    //            //app.UseCors(x => x
    //            //               .AllowAnyOrigin()
    //            //               .AllowAnyMethod()
    //            //               .AllowAnyHeader());

    //            app.UseAuthentication();
    //            app.UseAuthorization();

    //            return app;

    //        }


}
