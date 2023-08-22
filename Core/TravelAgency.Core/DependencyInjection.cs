using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TravelAgency.Core.Common.Behaviors;
using TravelAgency.Core.Entities;

namespace TravelAgency.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection BootStrapApplication(this IServiceCollection services,IConfiguration configuration)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(TourList));
            services.AddAutoMapper(coreAssembly);
            services.AddValidatorsFromAssembly(coreAssembly);
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(coreAssembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

            return services;
        }
    }
}