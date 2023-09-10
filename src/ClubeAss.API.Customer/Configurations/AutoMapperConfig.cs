using AutoMapper;
using ClubeAss.API.Customer.ViewModel.Customer;
using ClubeAss.Domain.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace ClubeAss.API.Customer.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddServiceAutoMapperConfig(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<CustomerAddRequest, Domain.Customer>();
                cfg.CreateMap<Domain.Customer, CustomerAddRequest>();

                cfg.CreateMap<CustomerUpdateRequest, Domain.Customer>();
                cfg.CreateMap<Domain.Customer, CustomerUpdateRequest>();


                cfg.CreateMap<Domain.Customer, BaseResponse>()
                .ConstructUsing(x => new BaseResponse(HttpStatusCode.OK, x, null));

                cfg.CreateMap<IReadOnlyList<Domain.Customer>, BaseResponse>()
                .ConstructUsing(x => new BaseResponse(HttpStatusCode.OK, x, null));


            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        public static IApplicationBuilder AddConfigureAutoMapperConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            throw new NotImplementedException();
        }
    }
}