using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Travel.Shared;
using TravelAgency.Core.Common.Behaviors;
using TravelAgency.Core.Entities;
using TravelAgency.Data;

namespace TravelAgency.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection BootStrapServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureShared(configuration);
            services.BootStrapInfrastructureData(configuration);
            services.BootStrapApplication(configuration);
            return services;
        }
    }
}