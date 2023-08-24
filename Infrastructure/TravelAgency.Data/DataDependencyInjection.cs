using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Core.Data;
using TravelAgency.Data.Contexts;

namespace TravelAgency.Data
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection BootStrapInfrastructureData(this IServiceCollection services, IConfiguration configuration)
        {

            var connection = configuration.GetConnectionString("SqlServerConnectionWindows");
          
            services.AddDbContext<ApplicationDbContext>(options => options
               .UseSqlServer(connection));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            
            return services;
        }
    }
}