using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelAgency.Core.Common.Interfaces;
using TravelAgency.Core.Settings;
using Travel.Shared.Files;

using TravelAgency.Core.Services;

namespace Travel.Shared
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureShared(this IServiceCollection services, IConfiguration config)
    {
      services.Configure<MailSettings>(config.GetSection("MailSettings"));
      services.AddTransient<IDateTime, DateTimeService>();
      services.AddTransient<IEmailService, EmailService>();
      services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

      return services;
    }
  }
}