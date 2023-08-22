using System;

using TravelAgency.Core.Common.Interfaces;

namespace TravelAgency.Core.Services
{
  public class DateTimeService : IDateTime
  {
    public DateTime Now => DateTime.UtcNow;
  }
}