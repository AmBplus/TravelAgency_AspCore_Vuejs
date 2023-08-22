using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Travel.Data.Contexts;
using TravelAgency.Core.Data;

namespace Travel.Data
{
  public static class DependencyInjection
  {
    public static IServiceCollection BootStrapInfrastructureData(this IServiceCollection services , IConfiguration configuration)
    {

     var connection = configuration.GetConnectionString("SqlServerConnection");
     services.AddDbContext<ApplicationDbContext>(options => options
        .UseSqlServer(connection));
         
     services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

      return services;
    }
  }
}