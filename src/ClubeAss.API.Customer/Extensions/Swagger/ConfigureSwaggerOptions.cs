using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace ClubeAss.API.Customer.Extensions.Swagger
{
    public class ConfigureSwaggerOptions
        : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Configure each API discovered for Swagger Documentation
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        /// <summary>
        /// Configure Swagger Options. Inherited from the Interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        /// <summary>
        /// Create information about the version of the API
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Information about the API</returns>
        private OpenApiInfo CreateVersionInfo(
                ApiVersionDescription desc)
        {
            var info = new OpenApiInfo()
            {
                Title = "API Core - Customer",
                Version = desc.ApiVersion.ToString(),
                Description = "Api - Customer",
                TermsOfService = new Uri("https://www.google.com.br/"),
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Api Customer",
                    Email = string.Empty,
                    Url = new Uri("https://www.google.com.br/"),
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = "© Copyright ClubeAss. Todos os Direitos Reservados.",
                    Url = new Uri("https://www.google.com.br/"),
                }
            };

            if (desc.IsDeprecated)
            {
                info.Description += " Esta versão da API esta obsoleta. Use uma das novas APIs disponíveis no explorer.";
            }

            return info;
        }
    }
}
